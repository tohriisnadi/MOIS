Imports System.Drawing.Printing

Public Class ReportSalesQuotation
    Private Sub ReportSalesQuotation_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        lbAddres1.Text = ModKoneksi.CompanyAddres1
        lbAddres2.Text = ModKoneksi.CompanyAddres2
        lbAddres3.Text = ModKoneksi.CompanyAddres3
        lbPhone.Text = ModKoneksi.Companytelp
        lbEmail.Text = ModKoneksi.CompanyEmail


        'FOpName.Text = ModKoneksi.FullNameOperator
        lbCreator.Text = ModKoneksi.FullNameOperator
        lbHPhone.Text = ModKoneksi.PhoneOperator
        LbEmailOP.Text = ModKoneksi.EmailOperator

        lbPrint.Text = Date.Now
        lbPrintBy.Text = ModKoneksi.FullNameOperator
    End Sub
End Class