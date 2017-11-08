Imports System.ComponentModel
Imports System.Data.Odbc
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FormAddSalesQuotation
    Dim dataSQ As New ClassSalesQuotation

    Dim dataItemMD As New ClassItemMD
    Dim OdataItem As New DataTable

    Public X As String = ""
    Public SQid As String = ""

    Dim oDataTabelUnbound As New DataTable
    Dim Orow As DataRow

    Sub clean()
        txtDate.EditValue = Date.Now
        txtValidUntil.EditValue = Date.Now
        txtDocNumber.Enabled = False
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
        cbCustomer.SelectedIndex = 0
        RepositoryItemSearchLookUpEdit1.NullText = "<select Item code>"
        txtContactPerson.Focus()
        setTabelUnbound()
    End Sub

    Sub Enable()
        cbCustomer.Enabled = True
        txtContactPerson.Enabled = True
        txtRef.Enabled = True
        txtCurrency.Enabled = True
        txtRate.Enabled = True
        txtDate.Enabled = True
        txtValidUntil.Enabled = True
        txtSalesPerson.Enabled = True
        txtDiscount.Enabled = True
        txtPPNStatus.Enabled = True
        txtNote.Enabled = True
        SimpleButton1.Enabled = True
        txtProject.Enabled = True
        btnConvert.Enabled = True
        GridControl1.Enabled = True
        txtDiscountHeader.Enabled = True
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
            oDataTabelUnbound.Columns.Add(New DataColumn("EnquiryId", GetType(String))) '11
            oDataTabelUnbound.Columns.Add(New DataColumn("QtyEnquiry", GetType(Integer))) '12
            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(CL As String, ItemCode As String, ItemDesc As String, UOM As String, Qty As Integer, UnitPrice As Long, DisType As String, Disc As Long, total As Long, remark As String, enquiryId As String, QtyEn As Integer)
        Orow = oDataTabelUnbound.NewRow()
        Orow(0) = oDataTabelUnbound.Rows.Count() + 1
        Orow(1) = CL
        Orow(2) = ItemCode
        Orow(3) = ItemDesc
        Orow(4) = UOM
        Orow(5) = Qty
        Orow(6) = UnitPrice
        Orow(7) = DisType
        Orow(8) = Disc
        Orow(9) = total
        Orow(10) = remark
        Orow(11) = enquiryId
        Orow(12) = QtyEn
        oDataTabelUnbound.Rows.Add(Orow)
    End Sub

    Sub loaddetilbyidmaster()
        Dim odata As New DataTable
        odata.Clear()
        odata = dataSQ.SelectDetilbyIdMaster(SQid)
        For i = 0 To odata.Rows.Count - 1
            addNewRow(odata.Rows(i).Item(1).ToString, odata.Rows(i).Item(2).ToString, odata.Rows(i).Item(3).ToString, odata.Rows(i).Item(4).ToString, odata.Rows(i).Item(5).ToString, odata.Rows(i).Item(6).ToString,
                      odata.Rows(i).Item(7).ToString, odata.Rows(i).Item(8).ToString, odata.Rows(i).Item(9).ToString, odata.Rows(i).Item(10).ToString, odata.Rows(i).Item(11).ToString, odata.Rows(i).Item(5).ToString)
        Next
    End Sub

    Sub setGrid()
        Try
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(3).OptionsColumn.AllowEdit = False
            GridView1.Columns(0).OptionsColumn.AllowEdit = False
            GridView1.Columns(4).OptionsColumn.AllowEdit = False
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
            GridView1.Columns(9).Width = 70
            GridView1.Columns(10).Width = 150

            GridView1.Columns(11).Visible = False
            GridView1.Columns(12).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        LoadItemtoSLU()
        GridView1.Columns(2).ColumnEdit = RepositoryItemSearchLookUpEdit1
        GridView1.Columns("Discount Type").ColumnEdit = RepocbPaymentType
        setGrid()
    End Sub

    Private Sub FormAddSalesQuotation_Load(sender As Object, e As EventArgs) Handles Me.Load
        'btnPrint.Enabled = False
        LoadCustomer()
        If X = "2" Then
            cbCustomer.SelectedIndex = Array.IndexOf(CustomerCode, KodeCustomer)
        End If
        formatangka()
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

    Sub LoadItemtoSLU()
        OdataItem.Clear()
        OdataItem = dataItemMD.SelectItemMDMini
        RepositoryItemSearchLookUpEdit1.DataSource = OdataItem
        RepositoryItemSearchLookUpEdit1.ValueMember = "ItemCode"
        RepositoryItemSearchLookUpEdit1.DisplayMember = "ItemCode"

        RepocbPaymentType.Items.Clear()
        RepocbPaymentType.Items.Add("Value")
        RepocbPaymentType.Items.Add("Percent")
    End Sub

    Dim dataCustomer As New ClassCustomer
    Public KodeCustomer As String
    Dim CustomerCode(5000) As String
    Sub LoadCustomer()
        Dim odata As New DataTable
        odata.Clear()
        odata = dataCustomer.selectDataCustomer
        cbCustomer.Properties.Items.Clear()
        For i = 0 To odata.Rows.Count - 1
            cbCustomer.Properties.Items.Add(odata.Rows(i).Item(2))
            CustomerCode(i) = odata.Rows(i).Item(1)
        Next
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        FormListEnquiry.X = "2"
        Try
            FormListEnquiry.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If X = "1" Then
                dataSQ.AddSalesQuotation(CustomerCode(cbCustomer.SelectedIndex), txtContactPerson.Text, txtRef.Text, txtCurrency.Text, txtRate.Text, Format(CDate(txtDate.Text), "yyyy/MM/dd"), Format(CDate(txtValidUntil.Text), "yyyy/MM/dd"),
                                         txtSalesPerson.Text, txtDiscountHeader.Text, txtPPNStatus.Text, txtNote.Text, txtTotal.Text, txtDiscount.Text, txtTotalPPN.Text,
                                         txtNetPrice.Text, txtProject.Text, oDataTabelUnbound)
                clean()
            ElseIf X = "2" Then
                dataSQ.EditSalesQuotation(SQid, CustomerCode(cbCustomer.SelectedIndex), txtContactPerson.Text, txtRef.Text, txtCurrency.Text, txtRate.Text, Format(CDate(txtDate.Text), "yyyy/MM/dd"), Format(CDate(txtValidUntil.Text), "yyyy/MM/dd"),
                                         txtSalesPerson.Text, txtDiscountHeader.Text, txtPPNStatus.Text, txtNote.Text, txtTotal.Text, txtDiscount.Text, txtTotalPPN.Text,
                                         txtNetPrice.Text, txtProject.Text, oDataTabelUnbound)
                clean()
                Close()
            End If
        Catch ex As Exception

        End Try
        FormDataSalesQuotation.loadData()
    End Sub

    Sub hitung()
        Dim TotalPrice As Long = 0
        Dim NetPrice As Long = 0
        Try
            For i As Integer = 0 To oDataTabelUnbound.Rows.Count - 1
                NetPrice = NetPrice + (CLng(oDataTabelUnbound.Rows(i).Item("Total")))
                TotalPrice = TotalPrice + (CLng(oDataTabelUnbound.Rows(i).Item("Qty") * CLng(oDataTabelUnbound.Rows(i).Item("Unit Price"))))
            Next
            txtTotal.Text = NetPrice.ToString
            txtDiscount.Text = CLng(txtTotal.Text) * (CLng(txtDiscountHeader.Text) / 100)
            If txtPPNStatus.SelectedIndex = 0 Then
                txtTotalPPN.Text = (CLng(txtTotal.Text) - CLng(txtDiscount.Text)) / 11
                txtNetPrice.Text = CLng(txtTotal.Text) - CLng(txtDiscount.Text)
            ElseIf txtPPNStatus.SelectedIndex = 1 Then
                txtTotalPPN.Text = (CLng(txtTotal.Text) - CLng(txtDiscount.Text)) / 10
                txtNetPrice.Text = CLng(txtTotal.Text) - (CLng(txtDiscount.Text) + CLng(txtTotalPPN.Text))
            ElseIf txtPPNStatus.SelectedIndex = 2 Then
                txtTotalPPN.Text = "0"
                txtNetPrice.Text = CLng(txtTotal.Text) - CLng(txtDiscount.Text)
            Else
                MsgBox("Error calculate data, please select PPN Status", MsgBoxStyle.Critical, "Error")
            End If
            txtTotal.Text = Format(CLng(txtTotal.Text), "###,###,##0.00")
            txtDiscount.Text = Format(CLng(txtDiscount.Text), "###,###,##0.00")
            txtNetPrice.Text = Format(CLng(txtNetPrice.Text), "###,###,##0.00")
            txtTotalPPN.Text = Format(CLng(txtTotalPPN.Text), "###,###,##0.00")
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
            genItem = a.Item(3)
        Catch ex As Exception
            genItem = "0"
        End Try
    End Sub

    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Item Code" Then
            e.Value = e.Value
            If genItem = "1" Then
                FormPopGenItem.X = "3"
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
            View.GetFocusedDataRow.Item("QtyEnquiry") = 999
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
        ElseIf View.FocusedColumn.FieldName = "Qty" Then
            Dim qty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Qty"))
            Dim qtymax As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("QtyEnquiry"))
            If e.Value > qtymax Then
                e.Valid = False
                e.ErrorText = "Value not more than " + qtymax.ToString
            Else
                e.Value = e.Value
            End If
        End If
    End Sub

    Private Sub GridView1_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView1.RowUpdated
        hitung()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            FormListPriceList.itemcode = GridView1.GetFocusedDataRow.Item(2)
            FormListPriceList.rowin = GridView1.GetFocusedDataSourceRowIndex
            FormListPriceList.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub



    Sub cetakLaporan(ByVal odata As DataTable)
        Dim laporan As New ReportSalesQuotation
        Dim Tool As ReportPrintTool = New ReportPrintTool(laporan)
        Dim oDataSet As New DataSet
        Dim oDataAdapter As New OdbcDataAdapter
        Dim i As Integer

        If oDataSet.Tables.Count <> 0 Then
            oDataSet.Tables.Remove("Table1")
        End If

        oDataSet.Tables.Add(odata.Copy)

        laporan.DataSource = oDataSet
        laporan.DataAdapter = oDataAdapter
        laporan.DataMember = "Table1"

        Dim oDataVendor As New DataTable
        oDataVendor.Clear()
        oDataVendor = dataCustomer.selectDataCustomerByID(KodeCustomer)
        If oDataVendor.Rows.Count > 0 Then
            laporan.lbCustomerName.Text = oDataVendor.Rows(0).Item("Name").ToString
            laporan.lbCustAddress.Text = oDataVendor.Rows(0).Item("address").ToString
            laporan.lbFax.Text = oDataVendor.Rows(0).Item("Fax").ToString
            laporan.lbTlp.Text = oDataVendor.Rows(0).Item("Telp").ToString
            laporan.lbAttn.Text = oDataVendor.Rows(0).Item("ContactPerson").ToString
        End If

        laporan.lbQuotationID.Text = SQid
        laporan.lbCustID.Text = KodeCustomer
        laporan.lbDate.Text = txtDate.Text
        laporan.lbValidUntil.Text = txtValidUntil.Text
        laporan.lbProject.Text = txtProject.Text
        laporan.lbYourRef.Text = txtRef.Text
        laporan.lbCurrency.Text = txtCurrency.Text

        laporan.txtNo.DataBindings.Add("Text", Nothing, "NO")
        laporan.txtMaterial.DataBindings.Add("Text", Nothing, "Item Description")
        laporan.txtQuantity.DataBindings.Add("Text", Nothing, "Qty")
        laporan.txtUom.DataBindings.Add("Text", Nothing, "UOM")
        laporan.txtAmmount.DataBindings.Add("Text", Nothing, "Total", "{0:#,#.00}")
        'laporan.txtCur1.Text = txtCurrency.Text
        'laporan.txtCur2.Text = txtCurrency.Text

        laporan.FlbTotal.Text = txtTotal.Text
        laporan.FDiscount.Text = txtDiscount.Text
        laporan.FNetFrice.Text = txtNetPrice.Text
        laporan.FlbFat.Text = txtTotalPPN.Text
        laporan.FGrandTotal.Text = Format(CLng(txtNetPrice.Text) + CLng(txtTotalPPN.Text), "###,###,##0.00")

        'laporan.txtNoteF.Text = txtNote.Text

        Tool.ShowPreview()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        cetakLaporan(oDataTabelUnbound)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If FormLogin.CekAkses(FormDataSalesQuotation.MenuId) > 2 Then
            btnSave.Enabled = True
            btnEdit.Enabled = False
            Enable()
        Else
            MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
        End If
    End Sub

    Private Sub txtDiscountHeader_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscountHeader.KeyDown
        If e.KeyCode = Keys.Enter Then
            hitung()
        End If
    End Sub
End Class