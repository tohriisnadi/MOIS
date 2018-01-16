Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.ComponentModel

Public Class FormPriceList
    Dim DataPriceList As New ClassPriceList
    Dim datavendor As New ClassMasterVendor
    Dim dataItemMD As New ClassItemMD
    Dim dataCustomer As New ClassCustomer
    Dim OdataDetil As New DataTable
    Dim Orow As DataRow

    Public X As String = ""
    Public idPL As String

    Dim OdataItem As New DataTable
    Dim Desc(5000) As String
    Dim ItemCodeMD(5000) As String

    Sub loadvendor()
        Dim odata As New DataTable
        odata.Clear()
        odata = datavendor.SelectMasterVendor
        SearchLookUpEdit1.Properties.DataSource = odata
        SearchLookUpEdit1.Properties.DisplayMember = "Name"
        SearchLookUpEdit1.Properties.ValueMember = "vendorCode"
    End Sub

    Sub setcolumnVendor()
        SearchLookUpEdit1View.Columns(0).Visible = False
        SearchLookUpEdit1View.Columns(3).Visible = False
        SearchLookUpEdit1View.Columns(4).Visible = False
        SearchLookUpEdit1View.Columns(5).Visible = False
        SearchLookUpEdit1View.Columns(6).Visible = False
        SearchLookUpEdit1View.Columns(7).Visible = False
        SearchLookUpEdit1View.Columns(8).Visible = False
        SearchLookUpEdit1View.Columns(9).Visible = False
        SearchLookUpEdit1View.Columns(10).Visible = False
        SearchLookUpEdit1View.Columns(11).Visible = False
        SearchLookUpEdit1View.Columns(12).Visible = False
        SearchLookUpEdit1View.Columns(13).Visible = False
        SearchLookUpEdit1View.Columns(14).Visible = False
        SearchLookUpEdit1View.Columns(15).Visible = False
        SearchLookUpEdit1View.Columns(16).Visible = False
        SearchLookUpEdit1View.Columns(17).Visible = False
        SearchLookUpEdit1View.Columns(18).Visible = False
        SearchLookUpEdit1View.Columns(19).Visible = False
        SearchLookUpEdit1View.Columns(20).Visible = False
        SearchLookUpEdit1View.Columns(21).Visible = False
        SearchLookUpEdit1View.Columns(22).Visible = False
    End Sub

    Sub LoadCustomer()
        Dim odata As New DataTable
        odata.Clear()
        odata = dataCustomer.selectDataCustomer
        SearchLookUpEdit1.Properties.DataSource = odata
        SearchLookUpEdit1.Properties.DisplayMember = "Name"
        SearchLookUpEdit1.Properties.ValueMember = "CustomerID"
    End Sub

    Sub setColumnCustomer()
        SearchLookUpEdit1View.Columns(0).Visible = False
        SearchLookUpEdit1View.Columns(3).Visible = False
        SearchLookUpEdit1View.Columns(4).Visible = False
        SearchLookUpEdit1View.Columns(5).Visible = False
        SearchLookUpEdit1View.Columns(6).Visible = False
        SearchLookUpEdit1View.Columns(7).Visible = False
        SearchLookUpEdit1View.Columns(8).Visible = False
        SearchLookUpEdit1View.Columns(9).Visible = False
        SearchLookUpEdit1View.Columns(10).Visible = False
        SearchLookUpEdit1View.Columns(11).Visible = False
        SearchLookUpEdit1View.Columns(12).Visible = False
        SearchLookUpEdit1View.Columns(13).Visible = False
        SearchLookUpEdit1View.Columns(14).Visible = False
        SearchLookUpEdit1View.Columns(15).Visible = False
        SearchLookUpEdit1View.Columns(16).Visible = False
        SearchLookUpEdit1View.Columns(17).Visible = False
        SearchLookUpEdit1View.Columns(18).Visible = False
    End Sub

    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As CancelEventArgs) Handles SearchLookUpEdit1.QueryPopUp
        If rbPurchase.Checked = True Then
            setcolumnVendor()
        Else
            setColumnCustomer()
        End If
    End Sub

    Private Sub FormPriceList_Load(sender As Object, e As EventArgs) Handles Me.Load
        'setColumn()
        txtValidFrom.EditValue = Date.Now
        txtValidTo.EditValue = Date.Now
        rbPurchase.Checked = True
        'loadvendor()
    End Sub

    Sub clean()
        setColumn()
        txtPLCode.Text = ""
        txtDesc.Text = ""
        txtRefrence.Text = ""
        txtPLCode.Focus()
    End Sub
    Sub setGrid()
        Try
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(2).OptionsColumn.AllowEdit = False
            GridView1.Columns(0).OptionsColumn.AllowEdit = False

            GridView1.Columns(0).Width = 50
            GridView1.Columns(1).Width = 200
            GridView1.Columns(2).Width = 250
            GridView1.Columns(3).Width = 100
            GridView1.Columns(4).Width = 150
            GridView1.Columns(5).Width = 150
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub loadItem()
        OdataItem.Clear()
        OdataItem = dataItemMD.SelectItemMDMini


        RepoSLEItemCode.DataSource = OdataItem
        RepoSLEItemCode.ValueMember = "ItemCode"
        RepoSLEItemCode.DisplayMember = "ItemCode"


    End Sub


    Public Sub setColumn()
        Try
            OdataDetil.Rows.Clear()
            OdataDetil.Columns.Clear()
            OdataDetil.Columns.Add(New DataColumn("NO", GetType(Integer))) '0
            OdataDetil.Columns.Add(New DataColumn("Item Code", GetType(String))) '1
            OdataDetil.Columns.Add(New DataColumn("Item Description", GetType(String))) '2
            OdataDetil.Columns.Add(New DataColumn("Min Qty", GetType(Integer))) '3
            OdataDetil.Columns.Add(New DataColumn("Price / Qty", GetType(Long))) '4
            OdataDetil.Columns.Add(New DataColumn("Discount", GetType(Long))) '5
            BindingSource1.DataSource = OdataDetil
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(ItemCode As String, ItemDesc As String, MinQty As Integer, pricePerQty As Long, discount As Long)
        Orow = OdataDetil.NewRow()
        Orow(0) = OdataDetil.Rows.Count() + 1
        Orow(1) = ItemCode
        Orow(2) = ItemDesc
        Orow(3) = MinQty
        Orow(4) = pricePerQty
        Orow(5) = discount
        OdataDetil.Rows.Add(Orow)
    End Sub

    Sub LoadDetilById()
        Dim Odata As New DataTable
        setColumn()
        Odata.Clear()
        Odata = DataPriceList.SelectPriceListDetilByIdPL(idPL)
        For i As Integer = 0 To Odata.Rows.Count - 1
            addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5))
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Purchase As String
        Dim Sell As String
        Try
            If rbPurchase.Checked = True Then Purchase = "1" Else Purchase = "0"
            If rbSell.Checked = True Then Sell = "1" Else Sell = "0"

            If X = "1" Then
                DataPriceList.AddMasterPriceList(txtPLCode.Text, txtDesc.Text, Format(txtValidFrom.EditValue, "yyyy/MM/dd"), Format(txtValidTo.EditValue, "yyyy/MM/dd"), Purchase, Sell, SearchLookUpEdit1View.GetFocusedDataRow.Item(1), txtRefrence.Text, OdataDetil)
                clean()
            ElseIf X = "2"
                DataPriceList.EditMasterPriceList(idPL, txtPLCode.Text, txtDesc.Text, Format(CDate(txtValidFrom.Text), "yyyy/MM/dd"), Format(CDate(txtValidTo.Text), "yyyy/MM/dd"), Purchase, Sell, SearchLookUpEdit1View.GetFocusedDataRow.Item(1), txtRefrence.Text, OdataDetil)
                clean()
                Close()
            End If
        Catch ex As Exception
            MsgBox("Plese complite all data", vbInformation, "Information")
        End Try

        FormDataPriceList.LoadData()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        loadItem()
        'GridView1.Columns(1).ColumnEdit = repoCbItemCode
        ' GridView1.Columns(1).ColumnEdit = RepotxtItemCode
        GridView1.Columns(1).ColumnEdit = RepoSLEItemCode
    End Sub



    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Close()
    End Sub

    Private Sub rbPurchase_CheckedChanged(sender As Object, e As EventArgs) Handles rbPurchase.CheckedChanged
        If rbPurchase.Checked = True Then
            loadvendor()
        Else
            LoadCustomer()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FormListPR.X = "2"
        Try
            FormListPR.ShowDialog()
        Catch
            FormListPR.Close()
            FormListPR.ShowDialog()
        End Try
    End Sub

    Private Sub RepotxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles RepotxtItemCode.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormListItem.X = "2"
            FormListItem.BindingSource1.DataSource = OdataItem
            FormListItem.ShowDialog()

        End If
    End Sub
    Dim description As String = ""
    Dim Uom As String = ""
    Dim genItem As String = ""

    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Item Code" Then
            e.Value = e.Value
            If genItem = "1" Then
                FormPopGenItem.X = "2"
                FormPopGenItem.ShowDialog()
            Else
                View.GetFocusedDataRow.Item("Item Description") = description

            End If


            View.GetFocusedDataRow.Item("Min Qty") = 0
            View.GetFocusedDataRow.Item("Price / Qty") = 0
            View.GetFocusedDataRow.Item("Discount") = 0
            View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
        End If
    End Sub

    Private Sub RepoSLEItemCode_EditValueChanged(sender As Object, e As EventArgs) Handles RepoSLEItemCode.EditValueChanged
        Dim a As DataRowView
        a = RepoSLEItemCode.GetRowByKeyValue(GridView1.ActiveEditor.EditValue)
        description = a.Item(1)

        Uom = a.Item(2)
        Try
            genItem = a.Item(3)
        Catch ex As Exception
            genItem = "0"
        End Try
    End Sub
End Class