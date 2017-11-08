Public Class FormDataPR
    Dim dataPR As New ClassPR

    Public MenuId As Integer = 10

    Dim OdataPR As New DataTable
    Public X As String

    Sub LoadData()
        Dim aktif As String = ""
        Dim NonAktif As String = ""

        If ckAktif.Checked = True Then aktif = "1" Else aktif = "0"
        If ckNonAktif.Checked = True Then NonAktif = "1" Else NonAktif = "0"

        OdataPR.Clear()
        OdataPR = dataPR.selectDataPR(aktif, NonAktif)
        BindingSource1.DataSource = OdataPR
    End Sub

    Private Sub FormDataPR_Load(sender As Object, e As EventArgs) Handles Me.Load
        ckAktif.Checked = True
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
            'GridView1.Columns(0).Visible = False
            GridView1.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(10).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(11).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#0,#.00"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        GridControl1.Show()
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
                FormAddPR.Clean()
                FormAddPR.X = "1"
                FormAddPR.btnSave.Text = "Save"
                FormAddPR.btnSave.Enabled = True
                FormAddPR.btnPrint.Enabled = False
                FormAddPR.btnEdit.Visible = False
                FormAddPR.btnConvert.Enabled = True
                FormAddPR.enable()

                FormAddPR.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddPR.X = "2"
                FormAddPR.DocNumberPR = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddPR.LoadDetil()
                FormAddPR.txtReqName.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddPR.txtReqDept.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddPR.txtReqDate.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddPR.txtValidUntil.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddPR.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddPR.txtStatus.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddPR.txtNote.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddPR.txtEnqRef.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormAddPR.txtTotal.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddPR.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(11).ToString
                FormAddPR.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(12).ToString

                FormAddPR.txtReqName.Enabled = False
                FormAddPR.txtReqDept.Enabled = False
                FormAddPR.txtReqDate.Enabled = False
                FormAddPR.txtValidUntil.Enabled = False
                FormAddPR.txtCurrency.Enabled = False
                FormAddPR.txtStatus.Enabled = False
                FormAddPR.txtNote.Enabled = False
                FormAddPR.txtEnqRef.Enabled = False
                FormAddPR.txtRate.Enabled = False
                FormAddPR.btnConvert.Enabled = False
                FormAddPR.GridControl1.Enabled = False

                FormAddPR.btnPrint.Enabled = True
                FormAddPR.btnEdit.Visible = True
                FormAddPR.btnEdit.Enabled = True
                FormAddPR.btnSave.Enabled = False

                FormAddPR.btnSave.Text = "Update"
                FormAddPR.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    dataPR.SetNonAktifPR(GridView1.GetFocusedDataRow().Item(0))
                    LoadData()
                End If
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LoadData()
    End Sub

    'Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
    '    'X = 1 req by formaddpo
    '    Dim Odata As New DataTable
    '    If X = "1" Then
    '        'x=1 ==> req by form FormAddPO
    '        FormAddPO.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
    '        FormAddPO.txtStatus.Text = GridView1.GetFocusedDataRow.Item(7)
    '        FormAddPO.txtNote.Text = GridView1.GetFocusedDataRow.Item(8)
    '        Odata.Clear()
    '        Odata = dataPR.selectPRDetilByDocumentNumber(GridView1.GetFocusedDataRow.Item(0))
    '        For i = 0 To Odata.Rows.Count - 1
    '            If Odata.Rows(i).Item(5) > 0 Then
    '                FormAddPO.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), 0, Odata.Rows(i).Item(10))
    '            Else
    '            End If
    '        Next
    '        FormAddPO.btnConvert.Enabled = False
    '        FormAddPO.PRNumber = GridView1.GetFocusedDataRow.Item(0)
    '        Close()
    '    ElseIf X = "2" Then
    '        Odata.Clear()
    '        Odata = dataPR.selectPRDetilByDocumentNumber(GridView1.GetFocusedDataRow.Item(0))
    '        For i = 0 To Odata.Rows.Count - 1
    '            FormPriceList.addNewRow(Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), 0, Odata.Rows(i).Item(5), Odata.Rows(i).Item(6))
    '            FormPriceList.txtRefrence.Text = GridView1.GetFocusedDataRow.Item(0)
    '        Next
    '        Me.Close()
    '    End If

    'End Sub

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