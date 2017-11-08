Public Class FormDataWarehouse

    Public MenuId As Integer = 1
    Dim DataWarehouse As New ClassWarehouse
    Dim odataWarehouse As New DataTable

    Public Sub loadData()
        odataWarehouse.Clear()
        odataWarehouse = DataWarehouse.SelectWarehouse
        BindingSource1.DataSource = odataWarehouse
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

    Private Sub FormDataWarehouse_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                FormAddWarehouse.clean()
                FormAddWarehouse.X = "1"
                FormAddWarehouse.clean()
                FormAddWarehouse.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddWarehouse.X = "2"
                FormAddWarehouse.txtWhsCode.Text = GridView1.GetFocusedDataRow.Item(1).ToString
                FormAddWarehouse.txtWhsDesc.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddWarehouse.txtAddress.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddWarehouse.txtCity.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddWarehouse.txtCountry.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddWarehouse.txtZipCode.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddWarehouse.txtContact.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddWarehouse.txtPhone.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddWarehouse.txtFax.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                If GridView1.GetFocusedDataRow.Item(10) = "1" Then
                    FormAddWarehouse.ckInactive.Checked = True
                Else
                    FormAddWarehouse.ckInactive.Checked = False
                End If
                FormAddWarehouse.IdWhs = GridView1.GetFocusedDataRow.Item(0)
                FormAddWarehouse.btnSave.Text = "Update"
                FormAddWarehouse.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        loadData()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        If SaveFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            GridView1.ExportToXlsx(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
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