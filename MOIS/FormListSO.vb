Public Class FormListSO
    Dim DataSO As New ClassSalesOrder
    Dim OdatSO As New DataTable
    Public MenuId As Integer = 14
    Public X As String = ""

    Sub loadData()
        OdatSO.Clear()
        OdatSO = DataSO.selectDataSalesOrder(1, 0)
        BindingSource1.DataSource = OdatSO
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
            GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(13).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(14).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(15).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(15).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(16).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(16).DisplayFormat.FormatString = "#,#.00"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormListSO_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadData()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = DataSO.SelectDetilbyIdMaster(GridView1.GetFocusedDataRow.Item(0))

        If X = "1" Then
            'X=1 req by form add delivery
            For i = 0 To Odata.Rows.Count - 1
                FormAddDelivery.addNewRow(Odata.Rows(i).Item(0), Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), "", Odata.Rows(i).Item(9), GridView1.GetFocusedDataRow.Item(0))
            Next
            FormAddDelivery.KodeCustomer = GridView1.GetFocusedDataRow.Item(1)
            FormAddDelivery.LoadCustomer()
            FormAddDelivery.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(2)
            FormAddDelivery.txtRef.Text = GridView1.GetFocusedDataRow.Item(3)
            FormAddDelivery.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4)
            FormAddDelivery.txtRate.Text = GridView1.GetFocusedDataRow.Item(5)

            FormAddDelivery.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(9)
            FormAddDelivery.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10)
            FormAddDelivery.txtNote.Text = GridView1.GetFocusedDataRow.Item(11)
            FormAddDelivery.txtSalesPerson.Text = GridView1.GetFocusedDataRow.Item(8)
            FormAddDelivery.txtTotal.Text = GridView1.GetFocusedDataRow.Item(13)
            FormAddDelivery.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(14)
            FormAddDelivery.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(15)
            FormAddDelivery.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(16)
            FormAddDelivery.formatangka()
            FormAddDelivery.btnConvert.Enabled = False
            FormAddDelivery.txtRef.Enabled = False
            Me.Close()
        ElseIf X = "2" Then
            For i = 0 To Odata.Rows.Count - 1
                FormAddSalesBilling.addNewRow(Odata.Rows(i).Item(0), Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), Odata.Rows(i).Item(9), GridView1.GetFocusedDataRow.Item(0))
            Next
            FormAddSalesBilling.cbCust.Text = GridView1.GetFocusedDataRow.Item(1)
            'FormAddSalesBilling.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(2)
            FormAddSalesBilling.txtRef.Text = GridView1.GetFocusedDataRow.Item(3)
            FormAddSalesBilling.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4)
            FormAddSalesBilling.txtRate.Text = GridView1.GetFocusedDataRow.Item(5)

            FormAddSalesBilling.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(9)
            FormAddSalesBilling.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10)
            FormAddSalesBilling.txtNote.Text = GridView1.GetFocusedDataRow.Item(11)
            FormAddSalesBilling.txtTotal.Text = GridView1.GetFocusedDataRow.Item(13)
            FormAddSalesBilling.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(14)
            FormAddSalesBilling.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(15)
            FormAddSalesBilling.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(16)
            FormAddSalesBilling.formatangka()
            FormAddSalesBilling.btnConvert.Enabled = False
            FormAddSalesBilling.txtRef.Enabled = False
            Me.Close()
        End If
    End Sub
End Class