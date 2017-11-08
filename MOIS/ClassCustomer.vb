Imports System.Data.Odbc
Public Class ClassCustomer
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function selectDataCustomer()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select id,CustomerID, Name,OtherName,CustType,SalesPerson,CreditStatus,TaxId,Telp,Fax,MobilePhone,Email,ContactPerson,Website,Address,PaymentTerms,CreditLimit,discount,PriceList from tbCustomer"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectDataCustomerByID(id As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec selecCustomerbyID '" & id & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectDataCustomerMiniById(id as String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select CustomerID,Name,Telp,Fax from tbCustomer where CustomerID='"& id &"'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function


    Sub AddCustomer(CustID As String, Name As String, OtherName As String, CustType As String, SalesPerson As String, CreditStatus As String, TaxId As String, telp As String, Fax As String, MobilePhone As String,
                    Email As String, ContactPerson As String, Website As String, remark As String, paymentTerm As String, creditLimit As Long, discount As Long, PriceList As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = String.Format("exec AddCustomer '" & CustID & "','" & Name & "','" & OtherName & "','" & CustType & "','" & SalesPerson & "','" & CreditStatus & "','" & TaxId & "','" & telp & "','" & Fax & "','" & MobilePhone & "','" & Email & "',
                                            '" & ContactPerson & "','" & Website & "','" & remark & "','" & paymentTerm & "','" & creditLimit & "','" & discount & "','" & PriceList & "'")
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Data Not Save" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub

    Sub EditCustomer(Id As String, CustID As String, Name As String, OtherName As String, CustType As String, SalesPerson As String, CreditStatus As String, TaxId As String, telp As String, Fax As String, MobilePhone As String,
                    Email As String, ContactPerson As String, Website As String, remark As String, paymentTerm As String, creditLimit As Long, discount As Long, PriceList As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = String.Format("exec EditCustomer '" & Id & "','" & CustID & "','" & Name & "','" & OtherName & "','" & CustType & "','" & SalesPerson & "','" & CreditStatus & "','" & TaxId & "','" & telp & "','" & Fax & "','" & MobilePhone & "','" & Email & "',
                                            '" & ContactPerson & "','" & Website & "','" & remark & "','" & paymentTerm & "','" & creditLimit & "','" & discount & "','" & PriceList & "'")
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Data Not Save" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
End Class
