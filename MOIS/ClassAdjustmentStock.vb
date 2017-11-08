Imports System.Data.Odbc
Public Class ClassAdjustmentStock
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function AddAdjustmentIn(DateAdj As String, Type As String, CountBy As String, ApproveBy As String, Reference As String, Notes As String, Data As DataTable)
        Dim Desc As String
        Dim KodeMaster As String
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call addStoctAdjustmentIn (?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@Date", OdbcType.VarChar, 50, ParameterDirection.Input).Value = DateAdj
            Command.Parameters.Add("@Type", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Type
            Command.Parameters.Add("@CountBy", OdbcType.VarChar, 50, ParameterDirection.Input).Value = CountBy
            Command.Parameters.Add("@ApproveBy", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ApproveBy
            Command.Parameters.Add("@Reference", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Reference
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Notes
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator

            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20)
            Command.Parameters("@DocumentNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocumentNumber").Value
            FormAddPO.DocumentNumber = KodeMaster

            For i As Integer = 0 To Data.Rows.Count - 1
                Desc = Data.Rows(i).Item(2)
                Command.CommandText = "exec addDetilGR '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & Data.Rows(i).Item(0) & "','" & Data.Rows(i).Item(1) & "','" & Desc & "','" & Data.Rows(i).Item(5) & "'," _
                                        & "'" & Data.Rows(i).Item(3) & "','" & Data.Rows(i).Item(4) & "','" & Data.Rows(i).Item(5) & "','" & Data.Rows(i).Item(6) & "','" & Reference & "','" & DateAdj & "'"
                Command.ExecuteNonQuery()
            Next

            Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
        Return KodeMaster
    End Function

    Function AddAdjustmentOut(DateAdj As String, Type As String, CountBy As String, ApproveBy As String, Reference As String, Notes As String, Data As DataTable)

        Dim KodeMaster As String
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call addStoctAdjustmentIn (?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@Date", OdbcType.VarChar, 50, ParameterDirection.Input).Value = DateAdj
            Command.Parameters.Add("@Type", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Type
            Command.Parameters.Add("@CountBy", OdbcType.VarChar, 50, ParameterDirection.Input).Value = CountBy
            Command.Parameters.Add("@ApproveBy", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ApproveBy
            Command.Parameters.Add("@Reference", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Reference
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Notes
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator

            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20)
            Command.Parameters("@DocumentNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocumentNumber").Value
            FormAddPO.DocumentNumber = KodeMaster

            'For i As Integer = 0 To Data.Rows.Count - 1
            '    Command.CommandText = "exec addDetilGR '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & Data.Rows(i).Item(1) & "','" & Data.Rows(i).Item(2) & "','" & Data.Rows(i).Item(3) & "','" & Data.Rows(i).Item(4) & "'," _
            '                            & "'" & Data.Rows(i).Item(5) & "','" & Data.Rows(i).Item(6) & "','" & Data.Rows(i).Item(7) & "','" & Data.Rows(i).Item(8) & "','" & Reference & "'"
            '    Command.ExecuteNonQuery()
            'Next
            '--------------------------------
            For i As Integer = 0 To Data.Rows.Count - 1
                Command.CommandText = "exec addDetilDelivery '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & Data.Rows(i).Item(0) & "','" & Data.Rows(i).Item(1) & "','" & Data.Rows(i).Item(5) & "','0'," _
                                       & "'0 ','0',' 0 ','" & Data.Rows(i).Item(6) & "','" & Reference & "','" & DateAdj & "'"
                Command.ExecuteNonQuery()
            Next

            Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
        Return KodeMaster
    End Function
End Class
