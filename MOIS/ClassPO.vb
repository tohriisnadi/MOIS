Imports System.Data.Odbc
Public Class ClassPO
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function selectDataPO(aktif As String, NonAktif As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec SelectDataPO '" & aktif & "','" & NonAktif & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectVendorByIdPO(DocumentNumber As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select DocumentNumber,Vendor from tbPO where DocumentNumber='" & DocumentNumber & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectDataPOOpen()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectDataPOOpen"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectPODetilByDocNumber(DocNumber As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec SelectDetilPObyDocNumber '" & DocNumber & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectPODetilByDocNumberForGR(DocNumber As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec selectPODetilByDocNumberForGR '" & DocNumber & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function


    Function AddPO(DatePo As String, vendor As String, ppnStatus As String, Currency As String, Rate As String, DiscountHeader As String,
                   status As String, Note As String, Refrence As String, totalPrice As Long, TotalDiscount As Long, TotalPPN As Long, NetPrice As Long, data As DataTable, prnumber As String)

        Dim KodeMaster As String
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call addMasterPO (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@Date", OdbcType.VarChar, 50, ParameterDirection.Input).Value = DatePo
            Command.Parameters.Add("@Vendor", OdbcType.VarChar, 50, ParameterDirection.Input).Value = vendor
            Command.Parameters.Add("@PPNStatus", OdbcType.Char, 1, ParameterDirection.Input).Value = ppnStatus
            Command.Parameters.Add("@Currency", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Currency
            Command.Parameters.Add("@Rate", OdbcType.Int, ParameterDirection.Input).Value = Rate
            Command.Parameters.Add("@DiscountHeader", OdbcType.Int, ParameterDirection.Input).Value = DiscountHeader
            Command.Parameters.Add("@Status", OdbcType.VarChar, 50, ParameterDirection.Input).Value = status
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Note
            Command.Parameters.Add("@Refrence", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Refrence
            Command.Parameters.Add("@TotalPrice", OdbcType.BigInt, ParameterDirection.Input).Value = totalPrice
            Command.Parameters.Add("@TotalDiscount", OdbcType.BigInt, ParameterDirection.Input).Value = TotalDiscount
            Command.Parameters.Add("@TotalPPN", OdbcType.BigInt, ParameterDirection.Input).Value = TotalPPN
            Command.Parameters.Add("@NetPrice", OdbcType.BigInt, ParameterDirection.Input).Value = NetPrice
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20)
            Command.Parameters("@DocumentNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocumentNumber").Value
            FormAddPO.DocumentNumber = KodeMaster
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec addDetilPO '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "'," _
                                        & "'" & data.Rows(i).Item(6) & "','" & data.Rows(i).Item(7) & "','" & data.Rows(i).Item(8) & "','" & data.Rows(i).Item(9) & "','" & data.Rows(i).Item(10) & "','" & data.Rows(i).Item(11) & "','" & prnumber & "'"
                Command.ExecuteNonQuery()
            Next

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


    Sub EditPO(DocumentNumber As String, DatePo As String, vendor As String, PpnStatus As String, Currency As String, Rate As String, DiscountHeader As String,
               status As String, Note As String, Refrence As String, totalPrice As Long, TotalDiscount As Long, TotalPPN As Long, NetPrice As Long, data As DataTable, prnumber As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call EditMasterPO (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20, ParameterDirection.Input).Value = DocumentNumber
            Command.Parameters.Add("@Date", OdbcType.VarChar, 50, ParameterDirection.Input).Value = DatePo
            Command.Parameters.Add("@Vendor", OdbcType.VarChar, 50, ParameterDirection.Input).Value = vendor
            Command.Parameters.Add("@PPNStatus", OdbcType.Char, 1, ParameterDirection.Input).Value = PpnStatus
            Command.Parameters.Add("@Currency", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Currency
            Command.Parameters.Add("@Rate", OdbcType.Int, ParameterDirection.Input).Value = Rate
            Command.Parameters.Add("@DiscountHeader", OdbcType.Int, ParameterDirection.Input).Value = DiscountHeader
            Command.Parameters.Add("@Status", OdbcType.VarChar, 50, ParameterDirection.Input).Value = status
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Note
            Command.Parameters.Add("@Refrence", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Refrence
            Command.Parameters.Add("@TotalPrice", OdbcType.BigInt, ParameterDirection.Input).Value = totalPrice
            Command.Parameters.Add("@TotalDiscount", OdbcType.BigInt, ParameterDirection.Input).Value = TotalDiscount
            Command.Parameters.Add("@TotalPPN", OdbcType.BigInt, ParameterDirection.Input).Value = TotalPPN
            Command.Parameters.Add("@NetPrice", OdbcType.BigInt, ParameterDirection.Input).Value = NetPrice
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.ExecuteNonQuery()
            ' id = '" & Guid.NewGuid.ToString & "'
            For i As Integer = 0 To data.Rows.Count - 1
                Command.CommandText = "exec addDetilPO '" & Guid.NewGuid.ToString & "','" & DocumentNumber & "','" & data.Rows(i).Item(1) & "','" & data.Rows(i).Item(2) & "','" & data.Rows(i).Item(3) & "','" & data.Rows(i).Item(4) & "','" & data.Rows(i).Item(5) & "'," _
                                        & "'" & data.Rows(i).Item(6) & "','" & data.Rows(i).Item(7) & "','" & data.Rows(i).Item(8) & "','" & data.Rows(i).Item(9) & "','" & data.Rows(i).Item(10) & "','" & data.Rows(i).Item(11) & "','" & prnumber & "'"
                Command.ExecuteNonQuery()
            Next

            'Command.Parameters.Clear()
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            'MsgBox("Pesan Error : " + vbCrLf + ex.Message + vbCrLf + "Data gagal disimpan ! ", MsgBoxStyle.Critical, "Error")
            MsgBox("Tidak dapat di proses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub

    Sub SetNonAktiPO(id As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec SetNonAktiPO '" & id & "'"
        Try
            Command.ExecuteNonQuery()
            dbTrans.Commit()
            MsgBox("Data deleted", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            'MsgBox("Error deleting data " + vbCrLf + "Error message: " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
            MsgBox("Tidak dapat di proses" + vbCrLf + "Periksa inputan anda", vbInformation, "Information")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
End Class
