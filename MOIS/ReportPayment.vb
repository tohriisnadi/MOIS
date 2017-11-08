Imports System.Drawing.Printing

Public Class ReportPayment
    Private Sub ReportPayment_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        '        lbCompany.Text = ModKoneksi.CompanyName
        lbAddres1.Text = ModKoneksi.CompanyAddres1
        lbAddres2.Text = ModKoneksi.CompanyAddres2
        lbAddres3.Text = ModKoneksi.CompanyAddres3
        lbEmail.Text = ModKoneksi.CompanyEmail
        lbPhone.Text = ModKoneksi.Companytelp
        lbPrint.Text = Date.Now
        lbPrintBy.Text = ModKoneksi.FullNameOperator

    End Sub
End Class