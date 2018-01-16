Public Class FormDataEnquiry
    Dim dataenquiry As New ClassEnquiry
    Dim odataenquiry As New DataTable

    Public MenuId As Integer = 9

    Public X As String = ""
    Sub LoadData()
        Dim aktif As String = ""
        Dim NonAktif As String = ""

        If ckAktif.Checked = True Then aktif = "1" Else aktif = "0"
        If ckNonAktif.Checked = True Then NonAktif = "1" Else NonAktif = "0"

        odataenquiry.Clear()
        odataenquiry = dataenquiry.SelectEnquiry(aktif, NonAktif)
        BindingSource1.DataSource = odataenquiry
    End Sub

    Private Sub FormDataEnquiry_Load(sender As Object, e As EventArgs) Handles Me.Load
        ckAktif.Checked = True
        LoadData()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
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
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
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
                FormEnquiry.clean()
                FormEnquiry.X = "1"
                FormEnquiry.setTabelUnbound()
                FormEnquiry.btnSave.Text = "Save"
                FormEnquiry.btnEdit.Visible = False
                FormEnquiry.btnPrint.Enabled = False
                FormEnquiry.enable()
                FormEnquiry.txtDocNumber.Text = "Otomatis"
                FormEnquiry.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormEnquiry.X = "2"
                FormEnquiry.idEnquiry = GridView1.GetFocusedDataRow.Item(0).ToString
                FormEnquiry.LoadDetil()
                FormEnquiry.txtDocNumber.Text = GridView1.GetFocusedDataRow.Item(0).ToString
                FormEnquiry.txtDate.EditValue = (GridView1.GetFocusedDataRow.Item(1)).ToString
                FormEnquiry.cbSourceOfCall.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormEnquiry.txtSourceOFCallDesc.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormEnquiry.txtRef.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormEnquiry.txtMaxResponDate.EditValue = (GridView1.GetFocusedDataRow.Item(5)).ToString
                FormEnquiry.txtNote.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormEnquiry.btnEdit.Visible = True
                FormEnquiry.btnEdit.Enabled = True
                FormEnquiry.btnSave.Enabled = False
                FormEnquiry.btnPrint.Enabled = True

                FormEnquiry.cbSourceOfCall.Enabled = False
                FormEnquiry.txtDate.Enabled = False
                FormEnquiry.txtSourceOFCallDesc.Enabled = False
                FormEnquiry.txtRef.Enabled = False
                FormEnquiry.txtMaxResponDate.Enabled = False
                FormEnquiry.txtNote.Enabled = False
                FormEnquiry.GridControl1.Enabled = False

                FormEnquiry.btnSave.Text = "Update"
                FormEnquiry.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    dataenquiry.SetNonAktifEnquiry(GridView1.GetFocusedDataRow().Item(0))
                    LoadData()
                End If
            Else

                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub

    Dim Gen As String = ""



    'Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
    '    'X = 1 request by FormAddPR
    '    Dim Odata As New DataTable
    '    Odata.Clear()
    '    Odata = dataenquiry.SelectEnquiryDetilByID(GridView1.GetFocusedDataRow.Item(0))
    '    If X = "1" Then
    '        ' x = 1 ==> req from FormAddPR
    '        FormAddPR.txtEnqRef.Text = GridView1.GetFocusedDataRow.Item(0)
    '        For i = 0 To Odata.Rows.Count - 1
    '            If Odata.Rows(i).Item(5) > 0 Then
    '                FormAddPR.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), 1, "", 0, 0, "", Odata.Rows(i).Item(6))
    '            Else
    '            End If
    '        Next
    '        FormAddPR.btnConvert.Enabled = False
    '        Me.Close()
    '    ElseIf X = "2" Then
    '        'x = 2 ==> request by form add sales quotation
    '        FormAddSalesQuotation.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
    '        For i = 0 To Odata.Rows.Count - 1
    '            FormAddSalesQuotation.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), 0, 0, 0, "", Odata.Rows(i).Item(0))
    '            'FormAddSalesQuotation.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), 0, 0, 0, Odata.Rows(i).Item(5), GridView1.GetFocusedDataRow.Item(0))
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