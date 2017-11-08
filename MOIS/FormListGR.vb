Public Class FormListGR
    Dim dataGR As New ClassGR
    Dim OdataGr As New DataTable

    Public MenuId As Integer = 12

    Sub loadGR()
        OdataGr.Clear()
        OdataGr = dataGR.selectDataGR(1, 0)
        BindingSource1.DataSource = OdataGr
        setGrid()
    End Sub

    Sub setGrid()
        Try
            GridView1.OptionsBehavior.Editable = False
            GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormListGR_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadGR()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim Odata As New DataTable
        Dim QtyGR As String
        Odata.Clear()
        Odata = dataGR.SelectDetilGRForAP(GridView1.GetFocusedDataRow.Item(0))

        For i = 0 To Odata.Rows.Count - 1
            QtyGR = Odata.Rows(i).Item(5).ToString
            If QtyGR = "" Then
                FormAddVendorInvoice.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(9), 0, "", 0, 0, Odata.Rows(i).Item(8), GridView1.GetFocusedDataRow.Item(0), Odata.Rows(i).Item(9))
            ElseIf CInt(QtyGR) > 0 Then
                FormAddVendorInvoice.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(9) - CInt(QtyGR), 0, "", 0, 0, Odata.Rows(i).Item(8), GridView1.GetFocusedDataRow.Item(0), Odata.Rows(i).Item(9) - CInt(QtyGR))
            End If
        Next
        FormAddVendorInvoice.txtRef.Text = GridView1.GetFocusedDataRow.Item("Refrence")
        FormAddVendorInvoice.txtRef.Enabled = False
        FormAddVendorInvoice.txtNote.Text = GridView1.GetFocusedDataRow.Item("Note")
        FormAddVendorInvoice.formatAngka()
        FormAddVendorInvoice.btnConvert.Enabled = False
        Close()
    End Sub
End Class