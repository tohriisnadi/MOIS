Imports System.Data.Odbc
Public Class ClassEnquiry
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function SelectEnquiry(aktif As String, NonAktif As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectDataEnquiry '" & aktif & "','" & NonAktif & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectEnquiryForList()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec selectListEnquiry"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectEnquiryDetilByID(DocNumber As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectDetilEnquirybyDocNumber '" & DocNumber & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectEnquiryDetilByIDForPR(DocNumber As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectDetilEnquiryforPR '" & DocNumber & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SElectSQDetilByItemandEnq(ItemCode As String, NOEnq As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select qty from tbSalesQuotationDetils where ItemCode='" & ItemCode & "' and NoEnquiry='" & NOEnq & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function addEnquiry(SourceOfCall As String, SourceOfCallDesc As String, Reference As String, MaxRespon As String, Note As String, data As DataTable)

        Dim KodeMaster As String = ""
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call AddEnquiry (?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@SourceOfCall", OdbcType.VarChar, 50, ParameterDirection.Input).Value = SourceOfCall
            Command.Parameters.Add("@SourceOfCallValue", OdbcType.VarChar, 50, ParameterDirection.Input).Value = SourceOfCallDesc
            Command.Parameters.Add("@Reference", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Reference
            Command.Parameters.Add("@MaxResponDate", OdbcType.VarChar, 50, ParameterDirection.Input).Value = MaxRespon
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Note
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20)
            Command.Parameters("@DocumentNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocumentNumber").Value
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec AddEnquiryDetil '" & KodeMaster & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "','" & data.Rows(i).Item(6) & "'"
                Command.ExecuteNonQuery()
            Next

            Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            'MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
            MsgBox("Data gagal disimpan" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
        End Try
        ModKoneksi.TutupKoneksi()
        Return KodeMaster
    End Function

    Sub EditEnquiry(DocNumber As String, SourceOfCall As String, SourceOfCallDesc As String, Reference As String, MaxRespon As String, Note As String, data As DataTable)

        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call EditEnquiry (?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20, ParameterDirection.Input).Value = DocNumber
            Command.Parameters.Add("@SourceOfCall", OdbcType.VarChar, 50, ParameterDirection.Input).Value = SourceOfCall
            Command.Parameters.Add("@SourceOfCallDesc", OdbcType.VarChar, 50, ParameterDirection.Input).Value = SourceOfCallDesc
            Command.Parameters.Add("@Reference", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Reference
            Command.Parameters.Add("@MaxResponDate", OdbcType.VarChar, 50, ParameterDirection.Input).Value = MaxRespon
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Note
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.ExecuteNonQuery()
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec AddEnquiryDetil '" & DocNumber & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "','" & data.Rows(i).Item(6) & "'"
                Command.ExecuteNonQuery()
            Next

            'Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            'MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
            MsgBox("Data gagal disimpan" + vbCrLf + "Periksa inputan anda, Terdapat Format data yang keliru", vbInformation, "Information")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
    Sub SetNonAktifEnquiry(idEnquiry As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = " update tbEnquiry set isAktif='0' where DocumentNumber = '" & idEnquiry & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Tidak dapat di proses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
            'MsgBox("Error deleting data " + vbCrLf + "Error message: " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
End Class
