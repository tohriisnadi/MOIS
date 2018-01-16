Public Class FormListEnquiry
    Dim dataenquiry As New ClassEnquiry
    Dim odataenquiry As New DataTable

    Public X As String = ""

    Sub LoadData()
        odataenquiry.Clear()
        odataenquiry = dataenquiry.SelectEnquiryForList
        BindingSource1.DataSource = odataenquiry
        setGrid()
    End Sub

    Sub setGrid()
        Try
            GridView1.OptionsBehavior.Editable = False
            GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            For i = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                GridView1.Columns(i).BestFit()
            Next
            'GridView1.Columns(0).Visible = False
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormListEnquiry_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        'X = 1 request by FormAddPR
        Dim Odata As New DataTable
        Dim OdataSQ As New DataTable
        Odata.Clear()
        Odata = dataenquiry.SelectEnquiryDetilByIDForPR(GridView1.GetFocusedDataRow.Item(0))
        If X = "1" Then
            ' x = 1 ==> req from FormAddPR
            FormAddPR.txtEnqRef.Text = GridView1.GetFocusedDataRow.Item(0)

            For i = 0 To Odata.Rows.Count - 1
                If Odata.Rows(i).Item(7).ToString = "" Then
                    FormAddPR.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), 1, "Value", 0, 0, "", Odata.Rows(i).Item(6), Odata.Rows(i).Item(5))
                ElseIf Odata.Rows(i).Item(5) - Odata.Rows(i).Item(7) > 0
                    FormAddPR.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5) - Odata.Rows(i).Item(7), 1, "", 0, 0, "", Odata.Rows(i).Item(6), Odata.Rows(i).Item(5) - Odata.Rows(i).Item(7))
                Else
                End If
            Next
            FormAddPR.btnConvert.Enabled = False
            FormAddPR.txtEnqRef.Enabled = False
            Me.Close()
        ElseIf X = "2" Then
            'x = 2 ==> request by form add sales quotation
            For i = 0 To Odata.Rows.Count - 1
                If CInt(Odata.Rows(i).Item(5)) > 0 Then
                    OdataSQ.Clear()
                    OdataSQ = dataenquiry.SElectSQDetilByItemandEnq(Odata.Rows(i).Item(2), GridView1.GetFocusedDataRow.Item(0))
                    If OdataSQ.Rows.Count - 1 Then
                        FormAddSalesQuotation.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5), 0, "Value", 0, 0, Odata.Rows(i).Item(6), Odata.Rows(i).Item(0), Odata.Rows(i).Item(5))
                    ElseIf CInt(OdataSQ.Rows(0).Item(0).ToString) < CInt(Odata.Rows(i).Item(5)) Then
                        FormAddSalesQuotation.addNewRow(Odata.Rows(i).Item(1), Odata.Rows(i).Item(2), Odata.Rows(i).Item(3), Odata.Rows(i).Item(4), Odata.Rows(i).Item(5) - CInt(OdataSQ.Rows(0).Item(0).ToString), 0, "", 0, 0, Odata.Rows(i).Item(6), Odata.Rows(i).Item(0), Odata.Rows(i).Item(5) - CInt(OdataSQ.Rows(0).Item(0).ToString))
                    End If
                End If
            Next
            FormAddSalesQuotation.txtRef.Text = GridView1.GetFocusedDataRow.Item(0)
            FormAddSalesQuotation.txtRef.Enabled = False
            FormAddSalesQuotation.btnConvert.Enabled = False
            Me.Close()
        End If

    End Sub


End Class