Imports System.Data.Odbc
Public Class ClassPayment
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function selectDataPayment()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select DocumentNumber,TypeOfPayment,[Cash/BankAccount],Currency,Rate,DateInput,PartnerType,PartnerName,TotalPayment,TotalPaymentIDR,Note,TotalRefInvAmmount,TotalPaymentAmount from tbPayment where isAktif='1'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectDataVendorInvoice()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select DocumentNumber,Currency,Rate,TermOfPayment,BaseLineDate,NetPrice from tbVendorInvoice where isAktif='1'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectDataSalesBilling()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select DocumentNumber,Currency,Rate,TermOfPayment,BaseLineDate,NetPrice from tbSalesBilling where isAktif='1'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function loaddetilbyid(id As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Select Reference,ReferenceInformation,RefInvoiceAmount,PaymentAmount,PaymentAmountinIDR,Remarks from tbPaymentDetils"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function


    Function AddPayment(typeOfPayment As String, CashBankAccount As String, currency As String, rate As Integer, dateinput As String, partnerType As String, PartnerName As String,
                        totalpayment As Long, totalpaymentIDR As Long, note As String, totalrefinvAmount As Long, totalPaymentAmount As Long, Data As DataTable)

        Dim KodeMaster As String = ""
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{Call AddPayment (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@TypeofPayment", OdbcType.VarChar, 50, ParameterDirection.Input).Value = typeOfPayment
            Command.Parameters.Add("@CashBankAcount", OdbcType.VarChar, 50, ParameterDirection.Input).Value = CashBankAccount
            Command.Parameters.Add("@Currency", OdbcType.VarChar, 50, ParameterDirection.Input).Value = currency
            Command.Parameters.Add("@Rate", OdbcType.VarChar, 250, ParameterDirection.Input).Value = rate
            Command.Parameters.Add("@dateinput", OdbcType.VarChar, 50, ParameterDirection.Input).Value = dateinput
            Command.Parameters.Add("@PartnerType", OdbcType.VarChar, 50, ParameterDirection.Input).Value = partnerType
            Command.Parameters.Add("@PartnerName", OdbcType.VarChar, 50, ParameterDirection.Input).Value = PartnerName
            Command.Parameters.Add("@TotalPayment", OdbcType.VarChar, 50, ParameterDirection.Input).Value = totalpayment
            Command.Parameters.Add("@TotalPaymentinIDR", OdbcType.VarChar, 250, ParameterDirection.Input).Value = totalpaymentIDR
            Command.Parameters.Add("@Note", OdbcType.VarChar, 50, ParameterDirection.Input).Value = note
            Command.Parameters.Add("@TotalRefInvAmount", OdbcType.BigInt, ParameterDirection.Input).Value = totalrefinvAmount
            Command.Parameters.Add("@TOtalPaymentAmount", OdbcType.BigInt, ParameterDirection.Input).Value = totalPaymentAmount
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.Parameters.Add("@DocNumber", OdbcType.VarChar, 50)
            Command.Parameters("@DocNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocNumber").Value
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To Data.Rows.Count - 1
                Command.CommandText = "exec addDetilPayment '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & Data.Rows(i).Item(1) & "','" & Data.Rows(i).Item(2) & "','" & Data.Rows(i).Item(3) & "','" & Data.Rows(i).Item(4) & "','" & Data.Rows(i).Item(5) & "'," _
                                       & "'" & Data.Rows(i).Item(6) & "'"
                Command.ExecuteNonQuery()
            Next
            FormAddPayment.Docnumber = KodeMaster
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

    Sub SetNonAktifPayment(id As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = " update tbPayment set isAktif='0' where DocumentNumber = '" & id & "'"
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
