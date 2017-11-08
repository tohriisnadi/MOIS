Public Class FormDataSalesOrder
    Dim DataSO As New ClassSalesOrder
    Dim OdatSO As New DataTable
    Public MenuId As Integer = 14
    Public X as String =""

    Sub loadData()
        Dim aktif As String = ""
        Dim NonAktif As String = ""

        If ckAktif.Checked = True Then aktif = "1" Else aktif = "0"
        If ckNonAktif.Checked = True Then NonAktif = "1" Else NonAktif = "0"

        OdatSO.Clear()
        OdatSO = DataSO.selectDataSalesOrder(aktif, NonAktif)
        BindingSource1.DataSource = OdatSO
    End Sub

    Private Sub FormDataSalesOrder_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            GridView1.Columns(13).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(13).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(14).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(15).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(15).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(16).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(16).DisplayFormat.FormatString = "#,#.00"
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
                FormAddSalesOrder.clean()
                FormAddSalesOrder.X = "1"
                FormAddSalesOrder.btnSave.Text = "Save"
                FormAddSalesOrder.btnSave.Enabled = True
                FormAddSalesOrder.btnPrint.Enabled = False
                FormAddSalesOrder.btnEdit.Visible = False
                FormAddSalesOrder.enable()
                FormAddSalesOrder.ShowDialog()

            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddSalesOrder.X = "2"
                FormAddSalesOrder.clean()
                FormAddSalesOrder.SOid = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddSalesOrder.txtDocNumber.Text = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddSalesOrder.KodeCustomer = GridView1.GetFocusedDataRow.Item(1).ToString
                FormAddSalesOrder.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddSalesOrder.txtRef.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddSalesOrder.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddSalesOrder.txtRate.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddSalesOrder.txtDate.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddSalesOrder.txtDeliveryDate.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddSalesOrder.txtSalesPerson.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddSalesOrder.txtDiscountHeader.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormAddSalesOrder.txtPPNStatus.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddSalesOrder.txtNote.Text = GridView1.GetFocusedDataRow.Item(11).ToString
                FormAddSalesOrder.txtTermOfPayment.Text = GridView1.GetFocusedDataRow.Item(12).ToString
                FormAddSalesOrder.txtTotal.Text = GridView1.GetFocusedDataRow.Item(13).ToString
                FormAddSalesOrder.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(14).ToString
                FormAddSalesOrder.txtTotalPPN.Text = GridView1.GetFocusedDataRow.Item(15).ToString
                FormAddSalesOrder.txtNetPrice.Text = GridView1.GetFocusedDataRow.Item(16).ToString
                FormAddSalesOrder.loaddetilbyidmaster()

                FormAddSalesOrder.cbCust.Enabled = False
                FormAddSalesOrder.txtContactPerson.Enabled = False
                FormAddSalesOrder.txtRef.Enabled = False
                FormAddSalesOrder.txtCurrency.Enabled = False
                FormAddSalesOrder.txtRate.Enabled = False
                FormAddSalesOrder.txtDate.Enabled = False
                FormAddSalesOrder.txtDeliveryDate.Enabled = False
                FormAddSalesOrder.txtSalesPerson.Enabled = False
                FormAddSalesOrder.txtDiscountHeader.Enabled = False
                FormAddSalesOrder.txtPPNStatus.Enabled = False
                FormAddSalesOrder.txtNote.Enabled = False
                FormAddSalesOrder.txtTermOfPayment.Enabled = False
                FormAddSalesOrder.GridControl1.Enabled = False
                FormAddSalesOrder.btnConvert.Enabled = False


                FormAddSalesOrder.btnPrint.Enabled = True
                FormAddSalesOrder.btnEdit.Visible = True
                FormAddSalesOrder.btnEdit.Enabled = True
                FormAddSalesOrder.btnSave.Enabled = False

                FormAddSalesOrder.btnSave.Text = "Update"
                FormAddSalesOrder.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    DataSO.SetNonAktifSO(GridView1.GetFocusedDataRow().Item(0))
                    loadData()
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
End Class