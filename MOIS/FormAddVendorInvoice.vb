Imports System.Data.Odbc
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FormAddVendorInvoice
    Dim DataAP As New ClassVendorInvoice

    Public X As String = ""
    Dim dataSQ As New ClassSalesQuotation

    Dim dataItemMD As New ClassItemMD
    Public VendorInvoiceId As String = ""

    Dim oDataTabelUnbound As New DataTable
    Dim Orow As DataRow

    Sub clean()
        txtDate.EditValue = Date.Now
        txtTermOfPayment.SelectedIndex = 0
        txtDocNumber.Enabled = False
        cbCust.SelectedIndex = -1
        txtRef.Text = ""
        txtNote.Text = ""
        txtRef.Text = ""
        txtContactPerson.Text = ""
        txtCurrency.Text = ""
        txtRate.Text = "1"
        txtDiscountHeader.Text = "0"
        txtBaseLineDate.EditValue = Date.Now
        txtPPNStatus.SelectedIndex = 0
        txtTotal.Text = "0"
        txtDiscount.Text = "0"
        txtTotalPPN.Text = "0"
        txtNetPrice.Text = "0"
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
            oDataTabelUnbound.Columns.Add(New DataColumn("Discount Type", GetType(String))) '7
            oDataTabelUnbound.Columns.Add(New DataColumn("Discount", GetType(Long))) '8
            oDataTabelUnbound.Columns.Add(New DataColumn("Total", GetType(Long))) '9
            oDataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '10
            oDataTabelUnbound.Columns.Add(New DataColumn("NOGR", GetType(String))) '11
            oDataTabelUnbound.Columns.Add(New DataColumn("MaxQty", GetType(String))) '12

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(CL As String, ItemCode As String, ItemDesc As String, UOM As String, Qty As Integer, UnitPrice As Long, DiscountType As String, Disc As Long, total As Long, remark As String, GRNumber As String, maxQty As Integer)
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
        Orow(11) = GRNumber
        Orow(12) = maxQty
        oDataTabelUnbound.Rows.Add(Orow)
    End Sub

    Sub loaddetilbyidmaster()
        Dim odata As New DataTable
        odata.Clear()
        odata = DataAP.SelectDetilbyIdMaster(VendorInvoiceId)
        For i = 0 To odata.Rows.Count - 1
            addNewRow(odata.Rows(i).Item(0), odata.Rows(i).Item(1), odata.Rows(i).Item(2), odata.Rows(i).Item(3), odata.Rows(i).Item(4), odata.Rows(i).Item(5), odata.Rows(i).Item(6), odata.Rows(i).Item(7), odata.Rows(i).Item(8), odata.Rows(i).Item(9), odata.Rows(i).Item(10), odata.Rows(i).Item(4))
        Next
    End Sub

    Sub setGrid()
        Try
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(3).OptionsColumn.AllowEdit = False
            GridView1.Columns(2).OptionsColumn.AllowEdit = False
            GridView1.Columns(1).OptionsColumn.AllowEdit = False
            GridView1.Columns(0).OptionsColumn.AllowEdit = False
            GridView1.Columns(4).OptionsColumn.AllowEdit = False
            GridView1.Columns(9).OptionsColumn.AllowEdit = False
            GridView1.Columns(11).OptionsColumn.AllowEdit = False

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
            GridView1.Columns(12).Visible = False
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

    Public Kodevendor As String = ""
    Dim VendorCode(5000) As String
    Dim Datavendor As New ClassMasterVendor
    Sub Loadvendor()
        Dim odata As New DataTable
        odata.Clear()
        odata = Datavendor.SelectMasterVendor
        cbCust.Properties.Items.Clear()
        For i = 0 To odata.Rows.Count - 1
            cbCust.Properties.Items.Add(odata.Rows(i).Item(2))
            VendorCode(i) = odata.Rows(i).Item(1)
        Next
        cbCust.SelectedIndex = 0
    End Sub


    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        loadItem()

        RepocbPaymentType.Items.Clear()
        RepocbPaymentType.Items.Add("Value")
        RepocbPaymentType.Items.Add("Percent")


        GridView1.Columns(2).ColumnEdit = RepoItemCode
        GridView1.Columns("Discount Type").ColumnEdit = RepocbPaymentType

        RepocbPaymentType.TextEditStyle = TextEditStyles.DisableTextEditor
        RepositoryItemSearchLookUpEdit1.TextEditStyle = TextEditStyles.DisableTextEditor
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub

    Sub formatAngka()
        txtTotal.Text = Format(CLng(txtTotal.Text), "###,###,##0.00")
        txtDiscount.Text = Format(CLng(txtDiscount.Text), "###,###,##0.00")
        txtNetPrice.Text = Format(CLng(txtNetPrice.Text), "###,###,##0.00")
        txtTotalPPN.Text = Format(CLng(txtTotalPPN.Text), "###,###,##0.00")
        txtTotal.Enabled = False
        txtDiscount.Enabled = False
        txtNetPrice.Enabled = False
        txtTotalPPN.Enabled = False
    End Sub

    Private Sub FormAddVendorInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load
        formatAngka()
        Loadvendor()
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
            formatAngka()
        Catch ex As Exception
            txtTotal.Text = "0"
            txtDiscount.Text = "0"
            txtNetPrice.Text = "0"
            txtTotalPPN.Text = "0"
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
            If ItemCode.Contains(e.Value) Then
                e.Value = e.Value
                View.GetFocusedDataRow.Item("Item Description") = ItemDesc(Array.IndexOf(ItemCode, e.Value))
                View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
            Else
                e.Valid = False
                e.ErrorText = "Enter a valid Item Code"
            End If
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
        ElseIf View.FocusedColumn.FieldName = "Qty" Then
            Dim qty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Qty"))
            Dim qtymax As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("MaxQty"))
            If e.Value > qtymax Then
                e.Valid = False
                e.ErrorText = "Value not more than " + qtymax.ToString
            Else
                e.Value = e.Value
            End If
        End If
    End Sub

    Private Sub GridView1_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView1.RowUpdated
        hitungDiscountItem()
        hitung()
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Try
            FormListGR.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtCurrency.Text = "" Then
            MsgBox("Currency cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
        ElseIf IsNumeric(txtRate.Text) = False Or txtRate.Text = "" Then
            MsgBox("Currency must more 0", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
        ElseIf txtDiscountHeader.Text = "" Or IsNumeric(txtDiscountHeader.Text) = False
            MsgBox("Discount format is false", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
        Else
            Try
                DataAP.AddVendorInvoice(VendorCode(cbCust.SelectedIndex), txtContactPerson.Text, txtRef.Text, txtCurrency.Text, txtRate.Text, Format(CDate(txtDate.Text), "yyyy/MM/dd"), txtTermOfPayment.Text, txtDiscountHeader.Text, txtPPNStatus.Text,
                                txtNote.Text, Format(CDate(txtBaseLineDate.Text), "yyyy/MM/dd"), txtTotal.Text, txtDiscount.Text, txtTotalPPN.Text, txtNetPrice.Text, oDataTabelUnbound)
                clean()
            Catch

            End Try
        End If
        FormDataVendorInvoice.LoadData()
    End Sub

    Private Sub txtDiscountHeader_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscountHeader.KeyDown
        If e.KeyCode = Keys.Enter Then
            hitung()
        End If
    End Sub

    Public DODate As String = ""
    '  Dim datavendor As New ClassCustomer
    Sub cetakLaporan(ByVal odata As DataTable)
        Dim laporan As New ReportVendorInvoice
        Dim Tool As ReportPrintTool = New ReportPrintTool(laporan)
        Dim oDataSet As New DataSet
        Dim oDataAdapter As New OdbcDataAdapter
        Dim i As Integer

        If oDataSet.Tables.Count <> 0 Then
            oDataSet.Tables.Remove("Table1")
        End If

        laporan.lbHDate.Text = txtDate.Text
        laporan.lbInvoice.Text = VendorInvoiceId
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
        oDataVendor = Datavendor.SelectVendorByID(Kodevendor)
        If oDataVendor.Rows.Count > 0 Then
            laporan.lbVendor.Text = oDataVendor.Rows(0).Item("Name").ToString
            laporan.lbVendorAddress.Text = oDataVendor.Rows(0).Item("address").ToString
            laporan.lbFax.Text = oDataVendor.Rows(0).Item("Fax").ToString
            laporan.lbTelp.Text = oDataVendor.Rows(0).Item("Telp").ToString

        End If


        ' laporan.lbInvoice.Text = SalesBillingId
        laporan.lbDONo.Text = txtRef.Text
        laporan.lbDODate.Text = DODate


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

        'laporan.FlbBankName.Text = dataRekening("BankName")
        'laporan.FlbBankAddress.Text = dataRekening("BankAddress")
        'laporan.FlbAccount.Text = dataRekening("AccountNumber")
        'laporan.FlbAccountName.Text = dataRekening("AccountName")
        'laporan.FlbCurrency.Text = dataRekening("Currency")

        Tool.ShowPreview()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        cetakLaporan(oDataTabelUnbound)
    End Sub

    Private Sub txtPPNStatus_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtPPNStatus.SelectedValueChanged
        hitung()
    End Sub
End Class