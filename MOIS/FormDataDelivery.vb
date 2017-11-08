Public Class FormDataDelivery
    Dim DataDelivery As New ClassDelivery
    Dim odataDelivery As New DataTable

    Public MenuId As Integer = 15

    Sub LoadData()
        Dim aktif As String = ""
        Dim NonAktif As String = ""

        If ckAktif.Checked = True Then aktif = "1" Else aktif = "0"
        If ckNonAktif.Checked = True Then NonAktif = "1" Else NonAktif = "0"

        odataDelivery.Clear()
        odataDelivery = DataDelivery.selectDataDelivery(aktif, NonAktif)
        BindingSource1.DataSource = odataDelivery
    End Sub

    Private Sub FormDataDelivery_Load(sender As Object, e As EventArgs) Handles Me.Load
        ckAktif.Checked = True
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
            GridView1.Columns(15).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(15).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(16).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(16).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(17).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(17).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(18).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(18).DisplayFormat.FormatString = "#,#.00"
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
                FormAddDelivery.clean()
                FormAddDelivery.X = "1"
                FormAddDelivery.btnSave.Text = "Save"
                FormAddDelivery.btnSave.Enabled = True
                FormAddDelivery.btnPrint.Enabled = False
                FormAddDelivery.btnEdit.Visible = False

                FormAddDelivery.cbCust.Enabled = True
                FormAddDelivery.txtContactPerson.Enabled = True
                FormAddDelivery.txtRef.Enabled = True
                FormAddDelivery.txtCurrency.Enabled = True
                FormAddDelivery.txtRate.Enabled = True
                FormAddDelivery.txtDate.Enabled = True
                FormAddDelivery.txtDeliveryDate.Enabled = True
                FormAddDelivery.txtSalesPerson.Enabled = True
                FormAddDelivery.txtDiscountHeader.Enabled = True
                FormAddDelivery.txtPPNStatus.Enabled = True
                FormAddDelivery.txtNote.Enabled = True
                FormAddDelivery.txtShipVia.Enabled = True
                FormAddDelivery.txtShipMetod.Enabled = True
                FormAddDelivery.txtDeliveryAddress.Enabled = True
                FormAddDelivery.btnConvert.Enabled = True
                FormAddDelivery.GridControl1.Enabled = True

                FormAddDelivery.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddDelivery.X = "2"
                FormAddDelivery.clean()
                FormAddDelivery.DOid = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddDelivery.txtDocNumber.Text = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddDelivery.KodeCustomer = GridView1.GetFocusedDataRow.Item(1).ToString
                FormAddDelivery.LoadCustomer()
                FormAddDelivery.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddDelivery.txtRef.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddDelivery.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddDelivery.txtRate.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddDelivery.txtDate.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddDelivery.txtDeliveryDate.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddDelivery.txtSalesPerson.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddDelivery.txtDiscountHeader.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormAddDelivery.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddDelivery.txtNote.Text = GridView1.GetFocusedDataRow.Item(11).ToString
                FormAddDelivery.txtShipVia.Text = GridView1.GetFocusedDataRow.Item(12).ToString
                FormAddDelivery.txtShipMetod.Text = GridView1.GetFocusedDataRow.Item(13).ToString
                FormAddDelivery.txtDeliveryAddress.Text = GridView1.GetFocusedDataRow.Item(14).ToString
                FormAddDelivery.txtTotal.Text = GridView1.GetFocusedDataRow.Item(15).ToString
                FormAddDelivery.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(16).ToString
                FormAddDelivery.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(17).ToString
                FormAddDelivery.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(18).ToString
                FormAddDelivery.loaddetilbyidmaster()

                FormAddDelivery.cbCust.Enabled = False
                FormAddDelivery.txtContactPerson.Enabled = False
                FormAddDelivery.txtRef.Enabled = False
                FormAddDelivery.txtCurrency.Enabled = False
                FormAddDelivery.txtRate.Enabled = False
                FormAddDelivery.txtDate.Enabled = False
                FormAddDelivery.txtDeliveryDate.Enabled = False
                FormAddDelivery.txtSalesPerson.Enabled = False
                FormAddDelivery.txtDiscountHeader.Enabled = False
                FormAddDelivery.txtPPNStatus.Enabled = False
                FormAddDelivery.txtNote.Enabled = False
                FormAddDelivery.txtShipVia.Enabled = False
                FormAddDelivery.txtShipMetod.Enabled = False
                FormAddDelivery.txtDeliveryAddress.Enabled = False
                FormAddDelivery.btnConvert.Enabled = False
                FormAddDelivery.GridControl1.Enabled = False

                FormAddDelivery.btnSave.Enabled = False
                FormAddDelivery.btnPrint.Enabled = True
                FormAddDelivery.btnEdit.Visible = False
                FormAddDelivery.btnSave.Text = "Update"
                FormAddDelivery.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3"
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    DataDelivery.SetNonAktifOD(GridView1.GetFocusedDataRow().Item(0))
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

    'Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
    '    Dim Odata As New DataTable
    '    Odata.Clear()
    '    Odata = DataDelivery.SelectDetilbyIdMaster(GridView1.GetFocusedDataRow.Item(0))
    '    For i = 0 To Odata.Rows.Count - 1
    '        FormAddSalesBilling.addNewRow(Odata.Rows(i).Item(0), Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), Odata.Rows(i).Item(6), Odata.Rows(i).Item(7), Odata.Rows(i).Item(8), GridView1.GetFocusedDataRow.Item(0))
    '    Next
    '    FormAddSalesBilling.cbCust.Text = GridView1.GetFocusedDataRow.Item(1)
    '    FormAddSalesBilling.DODate = GridView1.GetFocusedDataRow.Item(6)
    '    FormAddSalesBilling.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
    '    FormAddSalesBilling.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4)
    '    FormAddSalesBilling.txtRate.Text = GridView1.GetFocusedDataRow.Item(5)

    '    FormAddSalesBilling.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(9)
    '    FormAddSalesBilling.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10)
    '    FormAddSalesBilling.txtNote.Text = GridView1.GetFocusedDataRow.Item(11)
    '    FormAddSalesBilling.txtTotal.Text = GridView1.GetFocusedDataRow.Item(15)
    '    FormAddSalesBilling.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(16)
    '    FormAddSalesBilling.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(17)
    '    FormAddSalesBilling.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(18)
    '    FormAddSalesBilling.formatangka()
    '    FormAddSalesBilling.btnConvert.Enabled = False
    '    Me.Close()
    'End Sub
End Class