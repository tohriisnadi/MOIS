Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.Odbc
Imports DevExpress.XtraReports.UI
Imports System.ComponentModel

Public Class FormAddPO
    Dim DataPO As New ClassPO
    Dim datavendor As New ClassMasterVendor

    Public X As String = ""
    Public DocumentNumber As String
    Public PRNumber As String
    Public Docdate As String

    Dim oDataTabelUnbound As New DataTable
    Dim Orow As DataRow

    Dim dataItemMD As New ClassItemMD
    Dim OdataItem As New DataTable

    Sub clean()
        txtDate.EditValue = Date.Now
        RbI.Checked = False
        RbE.Checked = False
        RbO.Checked = False
        txtCurrency.Text = ""
        txtNote.Text = ""
        txtRef.Text = ""
        txtDocNumber.Text = "Otomatis"
        txtStatus.SelectedIndex = -1
        cbVendor.SelectedIndex = -1
        txtTotal.Text = "0"
        txtDiscount.Text = "0"
        txtPPN.Text = "0"
        txtNetPrice.Text = "0"
        loadvendor()
        setTabelUnbound()
        formatangka()
    End Sub

    Sub enable()
        cbVendor.Enabled = True
        txtCurrency.Enabled = True
        txtCurRate.Enabled = True
        txtDiscountHead.Enabled = True
        txtStatus.Enabled = True
        txtNote.Enabled = True
        txtRef.Enabled = True
        btnConvert.Enabled = True
        RbI.Enabled = True
        RbE.Enabled = True
        RbO.Enabled = True
        GridControl1.Enabled = True
    End Sub

    Sub formatangka()
        txtTotal.Text = Format(CLng(txtTotal.Text), "###,###,##0.00")
        txtDiscount.Text = Format(CLng(txtDiscount.Text), "###,###,##0.00")
        txtNetPrice.Text = Format(CLng(txtNetPrice.Text), "###,###,##0.00")
        txtPPN.Text = Format(CLng(txtPPN.Text), "###,###,##0.00")
        txtTotal.Enabled = False
        txtDiscount.Enabled = False
        txtNetPrice.Enabled = False
        txtPPN.Enabled = False
    End Sub

    Dim vendorcode(5000) As String
    Public Kodevendor As String = ""
    Sub loadvendor()
        Dim odata As New DataTable
        odata.Clear()
        odata = datavendor.SelectMasterVendor

        cbVendor.Properties.Items.Clear()
        For i = 0 To odata.Rows.Count - 1
            cbVendor.Properties.Items.Add(odata.Rows(i).Item("Name"))
            vendorcode(i) = odata.Rows(i).Item("vendorCode")
        Next

    End Sub

    Sub LoadItemtoSLU()
        OdataItem.Clear()
        OdataItem = dataItemMD.SelectItemMDMini
        RepositoryItemSearchLookUpEdit1.DataSource = OdataItem
        RepositoryItemSearchLookUpEdit1.ValueMember = "ItemCode"
        RepositoryItemSearchLookUpEdit1.DisplayMember = "ItemCode"

        RepocbDiscountType.Items.Clear()
        RepocbDiscountType.Items.Add("Value")
        RepocbDiscountType.Items.Add("Percent")
    End Sub

    Private Sub FormAddPO_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtDocNumber.Enabled = False
        txtDate.EditValue = Date.Now
        txtDate.Enabled = False
        'btnConvert.Enabled = True
        txtStatus.SelectedIndex = 0
        loadvendor()
        If X = "2" Then
            cbVendor.SelectedIndex = Array.IndexOf(vendorcode, Kodevendor)
        End If
        formatangka()

        If X = "1" Then
            RbO.Checked = True
        End If

        RepositoryItemComboBox1.TextEditStyle = TextEditStyles.DisableTextEditor
        RepocbDiscountType.TextEditStyle = TextEditStyles.DisableTextEditor
        RepositoryItemSearchLookUpEdit1.TextEditStyle = TextEditStyles.DisableTextEditor

    End Sub

    Sub hitung()
        Dim TotalPrice As Long = 0
        Dim discount As Long = 0
        Dim NetPrice As Long = 0
        Try
            For i As Integer = 0 To oDataTabelUnbound.Rows.Count - 1
                TotalPrice = TotalPrice + (CLng(oDataTabelUnbound.Rows(i).Item("Qty") * CLng(oDataTabelUnbound.Rows(i).Item("Req. Price"))))
                'discount = discount + oDataTabelUnbound.Rows(i).Item("Req. Discount")
                NetPrice = NetPrice + oDataTabelUnbound.Rows(i).Item("Total")
                discount = (TotalPrice - NetPrice) + (NetPrice * (CLng(txtDiscountHead.Text) / 100))
            Next
            txtTotal.Text = TotalPrice.ToString
            txtDiscount.Text = discount.ToString
            If RbI.Checked = True Then
                txtPPN.Text = (CLng(txtTotal.Text) - CLng(txtDiscount.Text)) / 11
                txtNetPrice.Text = CLng(txtTotal.Text) - CLng(txtDiscount.Text) - CLng(txtPPN.Text)

            ElseIf RbE.Checked = True Then
                txtPPN.Text = (CLng(txtTotal.Text) - CLng(txtDiscount.Text)) / 10
                txtNetPrice.Text = (CLng(txtTotal.Text) - CLng(txtDiscount.Text)) '+ CLng(txtPPN.Text)
            ElseIf RbO.Checked = True Then
                txtPPN.Text = "0"
                txtNetPrice.Text = CLng(txtTotal.Text) - CLng(txtDiscount.Text)
            Else
                'MsgBox("Error calculate data, please select PPN Status", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            txtTotal.Text = "0"
            txtDiscount.Text = "0"
            txtNetPrice.Text = "0"
            txtPPN.Text = "0"
        End Try
        formatangka()
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
            oDataTabelUnbound.Columns.Add(New DataColumn("Req. Price", GetType(long))) '6
            oDataTabelUnbound.Columns.Add(New DataColumn("Discount Type", GetType(String))) '7
            oDataTabelUnbound.Columns.Add(New DataColumn("Req. Discount", GetType(Integer))) '8
            oDataTabelUnbound.Columns.Add(New DataColumn("Total", GetType(long))) '9
            oDataTabelUnbound.Columns.Add(New DataColumn("EstDelvTime", GetType(Integer))) '10
            oDataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '11
            oDataTabelUnbound.Columns.Add(New DataColumn("maxQty", GetType(String))) '12

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(CL As String, ItemCode As String, ItemDesc As String, UOM As String, Qty As Integer, ReqPrice As Long, DiscType As String, reqDisc As Long, total As Long, EstDelvTime As Integer, remark As String)
        Orow = oDataTabelUnbound.NewRow()
        Orow(0) = oDataTabelUnbound.Rows.Count() + 1
        Orow(1) = CL
        Orow(2) = ItemCode
        Orow(3) = ItemDesc
        Orow(4) = UOM
        Orow(5) = Qty
        Orow(6) = ReqPrice
        Orow(7) = DiscType
        Orow(8) = reqDisc
        Orow(9) = total
        Orow(10) = EstDelvTime
        Orow(11) = remark
        Orow(12) = Qty
        oDataTabelUnbound.Rows.Add(Orow)
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

            GridView1.Columns(0).Width = 50
            GridView1.Columns(1).Width = 50
            GridView1.Columns(2).Width = 120
            GridView1.Columns(3).Width = 189
            GridView1.Columns(4).Width = 50
            GridView1.Columns(5).Width = 50
            GridView1.Columns(6).Width = 150
            GridView1.Columns(7).Width = 80
            GridView1.Columns(8).Width = 100
            GridView1.Columns(9).Width = 150
            GridView1.Columns(10).Width = 100
            GridView1.Columns(11).Width = 200
            GridView1.Columns(12).Visible = False

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Sub LoadDetil()
        Dim Odata As New DataTable
        setTabelUnbound()
        Odata.Clear()
        Odata = DataPO.selectPODetilByDocNumber(DocumentNumber)
        For i As Integer = 0 To Odata.Rows.Count - 1
            addNewRow(Odata.Rows(i).Item(1).ToString, Odata.Rows(i).Item(2).ToString, Odata.Rows(i).Item(3).ToString, Odata.Rows(i).Item(4).ToString, Odata.Rows(i).Item(5).ToString,
                      Odata.Rows(i).Item(6).ToString, Odata.Rows(i).Item(7).ToString, Odata.Rows(i).Item(8).ToString, Odata.Rows(i).Item(9).ToString, Odata.Rows(i).Item(10).ToString, Odata.Rows(i).Item(11).ToString)
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' hitung()

        Dim PPNStatus As String = ""
        If RbI.Checked = True Then PPNStatus = "I"
        If RbE.Checked = True Then PPNStatus = "E"
        If RbO.Checked = True Then PPNStatus = "O"

        If cbVendor.Text = "" Then
            MsgBox("Vendor Code cannot empty", MsgBoxStyle.Information, "Please fill all field")
            cbVendor.Focus()
        ElseIf txtCurrency.Text = ""
            MsgBox("Currency cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
        ElseIf txtCurRate.Text = "" Or isnumeric(txtCurRate.Text) = False Then
            MsgBox("Rate cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtCurrency.Focus()
        ElseIf txtStatus.Text = ""
            MsgBox("Status cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtStatus.Focus()
        ElseIf IsNumeric(txtDiscountHead.Text) = False Or txtDiscountHead.Text = "" Then
            MsgBox("Discount format is false", MsgBoxStyle.Information, "Please fill all field")
            txtDiscount.Focus()
        Else
            If X = "1" Then
                DataPO.AddPO(Format(txtDate.EditValue, "yyyy/MM/dd"), vendorcode(cbVendor.SelectedIndex), PPNStatus, txtCurrency.Text.ToUpper, txtCurRate.Text, txtDiscountHead.Text, txtStatus.Text, txtNote.Text,
                             txtRef.Text, txtTotal.Text, txtDiscount.Text, txtPPN.Text, txtNetPrice.Text, oDataTabelUnbound, PRNumber)
                clean()
            ElseIf X = "2" Then
                DataPO.EditPO(DocumentNumber, Format(CDate(txtDate.Text), "yyyy/MM/dd"), vendorcode(cbVendor.SelectedIndex), PPNStatus, txtCurrency.Text.ToUpper, txtCurRate.Text, txtDiscountHead.Text, txtStatus.Text, txtNote.Text,
                              txtRef.Text, txtTotal.Text, txtDiscount.Text, txtPPN.Text, txtNetPrice.Text, oDataTabelUnbound, PRNumber)
                clean()
                Close()
            End If
            FormDataPO.loadData()
        End If
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        'loadItem()
        LoadItemtoSLU()
        GridView1.Columns(2).ColumnEdit = RepositoryItemSearchLookUpEdit1
        GridView1.Columns(7).ColumnEdit = RepocbDiscountType
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        FormListPR.X = "1"
        Try
            FormListPR.ShowDialog()
        Catch ex As Exception
            FormListPR.Close()
            FormListPR.ShowDialog()
        End Try
        hitung()
    End Sub

    Sub hitungDiscountItem()
        Dim price As Long
        Dim qty As Integer
        Dim disc As Long
        For i = 0 To oDataTabelUnbound.Rows.Count - 1
            price = oDataTabelUnbound.Rows(i).Item("Req. Price")
            qty = oDataTabelUnbound.Rows(i).Item("Qty")
            disc = oDataTabelUnbound.Rows(i).Item("Req. Discount")
            oDataTabelUnbound.Rows(i).Item("Total") = 0
            If oDataTabelUnbound.Rows(i).Item("Discount Type") = "Percent" Then
                oDataTabelUnbound.Rows(i).Item("Total") = (price * qty) - (CDbl(disc / 100) * (price * qty))
            ElseIf oDataTabelUnbound.Rows(i).Item("Discount Type") = "Value" Then
                oDataTabelUnbound.Rows(i).Item("Total") = (qty * (price - disc))
            End If
        Next
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

    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Item Code" Then
            e.Value = e.Value
            If genItem = "1" Then
                FormPopGenItem.X = "2"
                FormPopGenItem.ShowDialog()
            Else
                View.GetFocusedDataRow.Item("Item Description") = description
                View.GetFocusedDataRow.Item("UOM") = Uom
            End If

            View.GetFocusedDataRow.Item("Qty") = 0
            View.GetFocusedDataRow.Item("MaxQty") = 999
            View.GetFocusedDataRow.Item("Req. Price") = 0
            View.GetFocusedDataRow.Item("Discount Type") = "Percent"
            View.GetFocusedDataRow.Item("Req. Discount") = 0
            View.GetFocusedDataRow.Item("Total") = 0
            View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
            hitung()
        ElseIf View.FocusedColumn.FieldName = "Qty" Then
            Dim mqty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("MaxQty"))
            If e.Value > mqty Then
                e.Valid = False
                e.ErrorText = "Value not more than " + mqty.ToString
            Else
                e.Value = e.Value
            End If
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
            'hitung()
        ElseIf View.FocusedColumn.FieldName = "Req. Price" Then
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
            '    hitung()
            'Catch ex As Exception
            'End Try
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
        hitungDiscountItem()
        hitung()
    End Sub

    Sub cetakLaporan(ByVal odata As DataTable)
        Dim laporan As New ReportPO
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
        oDataVendor = datavendor.SelectVendorByID(Kodevendor)
        If oDataVendor.Rows.Count > 0 Then
            laporan.lbVendor.Text = oDataVendor.Rows(0).Item("Name").ToString
            laporan.lbVendorAddress.Text = oDataVendor.Rows(0).Item("address").ToString
            laporan.lbAttn.Text = oDataVendor.Rows(0).Item("ContactPerson").ToString
            laporan.lbTelp.Text = oDataVendor.Rows(0).Item("Telp").ToString

        End If

        laporan.txtNo.DataBindings.Add("Text", Nothing, "NO")
        laporan.txtQty.DataBindings.Add("Text", Nothing, "Qty")
        laporan.txtUnit.DataBindings.Add("Text", Nothing, "UOM")
        laporan.txtUraian.DataBindings.Add("Text", Nothing, "Item Description")
        laporan.txtUnitPrice.DataBindings.Add("Text", Nothing, "Req. Price", "{0:#,#.00}")
        laporan.txtDisc.DataBindings.Add("Text", Nothing, "Req. Discount", "{0:#,#}")
        laporan.txtJumlah.DataBindings.Add("Text", Nothing, "Total", "{0:#,#.00}")
        laporan.txtCur1.Text = txtCurrency.Text
        laporan.txtCur2.Text = txtCurrency.Text


        laporan.lbCurrency.Text = txtCurrency.Text
        laporan.lbKurs.Text = txtCurRate.Text

        'Dim dpp As Long = CLng(txtNetPrice.Text) - CLng(txtDiscount.Text)
        laporan.txtSubTotalF.Text = Format(CLng(txtTotal.Text), "###,###,##0.00")
        laporan.txtDiscountF.Text = Format(CLng(txtDiscount.Text), "###,###,##0.00")
        laporan.txtVATIncF.Text = Format(CLng(txtPPN.Text), "###,###,##0.00")
        laporan.txtDPPF.Text = Format(CLng(txtNetPrice.Text), "###,###,##0.00")
        laporan.txtVAT10F.Text = Format(CLng(txtPPN.Text), "###,###,##0.00")
        laporan.txtGrandTotalF.Text = Format(CLng(txtNetPrice.Text + CLng(txtPPN.Text)), "###,###,##0.00")

        If X = "1" Then
            laporan.lbPODate.Text = txtDate.Text
        Else
            laporan.lbPODate.Text = Docdate
        End If
        laporan.lbPONo.Text = DocumentNumber

        If RbI.Checked = True Then
            laporan.lbVATStatus.Text = "Include"
        ElseIf RbE.Checked = True
            laporan.lbVATStatus.Text = "Exclude"
        Else
            laporan.lbVATStatus.Text = "N/A"
        End If

        laporan.txtNoteF.Text = txtNote.Text

        Tool.ShowPreview()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        cetakLaporan(oDataTabelUnbound)
    End Sub

    Public Function Terbilang(ByVal nilai As Long) As String
        Dim bilangan As String() = {" ", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"}
        If nilai < 12 Then
            Return " " & bilangan(nilai)
        ElseIf nilai < 20 Then
            Return Terbilang(nilai - 10) & " Belas"
        ElseIf nilai < 100 Then
            Return (Terbilang(CInt((nilai \ 10))) & " Puluh") + Terbilang(nilai Mod 10)
        ElseIf nilai < 200 Then
            Return " Seratus" & Terbilang(nilai - 100)
        ElseIf nilai < 1000 Then
            Return (Terbilang(CInt((nilai \ 100))) & " Ratus") + Terbilang(nilai Mod 100)
        ElseIf nilai < 2000 Then
            Return " Seribu" & Terbilang(nilai - 1000)
        ElseIf nilai < 1000000 Then
            Return (Terbilang(CInt((nilai \ 1000))) & " Ribu") + Terbilang(nilai Mod 1000)
        ElseIf nilai < 1000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000))) & " Juta") + Terbilang(nilai Mod 1000000)
        ElseIf nilai < 1000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000))) & " Milyar") + Terbilang(nilai Mod 1000000000)
        ElseIf nilai < 1000000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000000))) & " Trilyun") + Terbilang(nilai Mod 1000000000000)
        Else
            Return ""
        End If
    End Function

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If FormLogin.CekAkses(FormDataPO.MenuId) > 2 Then
            btnSave.Enabled = True
            btnEdit.Enabled = False
            enable()
        Else
            MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
        End If
    End Sub

    Private Sub txtDiscountHead_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscountHead.KeyDown
        If e.KeyCode = Keys.Enter Then
            hitung()
        End If
    End Sub

    Private Sub RbI_CheckedChanged(sender As Object, e As EventArgs) Handles RbI.CheckedChanged
        hitung()
    End Sub

    Private Sub RbO_CheckedChanged(sender As Object, e As EventArgs) Handles RbO.CheckedChanged
        hitung()
    End Sub

    Private Sub RbE_CheckedChanged(sender As Object, e As EventArgs) Handles RbE.CheckedChanged
        hitung()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FormAddMasterVendor.ShowDialog()
        loadvendor()
    End Sub
End Class