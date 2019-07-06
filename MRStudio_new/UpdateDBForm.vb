Public Class UpdateDBForm
    Dim cnn As New OleDb.OleDbConnection
    Dim search As Integer
    Dim page As Integer = 0
    Dim balance As UInt64 = 0
    Dim paid As UInt64 = 0
    Dim Discount As UInt64 = 0
    Dim balance1 As UInt64 = 0
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.UsersTableAdapter.Fill(Me.MRStudioDataSet2.Users)

        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\MRStudio.accdb;"
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        SearchResults.Enabled = True
        Dim da1 As New OleDb.OleDbDataAdapter("select Username from Admin union select Username from Users", cnn)
        Dim dt1 As New DataTable
        da1.Fill(dt1)
        cnn.Close()
        ComboBilled.DataSource = dt1
        SearchResults.Enabled = False
        search = 0
        SearchDate.Value = Now.Date
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If search = 1 Then
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            SearchResults.Enabled = True
            Dim da As New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                  " WHERE BillType = '" & ComboBillType.SelectedItem & "'", cnn)
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            SearchResults.DataSource = dt
            SearchResults.ForeColor = Color.Navy
        ElseIf search = 0 Then
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            SearchResults.Enabled = True
            Dim da As New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                  " WHERE BilledBy = '" & ComboBilled.SelectedValue & "'", cnn)
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            SearchResults.DataSource = dt
            SearchResults.ForeColor = Color.Navy
        ElseIf search = 2 Then
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            SearchResults.Enabled = True
            Dim da As New OleDb.OleDbDataAdapter
            If ComboBalance.SelectedItem = "Balance" Then
                da = New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                      " WHERE Balance <> '0'", cnn)
            Else
                da = New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                     " WHERE Balance = '0'", cnn)
            End If
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            SearchResults.DataSource = dt
            SearchResults.ForeColor = Color.Navy
        ElseIf search = 3 Then
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            SearchResults.Enabled = True
            Dim da As New OleDb.OleDbDataAdapter
            If ComboDelivered.SelectedItem = "Delivered" Then
                da = New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                      " WHERE [Delivered]= 'Yes' ", cnn)
            Else
                da = New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                     " WHERE [Delivered] = 'No' ", cnn)
            End If
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            SearchResults.DataSource = dt
            SearchResults.ForeColor = Color.Navy
        ElseIf search = 4 Then
            If Not String.IsNullOrEmpty(Convert.ToString(txtSearchName.Text)) Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                SearchResults.Enabled = True
                Dim da As New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                      " WHERE Cust_Name LIKE '%" & txtSearchName.Text & "%'", cnn)
                Dim dt As New DataTable
                da.Fill(dt)
                cnn.Close()
                SearchResults.DataSource = dt
                SearchResults.ForeColor = Color.Navy
            End If
        ElseIf search = 5 Then
            If Not String.IsNullOrEmpty(Convert.ToString(txtSearchPhone.Text)) Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                SearchResults.Enabled = True
                Dim da As New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                      " WHERE Cust_Phone LIKE '%" & txtSearchPhone.Text & "%'", cnn)
                Dim dt As New DataTable
                da.Fill(dt)
                cnn.Close()
                SearchResults.DataSource = dt
                SearchResults.ForeColor = Color.Navy
            End If
        ElseIf search = 6 Then
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            SearchResults.Enabled = True
            Dim da As New OleDb.OleDbDataAdapter
            da = New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder FROM Customer " & _
                                                  " WHERE [DateOrder]= #" & Format(SearchDate.Value, "yyyy/MM/dd") & "#", cnn)
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            SearchResults.DataSource = dt
            SearchResults.ForeColor = Color.Navy
        End If

    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintDialog1.Document = PrintDocument1
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        PrintDialog1.AllowSomePages = True
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim reportfont As Font = New Drawing.Font("Times New Roman", 22)
        Dim reportfont1 As Font = New Drawing.Font("Times New Roman", 12)
        Dim reportfont2 As Font = New Drawing.Font("Times New Roman", 25, FontStyle.Bold)
        Dim x As Integer
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT Cust_Name,Cust_Phone,Products,Total,Balance,Advance,Delivered, BillType,BilledBy,DateOrder FROM Customer " & _
                                                  " WHERE invoice_id='" & txtid.Text & "'", cnn)
        Dim dt As New DataTable
        da.Fill(dt)
        cnn.Close()
        Dim Cust_Name As String = dt.Rows(0).Item("Cust_name")
        Dim Cust_Phone As String = dt.Rows(0).Item("Cust_Phone")
        Dim Products As String = dt.Rows(0).Item("Products")
        Dim Total As String = dt.Rows(0).Item("Total")
        Dim Balance As String = dt.Rows(0).Item("Balance")
        Dim Advance As String = dt.Rows(0).Item("Advance")
        Dim Delivered As String = dt.Rows(0).Item("Delivered")
        Dim BillType As String = dt.Rows(0).Item("BillType")
        Dim BilledBy As String = dt.Rows(0).Item("BilledBy")
        Dim DateOrder As String = dt.Rows(0).Item("DateOrder")
        Dim Image1 As New System.Drawing.Bitmap(filename:="table.png")
        e.Graphics.DrawString("M.R. Digital Studio", reportfont2, Brushes.Black, 43, 20)
            e.Graphics.DrawString("10,Kumarasamy Colony Main Road", reportfont1, Brushes.Black, 70, 60)
            e.Graphics.DrawString("Kangayam Cross Road,Tirupur-4.", reportfont1, Brushes.Black, 80, 80)
            e.Graphics.DrawString("Ph : 0421-4254884/Cell : 9994455577", reportfont1, Brushes.Black, 60, 100)
            e.Graphics.DrawString("Email: rkmr2006@gmail.com", reportfont1, Brushes.Black, 100, 120)
            e.Graphics.DrawLine(Pens.Black, 15, 150, 395, 150)
        If BillType = "Cash" Then
            e.Graphics.DrawString("CASH BILL by " & BilledBy, reportfont1, Brushes.Black, 130, 160)
        Else
            e.Graphics.DrawString("ORDER BILL by " & BilledBy, reportfont1, Brushes.Black, 130, 160)
        End If
        e.Graphics.DrawString("Date : " & DateOrder, reportfont1, Brushes.Black, 10, 185)
            e.Graphics.DrawString("Date : "&txtid.Text, reportfont1, Brushes.Black, 200, 185)
            e.Graphics.DrawString(String.Concat("Name : ", txtName.Text), reportfont1, Brushes.Black, 10, 210)
            e.Graphics.DrawString(String.Concat("Phone : ", txtPhone.Text), reportfont1, Brushes.Black, 200, 210)
        e.Graphics.DrawImage(Image1, point:=New Point(x:=-4, y:=235))
        Dim IndProd() As String = Products.Split("|")
        Dim ProdDet() As String
        For x = 0 To IndProd.Length - 2
            ProdDet = IndProd(x).Split("-")
            e.Graphics.DrawString(ProdDet(0), reportfont1, Brushes.Black, 20, (270 + x * 25))
            e.Graphics.DrawString(ProdDet(1), reportfont1, Brushes.Black, 185, (270 + x * 25))
            e.Graphics.DrawString(Convert.ToInt64(ProdDet(2)) / Convert.ToInt64(ProdDet(1)), reportfont1, Brushes.Black, 275, (270 + x * 25))
            e.Graphics.DrawString(ProdDet(2), reportfont1, Brushes.Black, 335, (270 + x * 25))
        Next
        e.Graphics.DrawString(String.Concat("Total : ", "Rs.", Total), reportfont1, Brushes.Black, 15, 490)
        e.Graphics.DrawString(String.Concat("Advance : ", "Rs.", Advance), reportfont1, Brushes.Black, 135, 490)
        e.Graphics.DrawString(String.Concat("Balance : ", "Rs.", Balance), reportfont1, Brushes.Black, 265, 490)
        e.Graphics.DrawLine(Pens.Black, 15, 515, 395, 515)
        e.Graphics.DrawString("Thank You Visit us again!!!", reportfont1, Brushes.Black, 100, 525)
        'e.Graphics.DrawString("Please bring this invoice for delivery and no refund", reportfont1, Brushes.Black, 10, 525)
    End Sub
    Private Sub refresh_data()
        balance = 0
        paid = 0
        Discount = 0
        txtName.Text = ""
        txtPhone.Text = ""
        txtid.Text = ""
        txtProductDetails.Text = ""
        txtTotal.Text = ""
        txtBalance.Text = ""
        txtAdvance.Text = ""
        txtDiscount.Text = ""
        txtDate.Text = ""
        txtPay.Text = 0
    End Sub
    Private Sub SearchResults_Click(sender As Object, e As EventArgs) Handles SearchResults.Click
        Try
            txtName.Text = SearchResults.CurrentRow.Cells(0).Value
            txtPhone.Text = SearchResults.CurrentRow.Cells(1).Value
            txtid.Text = SearchResults.CurrentRow.Cells(2).Value
            txtProductDetails.Text = SearchResults.CurrentRow.Cells(3).Value
            txtTotal.Text = SearchResults.CurrentRow.Cells(4).Value
            txtBalance.Text = SearchResults.CurrentRow.Cells(5).Value
            balance = Convert.ToUInt64(SearchResults.CurrentRow.Cells(5).Value)
            txtAdvance.Text = SearchResults.CurrentRow.Cells(6).Value
            paid = Convert.ToUInt64(SearchResults.CurrentRow.Cells(6).Value)
            Discount = SearchResults.CurrentRow.Cells(7).Value
            txtDate.Text = SearchResults.CurrentRow.Cells("DateOrder").Value
        Catch ex1 As System.InvalidCastException
            MessageBox.Show("Can't select Empty Row", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub txtPay_GotFocus(sender As Object, e As EventArgs) Handles txtPay.GotFocus
        If txtPay.Text = "0" Then
            txtPay.ForeColor = Color.Black
            txtPay.Text = ""
        End If
    End Sub

    Private Sub txtPay_LostFocus(sender As Object, e As EventArgs) Handles txtPay.LostFocus
        If txtPay.Text = "" Then
            txtPay.ForeColor = Color.Silver
            txtPay.Text = "0"
        End If
        balance1 = Convert.ToUInt64(txtBalance.Text)
    End Sub
    Private Sub txtDiscount_GotFocus(sender As Object, e As EventArgs) Handles txtDiscount.GotFocus
        If txtDiscount.Text = "0" Then
            txtDiscount.ForeColor = Color.Black
            txtDiscount.Text = ""
        End If
    End Sub

    Private Sub txtDiscount_LostFocus(sender As Object, e As EventArgs) Handles txtDiscount.LostFocus
        If txtDiscount.Text = "" Then
            txtDiscount.ForeColor = Color.Silver
            txtDiscount.Text = "0"
        End If
        balance1 = Convert.ToUInt64(txtBalance.Text)
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cmd As New OleDb.OleDbCommand
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        cmd.Connection = cnn
        Dim del As String
        If txtBalance.Text = "0" Then
            del = "Yes"
        Else
            del = "No"
        End If
        cmd.CommandText = "UPDATE Customer SET Cust_Name= '" & txtName.Text & "',Cust_Phone='" & txtPhone.Text & "'," & _
                       "Total='" & txtTotal.Text & "',Balance='" & txtBalance.Text & "',Advance='" & txtAdvance.Text & "',Discount='" & Convert.ToString(Discount + Convert.ToUInt64(txtDiscount.Text)) & _
                       "',Delivered='" & del & "' WHERE invoice_id='" & txtid.Text & "'"
        cmd.ExecuteNonQuery()
        MessageBox.Show("Record Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub ComboBilled_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBilled.SelectedIndexChanged
        refresh_data()
        search = 0
    End Sub
    Private Sub ComboBillType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBillType.SelectedIndexChanged
        refresh_data()
        search = 1
    End Sub
    Private Sub ComboBalance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBalance.SelectedIndexChanged
        refresh_data()
        search = 2
    End Sub
    Private Sub ComboDelivered_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboDelivered.SelectedIndexChanged
        refresh_data()
        search = 3
    End Sub
    Private Sub txtSearchName_TextChanged(sender As Object, e As EventArgs) Handles txtSearchName.TextChanged
        refresh_data()
        search = 4
    End Sub
    Private Sub txtSearchPhone_TextChanged(sender As Object, e As EventArgs) Handles txtSearchPhone.TextChanged
        refresh_data()
        search = 5
    End Sub
    Private Sub SearchDate_GotFocus(sender As Object, e As EventArgs) Handles SearchDate.GotFocus
        refresh_data()
        search = 6
    End Sub
    Private Sub txtPay_TextChanged(sender As Object, e As EventArgs) Handles txtPay.TextChanged
        Dim pay As UInt64
        Try
            If Integer.TryParse(txtPay.Text, pay) Then
                txtBalance.Text = balance - pay
                txtAdvance.Text = paid + pay
            End If
        Catch ex1 As ArithmeticException
            txtPay.Text = ""
            txtBalance.Text = balance
            txtAdvance.Text = paid
            MessageBox.Show("Wrong Input.Please Check again!!!", "Data Entry Error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        Dim dis As UInt64
        Try
            If Integer.TryParse(txtDiscount.Text, dis) Then
                txtBalance.Text = balance1 - dis
            End If
        Catch ex1 As ArithmeticException
            txtDiscount.Text = ""
            txtBalance.Text = balance1
            MessageBox.Show("Wrong Input.Please Check again!!!", "Data Entry Error", MessageBoxButtons.OK)
        End Try
    End Sub
End Class