Imports System.Data.Odbc
Public Class ClassItemMD
    Dim Command As New OdbcCommand
    Dim oDataAdapter As New OdbcDataAdapter
    Dim dbTrans As OdbcTransaction

    Function SelectMasterItemMD()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectMasterItemMD"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function validationCode(ItemCode As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select ItemCode from tbMasterItemMD where ItemCode='" & ItemCode & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectItemMDMini()
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select ItemCode,Description1,UOM,genItem from tbMasterItemMD where isAktif='1'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectInventoryItembyIdMD(idItemMD As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectInventoryItemByItemMD '" & idItemMD & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectSalesItembyIdMD(idItemMD As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectSalesItemByItemMD '" & idItemMD & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectPurchaseItembyIdMD(idItemMD As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "exec SelectPurchaseItemByItemMD '" & idItemMD & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Function SelectUOMFactor(idItemMD As String)
        Dim oDataTabel As New DataTable
        ModKoneksi.BukaKoneksi()
        Command.Connection = ModKoneksi.Koneksi
        Command.CommandType = CommandType.Text
        Command.CommandText = "select UOM,Factor from tbUomFactor where idItemMD = '" & idItemMD & "'"
        oDataAdapter.SelectCommand = Command
        oDataAdapter.Fill(oDataTabel)
        ModKoneksi.TutupKoneksi()
        Return oDataTabel
    End Function

    Dim KdItemMasterData As String
    Function addMasterItemMD(genItem As String, ItemCode As String, Desc1 As String, Desc2 As String, ItemGroup As String, InventoryItem As String, SalesItem As String, PurchaseItem As String, Manufactur As String, HSCode As String, ShippingType As String, Uom As String, data As DataTable,
                             InWeight As Integer, InminStock As Integer, InmaxStock As Integer, InReorderPoin As String, InLength As Integer, Inwidth As Integer, InHeight As Integer, InVolume As String,
                             sTaxGroup As String, sUom As String, sMinOrderQty As String, sPacking As String, sLength As Integer, swidth As Integer, sheight As Integer, sVolume As String,
                             pTaxGroup As String, pPrefVendor As String, pUOM As String, pMinOrderQty As Integer, pOrderInterval As Integer, pLeadTime As Integer, pLength As Integer, pWidth As Integer, pHeight As Integer, pVolume As String, pGRProcessingTime As Integer)
        Dim KodeItemMD As String

        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        'Command.CommandText = "exec addMasterItemMD '" & ItemCode & "','" & Desc1 & "','" & Desc2 & "','" & ItemGroup & "','" & InventoryItem & "','" & SalesItem & "','" & PurchaseItem & "','" & Manufactur & "','" & HSCode & "','" & ShippingType & "','" & Uom & "'"
        Try
            Command.CommandText = "{ call addMasterItemMD (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
            Command.Parameters.Clear()
            Command.Parameters.Add("@ItemCode", OdbcType.VarChar, 20, ParameterDirection.Input).Value = ItemCode
            Command.Parameters.Add("@Desc1", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Desc1
            Command.Parameters.Add("@Desc2", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Desc2
            Command.Parameters.Add("@ItemGroup", OdbcType.VarChar, 20, ParameterDirection.Input).Value = ItemGroup
            Command.Parameters.Add("@inventoryItem", OdbcType.Char, 1, ParameterDirection.Input).Value = InventoryItem
            Command.Parameters.Add("@SalesItem", OdbcType.Char, 1, ParameterDirection.Input).Value = SalesItem
            Command.Parameters.Add("@PurchaseItem", OdbcType.Char, 1, ParameterDirection.Input).Value = PurchaseItem
            Command.Parameters.Add("@Manufactur", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Manufactur
            Command.Parameters.Add("@HSCode", OdbcType.VarChar, 50, ParameterDirection.Input).Value = HSCode
            Command.Parameters.Add("@ShippingType", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ShippingType
            Command.Parameters.Add("@UOM", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Uom
            Command.Parameters.Add("@GenItem", OdbcType.VarChar, 50, ParameterDirection.Input).Value = genItem
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.Parameters.Add("@idItemMD", OdbcType.VarChar, 20)
            Command.Parameters("@idItemMD").Direction = ParameterDirection.Output
            Command.ExecuteNonQuery()
            KodeItemMD = Command.Parameters("@idItemMD").Value
            KdItemMasterData = KodeItemMD

            For i = 0 To data.Rows.Count - 1
                Command.CommandText = "INSERT Into tbUomFactor(idItemMD, UOM, Factor) Values ('" & KdItemMasterData & "','" & data.Rows(i).Item(0) & "','" & data.Rows(i).Item(1) & "')"
                Command.ExecuteNonQuery()
            Next
            If InventoryItem = "1" Then
                Command.CommandText = "exec addInventoryItem '" & KdItemMasterData & "','" & InWeight & "','" & InminStock & "','" & InmaxStock & "','" & InReorderPoin & "','" & InLength & "','" & Inwidth & "','" & InHeight & "','" & InVolume & "'"
                Command.ExecuteNonQuery()
            ElseIf SalesItem = "1" Then
                Command.CommandText = "exec addSalesItem '" & KdItemMasterData & "','" & sTaxGroup & "','" & sUom & "','" & sMinOrderQty & "','" & sPacking & "','" & sLength & "','" & swidth & "','" & sheight & "','" & sVolume & "'"
                Command.ExecuteNonQuery()
            ElseIf PurchaseItem = "1" Then
                Command.CommandText = "exec addPurchaseItem '" & KdItemMasterData & "','" & pTaxGroup & "','" & pPrefVendor & "','" & pUOM & "','" & pMinOrderQty & "','" & pOrderInterval & "','" & pLeadTime & "','" & pLength & "','" & pWidth & "','" & pHeight & "','" & pVolume & "','" & pGRProcessingTime & "'"
                Command.ExecuteNonQuery()
            End If
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Data Not Save" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
        Return KdItemMasterData
    End Function


    Sub EditMasterItemMD(idItemMD As String, genItem As String, ItemCode As String, Desc1 As String, Desc2 As String, ItemGroup As String, InventoryItem As String, SalesItem As String, PurchaseItem As String, Manufactur As String, HSCode As String, ShippingType As String, Uom As String, data As DataTable,
                             InWeight As Integer, InminStock As Integer, InmaxStock As Integer, InReorderPoin As String, InLength As Integer, Inwidth As Integer, InHeight As Integer, InVolume As String,
                             sTaxGroup As String, sUom As String, sMinOrderQty As String, sPacking As String, sLength As Integer, swidth As Integer, sheight As Integer, sVolume As String,
                             pTaxGroup As String, pPrefVendor As String, pUOM As String, pMinOrderQty As Integer, pOrderInterval As Integer, pLeadTime As Integer, pLength As Integer, pWidth As Integer, pHeight As Integer, pVolume As String, pGRProcessingTime As Integer)
        Dim KodeItemMD As String

        ModKoneksi.BukaKoneksi()
        dbTrans = ModKoneksi.Koneksi.BeginTransaction
        Command.Connection = ModKoneksi.Koneksi
        Command.Transaction = dbTrans
        Command.CommandType = CommandType.StoredProcedure
        'Command.CommandText = "exec addMasterItemMD '" & ItemCode & "','" & Desc1 & "','" & Desc2 & "','" & ItemGroup & "','" & InventoryItem & "','" & SalesItem & "','" & PurchaseItem & "','" & Manufactur & "','" & HSCode & "','" & ShippingType & "','" & Uom & "'"
        Try
            Command.CommandText = "{ call EditMasterItemMD (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
            Command.Parameters.Clear()
            Command.Parameters.Add("@idItemMD", OdbcType.VarChar, 20, ParameterDirection.Input).Value = idItemMD
            Command.Parameters.Add("@ItemCode", OdbcType.VarChar, 20, ParameterDirection.Input).Value = ItemCode
            Command.Parameters.Add("@Desc1", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Desc1
            Command.Parameters.Add("@Desc2", OdbcType.VarChar, 250, ParameterDirection.Input).Value = Desc2
            Command.Parameters.Add("@ItemGroup", OdbcType.VarChar, 20, ParameterDirection.Input).Value = ItemGroup
            Command.Parameters.Add("@inventoryItem", OdbcType.Char, 1, ParameterDirection.Input).Value = InventoryItem
            Command.Parameters.Add("@SalesItem", OdbcType.Char, 1, ParameterDirection.Input).Value = SalesItem
            Command.Parameters.Add("@PurchaseItem", OdbcType.Char, 1, ParameterDirection.Input).Value = PurchaseItem
            Command.Parameters.Add("@Manufactur", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Manufactur
            Command.Parameters.Add("@HSCode", OdbcType.VarChar, 50, ParameterDirection.Input).Value = HSCode
            Command.Parameters.Add("@ShippingType", OdbcType.VarChar, 50, ParameterDirection.Input).Value = ShippingType
            Command.Parameters.Add("@UOM", OdbcType.VarChar, 50, ParameterDirection.Input).Value = Uom
            Command.Parameters.Add("@GenItem", OdbcType.VarChar, 50, ParameterDirection.Input).Value = genItem
            Command.Parameters.Add("@KodeOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = kodeOperator
            Command.Parameters.Add("@namaOperator", OdbcType.VarChar, 50, ParameterDirection.Input).Value = namaOperator
            Command.ExecuteNonQuery()

            For i = 0 To data.Rows.Count - 1
                Command.CommandText = "INSERT Into tbUomFactor(idItemMD, UOM, Factor) Values ('" & KdItemMasterData & "','" & data.Rows(i).Item(0) & "','" & data.Rows(i).Item(1) & "')"
                Command.ExecuteNonQuery()
            Next
            If InventoryItem = "1" Then
                Command.CommandText = "exec addInventoryItem '" & KdItemMasterData & "','" & InWeight & "','" & InminStock & "','" & InmaxStock & "','" & InReorderPoin & "','" & InLength & "','" & Inwidth & "','" & InHeight & "','" & InVolume & "'"
                Command.ExecuteNonQuery()
            ElseIf SalesItem = "1" Then
                Command.CommandText = "exec addSalesItem '" & KdItemMasterData & "','" & sTaxGroup & "','" & sUom & "','" & sMinOrderQty & "','" & sPacking & "','" & sLength & "','" & swidth & "','" & sheight & "','" & sVolume & "'"
                Command.ExecuteNonQuery()
            ElseIf PurchaseItem = "1" Then
                Command.CommandText = "exec addPurchaseItem '" & KdItemMasterData & "','" & pTaxGroup & "','" & pPrefVendor & "','" & pUOM & "','" & pMinOrderQty & "','" & pOrderInterval & "','" & pLeadTime & "','" & pLength & "','" & pWidth & "','" & pHeight & "','" & pVolume & "','" & pGRProcessingTime & "'"
                Command.ExecuteNonQuery()
            End If
            dbTrans.Commit()
            MsgBox("Data hase been save", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox("Data Not Save" + vbCrLf + "Error message : " + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ModKoneksi.TutupKoneksi()
    End Sub
End Class
