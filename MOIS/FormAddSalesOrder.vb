Imports System.Data.Odbc
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FormAddSalesOrder
    Dim dataSO As New ClassSalesOrder
    Dim dataSQ As New ClassSalesQuotation

    Dim dataItemMD As New ClassItemMD
    Public SOid As String = ""

    Dim oDataTabelUnbound As New DataTable
    Dim Orow As DataRow
    Public X As String = ""


    Sub clean()
        txtDate.EditValue = Date.Now
        txtDeliveryDate.EditValue = Date.Now
        txtTermOfPayment.Text = "0"
        txtDocNumber.Enabled = False
        cbCust.SelectedIndex = -1
        txtRef.Text = ""
        txtNote.Text = ""
        txtRef.Text = ""
        txtContactPerson.Text = ""
        txtCurrency.Text = ""
        txtRate.Text = "1"
        txtDiscountHeader.Text = "0"
        txtSalesPerson.Text = ""
        txtPPNStatus.SelectedIndex = 0
        txtTotal.Text = "0"
        txtDiscount.Text = "0"
        txtTotalPPN.Text = "0"
        txtNetPrice.Text = "0"
        btnConvert.Enabled = True
        setTabelUnbound()
    End Sub

    Sub enable()
        cbCust.Enabled = True
        txtContactPerson.Enabled = True
        txtRef.Enabled = True
        txtCurrency.Enabled = True
        txtRate.Enabled = True
        txtDate.Enabled = True
        txtDeliveryDate.Enabled = True
        txtSalesPerson.Enabled = True
        txtDiscountHeader.Enabled = True
        txtPPNStatus.Enabled = True
        txtNote.Enabled = True
        txtTermOfPayment.Enabled = True
        GridControl1.Enabled = True
        btnConvert.Enabled = True
    End Sub

    Sub setTabelUnbound()
        Try
            oDataTabelUnbound.Rows.Clear()
            oDataTabelUnbound.Columns.Clear()
            oDataTabelUnbound.Clear()
            oDataTabelUnbound.Columns.Add(New DataColumn("NO", GetType(String))) '0
            oDataTabelUnbound.Columns.Add(New DataColumn("C/L", GetType(String))) '1
            oDataTabelUnbound.Columns.Add(New DataColumn("Item Code", GetType(String))) '2
            oDataTabelUnbound.Columns.Add(New DataColumn("Item Description", GetType(String))) '3
            oDataTabelUnbound.Columns.Add(New DataColumn("UOM", GetType(String))) '4
            oDataTabelUnbound.Columns.Add(New DataColumn("Qty", GetType(Integer))) '5
            oDataTabelUnbound.Columns.Add(New DataColumn("Unit Price", GetType(Long))) '6
            oDataTabelUnbound.Columns.Add(New DataColumn("Discount Type", GetType(String))) '7
            oDataTabelUnbound.Columns.Add(New DataColumn("Discount", GetType(Long))) '8
            oDataTabelUnbound.Columns.Add(New DataColumn("Total", GetType(Long))) '9
            oDataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '10
            oDataTabelUnbound.Columns.Add(New DataColumn("NoSalesQuotation", GetType(String))) '11

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(CL As String, ItemCode As String, ItemDesc As String, UOM As String, Qty As Integer, UnitPrice As Long, DiscType As String, Disc As Long, total As Long, remark As String, SQId As String)
        Orow = oDataTabelUnbound.NewRow()
        Orow(0) = oDataTabelUnbound.Rows.Count() + 1
        Orow(1) = CL
        Orow(2) = ItemCode
        Orow(3) = ItemDesc
        Orow(4) = UOM
        Orow(5) = Qty
        Orow(6) = UnitPrice
        Orow(7) = DiscType
        Orow(8) = Disc
        Orow(9) = total
        Orow(10) = remark
        Orow(11) = SQId
        oDataTabelUnbound.Rows.Add(Orow)
    End Sub

    Sub loaddetilbyidmaster()
        Dim odata As New DataTable
        odata.Clear()
        odata = dataSO.SelectDetilbyIdMaster(SOid)
        For i = 0 To odata.Rows.Count - 1
            addNewRow(odata.Rows(i).Item(0).ToString, odata.Rows(i).Item(1).ToString, odata.Rows(i).Item(2).ToString, odata.Rows(i).Item(3).ToString, odata.Rows(i).Item(4).ToString, odata.Rows(i).Item(5).ToString, odata.Rows(i).Item(6).ToString,
                      odata.Rows(i).Item(7).ToString, odata.Rows(i).Item(8).ToString, odata.Rows(i).Item(9).ToString, odata.Rows(i).Item(10).ToString)
        Next
    End Sub

    Sub setGrid()
        Try
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(3).OptionsColumn.AllowEdit = False
            GridView1.Columns(4).OptionsColumn.AllowEdit = False
            GridView1.Columns(0).OptionsColumn.AllowEdit = False
            GridView1.Columns(9).OptionsColumn.AllowEdit = False

            GridView1.Columns(0).Width = 30
            GridView1.Columns(1).Width = 30
            GridView1.Columns(2).Width = 100
            GridView1.Columns(3).Width = 189
            GridView1.Columns(4).Width = 30
            GridView1.Columns(5).Width = 30
            GridView1.Columns(6).Width = 70
            GridView1.Columns(7).Width = 70
            GridView1.Columns(8).Width = 70
            GridView1.Columns(9).Width = 70
            GridView1.Columns(10).Width = 150
            GridView1.Columns(11).Width = 50

            GridView1.Columns(11).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub formatangka()
        txtTotal.Text = Format(CLng(txtTotal.Text), "###,###,##0.00")
        txtDiscount.Text = Format(CLng(txtDiscount.Text), "###,###,##0.00")
        txtNetPrice.Text = Format(CLng(txtNetPrice.Text), "###,###,##0.00")
        txtTotalPPN.Text = Format(CLng(txtTotalPPN.Text), "###,###,##0.00")
        txtTotal.Enabled = False
        txtDiscount.Enabled = False
        txtNetPrice.Enabled = False
        txtTotalPPN.Enabled = False
    End Sub

    Dim odataitem As New DataTable
    Sub LoadItemtoSLU()
        odataitem.Clear()
        odataitem = dataItemMD.SelectItemMDMini
        RepositoryItemSearchLookUpEdit1.DataSource = odataitem
        RepositoryItemSearchLookUpEdit1.ValueMember = "ItemCode"
        RepositoryItemSearchLookUpEdit1.DisplayMember = "ItemCode"

        RepocbDiscountType.Items.Clear()
        RepocbDiscountType.Items.Add("Value")
        RepocbDiscountType.Items.Add("Percent")

    End Sub

    Public KodeCustomer As String = ""
    Dim CustCode(5000) As String
    Sub LoadCustomer()
        Dim odata As New DataTable
        odata.Clear()
        odata = dataSQ.selectCustomerforcb
        cbCust.Properties.Items.Clear()
        For i = 0 To odata.Rows.Count - 1
            cbCust.Properties.Items.Add(odata.Rows(i).Item(1))
            CustCode(i) = odata.Rows(i).Item(0)
        Next
        cbCust.SelectedIndex = 0
        Try
            cbCust.SelectedIndex = Array.IndexOf(CustCode, KodeCustomer)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        LoadItemtoSLU()
        GridView1.Columns(2).ColumnEdit = RepositoryItemSearchLookUpEdit1
        GridView1.Columns(7).ColumnEdit = RepocbDiscountType
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub

    Private Sub FormAddSalesOrder_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' btnPrint.Enabled = False
        LoadCustomer()
        If X = "2" Then
            cbCust.SelectedIndex = Array.IndexOf(CustCode, KodeCustomer)
        End If
        formatangka()
        RepocbDiscountType.TextEditStyle = TextEditStyles.DisableTextEditor
        RepositoryItemSearchLookUpEdit1.TextEditStyle = TextEditStyles.DisableTextEditor
    End Sub

    Sub hitung()
        Dim TotalPrice As Long = 0
        Dim NetPrice As Long = 0
        Dim Discount As Long = 0
        Try
            For i As Integer = 0 To oDataTabelUnbound.Rows.Count - 1
                NetPrice = NetPrice + (CLng(oDataTabelUnbound.Rows(i).Item("Total")))
                TotalPrice = TotalPrice + (CLng(oDataTabelUnbound.Rows(i).Item("Qty") * CLng(oDataTabelUnbound.Rows(i).Item("Unit Price"))))
                Discount = (TotalPrice - NetPrice) + (NetPrice * (CLng(txtDiscountHeader.Text) / 100))
            Next
            txtTotal.Text = TotalPrice.ToString
            txtDiscount.Text = Discount.ToString
            If txtPPNStatus.SelectedIndex = 0 Then
                txtTotalPPN.Text = (CLng(txtTotal.Text) - CLng(txtDiscount.Text)) / 11
                txtNetPrice.Text = CLng(txtTotal.Text) - CLng(txtDiscount.Text) - CLng(txtTotalPPN.Text)
            ElseIf txtPPNStatus.SelectedIndex = 1 Then
                txtTotalPPN.Text = (CLng(txtTotal.Text) - CLng(txtDiscount.Text)) / 10
                txtNetPrice.Text = (CLng(txtTotal.Text) - CLng(txtDiscount.Text)) '+ CLng(txtTotalPPN.Text)
            ElseIf txtPPNStatus.SelectedIndex = 2 Then
                txtTotalPPN.Text = "0"
                txtNetPrice.Text = CLng(txtTotal.Text) - CLng(txtDiscount.Text)
            Else
                MsgBox("Error calculate data, please select PPN Status", MsgBoxStyle.Critical, "Error")
            End If
            formatangka()
        Catch ex As Exception
            txtTotal.Text = "0"
            txtDiscount.Text = "0"
            txtNetPrice.Text = "0"
            txtTotalPPN.Text = "0"
        End Try
        formatangka()
    End Sub

    Dim description As String = ""
    Dim Uom As String = ""
    Dim genItem As String = ""
    Private Sub RepositoryItemSearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit1.EditValueChanged
        Dim a As DataRowView
        a = RepositoryItemSearchLookUpEdit1.GetRowByKeyValue(GridView1.ActiveEditor.EditValue)
        description = a.Item(1)
        Uom = a.Item(2)
        Try
            GenItem = a.Item(3)
        Catch ex As Exception
            GenItem = "0"
        End Try
    End Sub
    Sub hitungDiscountItem()
        Dim price As Long
        Dim qty As Integer
        Dim disc As Long
        For i = 0 To oDataTabelUnbound.Rows.Count - 1
            price = oDataTabelUnbound.Rows(i).Item("Unit Price")
            qty = oDataTabelUnbound.Rows(i).Item("Qty")
            disc = oDataTabelUnbound.Rows(i).Item("Discount")
            oDataTabelUnbound.Rows(i).Item("Total") = 0
            If oDataTabelUnbound.Rows(i).Item("Discount Type") = "Percent" Then
                oDataTabelUnbound.Rows(i).Item("Total") = (price * qty) - (CDbl(disc / 100) * (price * qty))
            ElseIf oDataTabelUnbound.Rows(i).Item("Discount Type") = "Value" Then
                oDataTabelUnbound.Rows(i).Item("Total") = (qty * (price - disc))
            End If
        Next
    End Sub

    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Item Code" Then
            e.Value = e.Value
            If genItem = "1" Then
                FormPopGenItem.X = "4"
                FormPopGenItem.ShowDialog()
            Else
                View.GetFocusedDataRow.Item("Item Description") = description
                View.GetFocusedDataRow.Item("UOM") = Uom
            End If
            View.GetFocusedDataRow.Item("Unit Price") = 0
            View.GetFocusedDataRow.Item("Discount") = 0
            View.GetFocusedDataRow.Item("Discount Type") = "Percent"
            View.GetFocusedDataRow.Item("Total") = 0
            View.GetFocusedDataRow.Item("Qty") = 0
            View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
        ElseIf View.FocusedColumn.FieldName = "Discount" Then
            Dim price As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Unit Price"))
            Dim qty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Qty"))
            If price > 0 And qty > 0 Then
                'e.Value = e.Value
                If View.GetFocusedDataRow.Item("Discount Type") = "Percent" Then
                    View.GetFocusedDataRow.Item("Total") = (price * qty) - (CDbl(e.Value / 100) * (price * qty))
                Else
                    View.GetFocusedDataRow.Item("Total") = (qty * (price - e.Value))
                End If
            Else
                e.Valid = False
                e.ErrorText = "invalid Value"
            End If
            hitung()
        End If
    End Sub

    Private Sub GridView1_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView1.RowUpdated
        hitungDiscountItem()
        hitung()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtCurrency.Text = "" Then
                MsgBox("Currency cannot empty", MsgBoxStyle.Information, "Please fill all field")
                txtCurrency.Focus()
            ElseIf txtRate.Text = "" Or IsNumeric(txtRate.Text) = False
                MsgBox("Rate Format is false", MsgBoxStyle.Information, "Please fill all field")
                txtCurrency.Focus()
            ElseIf txtDiscountHeader.Text = "" Or IsNumeric(txtDiscountHeader.Text) = False
                MsgBox("Discount Format is false", MsgBoxStyle.Information, "Please fill all field")
                txtCurrency.Focus()
            Else
                If X = "1" Then
                    dataSO.AddSalesOrder(CustCode(cbCust.SelectedIndex), txtContactPerson.Text, txtRef.Text, txtCurrency.Text, txtRate.Text, Format(CDate(txtDate.Text), "yyyy/MM/dd"), Format(CDate(txtDeliveryDate.Text), "yyyy/MM/dd"),
                                             txtSalesPerson.Text, txtDiscountHeader.Text, txtPPNStatus.Text, txtNote.Text, txtTermOfPayment.Text, txtTotal.Text, txtDiscount.Text, txtTotalPPN.Text,
                                             txtNetPrice.Text, oDataTabelUnbound)
                    clean()
                ElseIf X = "2" Then
                    dataSO.EditSalesOrder(SOid, CustCode(cbCust.SelectedIndex), txtContactPerson.Text, txtRef.Text, txtCurrency.Text, txtRate.Text, Format(CDate(txtDate.Text), "yyyy/MM/dd"), Format(CDate(txtDeliveryDate.Text), "yyyy/MM/dd"),
                                             txtSalesPerson.Text, txtDiscountHeader.Text, txtPPNStatus.Text, txtNote.Text, txtTermOfPayment.Text, txtTotal.Text, txtDiscount.Text, txtTotalPPN.Text,
                                             txtNetPrice.Text, oDataTabelUnbound)
                    clean()
                    Close()
                End If
            End If

        Catch ex As Exception

        End Try
        FormDataSalesOrder.loadData()
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        FormListSQ.X = "1"
        Try
            FormListSQ.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If FormLogin.CekAkses(FormDataSalesOrder.MenuId) > 2 Then
            btnSave.Enabled = True
            btnEdit.Enabled = False
            enable()
        Else
            MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
        End If
    End Sub

    Dim datacust As New ClassCustomer

    Sub cetakLaporan(ByVal odata As DataTable, dataRekening As DataRow)
        Dim laporan As New ReportSalesOrder
        Dim Tool As ReportPrintTool = New ReportPrintTool(laporan)
        Dim oDataSet As New DataSet
        Dim oDataAdapter As New OdbcDataAdapter
        Dim i As Integer

        If oDataSet.Tables.Count <> 0 Then
            oDataSet.Tables.Remove("Table1")
        End If

        Dim oDataVendor As New DataTable
        oDataVendor.Clear()
        oDataVendor = dataCust.selectDataCustomerByID(KodeCustomer)
        If oDataVendor.Rows.Count > 0 Then
            laporan.lbVendor.Text = oDataVendor.Rows(0).Item("Name").ToString
            laporan.lbVendorAddress.Text = oDataVendor.Rows(0).Item("address").ToString
            laporan.lbFax.Text = oDataVendor.Rows(0).Item("Fax").ToString
            laporan.lbTelp.Text = oDataVendor.Rows(0).Item("Telp").ToString

        End If

        laporan.lbHDate.Text = txtDate.Text
        laporan.lbInvoice.Text = SOid
        laporan.lbPONo.Text = ""
        laporan.lbPODate.Text = ""
        laporan.lbDONo.Text = ""
        laporan.lbDODate.Text = ""
        laporan.lbTermOfPayment.Text = txtTermOfPayment.Text

        oDataSet.Tables.Add(odata.Copy)

        laporan.DataSource = oDataSet
        laporan.DataAdapter = oDataAdapter
        laporan.DataMember = "Table1"

        laporan.txtNo.DataBindings.Add("Text", Nothing, "NO")
        laporan.txtProductDesc.DataBindings.Add("Text", Nothing, "Item Description")
        laporan.txtQty.DataBindings.Add("Text", Nothing, "Qty")
        laporan.txtUnitPrice.DataBindings.Add("Text", Nothing, "Unit Price", "{0:#,#.00}")
        laporan.txtTotal.DataBindings.Add("Text", Nothing, "Total", "{0:#,#.00}")

        laporan.txtSubTotalF.Text = Format(CLng(txtTotal.Text), "###,###,##0.00")
        laporan.txtDiscountF.Text = Format(CLng(txtDiscount.Text), "###,###,##0.00")
        laporan.txtFTotal.Text = Format(CLng(txtTotal.Text) - CLng(txtDiscount.Text), "###,###,##0.00")
        laporan.txtFPPN.Text = Format(CLng(txtTotalPPN.Text), "###,###,##0.00")
        laporan.txtGrandTotalF.Text = Format(CLng(txtNetPrice.Text) + CLng(txtTotalPPN.Text), "###,###,##0.00")
        laporan.txtCurF1.Text = txtCurrency.Text
        laporan.txtCurF2.Text = txtCurrency.Text
        laporan.txtCurF3.Text = txtCurrency.Text
        laporan.txtCurF4.Text = txtCurrency.Text
        laporan.txtCurF5.Text = txtCurrency.Text

        laporan.FlbBankName.Text = dataRekening("BankName")
        laporan.FlbBankAddress.Text = dataRekening("BankAddress")
        laporan.FlbAccount.Text = dataRekening("AccountNumber")
        laporan.FlbAccountName.Text = dataRekening("AccountName")
        laporan.FlbCurrency.Text = dataRekening("Currency")

        Tool.ShowPreview()
    End Sub

    Public OdataRek As DataRow

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        FormChoseRekening.X = "1"
        FormChoseRekening.ShowDialog()
        Try
            cetakLaporan(oDataTabelUnbound, OdataRek)
        Catch ex As Exception
            MsgBox("Tidak ada Rekening terpilih. ", vbInformation, "Information")
        End Try
    End Sub

    Private Sub txtDiscountHeader_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscountHeader.KeyDown
        If e.KeyCode = Keys.Enter Then
            hitung()
        End If
    End Sub

    Private Sub txtPPNStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtPPNStatus.SelectedIndexChanged
        hitung()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FormAddCustomer.Show()
        LoadCustomer()
    End Sub
End Class