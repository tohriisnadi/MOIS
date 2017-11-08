Imports System.Drawing.Printing

Public Class ReportPR
    Private Sub ReportPR_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        ' lbCompany.Text = ModKoneksi.CompanyName
        lbAddres1.Text = ModKoneksi.CompanyAddres1
        lbAddres2.Text = ModKoneksi.CompanyAddres2
        lbAddres3.Text = ModKoneksi.CompanyAddres3
        lbPhone.Text = ModKoneksi.Companytelp
        lbEmail.Text = ModKoneksi.CompanyEmail
        ' PicHeader.ImageUrl = "\CMP0041922A.jpg"
        txtTerbilang.Text = FormAddPO.Terbilang(txtGrandTotalF.Text)

        txtCurF1.Text = txtCur1.Text
        txtCurF2.Text = txtCur1.Text
        txtCurF3.Text = txtCur1.Text


        FlbDepartemen.Text = ModKoneksi.RoleNameOperator
        FlbRequestor.Text = ModKoneksi.FullNameOperator

        lbPrint.Text = Date.Now
        lbPrintBy.Text = ModKoneksi.FullNameOperator
    End Sub
End Class