Public Class FormAddWarehouse
    Dim dataWarehouse As New ClassWarehouse

    Public X As String = ""
    Public IdWhs As String = ""
    Sub clean()
        txtWhsCode.Text = ""
        txtWhsDesc.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtContact.Text = ""
        txtCountry.Text = ""
        txtFax.Text = ""
        txtPhone.Text = ""
        txtZipCode.Text = ""
        txtWhsCode.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Inactive As String = ""
        If ckInactive.Checked = True Then
            Inactive = "1"
        Else
            Inactive = "0"
        End If
        If txtWhsCode.Text = "" Then
            MsgBox("Whs Code cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtWhsCode.Focus()
        ElseIf txtWhsDesc.Text = ""
            MsgBox("Whs Description cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtWhsDesc.Focus()
        ElseIf txtPhone.Text = ""
            MsgBox("Phone cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtPhone.Focus()
        Else
            Try
                If X = "1" Then
                    dataWarehouse.addWarehouse(txtWhsCode.Text, txtWhsDesc.Text, txtAddress.Text, txtCity.Text, txtCountry.Text, txtZipCode.Text, txtContact.Text, txtPhone.Text, txtFax.Text, Inactive)
                    If MsgBox("Add Other Data ?", MsgBoxStyle.YesNo, "Question") = MsgBoxResult.Yes Then
                        clean()
                    Else
                        Me.Close()
                    End If
                ElseIf X = "2" Then
                    dataWarehouse.EditWarehouse(IdWhs, txtWhsCode.Text, txtWhsDesc.Text, txtAddress.Text, txtCity.Text, txtCountry.Text, txtZipCode.Text, txtContact.Text, txtPhone.Text, txtFax.Text, Inactive)
                    clean()
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
        FormDataWarehouse.loadData()
    End Sub

    Private Sub txtFax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFax.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtZipCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtZipCode.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub

    Private Sub txtWhsCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhsCode.KeyDown
        Dim odata As New DataTable

        If e.KeyCode = Keys.Enter Then
            odata.Clear()
            txtWhsCode.Text = txtWhsCode.Text.ToUpper()
            odata = dataWarehouse.validationCode(txtWhsCode.Text)
            If odata.Rows.Count > 0 Then
                MsgBox("Whs Code already exist, please input other code", MsgBoxStyle.Critical, "Error")
                txtWhsCode.Text = ""
                txtWhsCode.Focus()
            ElseIf txtWhsCode.Text = ""
                MsgBox("Whs Code cannot empty", MsgBoxStyle.Critical, "Error")
            Else
                txtWhsDesc.Focus()
            End If
        End If
    End Sub
End Class