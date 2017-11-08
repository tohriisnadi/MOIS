Public Class FormAddOperator
    Dim dataoperator As New ClassOperator
    Dim dataRole As New ClassRule
    Public X As String

    Dim RoleId(5000) As String

    Sub clean()
        txtFullName.Text = ""
        txtPassword.Text = ""
        txtUsername.Text = ""
        txtUsername.Focus()
        LoadRole()
    End Sub

    Sub LoadRole()
        Dim odatarole As New DataTable
        odatarole.Clear()
        odatarole = dataRole.SelectRuleAktif
        cbRole.Properties.Items.Clear()
        For i = 0 To odatarole.Rows.Count - 1
            RoleId(i) = odatarole.Rows(i).Item(0)
            cbRole.Properties.Items.Add(odatarole.Rows(i).Item(1))
        Next
        cbRole.SelectedIndex = 0
    End Sub

    Private Sub FormAddOperator_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadRole()
    End Sub

    Public idOperator As String

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If txtPassword.Text = "" Then
            MsgBox("Password cannot empty", MsgBoxStyle.Critical, "Error")
            txtPassword.Focus()
        ElseIf txtUsername.Text = ""
            MsgBox("Username cannot empty", MsgBoxStyle.Critical, "Error")
            txtUsername.Focus()
        ElseIf txtFullName.Text = ""
            MsgBox("Fullname cannot empty", MsgBoxStyle.Critical, "Error")
            txtFullName.Focus()
        Else
            If X = "1" Then
                dataoperator.addOperator(txtUsername.Text, txtPassword.Text, txtFullName.Text, txtPhone.Text, txtEmail.Text, RoleId(cbRole.SelectedIndex))
                clean()
            ElseIf X = "2" Then
                Dim idrole As String = ""
                idrole = RoleId(cbRole.SelectedIndex)
                If idrole = "" Then
                    MsgBox("Please Select Role", MsgBoxStyle.Critical, "Error")
                    txtPassword.Focus()
                Else
                    dataoperator.EditOperator(idOperator, txtUsername.Text, txtPassword.Text, txtFullName.Text, txtPhone.Text, txtEmail.Text, idrole)
                    clean()
                    Close()
                End If
            End If

        End If
        FormManageOperator.loadDataOperator()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        Dim odata As New DataTable

        If e.KeyCode = Keys.Enter Then
            odata.Clear()
            'txtUsername.Text = txtUsername.Text.ToUpper()
            odata = dataoperator.ValidationCode(txtUsername.Text)
            If odata.Rows.Count > 0 Then
                MsgBox("username already exist, please input other data", MsgBoxStyle.Critical, "Error")
                txtUsername.Text = ""
                txtUsername.Focus()
            ElseIf txtUsername.Text = ""
                MsgBox("Username cannot empty", MsgBoxStyle.Critical, "Error")
            Else
                txtPassword.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clean()
        Close()
    End Sub
End Class