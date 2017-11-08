Imports System.ComponentModel
Imports System.Data.Odbc
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FormEnquiry
    Dim dataEnquiry As New ClassEnquiry
    Dim dataItemMD As New ClassItemMD
    Dim OdataItem As New DataTable

    Dim ItemCode(5000) As String
    Dim ItemDesc(5000) As String

    Public X As String
    Public idEnquiry As String

    Sub clean()
        setTabelUnbound()
        txtMaxResponDate.EditValue = Date.Now
        txtRef.Text = ""
        txtNote.Text = ""
        txtSourceOFCallDesc.Text = ""
        cbSourceOfCall.SelectedIndex = -1
        RepositoryItemSearchLookUpEdit1.NullText = "[Item Code]"
        txtSourceOFCallDesc.Focus()
    End Sub

    Sub enable()
        btnSave.Enabled = True
        btnPrint.Enabled = False
        cbSourceOfCall.Enabled = True
        txtSourceOFCallDesc.Enabled = True
        txtRef.Enabled = True
        txtMaxResponDate.Enabled = True
        txtNote.Enabled = True
        GridControl1.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If X = "1" Then
            dataEnquiry.addEnquiry(cbSourceOfCall.Text, txtSourceOFCallDesc.Text, txtRef.Text, Format(txtMaxResponDate.EditValue, "yyyy/MM/dd"), txtNote.Text, oDataTabelUnbound)
            clean()
        ElseIf X = "2" Then
            dataEnquiry.EditEnquiry(idEnquiry, cbSourceOfCall.Text, txtSourceOFCallDesc.Text, txtRef.Text, Format(CDate(txtMaxResponDate.EditValue), "yyyy/MM/dd"), txtNote.Text, oDataTabelUnbound)
            clean()
            Close()
        End If
        FormDataEnquiry.LoadData()
    End Sub


    Sub LoadItemtoSLU()
        OdataItem.Clear()
        OdataItem = dataItemMD.SelectItemMDMini
        RepositoryItemSearchLookUpEdit1.DataSource = OdataItem
        RepositoryItemSearchLookUpEdit1.ValueMember = "ItemCode"
        RepositoryItemSearchLookUpEdit1.DisplayMember = "ItemCode"
        ' RepositoryItemSearchLookUpEdit1.View.Columns("GenItem").Visible = False
    End Sub

    Dim oDataTabelUnbound As New DataTable
    Dim Orow As DataRow
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
            oDataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '6
            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub addNewRow(CL As String, ItemCode As String, ItemDesc As String, UOM As String, Qty As Integer, remarks As String)
        Orow = oDataTabelUnbound.NewRow()
        Orow(0) = oDataTabelUnbound.Rows.Count() + 1
        Orow(1) = CL
        Orow(2) = ItemCode
        Orow(3) = ItemDesc
        Orow(4) = UOM
        Orow(5) = Qty
        Orow(6) = remarks
        oDataTabelUnbound.Rows.Add(Orow)
    End Sub


    Sub LoadDetil()
        Dim Odata As New DataTable
        setTabelUnbound()
        Odata.Clear()
        Odata = dataEnquiry.SelectEnquiryDetilByID(idEnquiry)
        For i As Integer = 0 To Odata.Rows.Count - 1
            addNewRow(Odata.Rows(i).Item(1).ToString, Odata.Rows(i).Item(2).ToString, Odata.Rows(i).Item(3).ToString, Odata.Rows(i).Item(4).ToString, Odata.Rows(i).Item(5).ToString, Odata.Rows(i).Item(6).ToString)
        Next
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

            GridView1.Columns(0).Width = 30
            GridView1.Columns(1).Width = 100
            GridView1.Columns(2).Width = 150
            GridView1.Columns(3).Width = 250
            GridView1.Columns(4).Width = 50
            GridView1.Columns(5).Width = 100
            GridView1.Columns(6).Width = 250
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FormEnquiry_Load(sender As Object, e As EventArgs) Handles Me.Load
        If X = "1" Then
            txtDate.EditValue = Date.Now
        End If
        'txtDate.Enabled = False
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        LoadItemtoSLU()
        GridView1.Columns(2).ColumnEdit = RepositoryItemSearchLookUpEdit1
    End Sub
    Dim description As String = ""
    Dim Uom As String = ""
    Dim GenItem As String = ""

    Private Sub RepositoryItemSearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit1.EditValueChanged
        Dim a As DataRowView
        a = RepositoryItemSearchLookUpEdit1.GetRowByKeyValue(GridView1.ActiveEditor.EditValue)

        Try
            description = a.Item(1)
            Uom = a.Item(2)
            GenItem = a.Item(3)
        Catch ex As Exception
            GenItem = "0"
        End Try
    End Sub

    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Item Code" Then
            e.Value = e.Value
            Try
                If GenItem = "1" Then
                    FormPopGenItem.X = "6"
                    FormPopGenItem.ShowDialog()
                Else
                    View.GetFocusedDataRow.Item("Item Description") = description
                    View.GetFocusedDataRow.Item("UOM") = Uom
                End If

                View.GetFocusedDataRow.Item("Qty") = 0
                View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
            Catch ex As Exception
                MsgBox("Please check Item code", vbInformation, "Warning")
            End Try
        End If
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Close()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If FormLogin.CekAkses(FormDataEnquiry.MenuId) > 2 Then
            btnSave.Enabled = True
            btnEdit.Enabled = False
            enable()
        Else
            MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
        End If
    End Sub

    Sub cetakLaporan(ByVal odata As DataTable)
        Dim laporan As New ReportEnqiry
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


        laporan.lbENNo.Text = idEnquiry
        laporan.lbDate.Text = txtDate.Text
        laporan.lbValidUntil.Text = txtMaxResponDate.Text
        laporan.lbRef.Text = txtRef.Text
        laporan.lbSourceofCall.Text = cbSourceOfCall.Text
        laporan.lbSourceofCall2.Text = txtSourceOFCallDesc.Text

        laporan.txtNo.DataBindings.Add("Text", Nothing, "NO")
        laporan.txtQty.DataBindings.Add("Text", Nothing, "Qty")
        laporan.txtUnit.DataBindings.Add("Text", Nothing, "UOM")
        laporan.txtUraian.DataBindings.Add("Text", Nothing, "Item Description")
        'laporan.txtUnitPrice.DataBindings.Add("Text", Nothing, "C/L")
        laporan.txtCL.DataBindings.Add("Text", Nothing, "C/L")
        laporan.txtRemarks.DataBindings.Add("Text", Nothing, "Remarks")
        'laporan.txtCur1.Text = txtCurrency.Text
        'laporan.txtCur2.Text = txtCurrency.Text


        laporan.txtNote.Text = txtNote.Text

        Tool.ShowPreview()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        cetakLaporan(oDataTabelUnbound)
    End Sub
End Class