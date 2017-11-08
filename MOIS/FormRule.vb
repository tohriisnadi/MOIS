Public Class FormRule
    Dim dataRole As New ClassRule
    Dim odatarole As New DataTable

    Dim oDataTabelUnbound As New DataTable
    Dim orow As DataRow

    Sub LoadAkses()
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = dataRole.SelectMenuAktif
        For i = 0 To Odata.Rows.Count - 1
            addNewRow(Odata.Rows(i).Item(0), Odata.Rows(i).Item(1), "0", "0", "0")
        Next
    End Sub

    Sub clean()
        oDataTabelUnbound.Clear()
    End Sub
    Sub setTabelUnbound()
        Try
            oDataTabelUnbound.Rows.Clear()
            oDataTabelUnbound.Columns.Clear()
            oDataTabelUnbound.Clear()
            oDataTabelUnbound.Columns.Add(New DataColumn("Menu Id", GetType(String))) '0
            oDataTabelUnbound.Columns.Add(New DataColumn("Menu", GetType(String))) '1
            oDataTabelUnbound.Columns.Add(New DataColumn("View", GetType(String))) '2
            oDataTabelUnbound.Columns.Add(New DataColumn("Insert", GetType(String))) '3
            oDataTabelUnbound.Columns.Add(New DataColumn("Update", GetType(String))) '4
            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(MenuId As String, Menu As String, View As String, Insert As String, Update As String)
        orow = oDataTabelUnbound.NewRow()
        orow(0) = MenuId
        orow(1) = Menu
        orow(2) = View
        orow(3) = Insert
        orow(4) = Update
        oDataTabelUnbound.Rows.Add(orow)
    End Sub

    Private Sub FormRule_Load(sender As Object, e As EventArgs) Handles Me.Load
        setTabelUnbound()
        LoadAkses()
    End Sub

End Class