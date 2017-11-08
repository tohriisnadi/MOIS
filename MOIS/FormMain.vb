Imports System.ComponentModel

Public Class FormMain
    Private Sub btnLogin_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnLogin.ItemClick
        FormLogin.ShowDialog()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If FormLogin.CekAkses(1) > 0 Then
            FormDataWarehouse.MdiParent = Me
            FormDataWarehouse.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataWarehouse)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If FormLogin.CekAkses(2) > 0 Then
            FormDataUom.MdiParent = Me
            FormDataUom.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataUom)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        If FormLogin.CekAkses(3) > 0 Then
            FormDataItemGroup.MdiParent = Me
            FormDataItemGroup.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataItemGroup)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub S_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles S.ItemClick
        If FormLogin.CekAkses(6) > 0 Then
            FormDataCompanySetup.MdiParent = Me
            FormDataCompanySetup.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataCompanySetup)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If FormLogin.CekAkses(4) > 0 Then
            FormDataItemMD.MdiParent = Me
            FormDataItemMD.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataItemMD)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        If FormLogin.CekAkses(5) > 0 Then
            FormDataMasterVendor.MdiParent = Me
            FormDataMasterVendor.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataMasterVendor)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If FormLogin.CekAkses(6) > 0 Then
            FormDataPriceList.MdiParent = Me
            FormDataPriceList.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataPriceList)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        If FormLogin.CekAkses(9) > 0 Then
            FormDataEnquiry.MdiParent = Me
            FormDataEnquiry.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataEnquiry)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        If FormLogin.CekAkses(10) > 0 Then
            FormDataPR.MdiParent = Me
            FormDataPR.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataPR)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        If FormLogin.CekAkses(11) > 0 Then
            FormDataPO.MdiParent = Me
            FormDataPO.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataPO)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If FormLogin.CekAkses(0) > 0 Then
            FormManageOperator.MdiParent = Me
            StAction = "1"
            FormManageOperator.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormManageOperator)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Public StAction As String
    Private Sub btnAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        If StAction = "1" Then
            If FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 0 Then
                FormAddOperator.X = "1"
                FormAddOperator.ShowDialog()
            ElseIf FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 1 Then
                FormAddRole.X = "1"
                FormAddRole.ShowDialog()
            ElseIf FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 2 Then
                FormRule.ShowDialog()
            End If
        Else
            MsgBox("Not Allowed")
        End If

    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbUserLogin.Caption = ModKoneksi.namaOperator
        FormDashboard.MdiParent = Me
        FormDashboard.Show()

    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        If FormLogin.CekAkses(12) > 0 Then
            FormDataGR.MdiParent = Me
            FormDataGR.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataGR)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        FormDataCustomer.MdiParent = Me
        FormDataCustomer.Show()
        XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataCustomer)
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        If FormLogin.CekAkses(13) > 0 Then
            FormDataSalesQuotation.MdiParent = Me
            FormDataSalesQuotation.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataSalesQuotation)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        If FormLogin.CekAkses(14) > 0 Then
            FormDataSalesOrder.MdiParent = Me
            FormDataSalesOrder.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataSalesOrder)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        If FormLogin.CekAkses(15) > 0 Then
            FormDataDelivery.MdiParent = Me
            FormDataDelivery.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataDelivery)
        Else
        End If
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        If FormLogin.CekAkses(16) > 0 Then
            FormDataSalesBilling.MdiParent = Me
            FormDataSalesBilling.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataSalesBilling)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        If FormLogin.CekAkses(17) > 0 Then
            FormDataVendorInvoice.MdiParent = Me
            FormDataVendorInvoice.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataVendorInvoice)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        If FormLogin.CekAkses(18) > 0 Then
            FormDataPayment.MdiParent = Me
            FormDataPayment.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDataPayment)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        If MsgBox("Are you sure to logout ?", vbQuestion + vbYesNo, "Qusetions") = MsgBoxResult.Yes Then
            Me.Close()
            FormLogin.txtUsername.Text = ""
            FormLogin.txtPassword.Text = ""
            FormLogin.Show()
        End If

    End Sub

    Private Sub FormMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FormLogin.txtUsername.Text = ""
        FormLogin.txtPassword.Text = ""
        FormLogin.Show()
    End Sub

    Private Sub BarButtonItem25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        FormChangePassowrd.ShowDialog()
    End Sub

    Private Sub FormMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = False
    End Sub

    Private Sub btnEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEdit.ItemClick
        If StAction = "1" Then
            If FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 0 Then
                FormAddOperator.X = "2"
                FormAddOperator.idOperator = FormManageOperator.GridView1.GetFocusedDataRow.Item(0)
                FormAddOperator.txtUsername.Text = FormManageOperator.GridView1.GetFocusedDataRow.Item(1)
                FormAddOperator.txtPassword.Text = FormManageOperator.GridView1.GetFocusedDataRow.Item(2)
                FormAddOperator.txtFullName.Text = FormManageOperator.GridView1.GetFocusedDataRow.Item(3)
                FormAddOperator.txtPhone.Text = FormManageOperator.GridView1.GetFocusedDataRow.Item(4)
                FormAddOperator.txtEmail.Text = FormManageOperator.GridView1.GetFocusedDataRow.Item(5)
                FormAddOperator.cbRole.Text = FormManageOperator.GridView1.GetFocusedDataRow.Item(7)
                'MsgBox(FormManageOperator.GridView1.GetFocusedDataRow.Item(0))
                FormAddOperator.ShowDialog()
            ElseIf FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 1 Then
                FormAddRole.X = "2"
                FormAddRole.txtRoleName.Text = ""
                FormAddRole.txtInfo.Text = ""
          '      MsgBox("ini edit")
                FormAddRole.ShowDialog()
            ElseIf FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 2 Then
                'MsgBox("ini edit")
                FormRule.ShowDialog()
            End If
        Else
            MsgBox("Not Allowed")
        End If
    End Sub
    Dim dataoperator As New ClassOperator
    Private Sub btnView_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnView.ItemClick
        If StAction = "1" Then
            If FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 0 Then
                dataoperator.SetNonAktifOperator(FormManageOperator.GridView1.GetFocusedDataRow.Item(0))
            ElseIf FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 1 Then
                dataoperator.SetNonAktifRole(FormManageOperator.GridView2.GetFocusedDataRow.Item(0))
            ElseIf FormManageOperator.XtraTabControl1.SelectedTabPageIndex = 2 Then
                ' MsgBox("ini Delete 3")
            End If
        Else
            MsgBox("Not Allowed")
        End If
    End Sub

    Private Sub BarButtonItem26_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
        If FormLogin.CekAkses(FormRekening.menuid) > 0 Then
            FormRekening.ShowDialog()
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem27_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        If FormLogin.CekAkses(FormAdjustmentStock.menuid) > 0 Then
            FormAdjustmentStock.Show()
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick

        If FormLogin.CekAkses(FormDaftarStock.menuid) > 0 Then
            FormDaftarStock.MdiParent = Me
            FormDaftarStock.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormDaftarStock)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub

    Private Sub BarButtonItem29_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        If FormLogin.CekAkses(FormKartuStock.menuid) > 0 Then
            FormKartuStock.MdiParent = Me
            FormKartuStock.Show()
            XtraTabbedMdiManager1.SelectedPage = XtraTabbedMdiManager1.Pages(FormKartuStock)
        Else
            MsgBox("NO AUTHORIZE", MsgBoxStyle.Critical, "Acces Failed")
        End If
    End Sub
End Class
