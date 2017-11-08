Imports System.ComponentModel

Public Class FormChoseRekening
    Dim datarekening As New ClassRekening
    Dim ODataRekening As New DataTable

    Public X As String = ""

    Sub loadRekening()
        ODataRekening.Clear()
        ODataRekening = datarekening.SelectRekening
        BindingSource1.DataSource = ODataRekening
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
            GridView1.Columns(0).Visible = False
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FormChoseRekening_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadRekening()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If X = "1" Then
            FormAddSalesOrder.OdataRek = GridView1.GetFocusedDataRow
        ElseIf X = "2" Then
            FormAddSalesBilling.OdataRek = GridView1.GetFocusedDataRow
        End If
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        MsgBox("Please Chose Rekening", vbInformation + vbOK, "Information")
    End Sub
End Class