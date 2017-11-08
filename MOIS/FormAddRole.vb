Public Class FormAddRole
    Dim dataRole As New ClassRule
    Public X As String

    Sub clean()
        txtRoleName.Text = ""
        txtInfo.Text = ""
        txtRoleName.Focus()
    End Sub

    Public idRole As String = ""
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtRoleName.Text = "" Then
            MsgBox("Rolename cannot empty", MsgBoxStyle.Critical, "Error")
            txtRoleName.Focus()
        Else
            If X = "1" Then
                dataRole.addRole(txtRoleName.Text, txtInfo.Text)
                clean()
            ElseIf X = "2"
                dataRole.EditRole(idRole, txtRoleName.Text, txtInfo.Text)
                clean()
                Close()
            End If
        End If
        FormManageOperator.loadDataRole()
    End Sub

    Private Sub txtRoleName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoleName.KeyDown
        Dim odata As New DataTable

        If e.KeyCode = Keys.Enter Then
            odata.Clear()
            txtRoleName.Text = txtRoleName.Text.ToUpper()
            odata = dataRole.ValidationCode(txtRoleName.Text)
            If odata.Rows.Count > 0 Then
                MsgBox("username already exist, please input other data", MsgBoxStyle.Critical, "Error")
                txtRoleName.Text = ""
                txtRoleName.Focus()
            ElseIf txtRoleName.Text = ""
                MsgBox("Username cannot empty", MsgBoxStyle.Critical, "Error")
            Else
                txtInfo.Focus()
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        clean()
        Close()
    End Sub
End Class