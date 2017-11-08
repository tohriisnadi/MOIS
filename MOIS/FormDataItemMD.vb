Public Class FormDataItemMD
    Dim dataItemMD As New ClassItemMD
    Dim OdataItemMD As New DataTable

     Public MenuId As Integer = 4

    Sub LoadData()
        OdataItemMD.Clear()
        OdataItemMD = dataItemMD.SelectMasterItemMD()
        BindingSource1.DataSource = OdataItemMD
    End Sub

    Private Sub FormDataItemMD_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            GridView1.Columns(0).Visible = False
            GridView1.Columns(5).Visible = False
            GridView1.Columns(6).Visible = False
            GridView1.Columns(7).Visible = False
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
                FormItemMD.X = "1"
                FormItemMD.btnSave.Text = "Save"
                FormItemMD.clean()
                FormItemMD.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormItemMD.X = "2"
                FormItemMD.KodeItemMD = GridView1.GetFocusedDataRow.Item(0).ToString
                FormItemMD.txtItemCode.Text = GridView1.GetFocusedDataRow.Item(1).ToString
                FormItemMD.txtDesc1.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormItemMD.txtDesc2.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormItemMD.txtItemGroup.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormItemMD.txtManufactur.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormItemMD.txtHsCode.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormItemMD.txtShippingType.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormItemMD.txtUom.Text = GridView1.GetFocusedDataRow.Item(11).ToString

                If GridView1.GetFocusedDataRow.Item(5) = "1" Then
                    FormItemMD.ckInvetory.Checked = True
                    Dim OdataInventory As New DataTable
                    OdataInventory.Clear()
                    OdataInventory = dataItemMD.SelectInventoryItembyIdMD(GridView1.GetFocusedDataRow.Item(0))
                    Try
                        FormItemMD.txtInvWeight.Text = OdataInventory.Rows(0).Item(0).ToString
                        FormItemMD.txtInvMinStock.Text = OdataInventory.Rows(0).Item(1).ToString
                        FormItemMD.txtInvMaxStock.Text = OdataInventory.Rows(0).Item(2).ToString
                        FormItemMD.txtInvReorderPoint.Text = OdataInventory.Rows(0).Item(3).ToString
                        FormItemMD.txtInvLength.Text = OdataInventory.Rows(0).Item(4).ToString
                        FormItemMD.txtInvWidth.Text = OdataInventory.Rows(0).Item(5).ToString
                        FormItemMD.txtInvHeight.Text = OdataInventory.Rows(0).Item(6).ToString
                        FormItemMD.txtInvVolume.Text = OdataInventory.Rows(0).Item(7).ToString
                    Catch ex As Exception

                    End Try


                ElseIf GridView1.GetFocusedDataRow.Item(6) = "1" Then
                    FormItemMD.ckSales.Checked = True
                    Dim OdataSales As New DataTable
                    OdataSales.Clear()
                    OdataSales = dataItemMD.SelectSalesItembyIdMD(GridView1.GetFocusedDataRow.Item(0))
                    Try
                        FormItemMD.txtSalesTaxGr.Text = OdataSales.Rows(0).Item(0).ToString
                        FormItemMD.txtSalesUom.Text = OdataSales.Rows(0).Item(1).ToString
                        FormItemMD.txtSalesMinOrderQty.Text = OdataSales.Rows(0).Item(2).ToString
                        FormItemMD.txtSalesPacking.Text = OdataSales.Rows(0).Item(3).ToString
                        FormItemMD.txtSalesLength.Text = OdataSales.Rows(0).Item(4).ToString
                        FormItemMD.txtSalesWidth.Text = OdataSales.Rows(0).Item(5).ToString
                        FormItemMD.txtSalesHeight.Text = OdataSales.Rows(0).Item(6).ToString
                        FormItemMD.txtSalesVolume.Text = OdataSales.Rows(0).Item(7).ToString

                    Catch ex As Exception

                    End Try
                ElseIf GridView1.GetFocusedDataRow.Item(7) = "1" Then
                    FormItemMD.ckPurchase.Checked = True
                    Dim OdataPurchase As New DataTable
                    OdataPurchase.Clear()
                    OdataPurchase = dataItemMD.SelectPurchaseItembyIdMD(GridView1.GetFocusedDataRow.Item(0))
                    Try
                        FormItemMD.txtPurTaxGr.Text = OdataPurchase.Rows(0).Item(0).ToString
                        FormItemMD.txtPurPrefVendor.Text = OdataPurchase.Rows(0).Item(1).ToString
                        FormItemMD.txtPurUOM.Text = OdataPurchase.Rows(0).Item(2).ToString
                        FormItemMD.txtPurMinOrderQty.Text = OdataPurchase.Rows(0).Item(3).ToString
                        FormItemMD.txtPurOrderInterval.Text = OdataPurchase.Rows(0).Item(4).ToString
                        FormItemMD.txtPurLeadTime.Text = OdataPurchase.Rows(0).Item(5).ToString
                        FormItemMD.txtPurLength.Text = OdataPurchase.Rows(0).Item(6).ToString
                        FormItemMD.txtPurWidth.Text = OdataPurchase.Rows(0).Item(7).ToString
                        FormItemMD.txtPurHeight.Text = OdataPurchase.Rows(0).Item(8).ToString
                        FormItemMD.txtPurHeight.Text = OdataPurchase.Rows(0).Item(9).ToString
                        FormItemMD.txtPurVolume.Text = OdataPurchase.Rows(0).Item(10).ToString
                        FormItemMD.txtPurGrProcessingTime.Text = OdataPurchase.Rows(0).Item(11).ToString

                    Catch ex As Exception

                    End Try
                End If

                FormItemMD.setTabelFactorUOM()
                Dim odata As New DataTable
                odata.Clear()
                odata = dataItemMD.SelectUOMFactor(GridView1.GetFocusedDataRow.Item(0))
                For i = 0 To odata.Rows.Count - 1
                    FormItemMD.addNewRow(odata.Rows(i).Item(0), odata.Rows(i).Item(1))
                Next

                FormItemMD.btnSave.Text = "Update"
                FormItemMD.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    '          DataUom.NonAktifUom(GridView1.GetFocusedDataRow().Item(0))
                    LoadData()
                End If
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "4" Then
            LoadData()
        End If
    End Sub

    Private Sub ToImageToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim opf As New SaveFileDialog() With {.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif"}
        If opf.ShowDialog(Me) = DialogResult.OK Then
            GridView1.Export(DevExpress.XtraPrinting.ExportTarget.Image, opf.FileName)
        End If
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