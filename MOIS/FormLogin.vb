Public Class FormLogin
    Dim dataLogin As New ClassOperator
    Dim dataRole As New ClassRule
    Dim OdataUserLogin As New DataTable
    Dim OdataAkses As New DataTable

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtPassword.Text = ""
        txtUsername.Text = ""
        txtPassword.Properties.PasswordChar = "*"
        Me.Show()
        txtUsername.Focus()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If txtUsername.Text <> "" And e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        ElseIf e.KeyCode = Keys.F1 Then
            MsgBox("Aplication Version 0.1.2.2" + vbCrLf + "update 23-01-2018", MsgBoxStyle.Information, "Version Info")
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If txtPassword.Text <> "" And e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Sub DefaultAkses()
        For i = 0 To ModKoneksi.Akses.Length - 1
            Akses(i) = "0"
        Next
    End Sub

    Sub AksesAdmin()
        For i = 0 To ModKoneksi.Akses.Length - 1
            Akses(i) = "4"
        Next
    End Sub

    Function CekAkses(idMenu As Integer)
        Dim Aks As String
        Aks = Akses(idMenu)
        Return Aks
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        OdataUserLogin.Clear()
        OdataUserLogin = dataLogin.SelectUserLogin(txtUsername.Text, txtPassword.Text)
        If OdataUserLogin.Rows.Count = 0 Then
            MsgBox("Login Failed", MsgBoxStyle.Critical, "Error Login")
            txtUsername.Text = ""
            txtPassword.Text = ""
            txtUsername.Focus()
        Else
            'MsgBox("Login Succes", MsgBoxStyle.Information, "Congratulations")
            ModKoneksi.kodeOperator = OdataUserLogin.Rows(0).Item(0).ToString
            ModKoneksi.namaOperator = OdataUserLogin.Rows(0).Item(1).ToString
            ModKoneksi.PhoneOperator = OdataUserLogin.Rows(0).Item(4).ToString
            ModKoneksi.EmailOperator = OdataUserLogin.Rows(0).Item(5).ToString
            ModKoneksi.FullNameOperator = OdataUserLogin.Rows(0).Item(3).ToString
            ModKoneksi.RoleNameOperator = OdataUserLogin.Rows(0).Item(7).ToString

            If kodeOperator = "SYSTEMADMIN" Then
                AksesAdmin()
                'DefaultAkses()
            Else

                FormMain.lbUserLogin.Caption = ModKoneksi.FullNameOperator
                OdataAkses.Clear()
                OdataAkses = dataRole.SelectAksesRolebyRoleId(OdataUserLogin.Rows(0).Item(6))
                If OdataAkses.Rows.Count > 0 Then
                    For i = 0 To OdataAkses.Rows.Count - 1
                        Akses(i) = OdataAkses.Rows(i).Item(5)
                    Next
                Else
                    DefaultAkses()
                End If
            End If
            Me.Hide()
            FormMain.Show()
        End If

    End Sub

End Class