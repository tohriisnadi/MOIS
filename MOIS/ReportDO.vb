Imports System.Drawing.Printing

Public Class ReportDO
    Private Sub ReportDO_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        'lbCompany.Text = ModKoneksi.CompanyName
        lbAddres1.Text = ModKoneksi.CompanyAddres1
        lbAddres2.Text = ModKoneksi.CompanyAddres2
        lbAddres3.Text = ModKoneksi.CompanyAddres3
        lbPhone.Text = ModKoneksi.Companytelp
        lbEmail.Text = ModKoneksi.CompanyEmail

        lbPrint.Text = Date.Now
        lbPrintBy.Text = ModKoneksi.FullNameOperator
    End Sub
End Class