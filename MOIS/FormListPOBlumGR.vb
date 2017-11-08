Public Class FormListPOBlumGR
    Dim dataPO As New ClassPO
    Dim DataGR As New ClassGR
    Dim OdataPO As New DataTable

    Sub loaddata()
        OdataPO.Clear()
        OdataPO = dataPO.selectDataPOOpen
        BindingSource1.DataSource = OdataPO
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
            'GridView1.Columns(0).Visible = False
            'GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView1.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(10).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(11).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(13).DisplayFormat.FormatString = "#,#.00"

            GridView1.Columns(2).Visible = False
            GridView1.Columns(8).Visible = False
            GridView1.Columns(12).Visible = False
            GridView1.Columns(13).Visible = False
            GridView1.Columns(14).Visible = False
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormListPOBlumGR_Load(sender As Object, e As EventArgs) Handles Me.Load
        loaddata()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim Odata As New DataTable
        Dim Qtygr As String

        Dim whs As String = ""
        Odata.Clear()
        Odata = dataPO.selectPODetilByDocNumberForGR(GridView1.GetFocusedDataRow.Item(0))
        ' OdataDetilGR = DataGR.selectPODetilByDocNumber

        If FormAddGR.ckDropship.Checked = True Then whs = "DROPSHIP"


        For i = 0 To Odata.Rows.Count - 1
            Qtygr = Odata.Rows(i).Item(4).ToString
            If Qtygr = "" Then
                FormAddGR.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(7).ToString, Odata.Rows(i).Item(5), whs, 0, Odata.Rows(i).Item(6), Odata.Rows(i).Item(7).ToString)
            ElseIf CInt(Qtygr) > 0 Then
                FormAddGR.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(7) - Qtygr, Odata.Rows(i).Item(5), whs, 0, Odata.Rows(i).Item(6), Odata.Rows(i).Item(7) - Qtygr)
            End If
        Next
        FormAddGR.idvendor = GridView1.GetFocusedDataRow.Item(2)
        FormAddGR.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
        FormAddGR.txtNote.Text = GridView1.GetFocusedDataRow.Item(9)
        '        FormAddGR.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
        FormAddGR.btnConvert.Enabled = False
        FormAddGR.txtRef.Enabled = False
        Close()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub


End Class