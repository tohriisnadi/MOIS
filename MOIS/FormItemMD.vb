Public Class FormItemMD
    Dim dataItemMD As New ClassItemMD
    Dim dataItemGroup As New ClassItemGroup
    Dim odatafactor As New DataTable
    Dim orow As DataRow

    Dim GrDesc(5000) As String

    Public KodeItemMD As String
    Public X As String

    Sub clean()
        ckInvetory.Checked = False
        ckPurchase.Checked = False
        ckSales.Checked = False
        LoadItemGroup()
        txtItemCode.Text = ""
        txtDesc1.Text = ""
        txtDesc2.Text = ""
        txtManufactur.Text = ""
        txtHsCode.Text = ""
        txtShippingType.Text = ""
        txtUom.Text = ""
        txtInvWeight.Text = "0"
        txtInvMinStock.Text = "0"
        txtInvMaxStock.Text = "0"
        txtInvReorderPoint.Text = "0"
        txtInvLength.Text = "0"
        txtInvWidth.Text = "0"
        txtInvHeight.Text = "0"
        txtInvVolume.Text = "0"
        txtSalesTaxGr.Text = ""
        txtSalesUom.Text = ""
        txtSalesMinOrderQty.Text = "0"
        txtSalesPacking.Text = ""
        txtSalesLength.Text = "0"
        txtSalesWidth.Text = "0"
        txtSalesHeight.Text = "0"
        txtSalesVolume.Text = "0"
        txtPurTaxGr.Text = ""
        txtPurPrefVendor.Text = ""
        txtPurUOM.Text = ""
        txtPurMinOrderQty.Text = "0"
        txtPurOrderInterval.Text = "0"
        txtPurLeadTime.Text = "0"
        txtPurLength.Text = "0"
        txtPurWidth.Text = "0"
        txtPurHeight.Text = "0"
        txtPurVolume.Text = "0"
        txtPurGrProcessingTime.Text = "0"
        setTabelFactorUOM()
        txtItemCode.Focus()
    End Sub

    Sub LoadItemGroup()
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = dataItemGroup.SelectItemGroupMini
        txtItemGroup.Properties.Items.Clear()
        For i = 0 To Odata.Rows.Count - 1
            GrDesc(i) = Odata.Rows(i).Item(1)
            txtItemGroup.Properties.Items.Add(Odata.Rows(i).Item(0))
        Next
        txtItemGroup.SelectedIndex = 0
    End Sub

    Sub setTabelFactorUOM()
        odatafactor.Clear()
        odatafactor.Rows.Clear()
        odatafactor.Columns.Clear()
        odatafactor.Columns.Add(New DataColumn("UOM", GetType(String))) '0
        odatafactor.Columns.Add(New DataColumn("Factor", GetType(Integer))) '1
        BindingSource1.DataSource = odatafactor
    End Sub

    Public Sub addNewRow(UOM As String, Factor As Integer)
        orow = odatafactor.NewRow()
        orow(0) = UOM
        orow(1) = Factor
        odatafactor.Rows.Add(orow)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim InventoryItem As String = ""
        Dim SalesItem As String = ""
        Dim PurchaseItem As String = ""
        Dim genItem As String = "0"

        If ckInvetory.Checked = True Then InventoryItem = "1" Else InventoryItem = "0"
        If ckSales.Checked = True Then SalesItem = "1" Else SalesItem = "0"
        If ckPurchase.Checked = True Then PurchaseItem = "1" Else PurchaseItem = "0"

        If ckGeneral.Checked = True Then genItem = "1" Else genItem = "0"

        Try
            If X = "1" Then
                dataItemMD.addMasterItemMD(genItem, txtItemCode.Text, txtDesc1.Text, txtDesc2.Text, txtItemGroup.Text, InventoryItem, SalesItem, PurchaseItem, txtManufactur.Text, txtHsCode.Text, txtShippingType.Text, txtUom.Text, odatafactor,
                                        txtInvWidth.Text, txtInvMinStock.Text, txtInvMaxStock.Text, txtInvReorderPoint.Text, txtInvLength.Text, txtInvWidth.Text, txtInvHeight.Text, txtInvVolume.Text,
                                        txtSalesTaxGr.Text, txtSalesUom.Text, txtSalesMinOrderQty.Text, txtSalesPacking.Text, txtSalesLength.Text, txtSalesWidth.Text, txtSalesHeight.Text, txtSalesVolume.Text,
                                        txtPurTaxGr.Text, txtPurPrefVendor.Text, txtPurUOM.Text, txtPurMinOrderQty.Text, txtPurOrderInterval.Text, txtPurLeadTime.Text, txtPurLength.Text, txtPurWidth.Text, txtPurHeight.Text, txtPurVolume.Text, txtPurGrProcessingTime.Text)
                clean()
            ElseIf X = "2"
                dataItemMD.EditMasterItemMD(KodeItemMD, genItem, txtItemCode.Text, txtDesc1.Text, txtDesc2.Text, txtItemGroup.Text, InventoryItem, SalesItem, PurchaseItem, txtManufactur.Text, txtHsCode.Text, txtShippingType.Text, txtUom.Text, odatafactor,
                                        txtInvWidth.Text, txtInvMinStock.Text, txtInvMaxStock.Text, txtInvReorderPoint.Text, txtInvLength.Text, txtInvWidth.Text, txtInvHeight.Text, txtInvVolume.Text,
                                        txtSalesTaxGr.Text, txtSalesUom.Text, txtSalesMinOrderQty.Text, txtSalesPacking.Text, txtSalesLength.Text, txtSalesWidth.Text, txtSalesHeight.Text, txtSalesVolume.Text,
                                        txtPurTaxGr.Text, txtPurPrefVendor.Text, txtPurUOM.Text, txtPurMinOrderQty.Text, txtPurOrderInterval.Text, txtPurLeadTime.Text, txtPurLength.Text, txtPurWidth.Text, txtPurHeight.Text, txtPurVolume.Text, txtPurGrProcessingTime.Text)
                clean()
                Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FormDataItemMD.LoadData()
    End Sub

    Sub setGrid()
        Try
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(0).Width = 30%
            GridView1.Columns(1).Width = 70%
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormItemMD_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadItemGroup()
    End Sub


    Private Sub ckInvetory_CheckedChanged(sender As Object, e As EventArgs) Handles ckInvetory.CheckedChanged
        If ckInvetory.Checked = True Then
            XtraTabPage2.Enabled = False
        Else
            XtraTabPage2.Enabled = True
        End If
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
    End Sub

    Private Sub txtItemGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtItemGroup.SelectedIndexChanged
        Try
            lbDescGr.Text = GrDesc(txtItemGroup.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        Dim odata As New DataTable
        If e.KeyCode = Keys.Enter Then
            odata.Clear()
            txtItemCode.Text = txtItemCode.Text.ToUpper
            odata = dataItemMD.validationCode(txtItemCode.Text)
            If odata.Rows.Count > 0 Then
                MsgBox("Item Code already exist, please input other code", MsgBoxStyle.Critical, "Error")
                txtItemCode.Text = ""
                txtItemCode.Focus()
            ElseIf txtItemCode.Text = ""
                MsgBox("Item Code cannot empty", MsgBoxStyle.Critical, "Error")
            Else
                txtDesc1.Focus()
            End If
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Close()
    End Sub
End Class