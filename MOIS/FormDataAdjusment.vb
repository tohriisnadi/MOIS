Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Public Class FormDataAdjusment
    Dim DataAdjustment As New ClassAdjustmentStock
    Dim odataAdjt As New DataTable

    Sub loaddata()
        odataAdjt.Clear()
        odataAdjt = DataAdjustment.SelectDataAdj()
        BindingSource1.DataSource = odataAdjt
    End Sub

    Private Sub FormDataAdjusment_Load(sender As Object, e As EventArgs) Handles Me.Load
        loaddata()
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
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FormAdjustmentStock.ShowDialog()
    End Sub
End Class