Public Class FormAddItemGroup
    Dim dataItemGroup As New ClassItemGroup
    Public X As String = ""

    Public idItemGr As String

    Sub clean()
        txtGrCode.Text = ""
        txtGrDesc.Text = ""
        txtNote.Text = ""
        loadParentGroup()
    End Sub

    Sub loadParentGroup()
        Dim odataParentGr As New DataTable
        odataParentGr.Clear()
        odataParentGr = dataItemGroup.selectParentGroup
        cbbParentGr.Properties.Items.Clear()
        For i = 0 To odataParentGr.Rows.Count - 1
            cbbParentGr.Properties.Items.Add(odataParentGr.Rows(i).Item(0))
        Next
        cbbParentGr.SelectedIndex = -1
    End Sub

    Private Sub FormAddItemGroup_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadParentGroup()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim parentGr As String
        If cbbParentGr.SelectedIndex <> -1 Then
            parentGr = cbbParentGr.Text
        Else
            parentGr = txtGrCode.Text
        End If

        If txtGrCode.Text = "" Then
            MsgBox("Group Code cannot empty", MsgBoxStyle.Information, "Please fill all field")
            txtGrCode.Focus()
        Else
            If X = "1" Then
                dataItemGroup.addItemGr(txtGrCode.Text, parentGr, txtGrDesc.Text, txtNote.Text)
                clean()
            ElseIf X = "2" Then
                dataItemGroup.EditItemGr(idItemGr, txtGrCode.Text, parentGr, txtGrDesc.Text, txtNote.Text)
                clean()
                FormDataItemGroup.loadData()
                Me.Close()
            End If
        End If
        FormDataItemGroup.loadData()
        loadParentGroup()
    End Sub

    Private Sub txtGrCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrCode.KeyDown
        Dim odata As New DataTable

        If e.KeyCode = Keys.Enter Then
            odata.Clear()
            txtGrCode.Text = txtGrCode.Text.ToUpper()
            odata = dataItemGroup.ValidateItemGroup(txtGrCode.Text)
            If odata.Rows.Count > 0 Then
                MsgBox("group code already exist, please input other code", MsgBoxStyle.Critical, "Error")
                txtGrCode.Text = ""
                txtGrCode.Focus()
            ElseIf txtGrCode.Text = ""
                MsgBox("group code cannot empty", MsgBoxStyle.Critical, "Error")
            Else
                cbbParentGr.Focus()
            End If

        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub
End Class