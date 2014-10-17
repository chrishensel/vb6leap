VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "I am a Form!"
   ClientHeight    =   3030
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   4560
   LinkTopic       =   "Form1"
   ScaleHeight     =   3030
   ScaleWidth      =   4560
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdButton 
      Caption         =   "I am a Button!"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   1575
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdButton_Click()
    Dim objSomeClass As cSomeClass
    Set objSomeClass = New cSomeClass
    
    Dim iResult As Integer
    iResult = objSomeClass.GiveMeRandomness()
    
    MsgBox "Result is: " & iResult
    
End Sub
