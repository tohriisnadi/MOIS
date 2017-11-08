Imports System.Data.Odbc
Public Class ClassGR
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function selectDataGR(aktif As String, NonAktif As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectDataGR '" & aktif & "','" & NonAktif & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectDataGRForList()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select DocumentNumber,DateInput,BillOfLading,ShippingMethod,Refrence,ShipVia,DeliveryNote,DeliveryDate,Note fRom tbgr WHERE IsAktif='1'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectDetilGRbyId(id As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select a.CL,a.ItemCode,b.Description1,b.uom,a.Qty,a.WHS,a.Allocation,A.Remarks from tbGRDetils a join tbMasterItemMD b on a.ItemCode = b.ItemCode where a.DocumentNumebr='" & id & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectDetilGRForAP(id As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectSisaQtyAPbyGR '" & id & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function selectGRDetilByDocNumber(DocNumber As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "Exec SelectDetilGRbyDocNumber '" & DocNumber & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function AddGR(DateGR As String, DeliveryNote As String, BillOfLading As String, Reference As String, ShipVia As String,
                   shippingMethod As String, Notes As String, DeliveryDate As String, Data As DataTable)

        Dim KodeMaster As String
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = "{call addMasterGR (?,?,?,?,?,?,?,?,?,?,?)}"
        Try
            Command.Parameters.Add("@Date", OdbcType.VarChar, 50, ParameterDirection.Input).Value = DateGR
            Command.Parameters.Add("@DeliveryNote", OdbcType.VarChar, 50, ParameterDirection.Input).Value = DeliveryNote
            Command.Parameters.Add("@BillOfLading", OdbcType.VarChar, 50, ParameterDirection.Input).Value = BillOfLading
            Command.Parameters.Add("@Ref", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Reference
            Command.Parameters.Add("@ShipVia", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ShipVia
            Command.Parameters.Add("@ShippingMethod", OdbcType.VarChar, 50, ParameterDirection.Input).Value = shippingMethod
            Command.Parameters.Add("@Note", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Notes
            Command.Parameters.Add("@DeliveryDate", OdbcType.VarChar, 250, ParameterDirection.Input).Value = DeliveryDate
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator

            Command.Parameters.Add("@DocumentNumber", OdbcType.VarChar, 20)
            Command.Parameters("@DocumentNumber").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeMaster = Command.Parameters("@DocumentNumber").Value
            FormAddPO.DocumentNumber = KodeMaster
            For i As Integer = 0 To Data.Rows.Count - 1
                Command.CommandText = "exec addDetilGR '" & Guid.NewGuid.ToString & "','" & KodeMaster & "','" & Data.Rows(i).Item(1) & "','" & Data.Rows(i).Item(2) & "','" & Data.Rows(i).Item(3) & "','" & Data.Rows(i).Item(4) & "'," _
                                        & "'" & Data.Rows(i).Item(5) & "','" & Data.Rows(i).Item(6) & "','" & Data.Rows(i).Item(7) & "','" & Data.Rows(i).Item(8) & "','" & Reference & "','" & DateGR & "'"
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

    Sub SetNonAktifGR(Id As String)
        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.Text
        Command.CommandText = "update tbGR set isAktif='0' where DocumentNumber = '" & Id & "'"
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
