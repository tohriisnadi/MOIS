Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class FormAdjustmentStock
    Public menuid As Integer = 21
    Dim DataAdjustment As New ClassAdjustmentStock
    Dim Datawhs As New ClassWarehouse
    Dim dataItemMD As New ClassItemMD
    Dim OdataItem As New DataTable

    Dim oDataTabelUnbound As New DataTable
    Dim Orow As DataRow

    Sub clean()
        txtDate.EditValue = Date.Now
        txtApproveBy.Text = ""
        txtCountBy.Text = ""
        txtReference.Text = ""
        txtNote.Text = ""
        setTabelUnbound()
        txtDate.Focus()
    End Sub

    Sub setTabelUnbound()
        Try
            oDataTabelUnbound.Rows.Clear()
            oDataTabelUnbound.Columns.Clear()
            oDataTabelUnbound.Clear()
            oDataTabelUnbound.Columns.Add(New DataColumn("NO", GetType(String))) '0
            oDataTabelUnbound.Columns.Add(New DataColumn("Item Code", GetType(String))) '1
            oDataTabelUnbound.Columns.Add(New DataColumn("Description", GetType(String))) '2
            oDataTabelUnbound.Columns.Add(New DataColumn("Uom", GetType(String))) '3
            oDataTabelUnbound.Columns.Add(New DataColumn("WHS", GetType(String))) '4
            oDataTabelUnbound.Columns.Add(New DataColumn("Qty", GetType(Integer))) '5
            oDataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '6

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub setGrid()
        Try
            'GridView1.OptionsView.ColumnAutoWidth = False
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            'GridView1.Columns(1).OptionsColumn.AllowEdit = False
            GridView1.Columns(0).OptionsColumn.AllowEdit = False
            GridView1.Columns(2).OptionsColumn.AllowEdit = False
            GridView1.Columns(3).OptionsColumn.AllowEdit = False
            'GridView1.Columns(4).OptionsColumn.AllowEdit = False

            GridView1.Columns(0).Width = 50
            GridView1.Columns(1).Width = 100
            GridView1.Columns(2).Width = 120
            GridView1.Columns(3).Width = 50
            GridView1.Columns(4).Width = 50
            GridView1.Columns(5).Width = 50
            GridView1.Columns(6).Width = 150

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormAdjustmentStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        setTabelUnbound()
        clean()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If rbAdjIn.Checked = True Then
            DataAdjustment.AddAdjustmentIn(Format(CDate(txtDate.EditValue), "yyyy/MM/dd"), "Adjusment In", txtCountBy.Text, txtApproveBy.Text, txtReference.Text, txtNote.Text, oDataTabelUnbound)
        ElseIf rbAdjOut.Checked = True Then
            DataAdjustment.AddAdjustmentOut(Format(CDate(txtDate.EditValue), "yyyy/MM/dd"), "Adjusment Out", txtCountBy.Text, txtApproveBy.Text, txtReference.Text, txtNote.Text, oDataTabelUnbound)
        End If
        clean()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        loadwhs()
        GridView1.Columns("WHS").ColumnEdit = RepocbWHS
        LoadItemtoSLU()
        GridView1.Columns("Item Code").ColumnEdit = RepositoryItemSearchLookUpEdit1
    End Sub

    Sub loadwhs()
        Dim odata As New DataTable
        odata.Clear()
        odata = Datawhs.SelectWarehouseMini
        RepocbWHS.Items.Clear()
        For i As Integer = 0 To odata.Rows.Count - 1
            RepocbWHS.Items.Add(odata.Rows(i).Item(0))
        Next

    End Sub

    Sub LoadItemtoSLU()
        OdataItem.Clear()
        OdataItem = dataItemMD.SelectItemMDMini
        RepositoryItemSearchLookUpEdit1.DataSource = OdataItem
        RepositoryItemSearchLookUpEdit1.ValueMember = "ItemCode"
        RepositoryItemSearchLookUpEdit1.DisplayMember = "ItemCode"

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
                FormPopGenItem.X = "7"
                FormPopGenItem.ShowDialog()
            Else
                View.GetFocusedDataRow.Item("Description") = description
                View.GetFocusedDataRow.Item("UOM") = Uom
            End If
            View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub
End Class