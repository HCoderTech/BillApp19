Public Class ReportsForm
    Dim cnn As New OleDb.OleDbConnection
    Dim today As Integer = 0
    Dim firstpage As Boolean = True
    Dim rec1 As Integer = 0
    Dim record As Integer = 0
    Dim print1 As Integer = 0
    Dim print2 As Integer = 0
    Dim print3 As Integer = 0
    Dim print4 As Integer = 0
    Dim print5 As Integer = 0
    Dim print6 As Integer = 0
    Dim print7 As Integer = 0
    Dim print8 As Integer = 0
    Dim print9 As Integer = 0
    Dim print10 As Integer = 0
    Dim print11 As Integer = 0
    Dim print12 As Integer = 0
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\MRStudio.accdb;"
        fromDate.Value = Now.Date
        ToDate.Value = Now.Date
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        today = 1
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT Cust_Name,DateOrder,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy FROM Customer " & _
                                              " WHERE [DateOrder] = #" & Format(Now.Date, "yyyy/MM/dd") & "#", cnn)
        Dim dt As New DataTable
        da.Fill(dt)
        cnn.Close()
        Results.DataSource = dt
        Results.ForeColor = Color.Navy
        Dim x As UInt64
        Dim sum As UInt64
        Dim sum1 As UInt64
        Dim sum2 As UInt64
        Dim sum3 As UInt64
        sum = 0
        sum1 = 0
        sum2 = 0
        sum3 = 0
        For x = 0 To Results.RowCount - 2
            sum = sum + Convert.ToInt64(Results.Rows(x).Cells("Total").Value)
            sum1 = sum1 + Convert.ToInt64(Results.Rows(x).Cells("Advance").Value)
            sum2 = sum2 + Convert.ToInt64(Results.Rows(x).Cells("Balance").Value)
            sum3 = sum3 + Convert.ToInt64(Results.Rows(x).Cells("Discount").Value)
        Next
        lblTotal.Text = sum
        lblBalance.Text = sum2
        lblAdvance.Text = sum1
        lblDiscount.Text = sum3
        NetTotal.Text = sum - sum3
    End Sub

    Private Sub btnRange_Click(sender As Object, e As EventArgs) Handles btnRange.Click
        today = 0
        If fromDate.Value > ToDate.Value Then
            MessageBox.Show("Wrong Dates", "Check Range", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            Dim da As New OleDb.OleDbDataAdapter("SELECT Cust_Name,DateOrder,invoice_id,Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy FROM Customer " & _
                                                  " WHERE [DateOrder] between #" & Format(fromDate.Value, "yyyy/MM/dd") & "# and #" & Format(ToDate.Value, "yyyy/MM/dd") & "#", cnn)
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            Results.DataSource = dt
            Results.ForeColor = Color.Navy
        End If
        Dim x As UInt64
        Dim sum As UInt64
        Dim sum1 As UInt64
        Dim sum2 As UInt64
        Dim sum3 As UInt64
        sum = 0
        sum1 = 0
        sum2 = 0
        sum3 = 0
        For x = 0 To Results.RowCount - 2
            sum = sum + Convert.ToInt64(Results.Rows(x).Cells("Total").Value)
            sum1 = sum1 + Convert.ToInt64(Results.Rows(x).Cells("Advance").Value)
            sum2 = sum2 + Convert.ToInt64(Results.Rows(x).Cells("Balance").Value)
            sum3 = sum3 + Convert.ToInt64(Results.Rows(x).Cells("Discount").Value)
        Next
        lblTotal.Text = sum
        lblBalance.Text = sum2
        lblAdvance.Text = sum1
        lblDiscount.Text = sum3
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintDialog1.Document = PrintDocument1
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        PrintDialog1.AllowSomePages = True
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
        Me.Close()
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim reportfont As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
        Dim reportfont1 As Font = New Drawing.Font("Times New Roman", 12)
        Dim reportfont2 As Font = New Drawing.Font("Times New Roman", 25, FontStyle.Bold)
        Dim reportfont3 As Font = New Drawing.Font("Times New Roman", 18, FontStyle.Italic)
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt1 As New DataTable
        Dim da1 As New OleDb.OleDbDataAdapter
        Dim dt2 As New DataTable
        Dim da2 As New OleDb.OleDbDataAdapter
        Dim dt3 As New DataTable
        Dim da3 As New OleDb.OleDbDataAdapter
        Dim dt4 As New DataTable
        Dim da4 As New OleDb.OleDbDataAdapter
        ' Dim x As Integer
        Dim ypos As Integer
        e.HasMorePages = False
        If firstpage = True Then
            e.Graphics.DrawString("M.R. Digital Studio", reportfont2, Brushes.Black, 268, 20)
            e.Graphics.DrawString("10,Kumarasamy Colony Main Road", reportfont1, Brushes.Black, 295, 60)
            e.Graphics.DrawString("Kangayam Cross Road,Tirupur-4.", reportfont1, Brushes.Black, 305, 80)
            e.Graphics.DrawString("Ph : 0421-4254884/Cell : 9994455577", reportfont1, Brushes.Black, 285, 100)
            e.Graphics.DrawString("Email: rkmr2006@gmail.com", reportfont1, Brushes.Black, 325, 120)
            e.Graphics.DrawLine(Pens.Black, 0, 150, 855, 150)
            If today = 1 Then
                e.Graphics.DrawString("Reports:" & Convert.ToString(Format(Now.Date, "dd/MM/yyyy")), reportfont2, Brushes.Black, 290, 170)
            Else
                e.Graphics.DrawString("Reports:" & Convert.ToString(Format(fromDate.Value, "dd/MM/yyyy")) & " - " & Convert.ToString(Format(ToDate.Value, "dd/MM/yyyy")), reportfont2, Brushes.Black, 170, 170)
            End If
            e.Graphics.DrawString("Name               Date                  Invoice Id       Total       Balance     Paid        Delivered    BillType   BilledBy", reportfont, Brushes.Black, 50, 225)
            ypos = 250
            firstpage = False
        Else
            ypos = 25
        End If
        For x = record To Results.RowCount - 2
            e.Graphics.DrawString(Results.Rows(x).Cells("Cust_Name").Value, reportfont1, Brushes.Black, 50, ypos)
            e.Graphics.DrawString(Format(Convert.ToDateTime(Results.Rows(x).Cells("DateOrder").Value), "dd/MM/yyyy"), reportfont1, Brushes.Black, 150, ypos)
            e.Graphics.DrawString(Results.Rows(x).Cells("invoice_id").Value, reportfont1, Brushes.Black, 275, ypos)
            e.Graphics.DrawString(Results.Rows(x).Cells("Total").Value, reportfont1, Brushes.Black, 380, ypos)
            e.Graphics.DrawString(Results.Rows(x).Cells("Balance").Value, reportfont1, Brushes.Black, 460, ypos)
            e.Graphics.DrawString(Results.Rows(x).Cells("Advance").Value, reportfont1, Brushes.Black, 525, ypos)
            e.Graphics.DrawString(Results.Rows(x).Cells("Delivered").Value, reportfont1, Brushes.Black, 606, ypos)
            e.Graphics.DrawString(Results.Rows(x).Cells("BillType").Value, reportfont1, Brushes.Black, 685, ypos)
            e.Graphics.DrawString(Results.Rows(x).Cells("BilledBy").Value, reportfont1, Brushes.Black, 755, ypos)
            ypos = ypos + 25
            record = record + 1
            If ypos >= 1075 Then
                e.HasMorePages = True
                Exit Sub
            End If
        Next
        ypos = ypos + 50
        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        End If
        If print10 = 0 Then
            e.Graphics.DrawString("Summary", reportfont2, Brushes.Black, 330, ypos)
            ypos = ypos + 75
            print10 = 1
        End If
        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        End If
        If print4 = 0 Then
            e.Graphics.DrawString("Total Number of Bills :" & Results.RowCount - 1, reportfont3, Brushes.Black, 300, ypos)
            print4 = 1
            ypos = ypos + 50
        End If
        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        End If
        If today = 1 Then
            If print5 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt, [BilledBy] as bill FROM Customer WHERE [DateOrder]= #" & Format(Now.Date, "yyyy/MM/dd") & "# GROUP BY [BilledBy]", cnn)
                da.Fill(dt)
                cnn.Close()
                For x = rec1 To dt.Rows.Count - 1
                    e.Graphics.DrawString("Bills Billed by " & Convert.ToString(dt.Rows(x).Item("bill")) & ":" & Convert.ToString(dt.Rows(x).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                    If x = dt.Rows.Count - 1 Then
                        print5 = 1
                    End If
                    ypos = ypos + 50
                    rec1 = rec1 + 1
                    If ypos >= 1075 Then
                        e.HasMorePages = True
                        Exit Sub
                    End If
                Next
            End If
        Else
            If print5 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt, [BilledBy] as bill FROM Customer WHERE [DateOrder] between #" & Format(fromDate.Value, "yyyy/MM/dd") & "# and #" & Format(ToDate.Value, "yyyy/MM/dd") & "# GROUP BY [BilledBy]", cnn)
                da.Fill(dt)
                cnn.Close()
                For x = rec1 To dt.Rows.Count - 1
                    e.Graphics.DrawString("Bills Billed by " & Convert.ToString(dt.Rows(x).Item("bill")) & ":" & Convert.ToString(dt.Rows(x).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                    If x = dt.Rows.Count - 1 Then
                        print5 = 1
                    End If
                    ypos = ypos + 50
                    rec1 = rec1 + 1
                    If ypos >= 1075 Then
                        e.HasMorePages = True
                        Exit Sub
                    End If
                Next
            End If
        End If

        If today = 1 Then
            If print6 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da1 = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt FROM Customer WHERE [DateOrder]= #" & Format(Now.Date, "yyyy/MM/dd") & "# AND [Delivered] = 'Yes'", cnn)
                da1.Fill(dt1)
                cnn.Close()
                e.Graphics.DrawString("Bills Delivered :" & Convert.ToString(dt1.Rows(0).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                print6 = 1
                ypos = ypos + 50
                If ypos >= 1075 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        Else
            If print6 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da1 = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt FROM Customer WHERE [DateOrder] between #" & Format(fromDate.Value, "yyyy/MM/dd") & "# and #" & Format(ToDate.Value, "yyyy/MM/dd") & "# AND [Delivered] = 'Yes'", cnn)
                da1.Fill(dt1)
                cnn.Close()
                e.Graphics.DrawString("Bills Delivered :" & Convert.ToString(dt1.Rows(0).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                print6 = 1
                ypos = ypos + 50
                If ypos >= 1075 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        End If


        If today = 1 Then
            If print7 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da2 = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt FROM Customer WHERE [DateOrder]= #" & Format(Now.Date, "yyyy/MM/dd") & "# AND [Delivered] = 'No'", cnn)
                da2.Fill(dt2)
                cnn.Close()
                e.Graphics.DrawString("Bills Not Delivered :" & Convert.ToString(dt2.Rows(0).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                print7 = 1
                ypos = ypos + 50
                If ypos >= 1075 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        Else
            If print7 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da2 = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt FROM Customer WHERE [DateOrder] between #" & Format(fromDate.Value, "yyyy/MM/dd") & "# and #" & Format(ToDate.Value, "yyyy/MM/dd") & "# AND [Delivered] = 'No'", cnn)
                da2.Fill(dt2)
                cnn.Close()
                e.Graphics.DrawString("Bills Not Delivered :" & Convert.ToString(dt2.Rows(0).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                print7 = 1
                ypos = ypos + 50
                If ypos >= 1075 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        End If

        If today = 1 Then
            If print8 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da3 = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt FROM Customer WHERE [DateOrder]= #" & Format(Now.Date, "yyyy/MM/dd") & "# AND [BillType] = 'Order'", cnn)
                da3.Fill(dt3)
                cnn.Close()
                e.Graphics.DrawString("No. of Order Bills :" & Convert.ToString(dt3.Rows(0).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                print8 = 1
                ypos = ypos + 50
                If ypos >= 1075 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        Else
            If print8 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da3 = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt FROM Customer WHERE [DateOrder] between #" & Format(fromDate.Value, "yyyy/MM/dd") & "# and #" & Format(ToDate.Value, "yyyy/MM/dd") & "# AND [BillType] = 'Order'", cnn)
                da3.Fill(dt3)
                cnn.Close()
                e.Graphics.DrawString("No. of Order Bills :" & Convert.ToString(dt3.Rows(0).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                print8 = 1
                ypos = ypos + 50
                If ypos >= 1075 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        End If

        If today = 1 Then
            If print9 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da4 = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt FROM Customer WHERE [DateOrder]= #" & Format(Now.Date, "yyyy/MM/dd") & "# AND [BillType] = 'Cash'", cnn)
                da4.Fill(dt4)
                cnn.Close()
                e.Graphics.DrawString("No. of Cash Bills :" & Convert.ToString(dt4.Rows(0).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                print9 = 1
                ypos = ypos + 50
                If ypos >= 1075 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        Else
            If print9 = 0 Then
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                da4 = New OleDb.OleDbDataAdapter("SELECT COUNT(Cust_name) as cnt FROM Customer WHERE [DateOrder] between #" & Format(fromDate.Value, "yyyy/MM/dd") & "# and #" & Format(ToDate.Value, "yyyy/MM/dd") & "# AND [BillType] = 'Cash'", cnn)
                da4.Fill(dt4)
                cnn.Close()
                e.Graphics.DrawString("No. of Cash Bills :" & Convert.ToString(dt4.Rows(0).Item("cnt")), reportfont3, Brushes.Black, 300, ypos)
                print9 = 1
                ypos = ypos + 50
                If ypos >= 1075 Then
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If
        End If

        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        End If
        If print1 = 0 Then
            e.Graphics.DrawString("Total Billed Amount :Rs." & lblTotal.Text, reportfont3, Brushes.Black, 300, ypos)
            print1 = 1
            ypos = ypos + 50
        End If

        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        End If
        If print2 = 0 Then
            e.Graphics.DrawString("Advance Collected :Rs." & lblAdvance.Text, reportfont3, Brushes.Black, 300, ypos)
            print2 = 1
            ypos = ypos + 50
        End If
        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        End If
        If print3 = 0 Then
            e.Graphics.DrawString("Balance to be collected :Rs." & lblBalance.Text, reportfont3, Brushes.Black, 300, ypos)
            print3 = 1
            ypos = ypos + 50
        End If
        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        End If
        If print11 = 0 Then
            e.Graphics.DrawString("Total Discount :Rs." & lblDiscount.Text, reportfont3, Brushes.Black, 300, ypos)
            print11 = 1
            ypos = ypos + 50
        End If
        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        End If
        If print12 = 0 Then
            e.Graphics.DrawString("Net Total :Rs." & NetTotal.Text, reportfont3, Brushes.Black, 300, ypos)
            print12 = 1
            ypos = ypos + 50
        End If
        If ypos >= 1075 Then
            e.HasMorePages = True
            Exit Sub
        Else
            e.HasMorePages = False
        End If

    End Sub
End Class