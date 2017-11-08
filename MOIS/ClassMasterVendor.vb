Imports System.Data.Odbc
Public Class ClassMasterVendor
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function SelectMasterVendor()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectMasterVendor"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectVendorByID(id As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec selecVendorByID '" & id & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectMasterVendorMiniById(id as String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select VendorCode,Name,Telp,Fax from tbMasterVendor where VendorCode='"& id &"'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function validationcode(VendorCode As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select VendorCode from tbMasterVendor where VendorCode='" & VendorCode & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Sub AddMasterVendor(VendorCode As String, name As String, OtherName As String, VendorGroup As String, AVLNumber As Integer, AVLSegment As String,
                        TaxId As String, Telp As String, Fax As String, MobilePhone As String, Email As String, ContactPerson As String, Website As String,
                        Remarks As String, PaymentTerm As Integer, CreditLimit As Long, Discount As String, Pricelist As String, Bank As String, Account As String,
                        IBAN As String, SwiftCode As String, KodeOperator As String, NamaOperator As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec AddMasterVendor '" & VendorCode & "','" & name & "','" & OtherName & "','" & VendorGroup & "','" & AVLNumber & "','" & AVLSegment & "',
                                '" & TaxId & "','" & Telp & "','" & Fax & "','" & MobilePhone & "','" & Email & "','" & ContactPerson & "','" & Website & "',
                                '" & Remarks & "','" & PaymentTerm & "','" & CreditLimit & "','" & Discount & "','" & Pricelist & "','" & Bank & "','" & Account & "',
                                '" & IBAN & "','" & SwiftCode & "','" & KodeOperator & "','" & NamaOperator & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data hase been deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Error deleting data" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub

    Sub EditMasterVendor(idMV As String, VendorCode As String, name As String, OtherName As String, VendorGroup As String, AVLNumber As Integer, AVLSegment As String,
                        TaxId As String, Telp As String, Fax As String, MobilePhone As String, Email As String, ContactPerson As String, Website As String,
                        Remarks As String, PaymentTerm As Integer, CreditLimit As Long, Discount As String, Pricelist As String, Bank As String, Account As String,
                        IBAN As String, SwiftCode As String, KodeOperator As String, NamaOperator As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec EditMasterVendor '" & idMV & "','" & VendorCode & "','" & name & "','" & OtherName & "','" & VendorGroup & "','" & AVLNumber & "','" & AVLSegment & "',
                                '" & TaxId & "','" & Telp & "','" & Fax & "','" & MobilePhone & "','" & Email & "','" & ContactPerson & "','" & Website & "',
                                '" & Remarks & "','" & PaymentTerm & "','" & CreditLimit & "','" & Discount & "','" & Pricelist & "','" & Bank & "','" & Account & "',
                                '" & IBAN & "','" & SwiftCode & "','" & KodeOperator & "','" & NamaOperator & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data hase been deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Error deleting data" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub


    Sub SetNonAktifMasterVendor(idMV As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = "UPDATE tbMasterVendor SET isAktif='0' where id='" & idMV & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data hase been deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Error deleting data" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub

End Class
