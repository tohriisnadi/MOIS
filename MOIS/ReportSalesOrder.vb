Imports System.Drawing.Printing

Public Class ReportSalesOrder
    Private Sub ReportSalesOrder_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint

        lbAddres1.Text = ModKoneksi.CompanyAddres1
        lbAddres2.Text = ModKoneksi.CompanyAddres2
        lbAddres3.Text = ModKoneksi.CompanyAddres3
        lbPhone.Text = ModKoneksi.Companytelp
        lbEmail.Text = ModKoneksi.CompanyEmail

        txtTerbilang.Text = FormAddPO.Terbilang(CLng(txtGrandTotalF.Text))

        lbPrint.Text = Date.Now
        lbPrintBy.Text = ModKoneksi.FullNameOperator

        FOpName.Text = ModKoneksi.FullNameOperator
        FOPRole.Text = ModKoneksi.RoleNameOperator

    End Sub
End Class