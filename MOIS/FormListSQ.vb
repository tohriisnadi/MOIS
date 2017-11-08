Public Class FormListSQ
    Dim dataSQ As New ClassSalesQuotation
    Dim OdataSQ As New DataTable

    Public X = "1"

    Sub loadData()
        OdataSQ.Clear()
        OdataSQ = dataSQ.selectDataSalesQuotation(1, 0)
        BindingSource1.DataSource = OdataSQ
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
            GridView1.Columns(0).Visible = False
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(13).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(14).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(15).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(15).DisplayFormat.FormatString = "#,#.00"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormListSQ_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadData()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = dataSQ.SelectDetilbyIdMaster(GridView1.GetFocusedDataRow.Item(0))

        If X = "1" Then
            For i = 0 To Odata.Rows.Count - 1
                FormAddSalesOrder.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), Odata.Rows(i).Item(9), Odata.Rows(i).Item(10), GridView1.GetFocusedDataRow.Item(0))
            Next
            FormAddSalesOrder.KodeCustomer = GridView1.GetFocusedDataRow.Item(1)
            FormAddSalesOrder.LoadCustomer()
            FormAddSalesOrder.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(2)
            FormAddSalesOrder.txtRef.Text = GridView1.GetFocusedDataRow.Item(3)
            FormAddSalesOrder.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4)
            FormAddSalesOrder.txtRate.Text = GridView1.GetFocusedDataRow.Item(5)
            FormAddSalesOrder.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(9)
            FormAddSalesOrder.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10)
            FormAddSalesOrder.txtNote.Text = GridView1.GetFocusedDataRow.Item(11)
            FormAddSalesOrder.txtSalesPerson.Text = GridView1.GetFocusedDataRow.Item(8)
            FormAddSalesOrder.txtTotal.Text = GridView1.GetFocusedDataRow.Item(12)
            FormAddSalesOrder.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(13)
            FormAddSalesOrder.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(14)
            FormAddSalesOrder.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(15)
            FormAddSalesOrder.btnConvert.Enabled = False
            FormAddSalesOrder.txtRef.Enabled = False
            FormAddSalesOrder.formatangka()
            Me.Close()
        End If
    End Sub
End Class