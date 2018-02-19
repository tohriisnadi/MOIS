Imports System.Data.Odbc
Public Class ClassPriceList
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function SelectPriceList()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select id,PLCode,Description,CONVERT(varchar(20),ValidFrom,111),CONVERT(varchar(20),Validto,111),Purchase,Sell,PartnerID,Refrence from tbPriceList where isAktif='1'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectpricelistbyItemCode(itemcode As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec selectpricelistbyItemCode '" & itemcode & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectPricelistdetilbyitemcode(Itemcode As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec selectPricelistdetilbyitemcode '" & Itemcode & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectPricelistdetilAll()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec selectpricelistdetilAll"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function


    Function SelectPriceListDetilByIdPL(idPL As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectPriceListDetilbyIdPL '" & idPL & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Sub AddMasterPriceList(PriceListCode As String, Desc As String, ValidFrom As String, ValidTo As String, purchase As Char, Sell As String, partnerid As String, Refrence As String, data As DataTable)
        Dim KodeMaster As String
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Try
            Command.CommandText = "{call addMasterPricelist (?,?,?,?,?,?,?,?,?,?,?)}"
            Command.Parameters.Clear()
            Command.Parameters.Add("@PLCode", OdbcType.VarChar, 20, ParameterDirection.Input).Value = PriceListCode
            Command.Parameters.Add("@Desc", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Desc
            Command.Parameters.Add("@ValidFrom", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ValidFrom
            Command.Parameters.Add("@ValidTo", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ValidTo
            Command.Parameters.Add("@Purchase", OdbcType.Char, 1, ParameterDirection.Input).Value = purchase
            Command.Parameters.Add("@Sell", OdbcType.Char, 1, ParameterDirection.Input).Value = Sell
            Command.Parameters.Add("@PartnerID", OdbcType.VarChar, 50, ParameterDirection.Input).Value = partnerid
            Command.Parameters.Add("@Refrence", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Refrence
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@NamaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.Parameters.Add("@idPL", OdbcType.VarChar, 50)
            Command.Parameters("@idPL").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@idPL").Value

            For i = 0 To data.Rows.Count - 1
                Command.CommandText = "exec AddDetilPriceList '" & KodeMaster & "','" & PriceListCode & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "'"
                Command.ExecuteNonQuery()
            Next
            Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Data Not Save" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub

    Sub EditMasterPriceList(idPL As String, PriceListCode As String, Desc As String, ValidFrom As String, ValidTo As String, purchase As Char, Sell As String, partnerid As String, Refrence As String, data As DataTable)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Try
            Command.CommandText = "{ call EditMasterPricelist (?,?,?,?,?,?,?,?,?,?,?)}"
            Command.Parameters.Clear()
            Command.Parameters.Add("@idPL", OdbcType.VarChar, 20, ParameterDirection.Input).Value = idPL
            Command.Parameters.Add("@PLCode", OdbcType.VarChar, 20, ParameterDirection.Input).Value = PriceListCode
            Command.Parameters.Add("@Desc", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Desc
            Command.Parameters.Add("@ValidFrom", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ValidFrom
            Command.Parameters.Add("@ValidTo", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ValidTo
            Command.Parameters.Add("@Purchase", OdbcType.Char, 1, ParameterDirection.Input).Value = purchase
            Command.Parameters.Add("@Sell", OdbcType.Char, 1, ParameterDirection.Input).Value = Sell
            Command.Parameters.Add("@PartnerID", OdbcType.VarChar, 50, ParameterDirection.Input).Value = partnerid
            Command.Parameters.Add("@Refrence", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Refrence
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@NamaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.ExecuteNonQuery()

            For i = 0 To data.Rows.Count - 1
                Command.CommandText = "exec AddDetilPriceList '" & idPL & "','" & PriceListCode & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "'"
                Command.ExecuteNonQuery()
            Next

            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Data Not Save" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub

    Sub SetNonAktifPriceList(idPL As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = " update tbPriceList set isAktif='0' where id = '" & idPL & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Error deleting data " + vbCrLf + "Error message: " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
End Class
