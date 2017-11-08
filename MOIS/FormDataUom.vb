Public Class FormDataUom
    Dim DataUom As New ClassUom
    Dim OdataUom As New DataTable
    Public MenuId As Integer = 2

    Sub loadData()
        OdataUom.Clear()
        OdataUom = DataUom.SelectUom()
        BindingSource1.DataSource = OdataUom
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

    Private Sub FormDataUom_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            Dim item3 = cms.Items.Add("Delete")
            Dim item4 = cms.Items.Add("Refresh")

            item1.Tag = 1
            item2.Tag = 2
            item3.Tag = 3
            item4.Tag = 4

            AddHandler item1.Click, AddressOf menuChoice
            AddHandler item2.Click, AddressOf menuChoice
            AddHandler item3.Click, AddressOf menuChoice
            AddHandler item4.Click, AddressOf menuChoice

            cms.Show(GridControl1, e.Location)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = "1" Then
            If FormLogin.CekAkses(MenuId) > 0 Then
                FormAddUom.X = "1"
                FormAddUom.btnSave.Text = "Save"
                FormAddUom.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddUom.X = "2"
                FormAddUom.idUom = GridView1.GetFocusedDataRow().Item(0).ToString
                FormAddUom.txtUomCode.Text = GridView1.GetFocusedDataRow().Item(1).ToString
                FormAddUom.txtDesc.Text = GridView1.GetFocusedDataRow().Item(2).ToString
                FormAddUom.txtNote.Text = GridView1.GetFocusedDataRow().Item(3).ToString
                FormAddUom.btnSave.Text = "Update"
                FormAddUom.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    DataUom.NonAktifUom(GridView1.GetFocusedDataRow().Item(0))
                    loadData()
                End If
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "4" Then
            loadData()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        loadData()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim opf As New SaveFileDialog() With {.Filter = "Excel File|*.xlsx"}
        If opf.ShowDialog(Me) = DialogResult.OK Then
            GridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xlsx, opf.FileName)
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim opf As New SaveFileDialog() With {.Filter = "PDF File|*.pdf"}
        If opf.ShowDialog(Me) = DialogResult.OK Then
            GridView1.Export(DevExpress.XtraPrinting.ExportTarget.Pdf, opf.FileName)
        End If
    End Sub
End Class