Public Class FormDataCustomer
    Dim dataCustomer As New ClassCustomer
    Dim OdataCustomer As New DataTable


    Public MenuId As Integer = 8
    Public IdCustomer As String = ""
    Sub loadData()
        OdataCustomer.Clear()
        OdataCustomer = dataCustomer.selectDataCustomer
        BindingSource1.DataSource = OdataCustomer
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
            GridView1.Columns(16).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(16).DisplayFormat.FormatString = "#0,#.00"

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FormDataCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadData()
    End Sub
    Private Sub GridControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles GridControl1.MouseClick
        Try
            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
            Dim cms = New ContextMenuStrip
            Dim item1 = cms.Items.Add("New")
            Dim item2 = cms.Items.Add("Edit Data")

            item1.Tag = 1
            item2.Tag = 2

            AddHandler item1.Click, AddressOf menuChoice
            AddHandler item2.Click, AddressOf menuChoice

            cms.Show(GridControl1, e.Location)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = "1" Then
            If FormLogin.CekAkses(MenuId) > 0 Then
                FormAddCustomer.clean()
                FormAddCustomer.X = "1"
                FormAddCustomer.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddCustomer.X = "2"
                FormAddCustomer.Id = GridView1.GetFocusedDataRow.Item(0).ToString
                FormAddCustomer.txtCustID.Text = GridView1.GetFocusedDataRow.Item(1).ToString
                FormAddCustomer.txtName.Text = GridView1.GetFocusedDataRow.Item(2).ToString
                FormAddCustomer.txtOtherName.Text = GridView1.GetFocusedDataRow.Item(3).ToString
                FormAddCustomer.txtCustType.Text = GridView1.GetFocusedDataRow.Item(4).ToString
                FormAddCustomer.txtSalesPerson.Text = GridView1.GetFocusedDataRow.Item(5).ToString
                FormAddCustomer.txtCreditStatus.Text = GridView1.GetFocusedDataRow.Item(6).ToString
                FormAddCustomer.txtTaxID.Text = GridView1.GetFocusedDataRow.Item(7).ToString
                FormAddCustomer.txtTelp.Text = GridView1.GetFocusedDataRow.Item(8).ToString
                FormAddCustomer.txtFax.Text = GridView1.GetFocusedDataRow.Item(9).ToString
                FormAddCustomer.txtMobPhone.Text = GridView1.GetFocusedDataRow.Item(10).ToString
                FormAddCustomer.txtEmail.Text = GridView1.GetFocusedDataRow.Item(11).ToString
                FormAddCustomer.txtContactPerson.Text = GridView1.GetFocusedDataRow.Item(12).ToString
                FormAddCustomer.txtWebsite.Text = GridView1.GetFocusedDataRow.Item(13).ToString
                FormAddCustomer.txtRemarks.Text = GridView1.GetFocusedDataRow.Item(14).ToString
                FormAddCustomer.txtPaymentTerm.Text = GridView1.GetFocusedDataRow.Item(15).ToString
                FormAddCustomer.txtCreditLimit.Text = GridView1.GetFocusedDataRow.Item(16).ToString
                FormAddCustomer.txtDiscount.Text = GridView1.GetFocusedDataRow.Item(17).ToString

                If GridView1.GetFocusedDataRow.Item(18).ToString = "1" Then
                    FormAddCustomer.ckPriceList.Checked = True
                Else
                    FormAddCustomer.ckPriceList.Checked = False
                End If

                FormAddCustomer.btnSave.Text = "Update"
                FormAddCustomer.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        loadData()
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