Imports System.ComponentModel

Public Class FormDashboard
    Private Sub FormDashboard_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub
End Class