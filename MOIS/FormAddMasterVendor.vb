Public Class FormAddMasterVendor
    Dim dataMasterVendor As New ClassMasterVendor

    Public X As String = ""
    Public idMasterVendor As String

    Sub Clean()
        txtVendorCode.Text = ""
        txtName.Text = ""
        txtOtherName.Text = ""
        txtVendorGroup.Text = ""
        txtAVLNumber.Text = ""
        txtAVLSegment.Text = ""
        txtTaxID.Text = ""
        txtTelp.Text = ""
        txtFax.Text = ""
        txtMobPhone.Text = ""
        txtEmail.Text = ""
        txtContactPerson.Text = ""
        txtWebsite.Text = ""
        txtRemarks.Text = ""
        txtPaymentTerm.Text = 0
        txtCreditLimit.Text = 0
        txtDiscount.Text = ""
        ckPricelist.Text = ""
        txtBank.Text = ""
        txtAccount.Text = ""
        txtIBAN.Text = ""
        txtSwiftCode.Text = ""
        txtVendorCode.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim pricelist As String = ""
        If ckPricelist.Checked = True Then
            pricelist = "1"
        Else
            pricelist = "0"
        End If
        Try
            If txtVendorCode.Text = "" Then
                MsgBox("Vendor Code cannot empty", MsgBoxStyle.Information, "Please fill all field")
                txtVendorCode.Focus()
            ElseIf txtName.Text = ""
                MsgBox("Vendor Name cannot empty", MsgBoxStyle.Information, "Please fill all field")
                txtName.Focus()
            ElseIf IsNumeric(txtAVLNumber.Text) = False Then
                MsgBox("AVL Number must be Integer", MsgBoxStyle.Information, "Please fill all field")
                txtAVLNumber.Focus()
            ElseIf IsNumeric(txtPaymentTerm.Text) = False Then
                MsgBox("Payment Term must be Integer", MsgBoxStyle.Information, "Please fill all field")
                txtPaymentTerm.Focus()
            ElseIf IsNumeric(txtDiscount.Text) = False Then
                MsgBox("Discount must be Integer", MsgBoxStyle.Information, "Please fill all field")
                txtDiscount.Focus()
            ElseIf IsNumeric(txtCreditLimit.Text) = False Then
                MsgBox("Credit Limit must be Integer", MsgBoxStyle.Information, "Please fill all field")
                txtCreditLimit.Focus()
            Else
                If X = "1" Then
                    dataMasterVendor.AddMasterVendor(txtVendorCode.Text, txtName.Text, txtOtherName.Text, txtVendorGroup.Text, txtAVLNumber.Text, txtAVLSegment.Text, txtTaxID.Text, txtTelp.Text,
                                                     txtFax.Text, txtMobPhone.Text, txtEmail.Text, txtContactPerson.Text, txtWebsite.Text, txtRemarks.Text, txtPaymentTerm.Text, txtCreditLimit.Text,
                                                     txtDiscount.Text, pricelist, txtBank.Text, txtAccount.Text, txtIBAN.Text, txtSwiftCode.Text, kodeOperator, namaOperator)
                    If MsgBox("Add Other Data ?", MsgBoxStyle.YesNo, "Question") = MsgBoxResult.Yes Then
                        Clean()
                    Else

                        Me.Close()
                    End If
                ElseIf X = "2"
                    dataMasterVendor.EditMasterVendor(idMasterVendor, txtVendorCode.Text, txtName.Text, txtOtherName.Text, txtVendorGroup.Text, txtAVLNumber.Text, txtAVLSegment.Text, txtTaxID.Text, txtTelp.Text,
                                                     txtFax.Text, txtMobPhone.Text, txtEmail.Text, txtContactPerson.Text, txtWebsite.Text, txtRemarks.Text, txtPaymentTerm.Text, txtCreditLimit.Text,
                                                     txtDiscount.Text, pricelist, txtBank.Text, txtAccount.Text, txtIBAN.Text, txtSwiftCode.Text, kodeOperator, namaOperator)
                End If
                Clean()
                FormDataMasterVendor.loadData()
            End If
        Catch ex As Exception
            MsgBox("Operation Failed" + vbCrLf + ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub txtVendorCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVendorCode.KeyDown
        Dim odata As New DataTable

        If e.KeyCode = Keys.Enter Then
            odata.Clear()
            txtVendorCode.Text = txtVendorCode.Text.ToUpper
            odata = dataMasterVendor.validationcode(txtVendorCode.Text)
            If odata.Rows.Count > 0 Then
                MsgBox("Vendor Code already exist, please input other code", MsgBoxStyle.Critical, "Error")
                txtVendorCode.Text = ""
                txtVendorCode.Focus()
            ElseIf txtVendorCode.Text = ""
                MsgBox("Vendor Code cannot empty", MsgBoxStyle.Critical, "Error")
            Else
                txtName.Focus()
            End If
        End If

    End Sub

    Private Sub txtTelp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtAVLNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAVLNumber.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtFax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFax.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtMobPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobPhone.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtPaymentTerm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaymentTerm.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtCreditLimit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCreditLimit.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtDiscount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiscount.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clean()
        Close()
    End Sub
End Class