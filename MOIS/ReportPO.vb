Imports System.Drawing.Printing

Public Class ReportPO
    Private Sub ReportPO_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        '  lbCompany.Text = ModKoneksi.CompanyName
        lbAddres1.Text = ModKoneksi.CompanyAddres1
        lbAddres2.Text = ModKoneksi.CompanyAddres2
        lbAddres3.Text = ModKoneksi.CompanyAddres3
        lbPhone.Text = ModKoneksi.Companytelp
        lbEmail.Text = ModKoneksi.CompanyEmail

        txtTerbilang.Text = FormAddPO.Terbilang(txtSubTotalF.Text)

        lbPrint.Text = Date.Now
        lbPrintBy.Text = ModKoneksi.FullNameOperator

        txtvendorF.Text = lbVendor.Text

        txtCurF1.Text = lbCurrency.Text
        txtCurF2.Text = lbCurrency.Text
        txtCurF3.Text = lbCurrency.Text
        txtCurF4.Text = lbCurrency.Text
        txtCurF5.Text = lbCurrency.Text
        txtCurF6.Text = lbCurrency.Text

    End Sub
End Class