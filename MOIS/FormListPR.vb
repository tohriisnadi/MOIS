Public Class FormListPR
    Dim dataPR As New ClassPR

    Dim OdataPR As New DataTable
    Public X As String = ""

    Sub LoadData()
        OdataPR.Clear()
        OdataPR = dataPR.selectDataPRForList
        BindingSource1.DataSource = OdataPR
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
            'GridView1.Columns(0).Visible = False
            GridView1.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(10).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(11).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#0,#.00"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormListPR_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim Odata As New DataTable
        If X = "1" Then
            'x=1 ==> req by form FormAddPO
            FormAddPO.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
            FormAddPO.txtStatus.Text = GridView1.GetFocusedDataRow.Item(7)
            FormAddPO.txtNote.Text = GridView1.GetFocusedDataRow.Item(8)
            Odata.Clear()
            Odata = dataPR.selectPRDetilByDocumentNumber(GridView1.GetFocusedDataRow.Item(0))
            For i = 0 To Odata.Rows.Count - 1
                If Odata.Rows(i).Item(5) > 0 Then
                    FormAddPO.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), Odata.Rows(i).Item(9), 0, Odata.Rows(i).Item(11))
                Else
                End If
            Next
            FormAddPO.btnConvert.Enabled = False
            FormAddPO.PRNumber = GridView1.GetFocusedDataRow.Item(0)
            Close()
        ElseIf X = "2" Then
            Odata.Clear()
            Odata = dataPR.selectPRDetilByDocumentNumber(GridView1.GetFocusedDataRow.Item(0))
            FormPriceList.setColumn()
            For i = 0 To Odata.Rows.Count - 1
                FormPriceList.addNewRow(Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), 0, Odata.Rows(i).Item(6), Odata.Rows(i).Item(8))
                FormPriceList.txtRefrence.Text = GridView1.GetFocusedDataRow.Item(0)
            Next
            Me.Close()
        End If
    End Sub
End Class