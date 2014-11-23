Attribute VB_Name = "modGlobals"
Public Const g_strHello As String = "World"
Const g_varConst = 2
Private g_varAnon

Private Function Asdf() As Variant              ' I'm a comment and I should be ignored! Test 1 2 3
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

    Comment
    ThisFunctionIsMultiline = 42
    
End Function

Public Sub MethodWithOptionalParameter(iHello As Integer, _
           Optional ByVal iNumber As Integer = 2, _
           Optional str = "Hello This is an optional string")

End Sub

Private Sub MyFunctionRandomNr1()

End Sub

Private Sub MyFunctionRandomNr2()

End Sub

Private Sub MyFunctionRandomNr3()

End Sub

Private Sub MyFunctionRandomNr4()

End Sub

Sub MyFunctionRandomNr5()

End Sub

Private Sub MyFunctionRandomNr6()

End Sub

Private Sub MyFunctionRandomNr7()

End Sub

Private Sub MyFunctionRandomNr8()

End Sub

Private Sub MyFunctionRandomNr9()

End Sub

Private Sub MyFunctionRandomNr10()

End Sub

Public Sub MyFunctionRandomNr11()

End Sub

Private Sub MyFunctionRandomNr12()

End Sub

Private Sub MyFunctionRandomNr13()

End Sub

Private Sub MyFunctionRandomNr14()

End Sub

Private Sub MyFunctionRandomNr15()

End Sub

Private Sub MyFunctionRandomNr16()

End Sub

Private Function MyFunctionRandomNr17(Test)
    MyFunctionRandomNr17 = 12
End Function

Private Sub MyFunctionRandomNr18()

End Sub

Private Sub MyFunctionRandomNr19()

End Sub

Private Sub MyFunctionRandomNr20()

End Sub
