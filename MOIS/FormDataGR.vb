Public Class FormDataGR
    Dim dataGR As New ClassGR
    Dim OdataGr As New DataTable

    Public MenuId As Integer = 12

    Sub loadGR()
        Dim aktif As String = ""
        Dim NonAktif As String = ""

        If ckAktif.Checked = True Then aktif = "1" Else aktif = "0"
        If ckNonAktif.Checked = True Then NonAktif = "1" Else NonAktif = "0"

        OdataGr.Clear()
        OdataGr = dataGR.selectDataGR(aktif, NonAktif)
        BindingSource1.DataSource = OdataGr
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
            'GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            'GridView1.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'GridView1.Columns(10).DisplayFormat.FormatString = "#,#.00"
            'GridView1.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'GridView1.Columns(11).DisplayFormat.FormatString = "#0,#.00"
            'GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'GridView1.Columns(12).DisplayFormat.FormatString = "#0,#.00"
            'GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'GridView1.Columns(13).DisplayFormat.FormatString = "#,#.00"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormDataGR_Load(sender As Object, e As EventArgs) Handles Me.Load
        ckAktif.Checked = True
        loadGR()
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

    Sub loaddetilgr(id As String)
        Dim odata As New DataTable
        odata = dataGR.selectDetilGRbyId(id)
        For i = 0 To odata.Rows.Count - 1
            FormAddGR.addNewRow(odata.Rows(i).Item(0), odata.Rows(i).Item(1), odata.Rows(i).Item(2), odata.Rows(i).Item(4), odata.Rows(i).Item(3), odata.Rows(i).Item(5), odata.Rows(i).Item(6), odata.Rows(i).Item(7), 0)
        Next
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = "1" Then
            If FormLogin.CekAkses(MenuId) > 0 Then
                FormAddGR.Clean()
                FormAddGR.X = "1"
                FormAddGR.btnSave.Text = "Save"
                FormAddGR.btnSave.Enabled = True
                FormAddGR.btnEdit.Visible = False
                FormAddGR.btnPrint.Enabled = False

                FormAddGR.btnSave.Enabled = True
                FormAddGR.txtDate.Enabled = True
                FormAddGR.txtDeliveryNote.Enabled = True
                FormAddGR.txtBillOfLading.Enabled = True
                FormAddGR.txtRef.Enabled = True
                FormAddGR.txtShipVia.Enabled = True
                FormAddGR.txtShippingMethod.Enabled = True
                FormAddGR.txtNote.Enabled = True
                FormAddGR.txtDeliveryDate.Enabled = True
                FormAddGR.btnConvert.Enabled = True
                FormAddGR.GridControl1.Enabled = True
                FormAddGR.btnConvert.Enabled = True

                FormAddGR.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddGR.Clean()
                FormAddGR.DocumentNumber = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddGR.txtDocNumber.Text = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddGR.txtDate.EditValue = GridView1.GetFocusedDataRow.Item(1).ToString
                FormAddGR.txtDeliveryNote.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddGR.txtBillOfLading.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddGR.txtRef.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddGR.txtShipVia.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddGR.txtShippingMethod.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddGR.txtNote.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddGR.txtDeliveryDate.EditValue = GridView1.GetFocusedDataRow.Item(7).ToString

                loaddetilgr(GridView1.GetFocusedDataRow.Item(0))
                FormAddGR.btnSave.Enabled = False
                FormAddGR.txtDate.Enabled = False
                FormAddGR.txtDeliveryNote.Enabled = False
                FormAddGR.txtBillOfLading.Enabled = False
                FormAddGR.txtRef.Enabled = False
                FormAddGR.txtShipVia.Enabled = False
                FormAddGR.txtShippingMethod.Enabled = False
                FormAddGR.txtNote.Enabled = False
                FormAddGR.txtDeliveryDate.Enabled = False
                FormAddGR.btnConvert.Enabled = False
                FormAddGR.GridControl1.Enabled = False
                FormAddGR.btnConvert.Enabled = False

                'FormAddGR.idvendor = GridView1.GetFocusedDataRow.Item(4)
                'FormAddGR.loadvendorbyid(FormAddGR.idvendor)

                FormAddGR.btnPrint.Enabled = True
                FormAddGR.ShowDialog()

            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If

        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Cancel this GR ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    dataGR.SetNonAktifGR(GridView1.GetFocusedDataRow().Item(0))
                    loadGR()
                End If

            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        loadGR()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
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