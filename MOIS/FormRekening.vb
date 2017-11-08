Public Class FormRekening
    Dim DataRekening As New ClassRekening
    Dim OdataRekening As New DataTable

    Public menuid As String = "20"
    Public X As String = ""

    Sub Loadrekening()
        OdataRekening.Clear()
        OdataRekening = DataRekening.SelectRekening
        BindingSource1.DataSource = OdataRekening
        setGrid()
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
            GridView1.Columns(0).Visible = False
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Sub clear()
        txtBankName.Text = ""
        txtBankAddress.Text = ""
        txtAccount.Text = ""
        txtAccountName.Text = ""
        txtCurrency.SelectedIndex = -1
        btnSave.Enabled = False
        txtBankName.Enabled = False
        txtBankAddress.Enabled = False
        txtAccount.Enabled = False
        txtAccountName.Enabled = False
        txtCurrency.Enabled = False
        btnSave.Enabled = False
        txtCurrency.Text = ""
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        X = "1"
        txtBankName.Enabled = True
        txtBankAddress.Enabled = True
        txtAccount.Enabled = True
        txtAccountName.Enabled = True
        txtCurrency.Enabled = True
        txtBankName.Focus()
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        txtBankName.Text = GridView1.GetFocusedDataRow.Item(1)
        txtBankAddress.Text = GridView1.GetFocusedDataRow.Item(2)
        txtAccount.Text = GridView1.GetFocusedDataRow.Item(3)
        txtAccountName.Text = GridView1.GetFocusedDataRow.Item(4)
        txtCurrency.Text = GridView1.GetFocusedDataRow.Item(5)

        txtBankName.Enabled = True
        txtBankAddress.Enabled = True
        txtAccount.Enabled = True
        txtAccountName.Enabled = True
        txtCurrency.Enabled = True
        txtBankName.Focus()
        btnNew.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtBankName.Text = "" Then
            MsgBox("Bank Name cannot empty", vbInformation + "Cannot Save")
            txtBankName.Focus()
        ElseIf txtBankAddress.Text = "" Then
            MsgBox("Bank Address cannot empty", vbInformation + "Cannot Save")
            txtBankAddress.Focus()
        ElseIf txtAccount.Text = "" Then
            MsgBox("Account Number cannot empty", vbInformation + "Cannot Save")
            txtAccount.Focus()
        ElseIf txtAccountName.Text = "" Then
            MsgBox("Account Name cannot empty", vbInformation + "Cannot Save")
            txtAccountName.Focus()
        ElseIf txtCurrency.Text = "" Then
            MsgBox("Currency cannot empty", vbInformation + "Cannot Save")
            txtCurrency.Focus()
        Else
            If X = "1" Then
                DataRekening.AddRekening(txtBankName.Text, txtBankAddress.Text, txtAccount.Text, txtAccountName.Text, txtCurrency.Text)
                txtBankName.Text = ""
                txtBankAddress.Text = ""
                txtAccount.Text = ""
                txtAccountName.Text = ""
                txtCurrency.Text = ""
            ElseIf X = "2"
                DataRekening.EditRekening(GridView1.GetFocusedDataRow.Item(0), txtBankName.Text, txtBankAddress.Text, txtAccount.Text, txtAccountName.Text, txtCurrency.Text)
                clear()
            End If

        End If
        Loadrekening()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBox("Delete Rekening " + GridView1.GetFocusedDataRow.Item(1) + vbCr + GridView1.GetFocusedDataRow.Item(1), vbQuestion + vbYesNo, "Question") = MsgBoxResult.Yes Then
            DataRekening.NonAktifRekening(GridView1.GetFocusedDataRow.Item(0))
        End If
        clear()
    End Sub

    Private Sub FormRekening_Load(sender As Object, e As EventArgs) Handles Me.Load
        Loadrekening()
        clear()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        btnNew.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = False
        clear()
    End Sub
End Class