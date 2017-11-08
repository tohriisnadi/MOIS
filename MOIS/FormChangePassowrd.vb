Public Class FormChangePassowrd
    Dim datalogin As New ClassOperator
    Dim odatauser As New DataTable
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        odatauser.Clear()
        odatauser = datalogin.SelectUserLogin(lbUsername.Text, txtOldpwd.Text)
        If odatauser.Rows.Count > 0 Then
            If txtNewPwd1.Text = txtNewPwd2.Text Then
                datalogin.EditPassword(lbUsername.Text, txtNewPwd1.Text)
                Close()
            Else
                MsgBox("new password not same", MsgBoxStyle.Critical, "Eror")
            End If
        Else
            MsgBox("Wrong Old Password ", MsgBoxStyle.Critical, "Eror")
        End If
        clean()
    End Sub

    Sub clean()
        txtNewPwd1.Text = ""
        txtNewPwd2.Text = ""
        txtOldpwd.Text = ""
        lbUsername.Text = ModKoneksi.namaOperator
        txtOldpwd.Properties.PasswordChar = "*"
        txtNewPwd1.Properties.PasswordChar = "*"
        txtNewPwd2.Properties.PasswordChar = "*"
        txtOldpwd.Focus()
    End Sub

    Private Sub FormChangePassowrd_Load(sender As Object, e As EventArgs) Handles Me.Load
        clean()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class