Public Class FormDataPO
    Dim dataPO As New ClassPO
    Dim OdataPO As New DataTable
    Public MenuId As Integer = 11

    Public X As String = ""

    Sub loadData()
        Dim aktif As String = ""
        Dim NonAktif As String = ""

        If ckAktif.Checked = True Then aktif = "1" Else aktif = "0"
        If ckNonAktif.Checked = True Then NonAktif = "1" Else NonAktif = "0"

        OdataPO.Clear()
        OdataPO = dataPO.selectDataPO(aktif, NonAktif)
        BindingSource1.DataSource = OdataPO
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
            'GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView1.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(10).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(11).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(13).DisplayFormat.FormatString = "#,#.00"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FormDataPO_Load(sender As Object, e As EventArgs) Handles Me.Load
        ckAktif.Checked = True
        loadData()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub

    Private Sub GridControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles GridControl1.MouseClick
        Try
            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
            Dim cms = New ContextMenuStrip
            Dim item1 = cms.Items.Add("Create Document")
            Dim item2 = cms.Items.Add("Display Document")
            Dim item3 = cms.Items.Add("Cancel Document")

            item1.Tag = 1
            item2.Tag = 2
            item3.Tag = 3
            'item4.Tag = 4

            AddHandler item1.Click, AddressOf menuChoice
            AddHandler item2.Click, AddressOf menuChoice
            AddHandler item3.Click, AddressOf menuChoice
            'AddHandler item4.Click, AddressOf menuChoice

            cms.Show(GridControl1, e.Location)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = "1" Then
            If FormLogin.CekAkses(MenuId) > 0 Then
                FormAddPO.clean()
                FormAddPO.X = "1"
                FormAddPO.btnSave.Text = "Save"
                FormAddPO.btnSave.Enabled = True
                FormAddPO.btnEdit.Visible = False
                FormAddPO.btnPrint.Enabled = False
                FormAddPO.enable()
                FormAddPO.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddPO.X = "2"
                FormAddPO.clean()
                FormAddPO.DocumentNumber = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddPO.txtDocNumber.Text = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddPO.Docdate = GridView1.GetFocusedDataRow.Item(1).ToString
                FormAddPO.LoadDetil()
                'FormAddPO.SearchLookUpEdit1.Text = GridView1.GetFocusedDataRow.Item(2)
                FormAddPO.Kodevendor = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddPO.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddPO.txtCurRate.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddPO.txtDiscountHead.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddPO.txtStatus.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddPO.txtNote.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddPO.txtRef.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormAddPO.txtTotal.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddPO.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(11).ToString
                FormAddPO.txtPPN.Text = GridView1.GetFocusedDataRow.Item(12).ToString
                FormAddPO.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(13).ToString
                If GridView1.GetFocusedDataRow.Item(3) = "I" Then FormAddPO.RbI.Checked = False Else FormAddPO.RbI.Checked = True
                If GridView1.GetFocusedDataRow.Item(3) = "E" Then FormAddPO.RbE.Checked = False Else FormAddPO.RbE.Checked = True
                If GridView1.GetFocusedDataRow.Item(3) = "O" Then FormAddPO.RbO.Checked = False Else FormAddPO.RbO.Checked = True

                FormAddPO.cbVendor.Enabled = False
                FormAddPO.txtCurrency.Enabled = False
                FormAddPO.txtCurRate.Enabled = False
                FormAddPO.txtDiscountHead.Enabled = False
                FormAddPO.txtStatus.Enabled = False
                FormAddPO.txtNote.Enabled = False
                FormAddPO.txtRef.Enabled = False
                FormAddPO.btnConvert.Enabled = False
                FormAddPO.RbI.Enabled = False
                FormAddPO.RbE.Enabled = False
                FormAddPO.RbO.Enabled = False
                FormAddPO.GridControl1.Enabled = False

                FormAddPO.btnSave.Text = "Update"
                FormAddPO.btnEdit.Visible = True
                FormAddPO.btnEdit.Enabled = True
                FormAddPO.btnPrint.Enabled = True
                FormAddPO.btnSave.Enabled = False
                FormAddPO.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If

        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    dataPO.SetNonAktiPO(GridView1.GetFocusedDataRow().Item(0))
                    loadData()
                End If
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        loadData()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim Odata As New DataTable
        If X = "1" Then
            Odata.Clear()
            Odata = dataPO.selectPODetilByDocNumberForGR(GridView1.GetFocusedDataRow.Item(0))
            For i = 0 To Odata.Rows.Count - 1
                FormAddGR.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), "", "", "", "", Odata.Rows(i).Item(4))
            Next
            FormAddGR.idvendor = GridView1.GetFocusedDataRow.Item(2)
            ' FormAddGR.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
            FormAddGR.btnConvert.Enabled = False
        End If
        Close()
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