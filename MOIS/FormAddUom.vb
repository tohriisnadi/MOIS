Public Class FormAddUom
    Dim dataUom As New ClassUom

    Public X As String = ""
    Public idUom As String = ""

    Sub Clear()
        txtUomCode.Text = ""
        txtDesc.Text = ""
        txtNote.Text = ""
        txtUomCode.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If X = "1" Then
            Try
                dataUom.addUom(txtUomCode.Text, txtDesc.Text, txtNote.Text)
                If MsgBox("Add Other Data ?", MsgBoxStyle.YesNo, "Question") = DialogResult.Yes Then
                    clear()
                Else
                    Close()
                End If
            Catch ex As Exception

            End Try
        ElseIf X = "2" Then
            If idUom <> "" Then
                dataUom.EditUom(idUom, txtUomCode.Text, txtDesc.Text, txtNote.Text)
                Close()
            Else
                MsgBox("Please Select Rigth Row", vbInformation, "Failed to Load Data")
            End If
        End If
        FormDataUom.loadData()
    End Sub

    Private Sub FormAddUom_Load(sender As Object, e As EventArgs) Handles Me.Load
        If X = "1" Then
            Clear()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
        Close()
    End Sub

    Private Sub txtUomCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUomCode.KeyDown
        Dim odata As New DataTable

        If e.KeyCode = Keys.Enter Then
            odata.Clear()
            txtUomCode.Text = txtUomCode.Text.ToUpper
            odata = dataUom.ValidationCode(txtUomCode.Text)
            If odata.Rows.Count > 0 Then
                MsgBox("Uom Code already exist, please input other code", MsgBoxStyle.Critical, "Error")
                txtUomCode.Text = ""
                txtUomCode.Focus()
            ElseIf txtUomCode.Text = ""
                MsgBox("uom Code cannot empty", MsgBoxStyle.Critical, "Error")
            Else
                txtDesc.Focus()
            End If
        End If

    End Sub
End Class