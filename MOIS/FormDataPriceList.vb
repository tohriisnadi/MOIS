Public Class FormDataPriceList
    Dim datapricelist As New ClassPriceList
    Dim OdataPriceL As New DataTable

    Public MenuId As Integer = 6

    Sub LoadData()
        OdataPriceL.Clear()
        OdataPriceL = datapricelist.SelectPriceList
        BindingSource1.DataSource = OdataPriceL
    End Sub

    Private Sub FormDataPriceList_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles GridControl1.MouseClick
        Try
            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
            Dim cms = New ContextMenuStrip
            Dim item1 = cms.Items.Add("Create")
            Dim item2 = cms.Items.Add("Edit Data")
            Dim item3 = cms.Items.Add("Delete")

            item1.Tag = 1
            item2.Tag = 2
            item3.Tag = 3

            AddHandler item1.Click, AddressOf menuChoice
            AddHandler item2.Click, AddressOf menuChoice
            AddHandler item3.Click, AddressOf menuChoice

            cms.Show(GridControl1, e.Location)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = "1" Then
            If FormLogin.CekAkses(MenuId) > 0 Then
                FormPriceList.clean()
                FormPriceList.X = "1"
                FormPriceList.setColumn()
                FormPriceList.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormPriceList.X = "2"
                FormPriceList.txtPLCode.Text = GridView1.GetFocusedDataRow.Item(1).ToString
                FormPriceList.txtDesc.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormPriceList.txtValidFrom.EditValue = FormatDateTime(GridView1.GetFocusedDataRow.Item(3), DateFormat.ShortDate)
                FormPriceList.txtValidTo.Text = FormatDateTime(GridView1.GetFocusedDataRow.Item(4), DateFormat.ShortDate)
                If GridView1.GetFocusedDataRow.Item(5) = "0" Then
                    FormPriceList.rbPurchase.Checked = False
                    FormPriceList.rbSell.Checked = True
                Else
                    FormPriceList.rbPurchase.Checked = True
                    FormPriceList.rbSell.Checked = False
                End If
                FormPriceList.idPL = GridView1.GetFocusedDataRow.Item(0)
                FormPriceList.LoadDetilById()
                FormPriceList.btnSave.Text = "Update"
                FormPriceList.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    datapricelist.SetNonAktifPriceList(GridView1.GetFocusedDataRow().Item(0))
                    LoadData()
                End If
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LoadData()
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