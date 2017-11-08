Public Class FormListPriceList
    Dim dataPricelist As New ClassPriceList
    Dim odatapricelist As New DataTable

    Public itemcode As String = ""
    Public rowin As Integer

    Sub loadData()
        odatapricelist.Clear()
        odatapricelist = dataPricelist.selectpricelistbyItemCode(itemcode)
        BindingSource1.DataSource = odatapricelist
    End Sub

    Private Sub FormListPriceList_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbItemCode.Text = itemcode
        lbIndex.Text = rowin
        Try
            loadData()
            LbDescription.Text = odatapricelist.Rows(0).Item(1)
        Catch ex As Exception

        End Try
    End Sub

    Sub setGrid()
        Try
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsBehavior.Editable = False
            GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(0).Visible = False
            GridView1.Columns(1).Visible = False
            GridView1.Columns(2).Visible = False
            GridView1.Columns(3).Visible = False

            GridView1.Columns("PricePerQty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("PricePerQty").DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns("Discount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("Discount").DisplayFormat.FormatString = "#"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            FormAddSalesQuotation.GridView1.GetFocusedDataRow.Item("Qty") = GridView1.GetFocusedDataRow.Item("MinQty")
            FormAddSalesQuotation.GridView1.GetFocusedDataRow.Item("Unit Price") = GridView1.GetFocusedDataRow.Item("PricePerQty")
            FormAddSalesQuotation.GridView1.GetFocusedDataRow.Item("Discount") = GridView1.GetFocusedDataRow.Item("Discount")
        Catch ex As Exception
            MsgBox("Failed Load price list to data, please contact your programmer", MsgBoxStyle.Information, "information")
        End Try
        Close()
    End Sub
End Class