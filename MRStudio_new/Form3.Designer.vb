<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblid = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAdvance = New System.Windows.Forms.TextBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ProductDetails = New System.Windows.Forms.DataGridView()
        Me.ProductDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MRStudioDataSet = New MRStudio_new.MRStudioDataSet()
        Me.ProductDetailTableAdapter = New MRStudio_new.MRStudioDataSetTableAdapters.ProductDetailTableAdapter()
        Me.btnProducts = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.checkDeliver = New System.Windows.Forms.CheckBox()
        Me.ComboBill = New System.Windows.Forms.ComboBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtChangePassword = New System.Windows.Forms.TextBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.btnChangeUsername = New System.Windows.Forms.Button()
        Me.txtChangeUsername = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.Product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ProductDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MRStudioDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.ForeColor = System.Drawing.Color.Silver
        Me.txtPhone.Location = New System.Drawing.Point(388, 332)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(296, 31)
        Me.txtPhone.TabIndex = 5
        Me.txtPhone.Text = "1234567890"
        Me.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.Silver
        Me.txtName.Location = New System.Drawing.Point(388, 278)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(296, 31)
        Me.txtName.TabIndex = 4
        Me.txtName.Text = "Enter Name"
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.BackColor = System.Drawing.Color.Transparent
        Me.lblid.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblid.ForeColor = System.Drawing.Color.Transparent
        Me.lblid.Location = New System.Drawing.Point(516, 202)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(168, 23)
        Me.lblid.TabIndex = 1
        Me.lblid.Text = "Invoice : MR001"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDate.Location = New System.Drawing.Point(220, 202)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(184, 23)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date: 13/03/2016"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Navy
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(405, 614)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 44)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.Navy
        Me.btnNew.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(562, 615)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(133, 44)
        Me.btnNew.TabIndex = 26
        Me.btnNew.Text = "New Invoice"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Navy
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(789, 615)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(368, 47)
        Me.btnPrint.TabIndex = 27
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Navy
        Me.btnSave.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(224, 614)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(158, 44)
        Me.btnSave.TabIndex = 28
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblBalance
        '
        Me.lblBalance.AutoSize = True
        Me.lblBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblBalance.Font = New System.Drawing.Font("Verdana", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalance.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblBalance.Location = New System.Drawing.Point(931, 388)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(74, 78)
        Me.lblBalance.TabIndex = 32
        Me.lblBalance.Text = "0"
        Me.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Verdana", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal.Location = New System.Drawing.Point(931, 259)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(74, 78)
        Me.lblTotal.TabIndex = 33
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(805, 259)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 78)
        Me.Label6.TabIndex = 34
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAdvance
        '
        Me.txtAdvance.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdvance.ForeColor = System.Drawing.Color.Silver
        Me.txtAdvance.Location = New System.Drawing.Point(964, 498)
        Me.txtAdvance.Name = "txtAdvance"
        Me.txtAdvance.Size = New System.Drawing.Size(109, 33)
        Me.txtAdvance.TabIndex = 39
        Me.txtAdvance.Text = "0"
        Me.txtAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'ProductDetails
        '
        Me.ProductDetails.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.ProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProductDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Product, Me.Quantity, Me.Rate, Me.Amount})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProductDetails.DefaultCellStyle = DataGridViewCellStyle5
        Me.ProductDetails.Location = New System.Drawing.Point(224, 423)
        Me.ProductDetails.Name = "ProductDetails"
        Me.ProductDetails.Size = New System.Drawing.Size(471, 137)
        Me.ProductDetails.TabIndex = 40
        '
        'ProductDetailBindingSource
        '
        Me.ProductDetailBindingSource.DataMember = "ProductDetail"
        Me.ProductDetailBindingSource.DataSource = Me.MRStudioDataSet
        '
        'MRStudioDataSet
        '
        Me.MRStudioDataSet.DataSetName = "MRStudioDataSet"
        Me.MRStudioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProductDetailTableAdapter
        '
        Me.ProductDetailTableAdapter.ClearBeforeFill = True
        '
        'btnProducts
        '
        Me.btnProducts.BackColor = System.Drawing.Color.Navy
        Me.btnProducts.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProducts.ForeColor = System.Drawing.Color.White
        Me.btnProducts.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProducts.Location = New System.Drawing.Point(28, 243)
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Size = New System.Drawing.Size(111, 46)
        Me.btnProducts.TabIndex = 41
        Me.btnProducts.Text = "Products"
        Me.btnProducts.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Navy
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(28, 305)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(111, 44)
        Me.btnSearch.TabIndex = 42
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'checkDeliver
        '
        Me.checkDeliver.AutoSize = True
        Me.checkDeliver.BackColor = System.Drawing.Color.Transparent
        Me.checkDeliver.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkDeliver.Location = New System.Drawing.Point(266, 579)
        Me.checkDeliver.Name = "checkDeliver"
        Me.checkDeliver.Size = New System.Drawing.Size(104, 22)
        Me.checkDeliver.TabIndex = 43
        Me.checkDeliver.Text = "Delivered"
        Me.checkDeliver.UseVisualStyleBackColor = False
        '
        'ComboBill
        '
        Me.ComboBill.FormattingEnabled = True
        Me.ComboBill.Items.AddRange(New Object() {"Cash", "Order"})
        Me.ComboBill.Location = New System.Drawing.Point(512, 577)
        Me.ComboBill.Name = "ComboBill"
        Me.ComboBill.Size = New System.Drawing.Size(129, 24)
        Me.ComboBill.TabIndex = 44
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        Me.lblUser.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblUser.Location = New System.Drawing.Point(100, 193)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(53, 23)
        Me.lblUser.TabIndex = 45
        Me.lblUser.Text = "User"
        '
        'txtChangePassword
        '
        Me.txtChangePassword.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChangePassword.ForeColor = System.Drawing.Color.Black
        Me.txtChangePassword.Location = New System.Drawing.Point(1180, 423)
        Me.txtChangePassword.Name = "txtChangePassword"
        Me.txtChangePassword.Size = New System.Drawing.Size(127, 26)
        Me.txtChangePassword.TabIndex = 46
        Me.txtChangePassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnChange
        '
        Me.btnChange.BackColor = System.Drawing.Color.Navy
        Me.btnChange.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChange.ForeColor = System.Drawing.Color.White
        Me.btnChange.Location = New System.Drawing.Point(1180, 467)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(127, 44)
        Me.btnChange.TabIndex = 47
        Me.btnChange.Text = "Change Password"
        Me.btnChange.UseVisualStyleBackColor = False
        '
        'btnReport
        '
        Me.btnReport.BackColor = System.Drawing.Color.Navy
        Me.btnReport.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.White
        Me.btnReport.Location = New System.Drawing.Point(28, 372)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(111, 44)
        Me.btnReport.TabIndex = 48
        Me.btnReport.Text = "Reports"
        Me.btnReport.UseVisualStyleBackColor = False
        '
        'btnUser
        '
        Me.btnUser.BackColor = System.Drawing.Color.Navy
        Me.btnUser.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUser.ForeColor = System.Drawing.Color.White
        Me.btnUser.Location = New System.Drawing.Point(28, 438)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(111, 44)
        Me.btnUser.TabIndex = 49
        Me.btnUser.Text = "Users"
        Me.btnUser.UseVisualStyleBackColor = False
        '
        'btnChangeUsername
        '
        Me.btnChangeUsername.BackColor = System.Drawing.Color.Navy
        Me.btnChangeUsername.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeUsername.ForeColor = System.Drawing.Color.White
        Me.btnChangeUsername.Location = New System.Drawing.Point(1180, 351)
        Me.btnChangeUsername.Name = "btnChangeUsername"
        Me.btnChangeUsername.Size = New System.Drawing.Size(127, 43)
        Me.btnChangeUsername.TabIndex = 51
        Me.btnChangeUsername.Text = "Change Username"
        Me.btnChangeUsername.UseVisualStyleBackColor = False
        '
        'txtChangeUsername
        '
        Me.txtChangeUsername.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChangeUsername.ForeColor = System.Drawing.Color.Black
        Me.txtChangeUsername.Location = New System.Drawing.Point(1180, 306)
        Me.txtChangeUsername.Name = "txtChangeUsername"
        Me.txtChangeUsername.Size = New System.Drawing.Size(127, 26)
        Me.txtChangeUsername.TabIndex = 50
        Me.txtChangeUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Navy
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1180, 224)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 43)
        Me.Button1.TabIndex = 52
        Me.Button1.Text = "Logout"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Navy
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(1180, 158)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(127, 44)
        Me.btnUpdate.TabIndex = 53
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(801, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Version 1.1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(420, 577)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 22)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Bill type :"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MRStudio_new.My.Resources.Resources.mr__2
        Me.PictureBox1.Location = New System.Drawing.Point(364, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(627, 146)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 56
        Me.PictureBox1.TabStop = False
        '
        'txtDiscount
        '
        Me.txtDiscount.Enabled = False
        Me.txtDiscount.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscount.ForeColor = System.Drawing.Color.Silver
        Me.txtDiscount.Location = New System.Drawing.Point(964, 544)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(109, 33)
        Me.txtDiscount.TabIndex = 57
        Me.txtDiscount.Text = "0"
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Product
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        Me.Product.DefaultCellStyle = DataGridViewCellStyle1
        Me.Product.HeaderText = "Product Name"
        Me.Product.Name = "Product"
        Me.Product.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Product.Width = 200
        '
        'Quantity
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Width = 75
        '
        'Rate
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        Me.Rate.DefaultCellStyle = DataGridViewCellStyle3
        Me.Rate.HeaderText = "Rate(Rs.)"
        Me.Rate.Name = "Rate"
        Me.Rate.Width = 75
        '
        'Amount
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle4
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        Me.Amount.Width = 75
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MRStudio_new.My.Resources.Resources.backg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1319, 711)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnChangeUsername)
        Me.Controls.Add(Me.txtChangeUsername)
        Me.Controls.Add(Me.btnUser)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.txtChangePassword)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.ComboBill)
        Me.Controls.Add(Me.checkDeliver)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnProducts)
        Me.Controls.Add(Me.ProductDetails)
        Me.Controls.Add(Me.txtAdvance)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblid)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtPhone)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Transparent
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form3"
        Me.Text = "New Invoice-M R Studio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ProductDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MRStudioDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAdvance As System.Windows.Forms.TextBox
    Friend WithEvents ProductName1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ProductDetails As System.Windows.Forms.DataGridView
    Friend WithEvents MRStudioDataSet As MRStudio_new.MRStudioDataSet
    Friend WithEvents ProductDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProductDetailTableAdapter As MRStudio_new.MRStudioDataSetTableAdapters.ProductDetailTableAdapter
    Friend WithEvents btnProducts As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents checkDeliver As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBill As System.Windows.Forms.ComboBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtChangePassword As System.Windows.Forms.TextBox
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnUser As System.Windows.Forms.Button
    Friend WithEvents btnChangeUsername As System.Windows.Forms.Button
    Friend WithEvents txtChangeUsername As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Product As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
