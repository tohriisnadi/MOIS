﻿Imports System.Drawing.Printing

Public Class ReportSalesInvoice
    Private Sub ReportSalesInvoice_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        'lbCompany.Text = ModKoneksi.CompanyName
        lbAddres1.Text = ModKoneksi.CompanyAddres1
        lbAddres2.Text = ModKoneksi.CompanyAddres2
        lbAddres3.Text = ModKoneksi.CompanyAddres3
        lbPhone.Text = ModKoneksi.Companytelp
        lbEmail.Text = ModKoneksi.CompanyEmail
        lbPrint.Text = Date.Now
        lbPrintBy.Text = ModKoneksi.FullNameOperator

        txtTerbilang.Text = FormAddPO.Terbilang(txtGrandTotalF.Text)

        txtCurF2.Text = txtCurF1.Text
        txtCurF3.Text = txtCurF1.Text
        txtCurF3.Text = txtCurF1.Text
        txtCurF4.Text = txtCurF1.Text
        txtCurF5.Text = txtCurF1.Text

        txtFDept.Text = ModKoneksi.RoleNameOperator
        txtFOpmName.Text = ModKoneksi.FullNameOperator
    End Sub
End Class