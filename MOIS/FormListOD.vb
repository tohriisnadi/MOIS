Public Class FormListOD
    Dim DataDelivery As New ClassDelivery
    Dim odataDelivery As New DataTable

    Sub LoadData()
        odataDelivery.Clear()
        odataDelivery = DataDelivery.selectDataDelivery(1, 0)
        BindingSource1.DataSource = odataDelivery
        setGrid()
    End Sub

    Sub setGrid()
        Try
            GridView1.OptionsBehavior.Editable = False
            GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            GridView1.OptionsView.ColumnAutoWidth = False
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            'GridView1.Columns(0).Visible = False
            GridView1.Columns(15).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(15).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(16).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(16).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(17).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(17).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(18).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(18).DisplayFormat.FormatString = "#,#.00"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormListOD_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = DataDelivery.SelectDetilbyIdMaster(GridView1.GetFocusedDataRow.Item(0))
        For i = 0 To Odata.Rows.Count - 1
            FormAddSalesBilling.addNewRow(Odata.Rows(i).Item(0), Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), Odata.Rows(i).Item(10), GridView1.GetFocusedDataRow.Item(0))
        Next
        FormAddSalesBilling.KodeCustomer = GridView1.GetFocusedDataRow.Item(1)
        FormAddSalesBilling.LoadCustomer()
        FormAddSalesBilling.DODate = GridView1.GetFocusedDataRow.Item(6)
        FormAddSalesBilling.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
        FormAddSalesBilling.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4)
        FormAddSalesBilling.txtRate.Text = GridView1.GetFocusedDataRow.Item(5)

        FormAddSalesBilling.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(9)
        FormAddSalesBilling.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10)
        FormAddSalesBilling.txtNote.Text = GridView1.GetFocusedDataRow.Item(11)
        FormAddSalesBilling.txtTotal.Text = GridView1.GetFocusedDataRow.Item(15)
        FormAddSalesBilling.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(16)
        FormAddSalesBilling.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(17)
        FormAddSalesBilling.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(18)
        FormAddSalesBilling.formatangka()
        FormAddSalesBilling.btnConvert.Enabled = False
        FormAddSalesBilling.txtRef.Enabled = False

        Me.Close()
    End Sub
End Class