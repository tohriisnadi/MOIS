Imports System.Data.Odbc
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FormAddPayment
    Dim DataPayment As New ClassPayment

    Public X As String = ""

    Public Docnumber As String = ""
    Dim dataSQ As New ClassSalesQuotation

    Dim oDataTabelUnbound As New DataTable
    Dim Orow As DataRow

    Sub clean()
        txtDate.EditValue = Date.Now
        txtPartnertType.SelectedIndex = 0
        txtDocNumber.Enabled = False
        KodeVendor = ""
        KodeCust = ""
        loadVendor()
        LoadCustomer()
        txtNote.Text = ""
        txtCurrency.Text = ""
        txtTotalPayment.Text = "0"
        txtCashBank.Text = ""
        txtRate.Text = "1"
        txtTotalPaymentIDR.Enabled = False
        setTabelUnbound()
    End Sub

    Sub setTabelUnbound()
        Try
            oDataTabelUnbound.Rows.Clear()
            oDataTabelUnbound.Columns.Clear()
            oDataTabelUnbound.Clear()
            oDataTabelUnbound.Columns.Add(New DataColumn("NO", GetType(String))) '0
            oDataTabelUnbound.Columns.Add(New DataColumn("Reference", GetType(String))) '1
            oDataTabelUnbound.Columns.Add(New DataColumn("Reference Information", GetType(String))) '2
            oDataTabelUnbound.Columns.Add(New DataColumn("Ref Invoice Amount", GetType(Long))) '3
            oDataTabelUnbound.Columns.Add(New DataColumn("Payment Amount", GetType(Long))) '4
            oDataTabelUnbound.Columns.Add(New DataColumn("Payment Amount in IDR", GetType(Long))) '5
            oDataTabelUnbound.Columns.Add(New DataColumn("Remarks", GetType(String))) '6

            BindingSource1.DataSource = oDataTabelUnbound
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addNewRow(Reference As String, RefInfo As String, RefInvoiceAmount As Long, PaymentAmount As Long, paymentAmountinIdr As Long, remarks As String)
        Orow = oDataTabelUnbound.NewRow()
        Orow(0) = oDataTabelUnbound.Rows.Count() + 1
        Orow(1) = Reference
        Orow(2) = RefInfo
        Orow(3) = RefInvoiceAmount
        Orow(4) = PaymentAmount
        Orow(5) = paymentAmountinIdr
        Orow(6) = remarks
        oDataTabelUnbound.Rows.Add(Orow)
    End Sub

    Sub setGrid()
        Try
            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            GridView1.Columns(0).OptionsColumn.AllowEdit = False
            GridView1.Columns(3).OptionsColumn.AllowEdit = False
            GridView1.Columns(5).OptionsColumn.AllowEdit = False

            GridView1.Columns(0).Width = 30
            GridView1.Columns(1).Width = 100
            GridView1.Columns(2).Width = 189
            GridView1.Columns(3).Width = 100
            GridView1.Columns(4).Width = 100
            GridView1.Columns(5).Width = 100
            GridView1.Columns(6).Width = 200
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load
        setGrid()
        Try
            GridView1.Columns("Reference").ColumnEdit = RepositoryItemSearchLookUpEdit1
        Catch ex As Exception

        End Try
    End Sub

    Public KodeCust As String
    Dim custCode(5000) As String

    Sub LoadCustomer()
        Dim odata As New DataTable
        odata.Clear()
        odata = dataSQ.selectCustomerforcb
        txtPartnerName.Properties.Items.Clear()
        For i = 0 To odata.Rows.Count - 1
            txtPartnerName.Properties.Items.Add(odata.Rows(i).Item(1))
            custCode(i) = odata.Rows(i).Item(0)
        Next
        txtPartnerName.SelectedIndex = 0
        Try
            txtPartnerName.SelectedIndex = Array.IndexOf(custCode, KodeCust)
        Catch ex As Exception

        End Try
    End Sub

    Dim dataVendor As New ClassMasterVendor
    Public KodeVendor As String
    Dim vendorCode(5000) As String

    Sub loadVendor()
        Dim odata As New DataTable
        odata.Clear()
        odata = dataVendor.SelectMasterVendor
        txtPartnerName.Properties.Items.Clear()
        For i = 0 To odata.Rows.Count - 1
            vendorCode(i) = odata.Rows(i).Item(1)
            txtPartnerName.Properties.Items.Add(odata.Rows(i).Item(2))
        Next
        txtPartnerName.SelectedIndex = 0

        Try
            txtPartnerName.SelectedIndex = Array.IndexOf(vendorCode, KodeVendor)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPartnertType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtPartnertType.SelectedIndexChanged
        Try
            If txtPartnertType.SelectedIndex = 0 Then
                LoadCustomer()
                LoadSalesbilling()
                setTabelUnbound()
                GridView1.Columns("Reference").ColumnEdit = RepositoryItemSearchLookUpEdit1

            ElseIf txtPartnertType.SelectedIndex = 1
                loadVendor()
                LoadvendorInvoice()
                setTabelUnbound()
                GridView1.Columns("Reference").ColumnEdit = RepositoryItemSearchLookUpEdit1

            Else
                txtPartnerName.Properties.Items.Clear()
                setTabelUnbound()
                GridView1.Columns("Reference").ColumnEdit = RepositoryItemTextEdit1
                txtPartnerName.Text = ""
                GridView1.OptionsBehavior.Editable = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub formatangka()
        txtTotalRefInvAmount.Text = Format(CLng(txtTotalRefInvAmount.Text), "###,###,##0.00")
        txtTotalPaymentAmount.Text = Format(CLng(txtTotalPaymentAmount.Text), "###,###,##0.00")
        'txtNetPrice.Text = Format(CLng(txtNetPrice.Text), "###,###,##0.00")
        'txtPPN.Text = Format(CLng(txtNetPrice.Text), "###,###,##0.00")
        'txtTotal.Enabled = False
        'txtDiscount.Enabled = False
        txtTotalRefInvAmount.Enabled = False
        txtTotalPaymentAmount.Enabled = False
    End Sub

    Sub LoadvendorInvoice()
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = DataPayment.selectDataSalesBilling
        RepositoryItemSearchLookUpEdit1.DataSource = Odata
        RepositoryItemSearchLookUpEdit1.ValueMember = "DocumentNumber"
        RepositoryItemSearchLookUpEdit1.DisplayMember = "DocumentNumber"
    End Sub


    Sub LoadSalesbilling()
        Dim Odata As New DataTable
        Odata.Clear()
        Odata = DataPayment.selectDataVendorInvoice
        RepositoryItemSearchLookUpEdit1.DataSource = Odata
        RepositoryItemSearchLookUpEdit1.ValueMember = "DocumentNumber"
        RepositoryItemSearchLookUpEdit1.DisplayMember = "DocumentNumber"
    End Sub


    Dim BlD As String = ""
    Dim NetPrice As String = ""
    Dim Termofpayemntinvoice As Integer = 0
    Private Sub RepositoryItemSearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit1.EditValueChanged
        Dim a As DataRowView
        Try
            a = RepositoryItemSearchLookUpEdit1.GetRowByKeyValue(GridView1.ActiveEditor.EditValue)
            BlD = a.Item("BaseLineDate")
            NetPrice = a.Item(5)
            Termofpayemntinvoice = a.Item(3)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim View As GridView = sender
        If View.FocusedColumn.FieldName = "Reference" Then
            e.Value = e.Value
            Try
                View.GetFocusedDataRow.Item("Ref Invoice Amount") = CLng(NetPrice)
                If CDate(txtDate.EditValue) <= (CDate(BlD).AddDays(Termofpayemntinvoice)) Then
                    View.GetFocusedDataRow.Item("Reference Information") = "Current"
                Else
                    View.GetFocusedDataRow.Item("Reference Information") = "Overdue " + ((CDate(txtDate.EditValue) - CDate(BlD).AddDays(Termofpayemntinvoice)).Days).ToString + " days"
                End If
            Catch ex As Exception

            End Try

            View.GetFocusedDataRow.Item("NO") = GridView1.RowCount
        ElseIf View.FocusedColumn.FieldName = "Payment Amount" Then
            Dim invAmount As Long = Convert.ToInt64(View.GetFocusedDataRow.Item("Ref Invoice Amount"))
            Try
                View.GetFocusedDataRow.Item("Payment Amount in IDR") = e.Value * CLng(txtRate.Text)
            Catch
                e.Valid = False
                e.ErrorText = "cannot calculate"
            End Try
            hitung()
        End If
    End Sub

    Sub hitung()
        Dim totalRefInvAmount As Long = 0
        Dim totalPaymentAmount As Long = 0
        Try
            For i = 0 To oDataTabelUnbound.Rows.Count - 1
                totalRefInvAmount = totalRefInvAmount + oDataTabelUnbound.Rows(i).Item("Ref Invoice Amount")
                totalPaymentAmount = totalPaymentAmount + oDataTabelUnbound.Rows(i).Item("Payment Amount in IDR")
            Next
        Catch ex As Exception
            totalRefInvAmount = 0
            totalPaymentAmount = 0
        End Try


        txtTotalRefInvAmount.Text = totalRefInvAmount
        txtTotalPaymentAmount.Text = totalPaymentAmount

        formatangka()
    End Sub

    Private Sub GridView1_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView1.RowUpdated
        hitung()
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim typePayment As String = ""
        Dim partnername As String = ""

        If txtPartnertType.SelectedIndex = 0 Then
            partnername = custCode(txtPartnerName.SelectedIndex)
        ElseIf txtPartnertType.SelectedIndex = 1 Then
            partnername = vendorCode(txtPartnerName.SelectedIndex)
        End If

        If RbIncoming.Checked = True Then typePayment = "Incoming" Else typePayment = "Outgoing"
        Try
            DataPayment.AddPayment(typePayment, txtCashBank.Text, txtCurrency.Text, txtRate.Text, Format(txtDate.EditValue, "yyyy/MM/dd"), txtPartnertType.Text, partnername, txtTotalPayment.Text,
                                   txtTotalPaymentIDR.Text, txtNote.Text, txtTotalRefInvAmount.Text, txtTotalPaymentAmount.Text, oDataTabelUnbound)
        Catch ex As Exception

        End Try
        clean()
        FormDataPayment.loadData()
    End Sub

    Sub cetakLaporan(ByVal odata As DataTable)
        Dim laporan As New ReportPayment
        Dim Tool As ReportPrintTool = New ReportPrintTool(laporan)
        Dim oDataSet As New DataSet
        Dim oDataAdapter As New OdbcDataAdapter
        Dim i As Integer

        If oDataSet.Tables.Count <> 0 Then
            oDataSet.Tables.Remove("Table1")
        End If

        oDataSet.Tables.Add(odata.Copy)

        laporan.DataSource = oDataSet
        laporan.DataAdapter = oDataAdapter
        laporan.DataMember = "Table1"

        Dim typePayment As String = ""
        If RbIncoming.Checked = True Then typePayment = "Incoming" Else typePayment = "Outgoing"

        laporan.lbType.Text = typePayment
        laporan.lbAccount.Text = ""
        laporan.lbDate.Text = txtDate.EditValue
        laporan.lbDocNum.Text = Docnumber

        laporan.txtNo.DataBindings.Add("Text", Nothing, "NO")
        laporan.txtRefrenceNum.DataBindings.Add("Text", Nothing, "Reference")
        laporan.txtRefrenceInfo.DataBindings.Add("Text", Nothing, "Reference Information")
        laporan.txtAmount.DataBindings.Add("Text", Nothing, "Payment Amount in IDR", "{0:#,#.00}")
        laporan.txtRemarks.DataBindings.Add("Text", Nothing, "Remarks")

        laporan.txtTotal.Text = txtTotalPaymentAmount.Text

        Tool.ShowPreview()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        cetakLaporan(oDataTabelUnbound)
    End Sub

    Private Sub txtTotalPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalPayment.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTotalPaymentIDR.Text = CLng(txtRate.Text) * CLng(txtTotalPayment.Text)

        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clean()
        Close()
    End Sub
End Class