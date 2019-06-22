<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.Results = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblAdvance = New System.Windows.Forms.Label()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.btnToday = New System.Windows.Forms.Button()
        Me.btnRange = New System.Windows.Forms.Button()
        Me.fromDate = New System.Windows.Forms.DateTimePicker()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.NetTotal = New System.Windows.Forms.Label()
        CType(Me.Results, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Results
        '
        Me.Results.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Results.Location = New System.Drawing.Point(277, 156)
        Me.Results.Name = "Results"
        Me.Results.Size = New System.Drawing.Size(948, 283)
        Me.Results.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(562, 466)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(25, 25)
        Me.lblTotal.TabIndex = 1
        Me.lblTotal.Text = "0"
        '
        'lblAdvance
        '
        Me.lblAdvance.AutoSize = True
        Me.lblAdvance.BackColor = System.Drawing.Color.Transparent
        Me.lblAdvance.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvance.ForeColor = System.Drawing.Color.White
        Me.lblAdvance.Location = New System.Drawing.Point(562, 509)
        Me.lblAdvance.Name = "lblAdvance"
        Me.lblAdvance.Size = New System.Drawing.Size(25, 25)
        Me.lblAdvance.TabIndex = 2
        Me.lblAdvance.Text = "0"
        '
        'lblBalance
        '
        Me.lblBalance.AutoSize = True
        Me.lblBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblBalance.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalance.ForeColor = System.Drawing.Color.White
        Me.lblBalance.Location = New System.Drawing.Point(956, 469)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(25, 25)
        Me.lblBalance.TabIndex = 3
        Me.lblBalance.Text = "0"
        '
        'btnToday
        '
        Me.btnToday.BackColor = System.Drawing.Color.Navy
        Me.btnToday.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToday.ForeColor = System.Drawing.Color.White
        Me.btnToday.Location = New System.Drawing.Point(52, 156)
        Me.btnToday.Name = "btnToday"
        Me.btnToday.Size = New System.Drawing.Size(186, 51)
        Me.btnToday.TabIndex = 4
        Me.btnToday.Text = "Show Todays Report"
        Me.btnToday.UseVisualStyleBackColor = False
        '
        'btnRange
        '
        Me.btnRange.BackColor = System.Drawing.Color.Navy
        Me.btnRange.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRange.ForeColor = System.Drawing.Color.White
        Me.btnRange.Location = New System.Drawing.Point(52, 434)
        Me.btnRange.Name = "btnRange"
        Me.btnRange.Size = New System.Drawing.Size(186, 45)
        Me.btnRange.TabIndex = 5
        Me.btnRange.Text = "Show Report"
        Me.btnRange.UseVisualStyleBackColor = False
        '
        'fromDate
        '
        Me.fromDate.Location = New System.Drawing.Point(52, 322)
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Size = New System.Drawing.Size(186, 20)
        Me.fromDate.TabIndex = 6
        Me.fromDate.Value = New Date(2016, 3, 27, 0, 0, 0, 0)
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(52, 396)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(186, 20)
        Me.ToDate.TabIndex = 7
        Me.ToDate.Value = New Date(2016, 3, 27, 21, 36, 42, 0)
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.Navy
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(52, 78)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(186, 51)
        Me.btnPrint.TabIndex = 15
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'lblDiscount
        '
        Me.lblDiscount.AutoSize = True
        Me.lblDiscount.BackColor = System.Drawing.Color.Transparent
        Me.lblDiscount.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscount.ForeColor = System.Drawing.Color.White
        Me.lblDiscount.Location = New System.Drawing.Point(956, 509)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(25, 25)
        Me.lblDiscount.TabIndex = 17
        Me.lblDiscount.Text = "0"
        '
        'NetTotal
        '
        Me.NetTotal.AutoSize = True
        Me.NetTotal.BackColor = System.Drawing.Color.Transparent
        Me.NetTotal.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NetTotal.ForeColor = System.Drawing.Color.White
        Me.NetTotal.Location = New System.Drawing.Point(708, 566)
        Me.NetTotal.Name = "NetTotal"
        Me.NetTotal.Size = New System.Drawing.Size(25, 25)
        Me.NetTotal.TabIndex = 19
        Me.NetTotal.Text = "0"
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MRStudio_new.My.Resources.Resources.reports
        Me.ClientSize = New System.Drawing.Size(1354, 630)
        Me.Controls.Add(Me.NetTotal)
        Me.Controls.Add(Me.lblDiscount)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.fromDate)
        Me.Controls.Add(Me.btnRange)
        Me.Controls.Add(Me.btnToday)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.lblAdvance)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Results)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reports -MRStudio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Results, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Results As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblAdvance As System.Windows.Forms.Label
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents btnToday As System.Windows.Forms.Button
    Friend WithEvents btnRange As System.Windows.Forms.Button
    Friend WithEvents fromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
    Friend WithEvents NetTotal As System.Windows.Forms.Label
End Class
