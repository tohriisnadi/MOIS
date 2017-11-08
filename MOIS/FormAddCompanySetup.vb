Public Class FormAddCompanySetup
    Dim dataCompanySetup As New ClassCompanySetup

    Public X As String = ""

    Sub Clean()
        txtCompanyName.Text = ""
        txtAddress.Text = ""
        txtTelp.Text = ""
        txtFax.Text = ""
        txtWebsite.Text = ""
        txtDirName.Text = ""
        txtTaxId.Text = ""

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim opf As New OpenFileDialog() With {.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif"}

        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then
            picLogo.Image = Image.FromFile(opf.FileName)
            imagename.Text = opf.FileName
        End If
        Dim ms As New IO.MemoryStream
        picLogo.Image.Save(ms, picLogo.Image.RawFormat)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If X = "1" Then
                dataCompanySetup.AddCompanySetup(txtCompanyName.Text, txtAddress.Text, txtTelp.Text, txtFax.Text, txtWebsite.Text, txtDirName.Text, txtTaxId.Text, picLogo.Image)
            ElseIf X = "2" Then

            End If


        Catch ex As Exception

        End Try
        Clean()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Close()
    End Sub
End Class