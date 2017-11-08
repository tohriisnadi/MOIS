Public Class FormAddCustomer
    Dim dataCustomer As New ClassCustomer
    Public X As String = ""
    Public Id As String = ""

    Sub clean()
        txtCustId.Text = ""
        txtName.Text = ""
        txtOtherName.Text = ""
        txtCustType.Text = ""
        txtSalesPerson.Text = ""
        txtCreditStatus.Text = ""
        txtTaxID.Text = ""
        txtTelp.Text = ""
        txtFax.Text = ""
        txtMobPhone.Text = ""
        txtEmail.Text = ""
        txtContactPerson.Text = ""
        txtWebsite.Text = ""
        txtRemarks.Text = ""
        txtPaymentTerm.Text = ""
        txtCreditLimit.Text = ""
        txtDiscount.Text = ""
        txtCustID.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtCustID.Text = "" Then
            MsgBox("Customer Id cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtCustID.Focus()
        ElseIf txtName.Text = ""
            MsgBox("Customer Id cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtCustID.Focus()
        Else
            Try
                Dim pricelist As String
                If ckPriceList.Checked = True Then
                    pricelist = "1"
                Else
                    pricelist = "0"
                End If
                If X = "1" Then
                    dataCustomer.AddCustomer(txtCustID.Text, txtName.Text, txtOtherName.Text, txtCustType.Text, txtSalesPerson.Text, txtCreditStatus.Text,
                             txtTaxID.Text, txtTelp.Text, txtFax.Text, txtMobPhone.Text, txtEmail.Text, txtContactPerson.Text, txtWebsite.Text,
                             txtRemarks.Text, txtPaymentTerm.Text, txtCreditLimit.Text, txtDiscount.Text, pricelist)
                    If MsgBox("Add Other Data ?", MsgBoxStyle.YesNo, "Question") = MsgBoxResult.Yes Then
                        clean()
                    Else
                        Me.Close()
                    End If
                ElseIf X = "2" Then
                    dataCustomer.EditCustomer(Id, txtCustID.Text, txtName.Text, txtOtherName.Text, txtCustType.Text, txtSalesPerson.Text, txtCreditStatus.Text,
                             txtTaxID.Text, txtTelp.Text, txtFax.Text, txtMobPhone.Text, txtEmail.Text, txtContactPerson.Text, txtWebsite.Text,
                             txtRemarks.Text, txtPaymentTerm.Text, txtCreditLimit.Text, txtDiscount.Text, pricelist)
                    clean()
                    Close()
                End If

            Catch ex As Exception

            End Try

        End If
    End Sub
End Class