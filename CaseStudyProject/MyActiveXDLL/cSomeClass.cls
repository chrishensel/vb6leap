VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "cSomeClass"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Const m_myVariantConstant = 4711

Public m_mySharedField As Integer
Private m_myString As String
Private m_myNumber As Integer

Public Property Let Value(RHS As Integer)
End Property

Public Property Get Value() As Integer
End Property

Public Function GiveMeRandomness() As Integer
    ' Chosen by fair dice roll... guaranteed to be random.
    GiveMeRandomness = 4
End Function

Public Sub MyNameIsSub(ByVal strInput As String, _
                        Optional ByVal iMode As Integer = 3)
                        
End Sub

