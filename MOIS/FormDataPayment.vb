Public Class FormDataPayment
    Dim DataPeyment As New ClassPayment
    Dim OdataPayment As New DataTable

    Public MenuId As Integer = 18
    Sub loadData()
        OdataPayment.Clear()
        OdataPayment = DataPeyment.selectDataPayment
        BindingSource1.DataSource = OdataPayment
    End Sub

    Private Sub FormDataPayment_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            'GridView1.Columns(0).Visible = False
            GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(8).DisplayFormat.FormatString = "#,#.00"
            GridView1.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(9).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(11).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(11).DisplayFormat.FormatString = "#0,#.00"
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatString = "#,#.00"
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
                FormAddPayment.clean()
                FormAddPayment.X = "1"
                FormAddPayment.btnSave.Enabled = True
                FormAddPayment.txtCashBank.Enabled = True
                FormAddPayment.txtCurrency.Enabled = True
                FormAddPayment.txtRate.Enabled = True
                FormAddPayment.txtDate.Enabled = True
                FormAddPayment.txtPartnertType.Enabled = True
                FormAddPayment.txtPartnerName.Enabled = True
                FormAddPayment.txtNote.Enabled = True
                FormAddPayment.btnPrint.Enabled = False
                FormAddPayment.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddPayment.clean()
                FormAddPayment.Docnumber = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddPayment.txtCashBank.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddPayment.txtCurrency.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddPayment.txtRate.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddPayment.txtDate.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddPayment.txtPartnertType.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                If GridView1.GetFocusedDataRow.Item(6) = "Customer" Then
                    FormAddPayment.LoadCustomer()
                ElseIf GridView1.GetFocusedDataRow.Item(6) = "Vendor" Then
                    FormAddPayment.loadVendor()
                End If
                FormAddPayment.txtPartnerName.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddPayment.txtNote.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddPayment.txtTotalPayment.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddPayment.txtTotalPaymentIDR.Text = GridView1.GetFocusedDataRow.Item(9).ToString

                If GridView1.GetFocusedDataRow.Item(1) = "Incoming" Then
                    FormAddPayment.RbIncoming.Checked = True
                Else
                    FormAddPayment.rbOutgoing.Checked = True
                End If

                Dim odata As New DataTable
                odata = DataPeyment.loaddetilbyid(GridView1.GetFocusedDataRow.Item(0))
                For i = 0 To odata.Rows.Count - 1
                    FormAddPayment.addNewRow(odata.Rows(i).Item(0), odata.Rows(i).Item(1), odata.Rows(i).Item(2), odata.Rows(i).Item(3), odata.Rows(i).Item(4), odata.Rows(i).Item(5))
                Next
                FormAddPayment.txtCashBank.Enabled = False
                FormAddPayment.txtCurrency.Enabled = False
                FormAddPayment.txtRate.Enabled = False
                FormAddPayment.txtDate.Enabled = False
                FormAddPayment.txtPartnertType.Enabled = False
                FormAddPayment.txtPartnerName.Enabled = False
                FormAddPayment.txtNote.Enabled = False
                FormAddPayment.txtTotalPayment.Enabled = False
                FormAddPayment.txtTotalPaymentIDR.Enabled = False
                FormAddPayment.btnSave.Enabled = False
                FormAddPayment.btnPrint.Enabled = True
                FormAddPayment.hitung()
                FormAddPayment.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    DataPeyment.SetNonAktifPayment(GridView1.GetFocusedDataRow().Item(0))
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        loadData()
    End Sub
End Class