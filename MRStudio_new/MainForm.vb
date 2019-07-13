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
        UpdatingUI = True
        presenter = New MainPresenter(Me, New MainDBHelper, New DialogHelper)
        InitializeComponent()
        UpdatingUI = False
    End Sub

    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus
        If UpdatingUI Then
            Return
        End If
        If txtName.Text = "Enter Name" Then
            txtName.ForeColor = Color.Black
            txtName.Text = ""
        End If
    End Sub
    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus
        If UpdatingUI Then
            Return
        End If
        If txtName.Text = "" Then
            txtName.ForeColor = Color.Silver
            txtName.Text = "Enter Name"
        End If
    End Sub
    Private Sub txtPhone_GotFocus(sender As Object, e As EventArgs) Handles txtPhone.GotFocus
        If UpdatingUI Then
            Return
        End If
        If txtPhone.Text = "1234567890" Then
            txtPhone.ForeColor = Color.Black
            txtPhone.Text = ""
        End If
    End Sub
    Private Sub txtPhone_LostFocus(sender As Object, e As EventArgs) Handles txtPhone.LostFocus
        If UpdatingUI Then
            Return
        End If
        If txtPhone.Text = "" Then
            txtPhone.ForeColor = Color.Silver
            txtPhone.Text = "1234567890"
        End If
    End Sub
    Private Sub txtAdvance_GotFocus(sender As Object, e As EventArgs) Handles txtAdvance.GotFocus
        If UpdatingUI Then
            Return
        End If
        If txtAdvance.Text = "0" Then
            txtAdvance.ForeColor = Color.Black
            txtAdvance.Text = ""
        End If
    End Sub
    Private Sub txtAdvance_LostFocus(sender As Object, e As EventArgs) Handles txtAdvance.LostFocus
        If UpdatingUI Then
            Return
        End If
        If txtAdvance.Text = "" Then
            txtAdvance.ForeColor = Color.Silver
            txtAdvance.Text = "0"
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        presenter.SaveCurrentEntry()
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
        If UpdatingUI Then
            Return
        End If
        Dim advance As Double
        If Integer.TryParse(txtAdvance.Text, advance) Then
            presenter.UpdateAdvance(advance)
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdatingUI = True
        presenter.Initialize(LoginForm.txtUsername.Text, LoginForm.RadioAdmin.Checked)
        UpdatingUI = False
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
        Dim reportfont1 As Font = New Font("Arial", 9, FontStyle.Bold)
        Dim reportfont3 As Font = New Font("Arial", 10, FontStyle.Bold)
        Dim reportfont2 As Font = New Font("Times New Roman", 16, FontStyle.Bold)
        Dim apen As Pen = New Pen(Color.Black, 2.0F)
        Dim apen1 As Pen = New Pen(Color.Black, 1.0F)
        Dim x As Integer
        Dim image1 As New Bitmap(filename:="table.png")
        Dim image2 As New Bitmap(filename:="MR.png")
        With e
            .Graphics.DrawImage(image2, point:=New Point(x:=30, y:=30))
            .Graphics.DrawString("M.R. DIGITAL STUDIO", reportfont2, Brushes.Black, 125, 30)
            .Graphics.DrawString("10,Kumarasamy Colony Main Road,", reportfont1, Brushes.Black, 125, 55)
            .Graphics.DrawString("Kangayam Cross Road,Tirupur-4.", reportfont1, Brushes.Black, 125, 73)
            .Graphics.DrawString("Ph : 0421-4254884 Cell : 9994455577", reportfont1, Brushes.Black, 125, 91)
            .Graphics.DrawString("Email: rkmr2006@gmail.com", reportfont1, Brushes.Black, 125, 109)

            .Graphics.DrawLine(apen, 20, 135, 385, 135)
            .Graphics.DrawLine(apen1, 20, 20, 385, 20)
            .Graphics.DrawLine(apen, 20, 20, 20, 135)
            .Graphics.DrawLine(apen1, 385, 20, 385, 135)

            .Graphics.DrawLine(apen1, 25, 130, 380, 130)
            .Graphics.DrawLine(apen, 25, 25, 380, 25)
            .Graphics.DrawLine(apen1, 25, 25, 25, 130)
            .Graphics.DrawLine(apen, 380, 25, 380, 130)
        End With

        If Me.ComboBill.SelectedItem = "Cash" Then
            e.Graphics.DrawString("CASH BILL", reportfont3, Brushes.Black, 145, 145)
        Else
            e.Graphics.DrawString("ORDER BILL", reportfont3, Brushes.Black, 145, 145)
        End If
        e.Graphics.DrawString(lblDate.Text, reportfont3, Brushes.Black, 15, 170)
        e.Graphics.DrawString("Bill No. : " & Replace(lblid.Text, "Invoice : ", ""), reportfont3, Brushes.Black, 210, 170)
        e.Graphics.DrawString(String.Concat("Name : ", txtName.Text), reportfont3, Brushes.Black, 15, 195)
        e.Graphics.DrawString(String.Concat("Contact : ", txtPhone.Text), reportfont3, Brushes.Black, 210, 195)
        e.Graphics.DrawImage(image1, point:=New Point(x:=-4, y:=220))
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
        If UpdatingUI Then
            Return
        End If
        If txtPhone.Text <> "1234567890" Then
            presenter.UpdatePhoneNumber(txtPhone.Text)
        End If
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtName.TextChanged
        If UpdatingUI Then
            Return
        End If
        If txtName.Text <> "Enter Name" Then
            presenter.UpdateCustomerName(txtName.Text)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If UpdatingUI Then
            Return
        End If
        presenter.CancelCurrentEntry()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If UpdatingUI Then
            Return
        End If
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
        presenter.ShowUpdateForm()

    End Sub

    Private Sub txtDiscount_GotFocus(sender As Object, e As EventArgs) Handles txtDiscount.GotFocus
        If UpdatingUI Then
            Return
        End If
        If txtDiscount.Text = "0" Then
            txtDiscount.ForeColor = Color.Black
            txtDiscount.Text = ""
        End If
    End Sub

    Private Sub txtDiscount_LostFocus(sender As Object, e As EventArgs) Handles txtDiscount.LostFocus
        If UpdatingUI Then
            Return
        End If
        If txtDiscount.Text = "" Then
            txtDiscount.ForeColor = Color.Silver
            txtDiscount.Text = "0"
        End If
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        If UpdatingUI Then
            Return
        End If
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
                Dim dataCollection As New AutoCompleteStringCollection()
                Dim productList As List(Of String)
                If ProductDetails.CurrentCell.Value = Nothing Then
                    productList = presenter.GetProductList("")
                    AddItems(dataCollection, productList)
                Else
                    productList = presenter.GetProductList(ProductDetails.CurrentCell.Value.ToString())
                    AddItems(dataCollection, productList)
                End If
                autoText.AutoCompleteCustomSource = dataCollection
            End If
        End If
    End Sub
    Public Sub AddItems(ByVal col As AutoCompleteStringCollection, ByVal productList As List(Of String))
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
            Catch
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
        If UpdatingUI Then
            Return
        End If
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
        lblBalance.Text = v
    End Sub

    Public Sub UpdateDiscount(v As String) Implements IMainView.UpdateDiscount
        txtDiscount.Text = v
    End Sub

    Public Sub UpdateAdvance(v As String) Implements IMainView.UpdateAdvance
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
        If ComboBill.SelectedIndex > -1 Then
            presenter.UpdateBillType(ComboBill.SelectedIndex)
        End If
    End Sub

    Private Sub checkDeliver_CheckedChanged(sender As Object, e As EventArgs) Handles checkDeliver.CheckedChanged
        presenter.UpdateDeliverStatus(checkDeliver.Checked)
    End Sub

    Public Sub UpdateAmount(amount As Double) Implements IMainView.UpdateAmount
        ProductDetails.Rows(ProductDetails.CurrentCell.RowIndex).Cells(3).Value = amount
    End Sub

    Public Sub UpdateTotalAmount(v As String) Implements IMainView.UpdateTotalAmount
        lblTotal.Text = v.ToString()
    End Sub

    Public Sub UpdateRate(amount As Double) Implements IMainView.UpdateRate
        ProductDetails.Rows(ProductDetails.CurrentCell.RowIndex).Cells(2).Value = amount
    End Sub

    Public Sub UpdateQuantity(v As Integer) Implements IMainView.UpdateQuantity
        ProductDetails.Rows(ProductDetails.CurrentCell.RowIndex).Cells(1).Value = v
    End Sub

    Public Sub ShowUpdateForm() Implements IMainView.ShowUpdateForm
        UpdateForm.Show()
    End Sub
End Class