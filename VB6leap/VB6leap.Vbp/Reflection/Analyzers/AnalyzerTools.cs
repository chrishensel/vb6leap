// This file is part of vb6leap.
// 
// vb6leap is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// vb6leap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with vb6leap.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using VB6leap.Vbp.Reflection.Members;
using VB6leap.Vbp.Reflection.Source;
using VB6leap.Vbp.Reflection.Types;

namespace VB6leap.Vbp.Reflection.Analyzers
{
    static class AnalyzerTools
    {
        private static readonly string[] Delimiters = new[] { ",", ")", "=" };

        internal static IEnumerable<IVbAttribute> GetAttributes(TokenStreamReader reader)
        {
            bool didEncounterAttributes = false;

            while (!reader.IsEOF)
            {
                IToken token = reader.Read();

                switch (token.Type)
                {
                    case TokenType.Word:
                        {
                            if (token.EqualsStringInvariant(AnalyzerConstants.Attribute_TokenName))
                            {
                                didEncounterAttributes = true;

                                List<IToken> lineTokens = new List<IToken>();
                                lineTokens.Add(token);
                                lineTokens.AddRange(reader.GetUntilEOL());

                                if (lineTokens.Count == 4)
                                {
                                    yield return new VbAttribute()
                                    {
                                        Location = lineTokens[0].Location,
                                        Name = lineTokens[1].Content,
                                        Value = lineTokens[3].Content.Replace("\"", ""),
                                    };
                                }
                            }
                            else
                            {
                                /* If we had attributes previously, it is now valid to break execution here.
                                 * VB Classic files always end their "preamble" or "header" with an "Attribute" block.
                                 * After that block, the user code is starting.
                                 */
                                if (didEncounterAttributes)
                                {
                                    yield break;
                                }
                            }
                        }
                        break;
                    default:
                    case TokenType.EOL:
                    case TokenType.EOF:
                        continue;
                }
            }
        }

        internal static bool EqualsStringInvariant(this IToken token, string other)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            return token.Content.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        internal static IEnumerable<IVbMethod> GetMethods(TokenStreamReader reader)
        {
            bool isInMethod = false;
            VbMethodType methodType = VbMethodType.Sub;

            // Remembers the complete signature for easier construction later.
            List<IToken> signatureTokens = new List<IToken>();

            IToken previous = null;

            while (!reader.IsEOF)
            {
                if (!reader.IsBOF)
                {
                    previous = reader.GetPrevious();
                }

                IToken token = reader.Read();

                if (token.Type == TokenType.Word)
                {
                    if (token.EqualsStringInvariant(AnalyzerConstants.Method_Sub) ||
                        token.EqualsStringInvariant(AnalyzerConstants.Method_Function) ||
                        token.EqualsStringInvariant(AnalyzerConstants.Method_Property))
                    {
                        if (isInMethod)
                        {
                            if (previous.EqualsStringInvariant(AnalyzerConstants.End))
                            {
                                isInMethod = false;
                            }

                            continue;
                        }

                        isInMethod = true;

                        methodType = (VbMethodType)Enum.Parse(typeof(VbMethodType), token.Content, true);

                        VbMethod method = new VbMethod();

                        // Properties have Let/Get/Set next... eat that and store it.
                        if (methodType == VbMethodType.Property)
                        {
                            IToken propertyAcc = reader.Read();

                            method = new VbProperty()
                            {
                                Accessor = (VbPropertyAccessor)Enum.Parse(typeof(VbPropertyAccessor), propertyAcc.Content, true),
                            };
                        }

                        method.Visibility = MemberVisibility.Default;
                        method.Location = token.Location;
                        method.MethodKind = methodType;

                        /* Check if there was a visibility-modifier preceeding this method. If so, add it to our signature.
                         */
                        if (previous.EqualsStringInvariant(AnalyzerConstants.Visibility_Private) ||
                            previous.EqualsStringInvariant(AnalyzerConstants.Visibility_Public))
                        {
                            if (previous.EqualsStringInvariant(AnalyzerConstants.Visibility_Public))
                            {
                                method.Visibility = MemberVisibility.Public;
                            }
                            else
                            {
                                method.Visibility = MemberVisibility.Private;
                            }

                            // Set method location to the previous token (start of line).
                            method.Location = previous.Location;
                        }

                        method.Name = reader.Read().Content;

                        signatureTokens.AddRange(reader.GetUntilEOL());

                        bool success = false;
                        try
                        {
                            ParseSignatureIntoMethod(method, signatureTokens);
                            success = true;
                        }
                        catch (Exception)
                        {
                            // FIXME: The parser may peek() too far beyond EOF. Need to handle that!
                        }

                        if (success)
                        {
                            yield return method;
                        }

                        signatureTokens.Clear();
                    }
                }
            }
        }

