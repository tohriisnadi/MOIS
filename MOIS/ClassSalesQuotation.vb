Imports System.Data.Odbc
Public Class ClassSalesQuotation
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function selectDataSalesQuotation(aktif As String, NonAktif As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec SelectDataSalesQuotation '" & aktif & "','" & NonAktif & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectCustomerforcb()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select CustomerID,Name from tbcustomer"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectDetilbyIdMaster(SqId As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec SelectDetilSalesQuotaionByid'" & SqId & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function AddSalesQuotation(customer As String, ContactPerson As String, Ref As String, Currency As String, rate As String, dateinput As String, validuntil As String, salesPerson As String,
                               Discount As Integer, ppnStatus As String, note As String, TotalPrice As Long, TotalDiscount As Long, TotalPPN As Long, NetPrice As Long, project As String, data As DataTable)

        Dim KodeMaster As String = ""
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call AddSalesQuotation (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@Customer", OdbcType.VarChar, 50, ParameterDirection.Input).Value = customer
            Command.Parameters.Add("@ContactPerson", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ContactPerson
            Command.Parameters.Add("@Reference", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Ref
            Command.Parameters.Add("@Currency", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Currency
            Command.Parameters.Add("@Rate", OdbcType.VarChar, 250, ParameterDirection.Input).Value = rate
            Command.Parameters.Add("@dateinput", OdbcType.VarChar, 50, ParameterDirection.Input).Value = dateinput
            Command.Parameters.Add("@ValidUntil", OdbcType.VarChar, 50, ParameterDirection.Input).Value = validuntil
            Command.Parameters.Add("@SalesPerson", OdbcType.VarChar, 250, ParameterDirection.Input).Value = salesPerson
            Command.Parameters.Add("@Discount", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Discount
            Command.Parameters.Add("@PPNStatus", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ppnStatus
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = note
            Command.Parameters.Add("@TotalPrice", OdbcType.BigInt, ParameterDirection.Input).Value = TotalPrice
            Command.Parameters.Add("@TotalDiscount", OdbcType.BigInt, ParameterDirection.Input).Value = TotalDiscount
            Command.Parameters.Add("@TotalPPN", OdbcType.BigInt, ParameterDirection.Input).Value = TotalPPN
            Command.Parameters.Add("@NetPrice", OdbcType.BigInt, ParameterDirection.Input).Value = NetPrice
            Command.Parameters.Add("@Project", OdbcType.VarChar, 50, ParameterDirection.Input).Value = project
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.Parameters.Add("@DocNumber", OdbcType.VarChar, 50)
            Command.Parameters("@DocNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocNumber").Value
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec addDetilSalesQuotation '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "','" & data.Rows(i).Item(6) & "'," _
                                       & "'" & data.Rows(i).Item(7) & "','" & data.Rows(i).Item(8) & "','" & data.Rows(i).Item(9) & "','" & data.Rows(i).Item(10) & "','" & data.Rows(i).Item(11) & "'"
                Command.ExecuteNonQuery()
            Next

            Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            'MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
            MsgBox("Tidak dapat diproses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
        End Try
        ModKoneksi.TutupKoneksi()
        Return KodeMaster
    End Function

    Sub EditSalesQuotation(salesQuotationid As String, customer As String, ContactPerson As String, Ref As String, Currency As String, rate As String, dateinput As String, validuntil As String, salesPerson As String,
                              Discount As Integer, ppnStatus As String, note As String, TotalPrice As Long, TotalDiscount As Long, TotalPPN As Long, NetPrice As Long, project As String, data As DataTable)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call EditSalesQuotation (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@SalesQuotationid", OdbcType.VarChar, 50, ParameterDirection.Input).Value = salesQuotationid
            Command.Parameters.Add("@Customer", OdbcType.VarChar, 50, ParameterDirection.Input).Value = customer
            Command.Parameters.Add("@ContactPerson", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ContactPerson
            Command.Parameters.Add("@Reference", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Ref
            Command.Parameters.Add("@Currency", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Currency
            Command.Parameters.Add("@Rate", OdbcType.VarChar, 250, ParameterDirection.Input).Value = rate
            Command.Parameters.Add("@dateinput", OdbcType.VarChar, 50, ParameterDirection.Input).Value = dateinput
            Command.Parameters.Add("@ValidUntil", OdbcType.VarChar, 50, ParameterDirection.Input).Value = validuntil
            Command.Parameters.Add("@SalesPerson", OdbcType.VarChar, 250, ParameterDirection.Input).Value = salesPerson
            Command.Parameters.Add("@Discount", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Discount
            Command.Parameters.Add("@PPNStatus", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ppnStatus
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = note
            Command.Parameters.Add("@TotalPrice", OdbcType.BigInt, ParameterDirection.Input).Value = TotalPrice
            Command.Parameters.Add("@TotalDiscount", OdbcType.BigInt, ParameterDirection.Input).Value = TotalDiscount
            Command.Parameters.Add("@TotalPPN", OdbcType.BigInt, ParameterDirection.Input).Value = TotalPPN
            Command.Parameters.Add("@NetPrice", OdbcType.BigInt, ParameterDirection.Input).Value = NetPrice
            Command.Parameters.Add("@Project", OdbcType.VarChar, 50, ParameterDirection.Input).Value = project
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.ExecuteNonQuery()
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec addDetilSalesQuotation '" & Guid.NewGuid.ToString & "','" & salesQuotationid & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "','" & data.Rows(i).Item(6) & "'," _
                                       & "'" & data.Rows(i).Item(7) & "','" & data.Rows(i).Item(8) & "','" & data.Rows(i).Item(9) & "','" & data.Rows(i).Item(10) & "','" & data.Rows(i).Item(11) & "'"
                Command.ExecuteNonQuery()
            Next

            Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Tidak dapat diproses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
            ' MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub

    Sub SetNonAktifSalesQuotation(id As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = " update tbSalesQuotation set isAktif='0' where DocumentNumber = '" & id & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Tidak dapat diproses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
            '  MsgBox("Error deleting data " + vbCrLf + "Error message: " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
End Class
