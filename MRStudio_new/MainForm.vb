Imports System.Collections
Imports System.Collections.Generic
Imports BillApp.DBHelper.MainForm
Imports BillApp.Presenter
Imports BillApp.ViewHelper

Public Class MainForm
    Implements IMainView
    Dim wait As Integer = 0
    Dim save As Integer = 0
    Dim entered As Integer = 0
    Dim mouseclicked As Integer = 0
    Dim presenter As IMainPresenter

    Public Sub New()
        InitializeComponent()
        presenter = New MainPresenter(Me, New MainDBHelper)
    End Sub

    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus
        If txtName.Text = "Enter Name" Then
            txtName.ForeColor = Color.Black
            txtName.Text = ""
        End If
    End Sub
    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus
        If txtName.Text = "" Then
            txtName.ForeColor = Color.Silver
            txtName.Text = "Enter Name"
        End If
    End Sub
    Private Sub txtPhone_GotFocus(sender As Object, e As EventArgs) Handles txtPhone.GotFocus
        If txtPhone.Text = "1234567890" Then
            txtPhone.ForeColor = Color.Black
            txtPhone.Text = ""
        End If
    End Sub
    Private Sub txtPhone_LostFocus(sender As Object, e As EventArgs) Handles txtPhone.LostFocus
        If txtPhone.Text = "" Then
            txtPhone.ForeColor = Color.Silver
            txtPhone.Text = "1234567890"
        End If
    End Sub
    Private Sub txtAdvance_GotFocus(sender As Object, e As EventArgs) Handles txtAdvance.GotFocus
        If txtAdvance.Text = "0" Then
            txtAdvance.ForeColor = Color.Black
            txtAdvance.Text = ""
        End If
    End Sub
    Private Sub txtAdvance_LostFocus(sender As Object, e As EventArgs) Handles txtAdvance.LostFocus
        If txtAdvance.Text = "" Then
            txtAdvance.ForeColor = Color.Silver
            txtAdvance.Text = "0"
        End If
    End Sub
    Private Sub RefreshInvoiceId()
        Dim number As UInt64
        number = My.Computer.FileSystem.ReadAllText("MRStudio\count.txt")
        lblid.Text = String.Concat("Invoice : ", Format(number, "0000"))
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Dim productdetail As String
        'Dim x As Integer
        'Dim number As Integer
        'Dim deliver As String
        'Dim billtype As String
        'productdetail = ""
        'If txtName.Text = "Enter Name" Or txtPhone.Text = "1234567890" Or lblTotal.Text = "0" Then
        '    MessageBox.Show("Customer Name or Phone Number or Product details missing", "Required!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        'ElseIf IsNothing(ComboBill.SelectedItem) Then
        '    MessageBox.Show("Select Bill Type", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        'Else
        '    If checkDeliver.Checked = True Then
        '        deliver = "Yes"
        '    Else
        '        deliver = "No"
        '    End If
        '    If ComboBill.SelectedValue = "Order" Then
        '        billtype = "Order"
        '    Else
        '        billtype = "Cash"
        '    End If
        '    number = My.Computer.FileSystem.ReadAllText("MRStudio\count.txt")
        '    For x = 0 To ProductDetails.RowCount - 2
        '        productdetail = String.Concat(productdetail, ProductDetails.Rows(x).Cells(0).Value, "-", ProductDetails.Rows(x).Cells(1).Value, "-", ProductDetails.Rows(x).Cells(3).Value, "|")
        '    Next
        '    Dim cmd As New OleDb.OleDbCommand
        '    If Not cnn.State = ConnectionState.Open Then
        '        'open connection if it is not yet open
        '        cnn.Open()
        '    End If
        '    Try
        '        If save = 0 Then
        '            RefreshInvoiceId()
        '            cmd.Connection = cnn
        '            cmd.CommandText = "INSERT INTO Customer(Cust_Name, Cust_Phone, invoice_id, Products,Total,Balance,Advance,Discount,Delivered,BillType,BilledBy,DateOrder) " &
        '                           " VALUES('" & txtName.Text & "','" & txtPhone.Text & "','" &
        '                           Replace(lblid.Text, "Invoice : ", "") & "','" & productdetail & "','" &
        '                           lblTotal.Text & "','" & lblBalance.Text & "','" & txtAdvance.Text & "','" & txtDiscount.Text & "','" & deliver & "','" & billtype & "','" & lblUser.Text & "','" & Now.Date & "')"
        '            cmd.ExecuteNonQuery()
        '            MessageBox.Show("Details Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            save = 1
        '            number = Convert.ToInt64(number) + 1
        '            My.Computer.FileSystem.WriteAllText("MRStudio\count.txt", number, False)
        '            btnCancel.Enabled = False
        '        Else
        '            MessageBox.Show("Already Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    Catch ex As OleDb.OleDbException
        '        MessageBox.Show("Invoice Id Error", "Exit and Restart", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
    End Sub

    Private Sub ProductDetails_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductDetails.CellMouseEnter
        Try
            If e.ColumnIndex = 1 And e.RowIndex >= 0 Then
                mouseclicked = 1
                ProductDetails.CurrentCell = ProductDetails.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        Catch exe As IndexOutOfRangeException
        End Try
    End Sub
    Dim UpdatingUI As Boolean
    Private Sub ProductDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles ProductDetails.CellValueChanged
        If UpdatingUI = True Then
            Return
        End If
        UpdatingUI = True
        If e.ColumnIndex = 0 Then
            presenter.AddProduct(ProductDetails.Rows(e.RowIndex).Cells(0).Value.ToString())
        ElseIf e.ColumnIndex = 1 Then
            presenter.UpdateQuantity(ProductDetails.Rows(e.RowIndex).Cells(0).Value.ToString(), ProductDetails.Rows(e.RowIndex).Cells(1).Value)
        End If

        Try
            If ProductDetails.CurrentCell.ColumnIndex = 0 Then
                If ProductDetails.CurrentCell.RowIndex = 0 Then
                    ProductDetails.CurrentCell = ProductDetails.Rows(0).Cells(ProductDetails.CurrentCell.ColumnIndex + 1)
                Else
                    ProductDetails.CurrentCell = ProductDetails.Rows(ProductDetails.CurrentCell.RowIndex - 1).Cells(ProductDetails.CurrentCell.ColumnIndex + 1)
                End If
            End If
        Catch exe As NullReferenceException
            UpdatingUI = False
        End Try
        UpdatingUI = False
    End Sub

    Private Sub txtAdvance_TextChanged(sender As Object, e As EventArgs) Handles txtAdvance.TextChanged
        Dim advance As Double
        If Integer.TryParse(txtAdvance.Text, advance) Then
            presenter.UpdateAdvance(advance)
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles Me.Load
        presenter.Initialize(LoginForm.txtUsername.Text, LoginForm.RadioAdmin.Checked)
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
        Dim reportfont1 As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim reportfont3 As Font = New Drawing.Font("Arial", 10, FontStyle.Bold)
        Dim reportfont2 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
        Dim apen As Pen = New Pen(Color.Black, 2.0F)
        Dim apen1 As Pen = New Pen(Color.Black, 1.0F)
        Dim x As Integer
        Dim Image1 As New System.Drawing.Bitmap(filename:="table.png")
        Dim Image2 As New System.Drawing.Bitmap(filename:="MR.png")
        e.Graphics.DrawImage(Image2, point:=New Point(x:=30, y:=30))
        e.Graphics.DrawString("M.R. DIGITAL STUDIO", reportfont2, Brushes.Black, 125, 30)
        e.Graphics.DrawString("10,Kumarasamy Colony Main Road,", reportfont1, Brushes.Black, 125, 55)
        e.Graphics.DrawString("Kangayam Cross Road,Tirupur-4.", reportfont1, Brushes.Black, 125, 73)
        e.Graphics.DrawString("Ph : 0421-4254884 Cell : 9994455577", reportfont1, Brushes.Black, 125, 91)
        e.Graphics.DrawString("Email: rkmr2006@gmail.com", reportfont1, Brushes.Black, 125, 109)

        e.Graphics.DrawLine(apen, 20, 135, 385, 135)
        e.Graphics.DrawLine(apen1, 20, 20, 385, 20)
        e.Graphics.DrawLine(apen, 20, 20, 20, 135)
        e.Graphics.DrawLine(apen1, 385, 20, 385, 135)

        e.Graphics.DrawLine(apen1, 25, 130, 380, 130)
        e.Graphics.DrawLine(apen, 25, 25, 380, 25)
        e.Graphics.DrawLine(apen1, 25, 25, 25, 130)
        e.Graphics.DrawLine(apen, 380, 25, 380, 130)
        If Me.ComboBill.SelectedItem = "Cash" Then
            e.Graphics.DrawString("CASH BILL", reportfont3, Brushes.Black, 145, 145)
        Else
            e.Graphics.DrawString("ORDER BILL", reportfont3, Brushes.Black, 145, 145)
        End If
        e.Graphics.DrawString(lblDate.Text, reportfont3, Brushes.Black, 15, 170)
        e.Graphics.DrawString("Bill No. : " & Replace(lblid.Text, "Invoice : ", ""), reportfont3, Brushes.Black, 210, 170)
        e.Graphics.DrawString(String.Concat("Name : ", txtName.Text), reportfont3, Brushes.Black, 15, 195)
        e.Graphics.DrawString(String.Concat("Contact : ", txtPhone.Text), reportfont3, Brushes.Black, 210, 195)
        e.Graphics.DrawImage(Image1, point:=New Point(x:=-4, y:=220))
        For x = 0 To ProductDetails.RowCount - 2
            e.Graphics.DrawString(ProductDetails.Rows(x).Cells(0).Value, reportfont3, Brushes.Black, 20, (255 + x * 25))
            e.Graphics.DrawString(ProductDetails.Rows(x).Cells(1).Value, reportfont3, Brushes.Black, 185, (255 + x * 25))
            e.Graphics.DrawString(ProductDetails.Rows(x).Cells(2).Value, reportfont3, Brushes.Black, 265, (255 + x * 25))
            e.Graphics.DrawString(ProductDetails.Rows(x).Cells(3).Value, reportfont3, Brushes.Black, 335, (255 + x * 25))
        Next
        e.Graphics.DrawString(String.Concat("Total : ", "Rs.", lblTotal.Text), reportfont1, Brushes.Black, 15, 490)
        e.Graphics.DrawString(String.Concat("Adv. : ", "Rs.", txtAdvance.Text), reportfont1, Brushes.Black, 135, 490)
        e.Graphics.DrawString(String.Concat("Bal. : ", "Rs.", lblBalance.Text), reportfont1, Brushes.Black, 265, 490)
        e.Graphics.DrawLine(Pens.Black, 15, 525, 395, 525)
        e.Graphics.DrawString("Thank You Visit us again!", reportfont1, Brushes.Black, 100, 540)
    End Sub

    Private Sub txtPhone_TextChanged(sender As Object, e As EventArgs) Handles txtPhone.TextChanged
        presenter.UpdatePhoneNumber(txtPhone.Text)
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        presenter.UpdateCustomerName(txtName.Text)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        presenter.CancelCurrentEntry()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        presenter.CreateNewBillEntry()
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        presenter.ShowProductForm()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        presenter.ShowUpdateDBForm()

    End Sub
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        'Dim cmd As New OleDb.OleDbCommand
        'If Not cnn.State = ConnectionState.Open Then
        '    cnn.Open()
        'End If
        'cmd.Connection = cnn
        'cmd.CommandText = "UPDATE [Admin] SET [Password] = '" & txtChangePassword.Text & "' WHERE Username ='" & lblUser.Text & "'"
        'cmd.ExecuteNonQuery()
        'cnn.Close()
        'MessageBox.Show("Password Changed", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'txtChangePassword.Text = ""
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        ReportsForm.Show()
    End Sub

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        presenter.ShowUserForm()
    End Sub

    Private Sub btnChangeUsername_Click(sender As Object, e As EventArgs) Handles btnChangeUsername.Click
        'Dim cmd As New OleDb.OleDbCommand
        'If Not cnn.State = ConnectionState.Open Then
        '    cnn.Open()
        'End If
        'cmd.Connection = cnn
        'cmd.CommandText = "UPDATE [Admin] SET [Username] = '" & txtChangeUsername.Text & "' WHERE ID =1"
        'cmd.ExecuteNonQuery()
        'cnn.Close()
        'MessageBox.Show("Username Changed", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'lblUser.Text = txtChangeUsername.Text
        'txtChangeUsername.Text = ""

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoginForm.Show()
        Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateForm.Show()
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
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        Dim discount As Double
        If Double.TryParse(txtDiscount.Text, discount) Then
            presenter.UpdateDiscount(discount)
        End If
    End Sub
    Private Sub ProductDetails_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles ProductDetails.EditingControlShowing
        Dim titleText As String = ProductDetails.Columns(0).HeaderText
        If titleText.Equals("Product Name") Then
            Dim autoText As TextBox = TryCast(e.Control, TextBox)
            If autoText IsNot Nothing Then
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                Dim DataCollection As New AutoCompleteStringCollection()
                Dim ProductList As List(Of String)
                ProductList = presenter.GetProductList(ProductDetails.CurrentCell.Value.ToString())
                addItems(DataCollection, ProductList)
                autoText.AutoCompleteCustomSource = DataCollection
            End If
        End If
    End Sub
    Public Sub addItems(ByVal col As AutoCompleteStringCollection, ByVal productList As List(Of String))
        Dim product As String
        For Each product In productList
            col.Add(product)
        Next
    End Sub
    Private Sub ProductDetails_SelectionChanged(sender As Object, e As EventArgs) Handles ProductDetails.SelectionChanged

        If mouseclicked = 1 Then
            mouseclicked = 0
        Else
            Try
                If ProductDetails.CurrentCell.ColumnIndex = 1 Then
                    If ProductDetails.CurrentCell.RowIndex = 0 Then
                        ProductDetails.CurrentCell = ProductDetails.Rows(0).Cells(ProductDetails.CurrentCell.ColumnIndex)
                    Else
                        ProductDetails.CurrentCell = ProductDetails.Rows(ProductDetails.CurrentCell.RowIndex - 1).Cells(ProductDetails.CurrentCell.ColumnIndex)
                    End If
                End If
            Catch exe As NullReferenceException
            End Try
        End If
    End Sub

    Public Sub UpdateCustomerName(currentName As String) Implements IMainView.UpdateCustomerName
        txtName.Text = currentName
    End Sub

    Public Sub UpdatePhoneNumber(currentPhoneNumber As String) Implements IMainView.UpdatePhoneNumber
        txtPhone.Text = currentPhoneNumber
    End Sub

    Public Sub SetFocusToName() Implements IMainView.SetFocusToName
        txtName.Focus()
    End Sub

    Public Sub SetSessionUserName(userName As String) Implements IMainView.SetSessionUserName
        lblUser.Text = userName
    End Sub

    Public Sub SetDate(dateAsString As String) Implements IMainView.SetDate
        lblDate.Text = dateAsString
    End Sub

    Public Sub UpdateInvoiceID(v As String) Implements IMainView.UpdateInvoiceID
        lblid.Text = v
    End Sub

    Public Sub ShowAdminOptions() Implements IMainView.ShowAdminOptions
        btnUser.Visible = True
        btnReport.Visible = True
        btnChange.Visible = True
        txtChangePassword.Visible = True
        txtChangeUsername.Visible = True
        btnChangeUsername.Visible = True
    End Sub

    Public Sub HideAdminOptions() Implements IMainView.HideAdminOptions
        btnUser.Visible = False
        btnReport.Visible = False
        btnChange.Visible = False
        txtChangePassword.Visible = False
        txtChangeUsername.Visible = False
        btnChangeUsername.Visible = False
    End Sub

    Public Sub GreyoutDiscount() Implements IMainView.GreyoutDiscount
        txtDiscount.Enabled = False
    End Sub

    Public Sub UpdateBalance(v As String) Implements IMainView.UpdateBalance
        If UpdatingUI Then
            Return
        End If
        lblBalance.Text = v
    End Sub

    Public Sub UpdateDiscount(v As String) Implements IMainView.UpdateDiscount
        If UpdatingUI Then
            Return
        End If
        txtDiscount.Text = v
    End Sub

    Public Sub UpdateAdvance(v As String) Implements IMainView.UpdateAdvance
        If UpdatingUI Then
            Return
        End If
        txtAdvance.Text = v
    End Sub

    Public Sub SetDiscountAsAvailable() Implements IMainView.SetDiscountAsAvailable
        txtDiscount.Enabled = True
    End Sub

    Public Sub ShowUserForm() Implements IMainView.ShowUserForm
        UserForm.Show()
    End Sub

    Public Sub InitializeNewEntry() Implements IMainView.InitializeNewEntry
        txtName.Text = ""
        txtPhone.Text = ""
        lblTotal.Text = 0
        txtAdvance.Text = 0
        lblBalance.Text = 0
        btnCancel.Enabled = True
        ProductDetails.Rows.Clear()
        txtDiscount.ForeColor = Color.Silver
        txtAdvance.ForeColor = Color.Silver
        txtDiscount.Text = 0
        txtDiscount.Enabled = False
    End Sub

    Public Sub ShowProductForm() Implements IMainView.ShowProductForm
        ProductForm.Show()
    End Sub

    Public Sub ShowUpdateDBForm() Implements IMainView.ShowUpdateDBForm
        UpdateDBForm.Show()
    End Sub

    Private Sub ComboBill_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBill.SelectedIndexChanged
        presenter.UpdateBillType(ComboBill.SelectedValue.ToString())
    End Sub

    Private Sub checkDeliver_CheckedChanged(sender As Object, e As EventArgs) Handles checkDeliver.CheckedChanged
        presenter.UpdateDeliverStatus(checkDeliver.Checked)
    End Sub

    Public Sub UpdateAmount(amount As Double) Implements IMainView.UpdateAmount
        ProductDetails.Rows(ProductDetails.CurrentCell.RowIndex).Cells(3).Value = amount
    End Sub

    Public Sub UpdateTotalAmount(v As Object) Implements IMainView.UpdateTotalAmount
        If UpdatingUI Then
            Return
        End If
        lblTotal.Text = v.ToString()
    End Sub

    Public Sub UpdateRate(amount As Double) Implements IMainView.UpdateRate
        ProductDetails.Rows(ProductDetails.CurrentCell.RowIndex).Cells(2).Value = amount
    End Sub
End Class