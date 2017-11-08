Public Class FormDataCompanySetup
    Dim dataSetup As New ClassCompanySetup
    Dim odataSetup As New DataTable

    Public MenuId As Integer = 7

    Sub loadData()
        odataSetup.Clear()
        odataSetup = dataSetup.SelectCompanySetup
        'GridControl1.DataSource = odataSetup
        BindingSource1.DataSource = odataSetup
    End Sub

    Sub setGrid()
        Dim imgc As New DataGridViewImageColumn

        Dim riPicEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch}

        Try
            GridView1.OptionsBehavior.Editable = False
            GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns("Logo").ColumnEdit = riPicEdit
            GridView1.RowHeight = 100
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormDataCompanySetup_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadData()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub

    Private Sub GridControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles GridControl1.MouseClick
        Try
            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
            Dim cms = New ContextMenuStrip
            Dim item1 = cms.Items.Add("New")
            Dim item2 = cms.Items.Add("Edit Data")

            item1.Tag = 1
            item2.Tag = 2

            AddHandler item1.Click, AddressOf menuChoice
            AddHandler item2.Click, AddressOf menuChoice

            cms.Show(GridControl1, e.Location)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = "1" Then
            If FormLogin.CekAkses(MenuId) > 0 Then
                FormAddCompanySetup.Clean()
                FormAddCompanySetup.X = "1"
                FormAddCompanySetup.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddCompanySetup.X = "2"
                'FormAddCompanySetup.Id = GridView1.GetFocusedDataRow.Item(0)


                FormAddCompanySetup.btnSave.Text = "Update"
                FormAddCompanySetup.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub
End Class