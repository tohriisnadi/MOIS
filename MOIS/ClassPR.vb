Imports System.Data.Odbc
Public Class ClassPR
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function selectDataPR(aktif As String, NonAktif As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec SelectDataPr '" & aktif & "','" & NonAktif & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectDataPRForList()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select DocumentNumber,DateInput,RequestedName,ReqDepartemen,ReqDate,ValidUntil,Currency,Status,Note,EnqRefrence,TotalPrice,Discount,NetPrice from tbPR where isAktif='1'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectPRDetilByDocumentNumber(DocNumber As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec SelectDetilPRbyDocNumber '" & DocNumber & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function AddPR(DatePr As String, ReqName As String, ReqDepartemen As String, ReqDate As String, validUntil As String, Currency As String,rate as String,
                   status As String, Note As String, EnqRefrence As String, totalPrice As Long, Discount As Long, NetPrice As Long, data As DataTable)

        Dim KodeMaster As String
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call addMasterPR (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@Date", OdbcType.VarChar, 50, ParameterDirection.Input).Value = DatePr
            Command.Parameters.Add("@requeredName", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ReqName
            Command.Parameters.Add("@ReqDepartemen", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ReqDepartemen
            Command.Parameters.Add("@ReqDate", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ReqDate
            Command.Parameters.Add("@ValidUntil", OdbcType.VarChar, 250, ParameterDirection.Input).Value = validUntil
            Command.Parameters.Add("@currency", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Currency
            Command.Parameters.Add("@Rate", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Rate
            Command.Parameters.Add("@Status", OdbcType.VarChar, 50, ParameterDirection.Input).Value = status
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Note
            Command.Parameters.Add("@EnqReference", OdbcType.VarChar, 50, ParameterDirection.Input).Value = EnqRefrence
            Command.Parameters.Add("@TotalPrice", OdbcType.BigInt, ParameterDirection.Input).Value = totalPrice
            Command.Parameters.Add("@Discount", OdbcType.BigInt, ParameterDirection.Input).Value = Discount
            Command.Parameters.Add("@NetPrice", OdbcType.BigInt, ParameterDirection.Input).Value = NetPrice
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20)
            Command.Parameters("@DocumentNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocumentNumber").Value
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec addDetilPR '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "'," _
                                       & "'" & data.Rows(i).Item(6) & "','" & data.Rows(i).Item(7) & "','" & data.Rows(i).Item(8) & "','" & data.Rows(i).Item(9) & "','" & data.Rows(i).Item(10) & "','" & data.Rows(i).Item(11) & "','" & EnqRefrence & "'"
                Command.ExecuteNonQuery()
            Next
            FormAddPR.DocNumberPR = KodeMaster

            Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            'MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
            MsgBox("Tidak dapat di proses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
        End Try
        ModKoneksi.TutupKoneksi()
        Return KodeMaster
    End Function

    Function SelectItemCode()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Select Itemcode,Desc from tbMasterData"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Sub EditPR(DocumentNumber As String, DatePr As String, ReqName As String, ReqDepartemen As String, ReqDate As String, validUntil As String, Currency As String, Rate As String,
              status As String, Note As String, EnqRefrence As String, totalPrice As Long, Discount As Long, NetPrice As Long, data As DataTable)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call EditMasterPR (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20, ParameterDirection.Input).Value = DocumentNumber
            Command.Parameters.Add("@Date", OdbcType.VarChar, 50, ParameterDirection.Input).Value = DatePr
            Command.Parameters.Add("@requeredName", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ReqName
            Command.Parameters.Add("@ReqDepartemen", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ReqDepartemen
            Command.Parameters.Add("@ReqDate", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ReqDate
            Command.Parameters.Add("@ValidUntil", OdbcType.VarChar, 250, ParameterDirection.Input).Value = validUntil
            Command.Parameters.Add("@currency", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Currency
            Command.Parameters.Add("@Rate", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Rate
            Command.Parameters.Add("@Status", OdbcType.VarChar, 50, ParameterDirection.Input).Value = status
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Note
            Command.Parameters.Add("@EnqRefrence", OdbcType.VarChar, 50, ParameterDirection.Input).Value = EnqRefrence
            Command.Parameters.Add("@TotalPrice", OdbcType.BigInt, ParameterDirection.Input).Value = totalPrice
            Command.Parameters.Add("@Discount", OdbcType.BigInt, ParameterDirection.Input).Value = Discount
            Command.Parameters.Add("@NetPrice", OdbcType.BigInt, ParameterDirection.Input).Value = NetPrice
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.ExecuteNonQuery()
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec addDetilPR '" & Guid.NewGuid.ToString & "','" & DocumentNumber & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "'," _
                                       & "'" & data.Rows(i).Item(6) & "','" & data.Rows(i).Item(7) & "','" & data.Rows(i).Item(8) & "','" & data.Rows(i).Item(9) & "','" & data.Rows(i).Item(10) & "','" & data.Rows(i).Item(11) & "','" & EnqRefrence & "'"
                Command.ExecuteNonQuery()
            Next

            FormAddPR.DocNumberPR = DocumentNumber
            Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            'MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
            MsgBox("Tidak dapat diproses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub

    Sub SetNonAktifPR(idPR As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = " update tbPR set isAktif='0' where DocumentNumber = '" & idPR & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            '            MsgBox("Error deleting data " + vbCrLf + "Error message: " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
            MsgBox("Tidak dapat diproses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
End Class
