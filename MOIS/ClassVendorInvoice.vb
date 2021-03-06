﻿Imports System.Data.Odbc
Public Class ClassVendorInvoice
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function selectDataVendorInvoice()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select DocumentNumber,Vendor,ContactPerson,Reference,Currency,Rate,DateInput,TermOfPayment,Discount,PPNStatus,Note,BaseLineDate,TotalPrice,TotalDiscount,TotalPPN,NetPrice,IsAktif from tbVendorInvoice" ' where isAktif='1'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectDetilbyIdMaster(SalesBillingId As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select a.CL,a.ItemCode,a.Description,a.uom,a.Qty,a.UnitPrice,a.DiscountType,a.Discount,a.Total,a.Remarks,a.GRNumber from tbVendorInvoiceDetils a inner join tbMasterItemMD b on a.ItemCode = b.ItemCode where a.VendorInvoiceId='" & SalesBillingId & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectSisaQtyAPbyGR(SalesBillingId As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select a.CL,a.ItemCode,b.Description1,b.UOM,a.Qty,a.UnitPrice,a.DiscountType,a.Discount,a.Total,a.Remarks,a.GRNumber from tbVendorInvoiceDetils a inner join tbMasterItemMD b on a.ItemCode = b.ItemCode where a.VendorInvoiceId='" & SalesBillingId & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function AddVendorInvoice(customer As String, ContactPerson As String, Ref As String, Currency As String, rate As String, dateinput As String, TermOfPayment As String,
                    Discount As Integer, ppnStatus As String, note As String, BaseLineDate As String, TotalPrice As Long, TotalDiscount As Long, TotalPPN As Long, NetPrice As Long, data As DataTable)

        Dim KodeMaster As String = ""
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call AddVendorInvoice (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@Customer", OdbcType.VarChar, 50, ParameterDirection.Input).Value = customer
            Command.Parameters.Add("@ContactPerson", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ContactPerson
            Command.Parameters.Add("@Reference", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Ref
            Command.Parameters.Add("@Currency", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Currency
            Command.Parameters.Add("@Rate", OdbcType.Int, ParameterDirection.Input).Value = rate
            Command.Parameters.Add("@dateinput", OdbcType.VarChar, 50, ParameterDirection.Input).Value = dateinput
            Command.Parameters.Add("@TermOfPayment", OdbcType.VarChar, 50, ParameterDirection.Input).Value = TermOfPayment
            Command.Parameters.Add("@Discount", OdbcType.Int, ParameterDirection.Input).Value = Discount
            Command.Parameters.Add("@PPNStatus", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ppnStatus
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = note
            Command.Parameters.Add("@BaseLineDate", OdbcType.VarChar, 50, ParameterDirection.Input).Value = BaseLineDate
            Command.Parameters.Add("@TotalPrice", OdbcType.BigInt, ParameterDirection.Input).Value = TotalPrice
            Command.Parameters.Add("@TotalDiscount", OdbcType.BigInt, ParameterDirection.Input).Value = TotalDiscount
            Command.Parameters.Add("@TotalPPN", OdbcType.BigInt, ParameterDirection.Input).Value = TotalPPN
            Command.Parameters.Add("@NetPrice", OdbcType.BigInt, ParameterDirection.Input).Value = NetPrice
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.Parameters.Add("@DocNumber", OdbcType.VarChar, 50)
            Command.Parameters("@DocNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocNumber").Value
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec AddDetilsVendorInvoice '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "','" & data.Rows(i).Item(6) & "'," _
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

    Sub SetNonAktifVendorInvoice(id As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = " update tbVendorInvoice set isAktif='0' where DocumentNumber= '" & id & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Tidak dapat diproses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
            'MsgBox("Error deleting data " + vbCrLf + "Error message: " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
End Class
