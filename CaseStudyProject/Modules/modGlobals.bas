Attribute VB_Name = "modGlobals"
Public Const g_strHello As String = "World"

Private Function Asdf() As Variant
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