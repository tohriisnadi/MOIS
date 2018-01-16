Public Class FormListItem
    Dim Odata As New DataTable
    Public X As String = ""

    Sub setGrid()
        Try
            GridView1.OptionsBehavior.Editable = False
            GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Next

            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).BestFit()
            Next

            'GridView1.Columns(2).Visible = False

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If X = "1" Then
            FormKartuStock.txtItemCode.Text = GridView1.GetFocusedDataRow.Item(0)
            FormKartuStock.txtDesc.Text = GridView1.GetFocusedDataRow.Item(1)
        ElseIf X = "2"
            FormPriceList.GridView1.GetFocusedDataRow.Item("Item Code") = GridView1.GetFocusedDataRow.Item("ItemCode")
            FormPriceList.GridView1.GetFocusedDataRow.Item("Item Description") = GridView1.GetFocusedDataRow.Item("Description1")
            FormPriceList.GridView1.GetFocusedDataRow.Item("Min Qty") = 0
            FormPriceList.GridView1.GetFocusedDataRow.Item("Price / Qty") = 0
            FormPriceList.GridView1.GetFocusedDataRow.Item("Discount") = 0
        End If
        Close()
    End Sub
End Class