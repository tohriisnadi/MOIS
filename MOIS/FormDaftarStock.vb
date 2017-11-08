Public Class FormDaftarStock
    Public menuid As Integer = 22

    Dim dataReport As New ClassReport
    Dim oDataTabelUnbound As New DataTable
    Dim orow As DataRow

    Dim odataStok As New DataTable

    Sub setTabelUnbound()
        Try
            oDataTabelUnbound.Rows.Clear()
            oDataTabelUnbound.Columns.Clear()
            oDataTabelUnbound.Clear()
            oDataTabelUnbound.Columns.Add(New DataColumn("NO", GetType(String))) '0
            oDataTabelUnbound.Columns.Add(New DataColumn("Item Code", GetType(String))) '1
            oDataTabelUnbound.Columns.Add(New DataColumn("Description", GetType(String))) '2
            oDataTabelUnbound.Columns.Add(New DataColumn("UOM", GetType(String))) '3
            oDataTabelUnbound.Columns.Add(New DataColumn("Warehouse", GetType(String))) '4
            oDataTabelUnbound.Columns.Add(New DataColumn("Qty Awal", GetType(Integer))) '5
            oDataTabelUnbound.Columns.Add(New DataColumn("Qty In", GetType(Integer))) '6
            oDataTabelUnbound.Columns.Add(New DataColumn("Qty Out", GetType(Integer))) '7
            oDataTabelUnbound.Columns.Add(New DataColumn("Final Qty", GetType(Integer))) '8

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(ItemCode As String, Desc As String, UOM As String, Warehouse As String, QtyAwal As String, QtyIn As String, QtyOUt As String, FinalQty As String)
        orow = oDataTabelUnbound.NewRow()
        orow(0) = oDataTabelUnbound.Rows.Count() + 1
        orow(1) = ItemCode
        orow(2) = Desc
        orow(3) = UOM
        orow(4) = Warehouse
        orow(5) = QtyAwal
        orow(6) = QtyIn
        orow(7) = QtyOUt
        orow(8) = FinalQty

        oDataTabelUnbound.Rows.Add(orow)
    End Sub

    Sub setGrid()
        Try
            GridView1.OptionsBehavior.Editable = False
            GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            GridView1.OptionsView.ColumnAutoWidth = False

            For i = 0 To GridView1.Columns.Count - 1
                ' GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Next

            'For i = 0 To GridView1.Columns.Count - 1
            '    GridView1.Columns(i).BestFit()
            'Next

            GridView1.Columns(0).Width = 0.05 * FormMain.Width
            GridView1.Columns(1).Width = 0.15 * FormMain.Width
            GridView1.Columns(2).Width = 0.1 * FormMain.Width
            GridView1.Columns(3).Width = 0.15 * FormMain.Width
            GridView1.Columns(4).Width = 0.1 * FormMain.Width
            GridView1.Columns(5).Width = 0.1 * FormMain.Width
            GridView1.Columns(6).Width = 0.1 * FormMain.Width
            GridView1.Columns(7).Width = 0.1 * FormMain.Width
            GridView1.Columns(8).Width = 0.1 * FormMain.Width
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub
    Dim ODataItem As New DataTable
    Sub LoadItemDaftarStock()
        ODataItem.Clear()
        ODataItem = dataReport.SelectItemDaftarStok
        For i = 0 To ODataItem.Rows.Count - 1
            addNewRow(ODataItem.Rows(i).Item(0), ODataItem.Rows(i).Item(1), ODataItem.Rows(i).Item(2), "", 0, 0, 0, 0)
        Next
        ODataItem.Clear()
    End Sub

    Dim OdataQty As New DataTable
    Sub LoadDaftarStock()
        For i = 0 To oDataTabelUnbound.Rows.Count - 1
            OdataQty.Clear()
            OdataQty = dataReport.SelectQtyDaftarStok(oDataTabelUnbound.Rows(i).Item("Item Code"), Format(CDate(txtDate1.EditValue), "yyyy/MM/dd"), Format(CDate(txtDate2.EditValue), "yyyy/MM/dd"))
            oDataTabelUnbound.Rows(i).Item("Warehouse") = OdataQty.Rows(0).Item(1)
            oDataTabelUnbound.Rows(i).Item("Qty Awal") = OdataQty.Rows(0).Item(2)
            oDataTabelUnbound.Rows(i).Item("Qty In") = OdataQty.Rows(0).Item(3)
            oDataTabelUnbound.Rows(i).Item("Qty Out") = OdataQty.Rows(0).Item(4)
            oDataTabelUnbound.Rows(i).Item("Final Qty") = OdataQty.Rows(0).Item(5)
        Next
    End Sub

    Private Function getIndexItem(ByVal key As String)
        Dim ketemu As Boolean = False
        Dim index As String = -1
        Dim i As Integer

        For i = 0 To oDataTabelUnbound.Rows.Count - 1
            If ketemu = False And oDataTabelUnbound.Rows(i).Item(0) = key Then
                ketemu = True
                index = i
                Exit For
            End If
        Next

        Return index
    End Function

    Private Sub FormDaftarStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        setTabelUnbound()
        LoadItemDaftarStock()
        txtDate1.EditValue = Date.Now
        txtDate2.EditValue = Date.Now
    End Sub

    Private Function GetIndex(ByVal key As String)
        Dim ketemu As Boolean = False
        Dim index As String = -1
        Dim i As Integer

        For i = 0 To oDataTabelUnbound.Rows.Count - 1
            If ketemu = False And oDataTabelUnbound.Rows(i).Item(0) = key Then
                ketemu = True
                index = i
                Exit For
            End If
        Next

        Return index
    End Function

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        LoadDaftarStock()
    End Sub
End Class