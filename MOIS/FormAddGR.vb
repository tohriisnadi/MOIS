Imports System.Data.Odbc
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FormAddGR
    Dim DataGR As New ClassGR
    Dim Datawhs As New ClassWarehouse

    Dim ODataTabelUnbound As New DataTable
    Dim Orow As DataRow

    Public X As String
    Public DocumentNumber As String

    Dim dataItemMD As New ClassItemMD
    Dim OdataItem As New DataTable

    Dim ItemCode(5000) As String
    Dim ItemDesc(5000) As String

    Sub Clean()
        txtDeliveryNote.Text = ""
        txtBillOfLading.Text = ""
        txtRef.Text = ""
        txtShipVia.Text = ""
        txtShippingMethod.Text = ""
        txtNote.Text = ""
        txtDeliveryDate.EditValue = Date.Now
        txtDate.EditValue = Date.Now
        txtDeliveryNote.Focus()
        setTabelUnbound()
        btnConvert.Enabled = True
    End Sub


    Sub loadwhs()
        Dim odata As New DataTable
        odata.Clear()
        odata = Datawhs.SelectWarehouseMini
        RepoWhsCode.Items.Clear()
        For i As Integer = 0 To odata.Rows.Count - 1
            RepoWhsCode.Items.Add(odata.Rows(i).Item(0))
        Next
    End Sub

    Public dataPO As New ClassPO

    Private Sub FormAddGR_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtDate.EditValue = Date.Now
        txtDeliveryDate.EditValue = Date.Now
        txtDocNumber.Enabled = False
        txtDeliveryNote.Focus()

        Dim odata As New DataTable
        Try
            odata.Clear()
            odata = dataPO.SelectVendorByIdPO(txtRef.Text)
            idvendor = odata.Rows(0).Item(1)
        Catch ex As Exception

        End Try

        'btnConvert.Enabled = True
    End Sub

    Sub setTabelUnbound()
        Try
            ODataTabelUnbound.Rows.Clear()
            ODataTabelUnbound.Columns.Clear()
            ODataTabelUnbound.Clear()
            ODataTabelUnbound.Columns.Add(New DataColumn("NO", GetType(String))) '0
            ODataTabelUnbound.Columns.Add(New DataColumn("C/L", GetType(String))) '1
            ODataTabelUnbound.Columns.Add(New DataColumn("Item Code", GetType(String))) '2
            ODataTabelUnbound.Columns.Add(New DataColumn("Item Description", GetType(String))) '3
            ODataTabelUnbound.Columns.Add(New DataColumn("Qty", GetType(Integer))) '4
            ODataTabelUnbound.Columns.Add(New DataColumn("UOM", GetType(String))) '5
            ODataTabelUnbound.Columns.Add(New DataColumn("WHS", GetType(String))) '6
            ODataTabelUnbound.Columns.Add(New DataColumn("Allocation", GetType(Integer))) '7
            ODataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '8
            ODataTabelUnbound.Columns.Add(New DataColumn("Stock PO", GetType(Integer))) '9

            BindingSource1.DataSource = ODataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(CL As String, ItemCode As String, ItemDesc As String, Qty As String, UOM As String, WHS As String, Allocation As String, remark As String, QTyPO As String)
        Orow = ODataTabelUnbound.NewRow()
        Orow(0) = ODataTabelUnbound.Rows.Count() + 1
        Orow(1) = CL
        Orow(2) = ItemCode
        Orow(3) = ItemDesc
        Orow(4) = Qty
        Orow(5) = UOM
        Orow(6) = WHS
        Orow(7) = Allocation
        Orow(8) = remark
        Orow(9) = QTyPO
        ODataTabelUnbound.Rows.Add(Orow)
    End Sub

    Sub setGrid()
        Try
            GridView1.OptionsView.ColumnAutoWidth = False
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(1).OptionsColumn.AllowEdit = False
            GridView1.Columns(0).OptionsColumn.AllowEdit = False
            GridView1.Columns(2).OptionsColumn.AllowEdit = False
            GridView1.Columns(3).OptionsColumn.AllowEdit = False
            'GridView1.Columns(4).OptionsColumn.AllowEdit = False

            GridView1.Columns(0).Width = 50
            GridView1.Columns(1).Width = 50
            GridView1.Columns(2).Width = 120
            GridView1.Columns(3).Width = 189
            GridView1.Columns(4).Width = 50
            GridView1.Columns(5).Width = 150
            GridView1.Columns(6).Width = 150
            GridView1.Columns(7).Width = 150
            GridView1.Columns(8).Width = 200
            GridView1.Columns(9).Width = 20

            GridView1.Columns(9).Visible = False

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtDeliveryDate.Text = "" Then
                MsgBox("Delivery Date cannot empty", MsgBoxStyle.Information, "Please fill all field")
                txtDeliveryDate.Focus()
            ElseIf txtBillOfLading.Text = ""
                MsgBox("BIll Of Lading cannot empty", MsgBoxStyle.Information, "Please fill all field")
                txtBillOfLading.Focus()
            Else
                If X = "1" Then
                    DataGR.AddGR(Format(txtDate.EditValue, "yyyy/MM/dd"), txtDeliveryNote.Text, txtBillOfLading.Text, txtRef.Text, txtShipVia.Text, txtShippingMethod.Text,
                                 txtNote.Text, Format(txtDeliveryDate.EditValue, "yyyy/MM/dd"), ODataTabelUnbound)
                    Clean()

                End If
                FormDataGR.loadGR()

            End If
        Catch ex As Exception
            MsgBox("Terdapat kekeliruan dalam inputan anda " + vbCrLf + "Periksa Inputan anda")
        End Try

    End Sub


    Public idvendor As String = ""

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        FormListPOBlumGR.ShowDialog()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        loadwhs()
        GridView1.Columns("WHS").ColumnEdit = RepoWhsCode
    End Sub

    Dim datavendor As New ClassMasterVendor
    Sub cetakLaporan(ByVal odata As DataTable)
        Dim laporan As New ReportGR
        Dim Tool As ReportPrintTool = New ReportPrintTool(laporan)
        Dim oDataSet As New DataSet
        Dim oDataAdapter As New OdbcDataAdapter
        Dim i As Integer

        If oDataSet.Tables.Count <> 0 Then
            oDataSet.Tables.Remove("Table1")
        End If

        laporan.lbDate.Text = txtDate.Text
        Dim oDataVendor As New DataTable
        oDataVendor.Clear()
        oDataVendor = datavendor.SelectVendorByID(idvendor)
        If oDataVendor.Rows.Count > 0 Then
            laporan.lbVendor.Text = oDataVendor.Rows(0).Item("Name").ToString
            laporan.lbVendorAddress.Text = oDataVendor.Rows(0).Item("address").ToString
            laporan.lbVenFax.Text = oDataVendor.Rows(0).Item("Fax").ToString
            laporan.lbVenTelp.Text = oDataVendor.Rows(0).Item("Telp").ToString

        End If

        oDataSet.Tables.Add(odata.Copy)

        laporan.DataSource = oDataSet
        laporan.DataAdapter = oDataAdapter
        laporan.DataMember = "Table1"

        laporan.txtNo.DataBindings.Add("Text", Nothing, "NO")
        laporan.txtProductNameDesc.DataBindings.Add("Text", Nothing, "Item Description")
        laporan.txtQty.DataBindings.Add("Text", Nothing, "Qty")
        laporan.txtUnitItem.DataBindings.Add("Text", Nothing, "UOM")
        laporan.txtRemarks.DataBindings.Add("Text", Nothing, "Remarks")

        laporan.txtShipVia.Text = txtShipVia.Text
        laporan.txtShipMethod.Text = txtShippingMethod.Text
        laporan.txtYourRef.Text = txtRef.Text
        laporan.txtDeliVeryDate.Text = txtDeliveryDate.Text

        Tool.ShowPreview()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        cetakLaporan(ODataTabelUnbound)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clean()
        Close()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If FormLogin.CekAkses(FormDataGR.MenuId) > 2 Then
            btnSave.Enabled = True
            btnEdit.Enabled = False
        Else
            MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
        End If
    End Sub

    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Qty" Then
            Dim qty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Qty"))
            Dim qtymax As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Stock PO"))
            If e.Value > qtymax Then
                e.Valid = False
                e.ErrorText = "Value not more than " + qtymax.ToString
            Else
                e.Value = e.Value
            End If

        ElseIf View.FocusedColumn.FieldName = "Allocation" Then

            Dim qty As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Qty"))
            If e.Value > qty Then
                e.Valid = False
                e.ErrorText = "Value not more than " + qty.ToString
            Else
                e.Value = e.Value
            End If
        End If
    End Sub
End Class