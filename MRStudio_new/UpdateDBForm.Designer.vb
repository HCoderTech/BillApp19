<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDBForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateDBForm))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtProductDetails = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.SearchResults = New System.Windows.Forms.DataGridView()
        Me.ComboBilled = New System.Windows.Forms.ComboBox()
        Me.ComboBillType = New System.Windows.Forms.ComboBox()
        Me.ComboBalance = New System.Windows.Forms.ComboBox()
        Me.ComboDelivered = New System.Windows.Forms.ComboBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.txtSearchName = New System.Windows.Forms.TextBox()
        Me.txtSearchPhone = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtAdvance = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SearchDate = New System.Windows.Forms.DateTimePicker()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.txtPay = New System.Windows.Forms.TextBox()
        Me.UsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MRStudioDataSet2 = New MRStudio_new.MRStudioDataSet2()
        Me.UsersTableAdapter = New MRStudio_new.MRStudioDataSet2TableAdapters.UsersTableAdapter()
        CType(Me.SearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MRStudioDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Navy
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(153, 426)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(89, 27)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Navy
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(489, 426)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 25)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'txtid
        '
        Me.txtid.Enabled = False
        Me.txtid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid.Location = New System.Drawing.Point(525, 208)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(105, 21)
        Me.txtid.TabIndex = 14
        '
        'txtBalance
        '
        Me.txtBalance.Enabled = False
        Me.txtBalance.Location = New System.Drawing.Point(525, 341)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Size = New System.Drawing.Size(84, 20)
        Me.txtBalance.TabIndex = 10
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(525, 294)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(84, 20)
        Me.txtTotal.TabIndex = 8
        '
        'txtProductDetails
        '
        Me.txtProductDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductDetails.Location = New System.Drawing.Point(525, 248)
        Me.txtProductDetails.Name = "txtProductDetails"
        Me.txtProductDetails.Size = New System.Drawing.Size(242, 21)
        Me.txtProductDetails.TabIndex = 6
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(525, 172)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(105, 21)
        Me.txtPhone.TabIndex = 4
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(525, 134)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(187, 21)
        Me.txtName.TabIndex = 2
        '
        'SearchResults
        '
        Me.SearchResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.SearchResults.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.SearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SearchResults.Location = New System.Drawing.Point(49, 500)
        Me.SearchResults.Name = "SearchResults"
        Me.SearchResults.Size = New System.Drawing.Size(744, 192)
        Me.SearchResults.TabIndex = 0
        '
        'ComboBilled
        '
        Me.ComboBilled.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBilled.FormattingEnabled = True
        Me.ComboBilled.Location = New System.Drawing.Point(164, 130)
        Me.ComboBilled.Name = "ComboBilled"
        Me.ComboBilled.Size = New System.Drawing.Size(144, 21)
        Me.ComboBilled.TabIndex = 15
        Me.ComboBilled.ValueMember = "Username"
        '
        'ComboBillType
        '
        Me.ComboBillType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBillType.FormattingEnabled = True
        Me.ComboBillType.Items.AddRange(New Object() {"Cash", "Order"})
        Me.ComboBillType.Location = New System.Drawing.Point(164, 174)
        Me.ComboBillType.Name = "ComboBillType"
        Me.ComboBillType.Size = New System.Drawing.Size(144, 21)
        Me.ComboBillType.TabIndex = 17
        '
        'ComboBalance
        '
        Me.ComboBalance.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBalance.FormattingEnabled = True
        Me.ComboBalance.Items.AddRange(New Object() {"Balance", "Paid"})
        Me.ComboBalance.Location = New System.Drawing.Point(164, 217)
        Me.ComboBalance.Name = "ComboBalance"
        Me.ComboBalance.Size = New System.Drawing.Size(144, 21)
        Me.ComboBalance.TabIndex = 18
        '
        'ComboDelivered
        '
        Me.ComboDelivered.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboDelivered.FormattingEnabled = True
        Me.ComboDelivered.Items.AddRange(New Object() {"Delivered", "Not Delivered"})
        Me.ComboDelivered.Location = New System.Drawing.Point(164, 259)
        Me.ComboDelivered.Name = "ComboDelivered"
        Me.ComboDelivered.Size = New System.Drawing.Size(144, 21)
        Me.ComboDelivered.TabIndex = 20
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Navy
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(619, 426)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(81, 25)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'txtSearchName
        '
        Me.txtSearchName.Location = New System.Drawing.Point(164, 308)
        Me.txtSearchName.Name = "txtSearchName"
        Me.txtSearchName.Size = New System.Drawing.Size(144, 20)
        Me.txtSearchName.TabIndex = 22
        '
        'txtSearchPhone
        '
        Me.txtSearchPhone.Location = New System.Drawing.Point(164, 353)
        Me.txtSearchPhone.Name = "txtSearchPhone"
        Me.txtSearchPhone.Size = New System.Drawing.Size(144, 20)
        Me.txtSearchPhone.TabIndex = 23
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.label1.Location = New System.Drawing.Point(464, 386)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(28, 13)
        Me.label1.TabIndex = 24
        Me.label1.Text = "Paid"
        '
        'txtAdvance
        '
        Me.txtAdvance.Enabled = False
        Me.txtAdvance.Location = New System.Drawing.Point(525, 379)
        Me.txtAdvance.Name = "txtAdvance"
        Me.txtAdvance.Size = New System.Drawing.Size(84, 20)
        Me.txtAdvance.TabIndex = 25
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MRStudio_new.My.Resources.Resources.mr__2
        Me.PictureBox1.Location = New System.Drawing.Point(229, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(390, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'SearchDate
        '
        Me.SearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.SearchDate.Location = New System.Drawing.Point(164, 392)
        Me.SearchDate.Name = "SearchDate"
        Me.SearchDate.Size = New System.Drawing.Size(144, 20)
        Me.SearchDate.TabIndex = 27
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(658, 198)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(100, 20)
        Me.txtDate.TabIndex = 28
        '
        'txtDiscount
        '
        Me.txtDiscount.Location = New System.Drawing.Point(658, 383)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(84, 20)
        Me.txtDiscount.TabIndex = 29
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPay
        '
        Me.txtPay.ForeColor = System.Drawing.Color.Silver
        Me.txtPay.Location = New System.Drawing.Point(658, 321)
        Me.txtPay.Name = "txtPay"
        Me.txtPay.Size = New System.Drawing.Size(84, 20)
        Me.txtPay.TabIndex = 30
        Me.txtPay.Text = "0"
        Me.txtPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UsersBindingSource
        '
        Me.UsersBindingSource.DataMember = "Users"
        Me.UsersBindingSource.DataSource = Me.MRStudioDataSet2
        '
        'MRStudioDataSet2
        '
        Me.MRStudioDataSet2.DataSetName = "MRStudioDataSet2"
        Me.MRStudioDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UsersTableAdapter
        '
        Me.UsersTableAdapter.ClearBeforeFill = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MRStudio_new.My.Resources.Resources.search
        Me.ClientSize = New System.Drawing.Size(848, 733)
        Me.Controls.Add(Me.txtPay)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.SearchDate)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtAdvance)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtSearchPhone)
        Me.Controls.Add(Me.txtSearchName)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.ComboDelivered)
        Me.Controls.Add(Me.ComboBalance)
        Me.Controls.Add(Me.ComboBillType)
        Me.Controls.Add(Me.ComboBilled)
        Me.Controls.Add(Me.SearchResults)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtProductDetails)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.btnSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.SearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MRStudioDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtProductDetails As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents SearchResults As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBilled As System.Windows.Forms.ComboBox
    Friend WithEvents MRStudioDataSet2 As MRStudio_new.MRStudioDataSet2
    Friend WithEvents UsersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UsersTableAdapter As MRStudio_new.MRStudioDataSet2TableAdapters.UsersTableAdapter
    Friend WithEvents ComboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBalance As System.Windows.Forms.ComboBox
    Friend WithEvents ComboDelivered As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents txtSearchName As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchPhone As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtAdvance As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SearchDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents txtPay As System.Windows.Forms.TextBox
End Class
