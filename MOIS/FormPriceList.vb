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
        repoCbItemCode.Items.Clear()
        For i As Integer = 0 To OdataItem.Rows.Count - 1
            Desc(i) = OdataItem.Rows(i).Item(1)
            ItemCodeMD(i) = OdataItem.Rows(i).Item(0)
            repoCbItemCode.Items.Add(OdataItem.Rows(i).Item(0))
        Next
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
        FormDataPriceList.LoadData()
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        loadItem()
        GridView1.Columns(1).ColumnEdit = repoCbItemCode
    End Sub


    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Item Code" Then
            ''Get the currently edited value 
            'Dim discount As Double = Convert.ToDouble(e.Value)
            ''Specify validation criteria 
            'If discount < 0 Then
            '    e.Valid = False
            '    e.ErrorText = "Enter a positive value"
            'End If
            If ItemCodeMD.Contains(e.Value) Then
                e.Value = e.Value
                View.GetFocusedDataRow.Item("Item Description") = Desc(Array.IndexOf(ItemCodeMD, e.Value))
                View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
            Else
                e.Valid = False
                e.ErrorText = "Enter a valid Item Code"
            End If

        End If
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

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged
        LabelControl7.Text = SearchLookUpEdit1View.GetFocusedDataRow.Item(2)
    End Sub
End Class