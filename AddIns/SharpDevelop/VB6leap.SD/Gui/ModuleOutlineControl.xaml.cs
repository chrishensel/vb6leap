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
using System.Windows;
using System.Windows.Controls;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Editor.CodeCompletion;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Parser;
using VB6leap.SDAddin.Parser;
using VB6leap.Vbp.Reflection.Members;

namespace VB6leap.SDAddin.Gui
{
    /// <summary>
    /// Interaction logic for ModuleOutlineControl.xaml
    /// </summary>
    public partial class ModuleOutlineControl : IOutlineContentHost, IDisposable
    {
        #region Fields

        private ITextEditor _textEditor;

        #endregion

        #region Constructors

        private ModuleOutlineControl()
        {
            InitializeComponent();
        }

        internal ModuleOutlineControl(ITextEditor textEditor)
            : this()
        {
            _textEditor = textEditor;

            SD.ParserService.ParseInformationUpdated += ParserService_ParseInformationUpdated;
        }

        #endregion

        #region Methods

        private static StackPanel GetNodeHeaderWithIcon(string text, CompletionImage image)
        {
            StackPanel header = new StackPanel();
            header.Orientation = Orientation.Horizontal;

            Image img = new Image();
            img.Source = image.BaseImage;
            img.RenderSize = new Size(16d, 16d);
            img.Width = 16d;
            img.Height = 16d;
            img.Margin = new Thickness(1d);
            header.Children.Add(img);

            TextBlock tb = new TextBlock();
            tb.Text = text;
            tb.Margin = new Thickness(1d);
            header.Children.Add(tb);

            return header;
        }

        private void ParserService_ParseInformationUpdated(object sender, ParseInformationEventArgs e)
        {
            if (_textEditor == null || !FileUtility.IsEqualFileName(_textEditor.FileName, e.FileName))
            {
                return;
            }

            trvLayout.Items.Clear();

            IVbModuleWrapper wrapper = (IVbModuleWrapper)e.NewUnresolvedFile;

            TreeViewItem root = new TreeViewItem();
            root.Header = GetNodeHeaderWithIcon(wrapper.Module.Name, CompletionImage.Class);

            TreeViewItem fields = new TreeViewItem();
            root.Items.Add(fields);

            TreeViewItem properties = new TreeViewItem();
            root.Items.Add(properties);

            TreeViewItem methods = new TreeViewItem();
            root.Items.Add(methods);

            foreach (IVbMember member in wrapper.Module.Members)
            {
                TreeViewItem memberNode = new TreeViewItem();
                memberNode.Header = member.Name;
                memberNode.Tag = member;
                memberNode.Selected += memberNode_Selected;

                if (member is IVbProperty)
                {
                    properties.Items.Add(memberNode);
                }
                else if (member is IVbMethod)
                {
                    methods.Items.Add(memberNode);
                }
                else if (member is IVbField)
                {
                    fields.Items.Add(memberNode);
                }
            }

            fields.Header = GetNodeHeaderWithIcon(string.Format("Fields ({0})", fields.Items.Count), CompletionImage.Field);
            properties.Header = GetNodeHeaderWithIcon(string.Format("Properties ({0})", properties.Items.Count), CompletionImage.Property);
            methods.Header = GetNodeHeaderWithIcon(string.Format("Methods ({0})", methods.Items.Count), CompletionImage.Method);

            root.ExpandSubtree();

            trvLayout.Items.Add(root);
        }

        private void memberNode_Selected(object sender, RoutedEventArgs e)
        {
            IVbMember member = ((TreeViewItem)e.Source).Tag as IVbMember;
            if (member == null)
            {
                return;
            }

            _textEditor.JumpTo(member.Location.Line, 1);
        }

        #endregion

        #region IOutlineContentHost Members

        object IOutlineContentHost.OutlineContent
        {
            get { return this; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            SD.ParserService.ParseInformationUpdated -= ParserService_ParseInformationUpdated;
            _textEditor = null;
        }

        #endregion
    }
}
