Public Class FormDataMasterVendor
    Dim dataMasterVendor As New ClassMasterVendor
    Dim OdataMasterVendor As New DataTable

    Public MenuId As Integer = 5

    Sub loadData()
        OdataMasterVendor.Clear()
        OdataMasterVendor = dataMasterVendor.SelectMasterVendor
        BindingSource1.DataSource = OdataMasterVendor
    End Sub

    Private Sub FormDataMasterVendor_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            GridView1.Columns(16).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(16).DisplayFormat.FormatString = "#0,#.00"
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
            Dim item3 = cms.Items.Add("NonAktif")

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
                FormAddMasterVendor.Clean()
                FormAddMasterVendor.X = "1"
                FormAddMasterVendor.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "2" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                FormAddMasterVendor.X = "2"
                FormAddMasterVendor.idMasterVendor = GridView1.GetFocusedDataRow().Item(0).ToString
                FormAddMasterVendor.txtVendorCode.Text = GridView1.GetFocusedDataRow().Item(1).ToString
                FormAddMasterVendor.txtName.Text = GridView1.GetFocusedDataRow().Item(2).ToString
                FormAddMasterVendor.txtOtherName.Text = GridView1.GetFocusedDataRow().Item(3).ToString
                FormAddMasterVendor.txtVendorGroup.Text = GridView1.GetFocusedDataRow().Item(4).ToString
                FormAddMasterVendor.txtAVLNumber.Text = GridView1.GetFocusedDataRow().Item(5).ToString
                FormAddMasterVendor.txtAVLSegment.Text = GridView1.GetFocusedDataRow().Item(6).ToString
                FormAddMasterVendor.txtTaxID.Text = GridView1.GetFocusedDataRow().Item(7).ToString
                FormAddMasterVendor.txtTelp.Text = GridView1.GetFocusedDataRow().Item(8).ToString
                FormAddMasterVendor.txtFax.Text = GridView1.GetFocusedDataRow().Item(9).ToString
                FormAddMasterVendor.txtMobPhone.Text = GridView1.GetFocusedDataRow().Item(10).ToString
                FormAddMasterVendor.txtEmail.Text = GridView1.GetFocusedDataRow().Item(11).ToString
                FormAddMasterVendor.txtContactPerson.Text = GridView1.GetFocusedDataRow().Item(12).ToString
                FormAddMasterVendor.txtWebsite.Text = GridView1.GetFocusedDataRow().Item(13).ToString
                FormAddMasterVendor.txtRemarks.Text = GridView1.GetFocusedDataRow().Item(14).ToString
                FormAddMasterVendor.txtPaymentTerm.Text = GridView1.GetFocusedDataRow().Item(15).ToString
                FormAddMasterVendor.txtCreditLimit.Text = GridView1.GetFocusedDataRow().Item(16).ToString
                FormAddMasterVendor.txtDiscount.Text = GridView1.GetFocusedDataRow().Item(17).ToString
                If GridView1.GetFocusedDataRow().Item(18) = "1" Then
                    FormAddMasterVendor.ckPricelist.Checked = True
                Else
                    FormAddMasterVendor.ckPricelist.Checked = False
                End If
                FormAddMasterVendor.txtBank.Text = GridView1.GetFocusedDataRow().Item(19)
                FormAddMasterVendor.txtAccount.Text = GridView1.GetFocusedDataRow().Item(20)
                FormAddMasterVendor.txtIBAN.Text = GridView1.GetFocusedDataRow().Item(21)
                FormAddMasterVendor.txtSwiftCode.Text = GridView1.GetFocusedDataRow().Item(22)
                FormAddMasterVendor.btnSave.Text = "Update"
                FormAddMasterVendor.ShowDialog()
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        ElseIf selection = "3" Then
            If FormLogin.CekAkses(MenuId) > 2 Then
                If MsgBox("Are you sure to Delete this data ?", vbYesNo + vbQuestion, "Question") = vbYes Then
                    dataMasterVendor.SetNonAktifMasterVendor(GridView1.GetFocusedDataRow().Item(0))
                    loadData()
                End If
            Else
                MsgBox("No Authorize", MsgBoxStyle.Critical, "Akses Failed")
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        loadData()
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