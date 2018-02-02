Public Class FormPopGenItem
    Public X As String

    Sub clean()
        txtDesc.Text = ""
        txtUom.Text = ""
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'txtDesc.Text = txtDesc.Text.ToUpper
        'txtUom.Text = txtUom.Text.ToUpper
        If X = "1" Then
            FormAddPR.GridView1.GetFocusedDataRow.Item("Item Description") = txtDesc.Text.ToUpper
            FormAddPR.GridView1.GetFocusedDataRow.Item("MaxQty") = 999
            FormAddPR.GridView1.GetFocusedDataRow.Item("UOM") = txtUom.Text.ToUpper
        ElseIf X = "2" Then
            FormAddPO.GridView1.GetFocusedDataRow.Item("Item Description") = txtDesc.Text.ToUpper
            FormAddPO.GridView1.GetFocusedDataRow.Item("MaxQty") = 999
            FormAddPO.GridView1.GetFocusedDataRow.Item("UOM") = txtUom.Text.ToUpper
        ElseIf X = "3" Then
            FormAddSalesQuotation.GridView1.GetFocusedDataRow.Item("Item Description") = txtDesc.Text.ToUpper
            FormAddSalesQuotation.GridView1.GetFocusedDataRow.Item("QtyEnquiry") = 999
            FormAddSalesQuotation.GridView1.GetFocusedDataRow.Item("UOM") = txtUom.Text.ToUpper
        ElseIf X = "4" Then
            FormAddSalesOrder.GridView1.GetFocusedDataRow.Item("Item Description") = txtDesc.Text.ToUpper
            ' 'FormAddSalesOrder.GridView1.GetFocusedDataRow.Item("MaxQty") = 999
            FormAddSalesOrder.GridView1.GetFocusedDataRow.Item("UOM") = txtUom.Text.ToUpper
        ElseIf X = "5" Then
            FormAddDelivery.GridView1.GetFocusedDataRow.Item("Item Description") = txtDesc.Text.ToUpper
            'FormAddDelivery.GridView1.GetFocusedDataRow.Item("MaxQty") = 999
            FormAddDelivery.GridView1.GetFocusedDataRow.Item("UOM") = txtUom.Text.ToUpper
        ElseIf X = "6" Then
            FormEnquiry.GridView1.GetFocusedDataRow.Item("Item Description") = txtDesc.Text.ToUpper
            'FormEnquiry.GridView1.GetFocusedDataRow.Item("MaxQty") = 999
            FormEnquiry.GridView1.GetFocusedDataRow.Item("UOM") = txtUom.Text.ToUpper
        ElseIf X = "7"
            FormAdjustmentStock.GridView1.GetFocusedDataRow.Item("Description") = txtDesc.Text.ToUpper
            FormAdjustmentStock.GridView1.GetFocusedDataRow.Item("UOM") = txtUom.Text.ToUpper
        End If
        clean()
        Close()
    End Sub

    Private Sub txtUom_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUom.KeyDown
        If e.KeyCode = Keys.Enter Then
            SimpleButton1.PerformClick()
        End If
    End Sub


End Class