        private static void ParseSignatureIntoMethod(VbMethod method, IReadOnlyList<IToken> signatureTokens)
        {
            TokenStreamReader tokenReader = new TokenStreamReader(signatureTokens);
            if (tokenReader.Peek().Type == TokenType.Symbol)
            {
                tokenReader.Read();
            }

            VbParameter parameter = new VbParameter();

            while (!tokenReader.IsEOF)
            {
                // If it's already the end of the signature, leave the loop.
                if (tokenReader.Peek().EqualsStringInvariant(")"))
                {
                    tokenReader.Read();
                    break;
                }

                IToken token = tokenReader.Read();

                if (IsParameterOptional(token))
                {
                    parameter.IsOptional = true;
                    continue;
                }

                VbParameterAccess access = VbParameterAccess.Default;
                if (IsParamaterAccessToken(token, out access))
                {
                    parameter.Access = access;
                    continue;
                }

                /* Assume that if the next parameter is "As", then this is a parameter name.
                 * Also watch out for implicit parameters, which are parameters that don't declare a type (variant).
                 */
                if (tokenReader.Peek().EqualsStringInvariant("As") ||
                    tokenReader.Peek().Type == TokenType.Symbol)
                {
                    parameter.Name = token.Content;
                    parameter.Location = token.Location;

                    if (tokenReader.Peek().Type == TokenType.Symbol)
                    {
                        parameter.Type = VbTypes.Variant;

                        // Eat token.
                        tokenReader.Read();
                    }
                    else
                    {
                        // Eat token.
                        tokenReader.Read();

                        parameter.Type = new VbType()
                        {
                            TypeName = ReadUntilEOLIntoString(tokenReader, Delimiters)
                        };
                    }

                    /* Look ahead for an optional value declaration if this parameter is optional.
                     */
                    if (parameter.IsOptional)
                    {
                        if (tokenReader.GetPrevious().Content == "=")
                        {
                            parameter.OptionalDefaultValue = ReadUntilEOLIntoString(tokenReader, Delimiters);
                        }
                    }

                    /* Add parameter and reset instance.
                     */
                    method.AddParameter(parameter);

                    parameter = new VbParameter();

                    continue;
                }
            }

            /* Specify "void" return "type" in advance; may be overridden.
             */
            method.ReturnType = VbTypes.Void;

            bool canHaveReturnType = false;
            if (method.MethodKind == VbMethodType.Function)
            {
                canHaveReturnType = true;
            }
            else if (method.MethodKind == VbMethodType.Property)
            {
                IVbProperty property = (IVbProperty)method;
                if (property.Accessor == VbPropertyAccessor.Get)
                {
                    canHaveReturnType = true;
                }
            }

            /* Look for a return type.
             */
            if (canHaveReturnType)
            {
                method.ReturnType = VbTypes.Variant;

                if (!tokenReader.IsEOF)
                {
                    var returnTokens = tokenReader.GetUntilEOL().ToArray();
                    if (returnTokens[0].EqualsStringInvariant("As"))
                    {
                        string typeName = string.Concat(returnTokens.Skip(1).Select(_ => _.Content));
                        method.ReturnType = new VbType() { TypeName = typeName };
                    }
                }
            }
        }

        private static string ReadUntilEOLIntoString(TokenStreamReader tokenReader, string[] tokensToIgnore)
        {
            return string.Concat(tokenReader.GetUntilEOL(true, tokensToIgnore).Select(_ => _.Content));
        }

        private static bool IsParameterOptional(IToken token)
        {
            return token.EqualsStringInvariant(AnalyzerConstants.Parameter_Optional);
        }

        private static bool IsParamaterAccessToken(IToken token, out VbParameterAccess access)
        {
            if (token.EqualsStringInvariant(AnalyzerConstants.Parameter_ByRef))
            {
                access = VbParameterAccess.ByRef;
                return true;
            }
            if (token.EqualsStringInvariant(AnalyzerConstants.Parameter_ByVal))
            {
                access = VbParameterAccess.ByVal;
                return true;
            }

            access = VbParameterAccess.ByVal;
            return false;
        }
    }
}
