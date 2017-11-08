Public Class FormManageOperator
    Dim dataOperator As New ClassOperator
    Dim dataRole As New ClassRule

    Public MenuId As Integer = 0

    Dim OdataOperator As New DataTable
    Dim OdataRole As New DataTable
    Dim OdataPermission As New DataTable

    Dim RoleId(100) As String

    Private Sub btnOperator_Click(sender As Object, e As EventArgs) Handles btnOperator.Click
        XtraTabControl1.SelectedTabPageIndex = 0
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        XtraTabControl1.SelectedTabPageIndex = 1
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        XtraTabControl1.SelectedTabPageIndex = 2
        setTabelUnbound()
        LoadAksesAwal()
        LoadRolecbRule()
    End Sub

    Sub loadDataOperator()
        OdataOperator.Clear()
        OdataOperator = dataOperator.SelectAllOperator
        BindingSource1.DataSource = OdataOperator
        setGrid1()
    End Sub

    Sub setGrid1()
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
            GridView1.Columns(2).Visible = False
            GridView1.Columns(4).Visible = False
            'GridView1.Columns(6).Visible = False
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Sub loadDataRole()
        OdataRole.Clear()
        OdataRole = dataRole.SelectRuleAktif
        BindingSource2.DataSource = OdataRole
        setGrid2()
    End Sub

    Sub setGrid2()
        Try
            GridView2.OptionsBehavior.Editable = False
            GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            GridView2.OptionsView.ColumnAutoWidth = False
            For i = 0 To GridView2.Columns.Count - 1
                GridView2.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView2.Columns(i).BestFit()
            Next
            GridView2.Columns(0).Visible = False
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Sub loadDataPermissions()
        OdataPermission.Clear()
    End Sub

    Private Sub FormManageOperator_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadDataOperator()
        loadDataRole()
        loadDataPermissions()
    End Sub

    Dim oDataTabelUnbound As New DataTable
    Dim orow As DataRow

    Sub LoadRolecbRule()
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = dataRole.SelectRuleAktif()
        cbbRule.Properties.Items.Clear()
        For i = 0 To Odata.Rows.Count - 1
            RoleId(i) = Odata.Rows(i).Item(0)
            cbbRule.Properties.Items.Add(Odata.Rows(i).Item(1))
        Next
        cbbRule.SelectedIndex = -1
    End Sub

    Sub LoadAksesAwal()
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = dataRole.SelectMenuAktif
        oDataTabelUnbound.Clear()

        For I = 0 To Odata.Rows.Count - 1
            addNewRow(Odata.Rows(I).Item(0), Odata.Rows(I).Item(1), "0", "0", "0")
        Next
    End Sub

    Sub LoadAksesByRoleid(RoleId As String)
        Dim odata As New DataTable
        Dim View, Insert, Update As String
        odata.Clear()
        odata = dataRole.SelectAksesRolebyRoleId(RoleId)
        If odata.Rows.Count < 1 Then
            LoadAksesAwal()
        Else
            oDataTabelUnbound.Clear()
            For i = 0 To odata.Rows.Count - 1
                View = "0"
                Insert = "0"
                Update = "0"
                If odata.Rows(i).Item(5) = "1" Then
                    View = "1"
                    Insert = "0"
                    Update = "0"
                ElseIf odata.Rows(i).Item(5) = "2" Then
                    View = "1"
                    Insert = "1"
                    Update = "0"
                ElseIf odata.Rows(i).Item(5) = "4" Then
                    View = "1"
                    Insert = "1"
                    Update = "1"
                End If
                addNewRow(odata.Rows(i).Item(0), odata.Rows(i).Item(1), View, Insert, Update)
            Next
        End If
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
            BindingSource3.DataSource = oDataTabelUnbound
            GridView3.Columns(2).ColumnEdit = RepoCbView
            GridView3.Columns(3).ColumnEdit = RepoCbInsert
            GridView3.Columns(4).ColumnEdit = RepoCbUpdate
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

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim idRoleAktif As String = ""
        Try
            idRoleAktif = RoleId(cbbRule.SelectedIndex)
        Catch ex As Exception
            idRoleAktif = ""
        End Try
        If idRoleAktif = "" Then
            MsgBox("Please Select Role", MsgBoxStyle.Critical, "Error")
        Else
            If MsgBox("Role is " + cbbRule.SelectedItem + vbCrLf, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                dataRole.addRoleDetils(idRoleAktif, oDataTabelUnbound)
            End If
        End If
    End Sub

    Private Sub cbbRule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbRule.SelectedIndexChanged
        LoadAksesByRoleid(RoleId(cbbRule.SelectedIndex))
    End Sub


End Class