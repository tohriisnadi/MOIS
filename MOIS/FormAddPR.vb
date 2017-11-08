﻿Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.Odbc
Imports DevExpress.XtraReports.UI

Public Class FormAddPR
    Dim dataPR As New ClassPR

    Dim oDataTabelUnbound As New DataTable
    Dim orow As DataRow

    Public X As String = ""
    Public DocNumberPR As String = ""

    Dim dataItemMD As New ClassItemMD
    Dim OdataItem As New DataTable

    Sub Clean()
        txtReqDate.EditValue = Date.Now
        txtValidUntil.EditValue = Date.Now
        txtCurrency.SelectedIndex = 0
        RepositoryItemSearchLookUpEdit1.NullText = "[Item Code]"
        txtRate.Text = "1"
        txtEnqRef.Text = ""
        txtNote.Text = ""
        txtStatus.SelectedIndex = -1
        txtTotal.Text = "0"
        txtDiscount.Text = "0"
        txtNetPrice.Text = "0"
        txtReqName.Text = ""
        txtReqName.Focus()
        LoadItemtoSLU()
        formatangka()
        setTabelUnbound()
        btnConvert.Enabled = True
        If DocNumberPR = "" Then
            btnPrint.Enabled = False
        Else
            btnPrint.Enabled = True
        End If
    End Sub

    Sub enable()
        txtReqName.Enabled = True
        txtReqDept.Enabled = True
        txtReqDate.Enabled = True
        txtValidUntil.Enabled = True
        txtCurrency.Enabled = True
        txtStatus.Enabled = True
        txtNote.Enabled = True
        txtEnqRef.Enabled = True
        txtRate.Enabled = True
        btnConvert.Enabled = True
        GridControl1.Enabled = True
    End Sub


    Sub formatangka()
        txtTotal.Text = Format(CLng(txtTotal.Text), "###,###,##0.00")
        txtDiscount.Text = Format(CLng(txtDiscount.Text), "###,###,##0.00")
        txtNetPrice.Text = Format(CLng(txtNetPrice.Text), "###,###,##0.00")
    End Sub

    Sub LoadItemtoSLU()
        OdataItem.Clear()
        OdataItem = dataItemMD.SelectItemMDMini
        RepositoryItemSearchLookUpEdit1.DataSource = OdataItem
        RepositoryItemSearchLookUpEdit1.ValueMember = "ItemCode"
        RepositoryItemSearchLookUpEdit1.DisplayMember = "ItemCode"

        RepoCbDisType.Items.Clear()
        RepoCbDisType.Items.Add("Value")
        RepoCbDisType.Items.Add("Percent")

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
            oDataTabelUnbound.Columns.Add(New DataColumn("Req. Price", GetType(Integer))) '6
            oDataTabelUnbound.Columns.Add(New DataColumn("Discount Type", GetType(String))) '7
            oDataTabelUnbound.Columns.Add(New DataColumn("Req. Discount", GetType(Integer))) '8
            oDataTabelUnbound.Columns.Add(New DataColumn("Total", GetType(Integer))) '9
            oDataTabelUnbound.Columns.Add(New DataColumn("IEO", GetType(String))) '10
            oDataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '11
            oDataTabelUnbound.Columns.Add(New DataColumn("MaxQty", GetType(Integer))) '12

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(CL As String, ItemCode As String, ItemDesc As String, Uom As String, Qty As Integer, ReqPrice As Long, DisCountType As String, reqDisc As Long, total As Long, IEO As String, remark As String, maxQty As Integer)
        orow = oDataTabelUnbound.NewRow()
        orow(0) = oDataTabelUnbound.Rows.Count() + 1
        orow(1) = CL
        orow(2) = ItemCode
        orow(3) = ItemDesc
        orow(4) = Uom
        orow(5) = Qty
        orow(6) = ReqPrice
        orow(7) = DisCountType
        orow(8) = reqDisc
        orow(9) = total
        orow(10) = IEO
        orow(11) = remark
        orow(12) = maxQty
        oDataTabelUnbound.Rows.Add(orow)
    End Sub

    Sub LoadDetil()
        Dim Odata As New DataTable
        setTabelUnbound()
        Odata.Clear()
        Odata = dataPR.selectPRDetilByDocumentNumber(DocNumberPR)
        For i As Integer = 0 To Odata.Rows.Count - 1
            addNewRow(Odata.Rows(i).Item(1).ToString, Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5),
                             Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), Odata.Rows(i).Item(9), Odata.Rows(i).Item(10), Odata.Rows(i).Item(11).ToString, Odata.Rows(i).Item(5))
        Next
    End Sub

    Sub loadrepoIEO()
        GridView1.Columns("IEO").ColumnEdit = RepositoryItemComboBox2
        RepositoryItemComboBox2.Items.Clear()
        RepositoryItemComboBox2.Items.Add("I")
        RepositoryItemComboBox2.Items.Add("E")
        RepositoryItemComboBox2.Items.Add("O")

    End Sub
    Private Sub FormAddPR_Load(sender As Object, e As EventArgs) Handles Me.Load

        txtDate.EditValue = Date.Now
        txtDate.Enabled = False
        txtDocNumber.Enabled = False
        txtReqDate.EditValue = Date.Now
        txtValidUntil.EditValue = Date.Now
        btnConvert.Enabled = True
        formatangka()

    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        loadrepoIEO()
        setGrid()
        'loadItem()
        'GridView1.Columns(2).ColumnEdit = RepoItemCode
        LoadItemtoSLU()
        GridView1.Columns("Item Code").ColumnEdit = RepositoryItemSearchLookUpEdit1
        GridView1.Columns("Discount Type").ColumnEdit = RepoCbDisType
    End Sub

    Sub hitung()
        Dim TotalPrice As Long = 0
        Dim discount As Long = 0
        Dim NetPrice As Long = 0
        Dim dis, price, qty As Long
        Try
            For i As Integer = 0 To oDataTabelUnbound.Rows.Count - 1
                'dis = oDataTabelUnbound.Rows(i).Item("Req. Discount")
                price = oDataTabelUnbound.Rows(i).Item("Req. price")
                qty = oDataTabelUnbound.Rows(i).Item("Qty")
                TotalPrice = TotalPrice + (CLng(oDataTabelUnbound.Rows(i).Item("Qty")) * CLng(oDataTabelUnbound.Rows(i).Item("Req. Price")))
                discount = discount + (((dis / 100) * price) * qty)
                'NetPrice = TotalPrice - discount
                NetPrice = NetPrice + CLng(oDataTabelUnbound.Rows(i).Item("Total"))
            Next
            txtTotal.Text = TotalPrice.ToString
            txtDiscount.Text = TotalPrice - NetPrice
            txtNetPrice.Text = NetPrice.ToString
        Catch ex As Exception
            txtTotal.Text = "0"
            txtDiscount.Text = "0"
            txtNetPrice.Text = "0"
        End Try
        formatangka()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtCurrency.Text = "" Then
            MsgBox("Currency cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
            'ElseIf txtRate.Text = "" Then
            '    MsgBox("rate cannot empty", MsgBoxStyle.Information, "Please fill all field")
            '    txtRate.Focus()
        Else
            If X = "1" Then
                dataPR.AddPR(Format(CDate(txtDate.Text), "yyyy/MM/dd"), txtReqName.Text, txtReqDept.Text, Format(txtReqDate.EditValue, "yyyy/MM/dd"), Format(txtValidUntil.EditValue, "yyyy/MM/dd"), txtCurrency.Text, txtRate.Text, txtStatus.Text,
                             txtNote.Text, txtEnqRef.Text, txtTotal.EditValue, txtDiscount.EditValue, txtNetPrice.EditValue, oDataTabelUnbound)
                Clean()
            ElseIf X = "2"
                dataPR.EditPR(DocNumberPR, Format(CDate(txtDate.Text), "yyyy/MM/dd"), txtReqName.Text, txtReqDept.Text, Format(txtReqDate.EditValue, "yyyy/MM/dd"), Format(txtValidUntil.EditValue, "yyyy/MM/dd"), txtCurrency.Text, txtRate.Text, txtStatus.Text,
                              txtNote.Text, txtEnqRef.Text, txtTotal.Text, txtDiscount.Text, txtNetPrice.Text, oDataTabelUnbound)
                Clean()
                Close()
            End If
            FormDataPR.LoadData()
        End If
    End Sub

    Sub setGrid()
        Try
            GridView1.OptionsView.ColumnAutoWidth = False
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(3).OptionsColumn.AllowEdit = False
            GridView1.Columns(0).OptionsColumn.AllowEdit = False
            GridView1.Columns(4).OptionsColumn.AllowEdit = False
            GridView1.Columns(9).OptionsColumn.AllowEdit = False
            'GridView1.Columns(7).OptionsColumn.AllowEdit = False

            GridView1.Columns(0).Width = 50
            GridView1.Columns(1).Width = 50
            GridView1.Columns(2).Width = 120
            GridView1.Columns(3).Width = 189
            GridView1.Columns(4).Width = 50
            GridView1.Columns(5).Width = 30
            GridView1.Columns(6).Width = 150
            GridView1.Columns(7).Width = 80
            GridView1.Columns(8).Width = 100
            GridView1.Columns(9).Width = 150
            GridView1.Columns(10).Width = 50
            GridView1.Columns(11).Width = 200
            GridView1.Columns(12).Visible = False
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        FormListEnquiry.X = "1"
        Try
            FormListEnquiry.ShowDialog()
        Catch
            FormListEnquiry.Close()
            FormListEnquiry.ShowDialog()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clean()
        Close()
    End Sub

    Dim description As String = ""
    Dim Uom As String = ""
    Dim GenItem As String = ""
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

    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Item Code" Then
            e.Value = e.Value
            If GenItem = "1" Then
                FormPopGenItem.X = "1"
                FormPopGenItem.ShowDialog()
            Else
                View.GetFocusedDataRow.Item("Item Description") = description
                View.GetFocusedDataRow.Item("UOM") = Uom
            End If

            View.GetFocusedDataRow.Item("Qty") = 0
            View.GetFocusedDataRow.Item("Req. Price") = 0
            View.GetFocusedDataRow.Item("Req. Discount") = 0
            View.GetFocusedDataRow.Item("Discount Type") = "Percent"
            View.GetFocusedDataRow.Item("MaxQty") = 999
            View.GetFocusedDataRow.Item("Total") = 0
            View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
        ElseIf View.FocusedColumn.FieldName = "Qty" Then
            Dim mqty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("MaxQty"))
            If e.Value > mqty Then
                e.Valid = False
                e.ErrorText = "Value not more than " + mqty.ToString
            Else
                e.Value = e.Value
            End If

            '------------hitung
            'Try
            '    Dim price As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Req. Price"))
            '    Dim qty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Qty"))
            '    If price > 0 And qty > 0 Then
            '        'e.Value = e.Value
            '        If View.GetFocusedDataRow.Item("Discount Type") = "Percent" Then
            '            View.GetFocusedDataRow.Item("Total") = (price * qty) - (CDbl(e.Value / 100) * (price * qty))
            '        Else
            '            View.GetFocusedDataRow.Item("Total") = (qty * (price - e.Value))
            '        End If
            '    Else
            '        e.Valid = False
            '        e.ErrorText = "invalid Value"
            '    End If
            'Catch ex As Exception

            'End Try
            hitung()
        ElseIf View.FocusedColumn.FieldName = "Req. Discount" Then
            Dim price As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Req. Price"))
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
        hitung()
    End Sub

    Sub cetakLaporan(ByVal odata As DataTable)
        Dim laporan As New ReportPR
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

        laporan.lbRequestor.Text = txtReqName.Text
        laporan.lbDepartemen.Text = txtReqDept.Text
        laporan.lbRef.Text = txtEnqRef.Text
        laporan.lbPRNo.Text = DocNumberPR
        laporan.lbPRDate.Text = txtDate.Text
        laporan.lbValidUntil.Text = txtValidUntil.Text

        laporan.txtNo.DataBindings.Add("Text", Nothing, "NO")
        laporan.txtQty.DataBindings.Add("Text", Nothing, "Qty")
        laporan.txtUnit.DataBindings.Add("Text", Nothing, "UOM")
        laporan.txtUraian.DataBindings.Add("Text", Nothing, "Item Description")
        laporan.txtUnitPrice.DataBindings.Add("Text", Nothing, "Req. Price", "{0: #,#.00}")
        laporan.txtDisc.DataBindings.Add("Text", Nothing, "Req. Discount", "{0:#,#}")
        laporan.txtJumlah.DataBindings.Add("Text", Nothing, "Total", "{0:#,#.00}")
        laporan.txtCur1.Text = txtCurrency.Text
        laporan.txtCur2.Text = txtCurrency.Text



        laporan.txtSubTotalF.Text = txtTotal.Text
        laporan.txtDiscountF.Text = txtDiscount.Text
        laporan.txtGrandTotalF.Text = txtNetPrice.Text

        laporan.txtNoteF.Text = txtNote.Text

        Tool.ShowPreview()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        cetakLaporan(oDataTabelUnbound)
    End Sub

    Private Sub txtRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRate.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If FormLogin.CekAkses(FormDataPR.MenuId) > 2 Then
            btnSave.Enabled = True
            btnEdit.Enabled = False
            enable()
        Else
            MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
        End If
    End Sub
End Class