Public Class FormDataSalesBilling
    Dim DataSalesBilling As New ClassSalesBilling
    Dim OdataAR As New DataTable

    Public MenuId As Integer = 16

    Sub LoadData()
        OdataAR.Clear()
        OdataAR = DataSalesBilling.selectDataSalesBilling
        BindingSource1.DataSource = OdataAR
    End Sub

    Private Sub FormDataSalesBilling_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            GridView1.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(11).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(13).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(14).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(15).Visible = False
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
            Dim item2 = cms.Items.Add("Dispaly Document")
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
                FormAddSalesBilling.clean()
                FormAddSalesBilling.X = "1"
                FormAddSalesBilling.btnSave.Text = "Save"
                FormAddSalesBilling.btnSave.Enabled = True
                FormAddSalesBilling.btnPrint.Enabled = False
                '                FormAddSalesBilling.btnConvert.Enabled = True

                FormAddSalesBilling.cbCust.Enabled = True
                FormAddSalesBilling.txtRef.Enabled = True
                FormAddSalesBilling.txtCurrency.Enabled = True
                FormAddSalesBilling.txtRate.Enabled = True
                FormAddSalesBilling.txtDate.Enabled = True
                FormAddSalesBilling.txtDiscountHeader.Enabled = True
                FormAddSalesBilling.txtPPNStatus.Enabled = True
                FormAddSalesBilling.txtNote.Enabled = True
                FormAddSalesBilling.txtTermOfPayment.Enabled = True
                FormAddSalesBilling.txtBaseLineDate.Enabled = True
                FormAddSalesBilling.btnConvert.Enabled = True
                FormAddSalesBilling.GridControl1.Enabled = True

                FormAddSalesBilling.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddSalesBilling.X = "2"
                FormAddSalesBilling.clean()
                FormAddSalesBilling.SalesBillingId = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddSalesBilling.txtDocNumber.Text = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddSalesBilling.KodeCustomer = GridView1.GetFocusedDataRow.Item(1).ToString
                FormAddSalesBilling.LoadCustomer()
                FormAddSalesBilling.txtRef.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddSalesBilling.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddSalesBilling.txtRate.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddSalesBilling.txtDate.EditValue = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddSalesBilling.txtDiscountHeader.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddSalesBilling.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddSalesBilling.txtNote.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormAddSalesBilling.txtTermOfPayment.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddSalesBilling.txtBaseLineDate.EditValue = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddSalesBilling.txtTotal.Text = GridView1.GetFocusedDataRow.Item(11).ToString
                FormAddSalesBilling.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(12).ToString
                FormAddSalesBilling.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(13).ToString
                FormAddSalesBilling.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(14).ToString
                FormAddSalesBilling.DODate = GridView1.GetFocusedDataRow.Item(15).ToString
                FormAddSalesBilling.txtPONo.Text = GridView1.GetFocusedDataRow.Item(16).ToString
                FormAddSalesBilling.txtPODate.Text = GridView1.GetFocusedDataRow.Item(17).ToString
                FormAddSalesBilling.loaddetilbyidmaster()

                FormAddSalesBilling.cbCust.Enabled = False
                FormAddSalesBilling.txtRef.Enabled = False
                FormAddSalesBilling.txtCurrency.Enabled = False
                FormAddSalesBilling.txtRate.Enabled = False
                FormAddSalesBilling.txtDate.Enabled = False
                FormAddSalesBilling.txtDiscountHeader.Enabled = False
                FormAddSalesBilling.txtPPNStatus.Enabled = False
                FormAddSalesBilling.txtNote.Enabled = False
                FormAddSalesBilling.txtTermOfPayment.Enabled = False
                FormAddSalesBilling.txtBaseLineDate.Enabled = False
                FormAddSalesBilling.btnConvert.Enabled = False
                FormAddSalesBilling.GridControl1.Enabled = False
                FormAddSalesBilling.txtPONo.Enabled = False
                FormAddSalesBilling.txtPODate.Enabled = False


                FormAddSalesBilling.btnPrint.Enabled = True
                FormAddSalesBilling.btnSave.Enabled = False
                FormAddSalesBilling.btnConvert.Enabled = False
                FormAddSalesBilling.btnSave.Text = "Update"
                FormAddSalesBilling.ShowDialog()

            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    DataSalesBilling.SetNonAktifSalesBilling(GridView1.GetFocusedDataRow().Item(0))
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