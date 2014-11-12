VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "cEventSource"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Public Event OnTestOccurred(vVariant, bBoolean As Boolean, ByRef objSomeObject As Object)

Public Sub DoTest()
Attribute DoTest.VB_Description = "Raises the OnTestOccurred event with some arbitrary argument values."

    RaiseEvent OnTestOccurred(1, True, Me)

End Sub
