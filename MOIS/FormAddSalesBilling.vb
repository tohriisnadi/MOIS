Imports System.Data.Odbc
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FormAddSalesBilling
    Dim DataAr As New ClassSalesBilling
    Public NoAR As String = ""
    Public X As String = ""
    Dim dataSQ As New ClassSalesQuotation

    Dim dataItemMD As New ClassItemMD
    Public SalesBillingId As String = ""

    Dim oDataTabelUnbound As New DataTable
    Dim Orow As DataRow

    Sub clean()
        txtDate.EditValue = Date.Now

        txtTermOfPayment.SelectedIndex = 0
        txtDocNumber.Enabled = False
        cbCust.SelectedIndex = -1
        LoadCustomer()
        txtRef.Text = ""
        txtNote.Text = ""
        txtRef.Text = ""
        txtCurrency.Text = ""
        txtRate.Text = "1"
        txtDiscountHeader.Text = "0"
        txtBaseLineDate.EditValue = Date.Now
        txtPPNStatus.SelectedIndex = 0
        txtTotal.Text = "0"
        txtDiscount.Text = "0"
        txtTotalPPN.Text = "0"
        txtNetPrice.Text = "0"
        txtPONo.Text = ""
        txtPODate.EditValue = Date.Now
        btnConvert.Enabled = True
        setTabelUnbound()
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
            oDataTabelUnbound.Columns.Add(New DataColumn("Discount Type", GetType(String))) '9
            oDataTabelUnbound.Columns.Add(New DataColumn("Discount", GetType(Long))) '7
            oDataTabelUnbound.Columns.Add(New DataColumn("Total", GetType(Long))) '8
            oDataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '9
            oDataTabelUnbound.Columns.Add(New DataColumn("NoSalesOrder", GetType(String))) '10

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(CL As String, ItemCode As String, ItemDesc As String, UOM As String, Qty As Integer, UnitPrice As Long, DiscountType As String, Disc As Long, total As Long, remark As String, SOId As String)
        Orow = oDataTabelUnbound.NewRow()
        Orow(0) = oDataTabelUnbound.Rows.Count() + 1
        Orow(1) = CL
        Orow(2) = ItemCode
        Orow(3) = ItemDesc
        Orow(4) = UOM
        Orow(5) = Qty
        Orow(6) = UnitPrice
        Orow(7) = DiscountType
        Orow(8) = Disc
        Orow(9) = total
        Orow(10) = remark
        Orow(11) = SOId
        oDataTabelUnbound.Rows.Add(Orow)
    End Sub

    Sub loaddetilbyidmaster()
        Dim odata As New DataTable
        odata.Clear()
        odata = DataAr.SelectDetilbyIdMaster(SalesBillingId)
        For i = 0 To odata.Rows.Count - 1
            addNewRow(odata.Rows(i).Item(0), odata.Rows(i).Item(1), odata.Rows(i).Item(2).ToString, odata.Rows(i).Item(3).ToString, odata.Rows(i).Item(4), odata.Rows(i).Item(5), odata.Rows(i).Item(6), odata.Rows(i).Item(7), odata.Rows(i).Item(8), odata.Rows(i).Item(9), odata.Rows(i).Item(10))
        Next
    End Sub

    Sub setGrid()
        Try
            GridView1.OptionsBehavior.Editable = False
            GridView1.OptionsView.ColumnAutoWidth = False
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
            GridView1.Columns(4).Width = 50
            GridView1.Columns(5).Width = 30
            GridView1.Columns(6).Width = 70
            GridView1.Columns(7).Width = 70
            GridView1.Columns(8).Width = 70
            GridView1.Columns(9).Width = 100
            GridView1.Columns(10).Width = 150
            GridView1.Columns(11).Width = 50

            GridView1.Columns(11).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim ItemDesc(5000) As String
    Dim ItemCode(5000) As String

    Sub loadItem()
        Dim OdataItem As New DataTable
        OdataItem.Clear()
        OdataItem = dataItemMD.SelectItemMDMini
        RepoItemCode.Items.Clear()
        For i As Integer = 0 To OdataItem.Rows.Count - 1
            ItemDesc(i) = OdataItem.Rows(i).Item(1)
            ItemCode(i) = OdataItem.Rows(i).Item(0)
            RepoItemCode.Items.Add(OdataItem.Rows(i).Item(0))
        Next
    End Sub

    Public KodeCustomer As String
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
        loadItem()

        GridView1.Columns(2).ColumnEdit = RepoItemCode
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
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

    Private Sub FormAddSalesBilling_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadCustomer()
        formatAngka()
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
    End Sub

    'Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
    '    Dim View As GridView = sender
    '    If View.FocusedColumn.FieldName = "Item Code" Then
    '        If ItemCode.Contains(e.Value) Then
    '            e.Value = e.Value
    '            View.GetFocusedDataRow.Item("Item Description") = ItemDesc(Array.IndexOf(ItemCode, e.Value))
    '            View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
    '        Else
    '            e.Valid = False
    '            e.ErrorText = "Enter a valid Item Code"
    '        End If
    '    ElseIf View.FocusedColumn.FieldName = "Discount" Then
    '        Dim price As Long = View.GetFocusedDataRow.Item("Unit Price")
    '        Dim qty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Qty"))
    '        If price > 0 And qty > 0 Then
    '            'e.Value = e.Value
    '            View.GetFocusedDataRow.Item("Total") = qty * (price - (CDbl(e.Value / 100) * (price)))

    '        Else
    '            e.Valid = False
    '            e.ErrorText = "Valid Value"
    '        End If
    '    End If
    'End Sub

    Private Sub GridView1_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView1.RowUpdated
        hitung()
    End Sub

    Public DODate As String = ""
    Dim dataCust As New ClassCustomer
    Sub cetakLaporan(ByVal odata As DataTable, dataRekening As DataRow)
        Dim laporan As New ReportSalesInvoice
        Dim Tool As ReportPrintTool = New ReportPrintTool(laporan)
        Dim oDataSet As New DataSet
        Dim oDataAdapter As New OdbcDataAdapter
        Dim i As Integer

        If oDataSet.Tables.Count <> 0 Then
            oDataSet.Tables.Remove("Table1")
        End If

        laporan.lbHDate.Text = txtDate.Text
        laporan.lbInvoice.Text = NoAR
        laporan.lbPONo.Text = ""
        laporan.lbPODate.Text = ""
        laporan.lbDONo.Text = ""
        laporan.lbDODate.Text = ""
        laporan.lbTermOfPayment.Text = txtTermOfPayment.Text

        oDataSet.Tables.Add(odata.Copy)

        laporan.DataSource = oDataSet
        laporan.DataAdapter = oDataAdapter
        laporan.DataMember = "Table1"

        Dim oDataVendor As New DataTable
        oDataVendor.Clear()
        oDataVendor = dataCust.selectDataCustomerByID(KodeCustomer)
        If oDataVendor.Rows.Count > 0 Then
            laporan.lbcustomer.Text = oDataVendor.Rows(0).Item("Name").ToString
            laporan.lbCustomerAddress.Text = oDataVendor.Rows(0).Item("address").ToString
            laporan.lbFax.Text = oDataVendor.Rows(0).Item("Fax").ToString
            laporan.lbTelp.Text = oDataVendor.Rows(0).Item("Telp").ToString

        End If


        laporan.lbInvoice.Text = SalesBillingId
        laporan.lbDONo.Text = txtRef.Text
        laporan.lbDODate.Text = DODate
        laporan.lbPONo.Text = txtPONo.Text
        laporan.lbPODate.Text = txtPODate.Text

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

        laporan.FlbBankName.Text = dataRekening("BankName")
        laporan.FlbBankAddress.Text = dataRekening("BankAddress")
        laporan.FlbAccount.Text = dataRekening("AccountNumber")
        laporan.FlbAccountName.Text = dataRekening("AccountName")
        laporan.FlbCurrency.Text = dataRekening("Currency")

        Tool.ShowPreview()
    End Sub
    Public OdataRek As DataRow
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        FormChoseRekening.X = "2"
        FormChoseRekening.ShowDialog()
        cetakLaporan(oDataTabelUnbound, OdataRek)
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        ' FormListOD.X = "2"
        Try
            FormListOD.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
        hitung()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtCurrency.Text = "" Then
            MsgBox("Currency cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
        ElseIf txtRate.Text = "" Or IsNumeric(txtRate.Text) = False
            MsgBox("Rate Format is false", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
        ElseIf txtdiscountHeader.Text = "" Or IsNumeric(txtDiscountHeader.Text) = False
            MsgBox("Discount Format is false", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
        Else
            If X = "1" Then
                DataAr.AddSaleBilling(CustCode(cbCust.SelectedIndex), txtRef.Text, txtCurrency.Text, txtRate.Text, Format(CDate(txtDate.Text), "yyyy/MM/dd"), txtTermOfPayment.Text, txtDiscountHeader.Text,
                                  txtPPNStatus.Text, txtNote.Text, Format(CDate(txtBaseLineDate.Text), "yyyy/MM/dd"), txtTotal.Text, txtDiscount.Text, txtTotalPPN.Text, txtNetPrice.Text, oDataTabelUnbound, Format(CDate(DODate), "yyyy/MM/dd"),
                                  txtPONo.Text, Format(CDate(txtPODate.Text), "yyyy/MM/dd"))
                clean()
            End If
        End If
        FormDataSalesBilling.LoadData()
    End Sub

    Private Sub txtDiscountHeader_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscountHeader.KeyDown
        If e.KeyCode = Keys.Enter Then
            hitung()
        End If
    End Sub
End Class