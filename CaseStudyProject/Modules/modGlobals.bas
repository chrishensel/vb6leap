Attribute VB_Name = "modGlobals"
Public Const g_strHello As String = "World"
Const g_varConst = 2
Private g_varAnon

Private Function Asdf() As Variant		' I'm a comment and I should be ignored! Test 1 2 3 
'---------------------------------------
' This is a comment.
'---------------------------------------
	
	On Error GoTo 0
	
	Dim strHello As String
	strHello = "ASDF"
	
	If (strHello = "123") Then
	
	Else
		
		Dim i As Integer
		
		For i = 0 To 5
		
		Next
		
	End If
	
	Asdf = 4
	
	Exit Function
	
ErrHandler:
	Exit Function
End Function

Function ThisFunctionIsMultiline(ByVal iFoo As Integer, _
								 ByRef bBar As Boolean)

	' Comment
	ThisFunctionIsMultiline = 42
								 
End Function

Public Sub MethodWithOptionalParameter(_
			iHello As Integer, _
			Optional ByVal iNumber As Integer = 2, Optional str = "Hello This is an optional string")

End Sub