Public Class FormDataVendorInvoice
    Dim DataVendorInvoice As New ClassVendorInvoice
    Dim OdataAP As New DataTable

    Public MenuId As Integer = 17

    Sub LoadData()
        OdataAP.Clear()
        OdataAP = DataVendorInvoice.selectDataVendorInvoice
        BindingSource1.DataSource = OdataAP
    End Sub

    Private Sub FormDataVendorInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
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
            'GridView1.Columns(0).Visible = False
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(13).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(14).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(15).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(15).DisplayFormat.FormatString = "#0,#.00"
        Catch ex As Exception
            MsgBox(ex.Message)
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
                FormAddVendorInvoice.clean()
                FormAddVendorInvoice.X = "1"
                FormAddVendorInvoice.btnSave.Enabled = True
                FormAddVendorInvoice.btnPrint.Enabled = False

                FormAddVendorInvoice.txtDate.Enabled = True
                FormAddVendorInvoice.txtRef.Enabled = True
                FormAddVendorInvoice.txtContactPerson.Enabled = True
                FormAddVendorInvoice.txtRate.Enabled = True
                FormAddVendorInvoice.txtCurrency.Enabled = True
                FormAddVendorInvoice.txtTermOfPayment.Enabled = True
                FormAddVendorInvoice.txtDiscount.Enabled = True
                FormAddVendorInvoice.txtPPNStatus.Enabled = True
                FormAddVendorInvoice.txtNote.Enabled = True
                FormAddVendorInvoice.txtBaseLineDate.Enabled = True
                FormAddVendorInvoice.GridControl1.Enabled = True
                FormAddVendorInvoice.btnConvert.Enabled = True
                FormAddVendorInvoice.txtDiscountHeader.Enabled = True
                FormAddVendorInvoice.cbCust.Enabled = True

                FormAddVendorInvoice.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddVendorInvoice.X = "2"
                FormAddVendorInvoice.clean()
                FormAddVendorInvoice.VendorInvoiceId = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddVendorInvoice.txtDocNumber.Text = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddVendorInvoice.txtDate.EditValue = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddVendorInvoice.txtRef.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddVendorInvoice.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddVendorInvoice.txtRate.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddVendorInvoice.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddVendorInvoice.txtTermOfPayment.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddVendorInvoice.txtDiscountHeader.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddVendorInvoice.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormAddVendorInvoice.txtNote.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddVendorInvoice.txtBaseLineDate.Text = GridView1.GetFocusedDataRow.Item(11).ToString
                FormAddVendorInvoice.txtTotal.Text = GridView1.GetFocusedDataRow.Item(12).ToString
                FormAddVendorInvoice.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(13).ToString
                FormAddVendorInvoice.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(14).ToString
                FormAddVendorInvoice.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(15).ToString
                FormAddVendorInvoice.loaddetilbyidmaster()

                FormAddVendorInvoice.txtDate.Enabled = False
                FormAddVendorInvoice.txtRef.Enabled = False
                FormAddVendorInvoice.txtContactPerson.Enabled = False
                FormAddVendorInvoice.txtRate.Enabled = False
                FormAddVendorInvoice.txtCurrency.Enabled = False
                FormAddVendorInvoice.txtTermOfPayment.Enabled = False
                FormAddVendorInvoice.txtDiscount.Enabled = False
                FormAddVendorInvoice.txtPPNStatus.Enabled = False
                FormAddVendorInvoice.txtNote.Enabled = False
                FormAddVendorInvoice.txtBaseLineDate.Enabled = False
                FormAddVendorInvoice.GridControl1.Enabled = False
                FormAddVendorInvoice.btnConvert.Enabled = False
                FormAddVendorInvoice.txtDiscountHeader.Enabled = False
                FormAddVendorInvoice.cbCust.Enabled = False


                FormAddVendorInvoice.btnPrint.Enabled = True
                FormAddVendorInvoice.btnSave.Enabled = False

                FormAddVendorInvoice.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3"
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    DataVendorInvoice.SetNonAktifVendorInvoice(GridView1.GetFocusedDataRow().Item(0))
                    LoadData()
                End If
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LoadData()
    End Sub
End Class