Imports System.Data.Odbc
Public Class ClassCompanySetup
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Sub AddCompanySetup(CompanyName As String, address As String, Telp As String, Fax As String, Website As String, DirektorName As String, TaxId As String, image As Image)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = String.Format("exec addCompanySetup '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'", CompanyName, address, Telp, Fax, Website, DirektorName, TaxId, image)
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

    Sub EditCompanySetup(idCompanySetup As String, CompanyName As String, address As String, Telp As String, Fax As String, Website As String, DirektorName As String, TaxId As String, image As Image)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = String.Format("exec EditCompanySetup '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", idCompanySetup, CompanyName, address, Telp, Fax, Website, DirektorName, TaxId, image)
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

    Function SelectCompanySetup()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select * from tbcompanySetup"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

End Class
