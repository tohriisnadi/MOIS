Public Class FormDataSalesQuotation
    Dim dataSQ As New ClassSalesQuotation
    Dim OdataSQ As New DataTable
    Public MenuId As Integer = 13
    Public X = "1"

    Sub loadData()
        Dim aktif As String = ""
        Dim NonAktif As String = ""

        If ckAktif.Checked = True Then aktif = "1" Else aktif = "0"
        If ckNonAktif.Checked = True Then NonAktif = "1" Else NonAktif = "0"

        OdataSQ.Clear()
        OdataSQ = dataSQ.selectDataSalesQuotation(aktif, NonAktif)
        BindingSource1.DataSource = OdataSQ
    End Sub

    Private Sub FormDataSalesQuotation_Load(sender As Object, e As EventArgs) Handles Me.Load
        ckAktif.Checked = True
        loadData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        loadData()
    End Sub
    Sub setGrid()
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
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(13).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(14).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(15).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(15).DisplayFormat.FormatString = "#,#.00"
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
                FormAddSalesQuotation.clean()
                FormAddSalesQuotation.X = "1"
                FormAddSalesQuotation.btnSave.Text = "Save"
                FormAddSalesQuotation.btnSave.Enabled = True
                FormAddSalesQuotation.btnPrint.Enabled = False
                FormAddSalesQuotation.btnEdit.Visible = False
                FormAddSalesQuotation.Enable()
                FormAddSalesQuotation.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddSalesQuotation.X = "2"
                FormAddSalesQuotation.clean()
                FormAddSalesQuotation.SQid = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddSalesQuotation.KodeCustomer = GridView1.GetFocusedDataRow.Item(1).ToString
                FormAddSalesQuotation.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddSalesQuotation.txtRef.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddSalesQuotation.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddSalesQuotation.txtRate.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddSalesQuotation.txtDate.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddSalesQuotation.txtValidUntil.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddSalesQuotation.txtSalesPerson.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddSalesQuotation.txtDiscountHeader.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormAddSalesQuotation.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddSalesQuotation.txtNote.Text = GridView1.GetFocusedDataRow.Item(11).ToString
                FormAddSalesQuotation.txtTotal.Text = GridView1.GetFocusedDataRow.Item(12).ToString
                FormAddSalesQuotation.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(13).ToString
                FormAddSalesQuotation.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(14).ToString
                FormAddSalesQuotation.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(15).ToString
                FormAddSalesQuotation.txtProject.Text = GridView1.GetFocusedDataRow.Item(16).ToString
                FormAddSalesQuotation.loaddetilbyidmaster()

                FormAddSalesQuotation.cbCustomer.Enabled = False
                FormAddSalesQuotation.txtContactPerson.Enabled = False
                FormAddSalesQuotation.txtRef.Enabled = False
                FormAddSalesQuotation.txtDiscount.Enabled = False
                FormAddSalesQuotation.txtCurrency.Enabled = False
                FormAddSalesQuotation.txtRate.Enabled = False
                FormAddSalesQuotation.txtDate.Enabled = False
                FormAddSalesQuotation.txtValidUntil.Enabled = False
                FormAddSalesQuotation.txtSalesPerson.Enabled = False
                FormAddSalesQuotation.txtDiscount.Enabled = False
                FormAddSalesQuotation.txtPPNStatus.Enabled = False
                FormAddSalesQuotation.txtNote.Enabled = False
                FormAddSalesQuotation.txtProject.Enabled = False
                FormAddSalesQuotation.SimpleButton1.Enabled = False
                FormAddSalesQuotation.btnConvert.Enabled = False
                FormAddSalesQuotation.GridControl1.Enabled = False
                FormAddSalesQuotation.txtDiscountHeader.Enabled = False

                FormAddSalesQuotation.btnPrint.Enabled = True
                FormAddSalesQuotation.btnEdit.Visible = True
                FormAddSalesQuotation.btnEdit.Enabled = True
                FormAddSalesQuotation.btnSave.Enabled = False

                FormAddSalesQuotation.btnSave.Text = "Update"

                FormAddSalesQuotation.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    dataSQ.SetNonAktifSalesQuotation(GridView1.GetFocusedDataRow().Item(0))
                    loadData()
                End If
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub

    'Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
    '    Dim Odata As New DataTable
    '    Odata.Clear()
    '    Odata = dataSQ.SelectDetilbyIdMaster(GridView1.GetFocusedDataRow.Item(0))

    '    If X = "1" Then
    '        For i = 0 To Odata.Rows.Count - 1
    '            FormAddSalesOrder.addNewRow(Odata.Rows(i).Item(0), Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), Odata.Rows(i).Item(9), GridView1.GetFocusedDataRow.Item(0))
    '        Next
    '        FormAddSalesOrder.cbCust.Text = GridView1.GetFocusedDataRow.Item(1)
    '        FormAddSalesOrder.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(2)
    '        FormAddSalesOrder.txtRef.Text = GridView1.GetFocusedDataRow.Item(3)
    '        FormAddSalesOrder.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4)
    '        FormAddSalesOrder.txtRate.Text = GridView1.GetFocusedDataRow.Item(5)
    '        FormAddSalesOrder.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(9)
    '        FormAddSalesOrder.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10)
    '        FormAddSalesOrder.txtNote.Text = GridView1.GetFocusedDataRow.Item(11)
    '        FormAddSalesOrder.txtSalesPerson.Text = GridView1.GetFocusedDataRow.Item(8)
    '        FormAddSalesOrder.txtTotal.Text = GridView1.GetFocusedDataRow.Item(12)
    '        FormAddSalesOrder.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(13)
    '        FormAddSalesOrder.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(14)
    '        FormAddSalesOrder.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(15)
    '        FormAddSalesOrder.formatAngka()
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