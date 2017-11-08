Public Class FormKartuStock
    Public menuid As Integer = 23

    Dim oDataTabelUnbound As New DataTable
    Dim orow As DataRow

    Dim DataReport As New ClassReport

    Dim DataItem As New ClassItemMD
    Dim DataWhs As New ClassWarehouse

    Sub clean()
        setTabelUnbound()
        txtItemCode.Text = ""
        txtDesc.Text = ""
        txtWhs.Text = ""
        txtDate1.EditValue = Date.Now
        txtDate2.EditValue = Date.Now
        LoadItem()
        LoadWhs()
        txtItemCode.Focus()
    End Sub

    Sub setTabelUnbound()
        Try
            oDataTabelUnbound.Rows.Clear()
            oDataTabelUnbound.Columns.Clear()
            oDataTabelUnbound.Clear()
            oDataTabelUnbound.Columns.Add(New DataColumn("NO", GetType(String))) '0
            oDataTabelUnbound.Columns.Add(New DataColumn("Document Number", GetType(String))) '1
            oDataTabelUnbound.Columns.Add(New DataColumn("Date", GetType(String))) '2
            oDataTabelUnbound.Columns.Add(New DataColumn("Qty In", GetType(Integer))) '3
            oDataTabelUnbound.Columns.Add(New DataColumn("Qty Out", GetType(Integer))) '4

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(DocNumber As String, DocDate As String, QtyIn As String, QtyOUt As String)
        orow = oDataTabelUnbound.NewRow()
        orow(0) = oDataTabelUnbound.Rows.Count() + 1
        orow(1) = DocNumber
        orow(2) = DocDate
        orow(3) = QtyIn
        orow(4) = QtyOUt
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

            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).BestFit()
            Next

            'GridView1.Columns(0).Width = 0.05 * FormMain.Width
            'GridView1.Columns(1).Width = 0.15 * FormMain.Width
            'GridView1.Columns(2).Width = 0.1 * FormMain.Width
            'GridView1.Columns(3).Width = 0.15 * FormMain.Width
            'GridView1.Columns(4).Width = 0.1 * FormMain.Width
            'GridView1.Columns(5).Width = 0.1 * FormMain.Width
            'GridView1.Columns(6).Width = 0.1 * FormMain.Width
            'GridView1.Columns(7).Width = 0.1 * FormMain.Width
            'GridView1.Columns(8).Width = 0.1 * FormMain.Width
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub

    Dim OdataQty As New DataTable

    Sub SetKartuStok()
        Dim odataStockAwal As New DataTable
        Dim stokawal As Integer
        Dim QtyIn As Integer = 0
        Dim QtyOut As Integer = 0
        Dim QtyAkhir As Integer = 0
        odataStockAwal.Clear()
        odataStockAwal = DataReport.SelectKartuStokQtyAwal(txtItemCode.Text, WhsCode(txtWhs.SelectedIndex), Format(CDate(txtDate1.EditValue), "yyyy/MM/dd"))

        OdataQty.Clear()
        OdataQty = DataReport.SelectQtyKartuStock(txtItemCode.Text, WhsCode(txtWhs.SelectedIndex), Format(CDate(txtDate1.EditValue), "yyyy/MM/dd"), Format(CDate(txtDate2.EditValue), "yyyy/MM/dd"))

        stokawal = odataStockAwal.Rows(0).Item(0)

        If stokawal < 0 Then
            addNewRow("Quantity Awal", "", 0, stokawal)
        Else
            addNewRow("Quantity Awal", "", stokawal, 0)
        End If

        If OdataQty.Rows.Count > 0 Then
            For i = 0 To OdataQty.Rows.Count - 1
                addNewRow(OdataQty.Rows(i).Item(0), OdataQty.Rows(i).Item(1), OdataQty.Rows(i).Item(6), 0)
                If OdataQty.Rows(i).Item(2).ToString <> "" Then
                    addNewRow(OdataQty.Rows(i).Item(2), OdataQty.Rows(i).Item(3), 0, OdataQty.Rows(i).Item(7))
                End If
            Next
        End If

        For x = 0 To oDataTabelUnbound.Rows.Count - 1
            QtyIn = QtyIn + CInt(oDataTabelUnbound.Rows(x).Item("Qty In"))
            QtyOut = QtyOut + CInt(oDataTabelUnbound.Rows(x).Item("Qty Out"))
        Next
        QtyAkhir = QtyIn - QtyOut
        If QtyAkhir < 0 Then
            addNewRow("Quantity Akhir", "", 0, QtyAkhir)
        Else
            addNewRow("Quantity Akhir", "", QtyAkhir, 0)
        End If

    End Sub

    Private Sub FormKartuStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        clean()

    End Sub

    Dim OdataItem As New DataTable
    Sub LoadItem()
        OdataItem.Clear()
        OdataItem = DataItem.SelectItemMDMini
        FormListItem.BindingSource1.DataSource = OdataItem
    End Sub

    Dim OdataWhs As New DataTable
    Dim WhsCode(100) As String
    Sub LoadWhs()
        OdataWhs.Clear()
        OdataWhs = DataWhs.SelectWarehouseMini
        txtWhs.Properties.Items.Clear()
        For i = 0 To OdataWhs.Rows.Count - 1
            txtWhs.Properties.Items.Add(OdataWhs.Rows(i).Item(1))
            WhsCode(i) = OdataWhs.Rows(i).Item(0)
        Next
        txtWhs.SelectedIndex = 0
    End Sub

    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormListItem.X = "1"
            FormListItem.ShowDialog()
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        oDataTabelUnbound.Clear()
        SetKartuStok()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub
End Class