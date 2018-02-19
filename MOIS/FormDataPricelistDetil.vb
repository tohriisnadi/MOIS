Public Class FormDataPricelistDetil
    Dim datapricelist As New ClassPriceList
    Dim OdataPriceL As New DataTable

    Public MenuId As Integer = 6

    Sub LoadData()
        OdataPriceL.Clear()
        OdataPriceL = datapricelist.selectPricelistdetilAll
        BindingSource1.DataSource = OdataPriceL
    End Sub

    Private Sub FormDataPricelistDetil_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
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
            GridView1.Columns(2).Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub


End Class