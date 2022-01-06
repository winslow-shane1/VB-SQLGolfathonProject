<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSponsorship
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
        Me.btnAddSponsorship = New System.Windows.Forms.Button()
        Me.cboEventYears = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstEventGolfer = New System.Windows.Forms.ListBox()
        Me.lstSponsors = New System.Windows.Forms.ListBox()
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPaymentStatus = New System.Windows.Forms.ComboBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSponsorshipType = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddSponsorship
        '
        Me.btnAddSponsorship.Location = New System.Drawing.Point(235, 253)
        Me.btnAddSponsorship.Name = "btnAddSponsorship"
        Me.btnAddSponsorship.Size = New System.Drawing.Size(104, 25)
        Me.btnAddSponsorship.TabIndex = 0
        Me.btnAddSponsorship.Text = "Add Sponsorship"
        Me.btnAddSponsorship.UseVisualStyleBackColor = True
        '
        'cboEventYears
        '
        Me.cboEventYears.FormattingEnabled = True
        Me.cboEventYears.Location = New System.Drawing.Point(28, 38)
        Me.cboEventYears.Name = "cboEventYears"
        Me.cboEventYears.Size = New System.Drawing.Size(121, 21)
        Me.cboEventYears.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select Event Year:"
        '
        'lstEventGolfer
        '
        Me.lstEventGolfer.FormattingEnabled = True
        Me.lstEventGolfer.Location = New System.Drawing.Point(28, 101)
        Me.lstEventGolfer.Name = "lstEventGolfer"
        Me.lstEventGolfer.Size = New System.Drawing.Size(132, 95)
        Me.lstEventGolfer.TabIndex = 3
        '
        'lstSponsors
        '
        Me.lstSponsors.FormattingEnabled = True
        Me.lstSponsors.Location = New System.Drawing.Point(28, 227)
        Me.lstSponsors.Name = "lstSponsors"
        Me.lstSponsors.Size = New System.Drawing.Size(132, 95)
        Me.lstSponsors.TabIndex = 4
        '
        'cboPaymentType
        '
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Location = New System.Drawing.Point(239, 91)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(121, 21)
        Me.cboPaymentType.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Select Payment Type:"
        '
        'cboPaymentStatus
        '
        Me.cboPaymentStatus.FormattingEnabled = True
        Me.cboPaymentStatus.Items.AddRange(New Object() {"Paid", "Not Paid"})
        Me.cboPaymentStatus.Location = New System.Drawing.Point(239, 193)
        Me.cboPaymentStatus.Name = "cboPaymentStatus"
        Me.cboPaymentStatus.Size = New System.Drawing.Size(121, 21)
        Me.cboPaymentStatus.TabIndex = 7
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(239, 139)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtAmount.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(236, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Sponsorship Amount:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Payment Status:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Select Sponsor:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Select Participating Golfer:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(236, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Select Sponsorship Type:"
        '
        'cboSponsorshipType
        '
        Me.cboSponsorshipType.FormattingEnabled = True
        Me.cboSponsorshipType.Location = New System.Drawing.Point(239, 38)
        Me.cboSponsorshipType.Name = "cboSponsorshipType"
        Me.cboSponsorshipType.Size = New System.Drawing.Size(121, 21)
        Me.cboSponsorshipType.TabIndex = 13
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(235, 284)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 23)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close Window"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmAddSponsorship
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 348)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboSponsorshipType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.cboPaymentStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPaymentType)
        Me.Controls.Add(Me.lstSponsors)
        Me.Controls.Add(Me.lstEventGolfer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEventYears)
        Me.Controls.Add(Me.btnAddSponsorship)
        Me.Name = "frmAddSponsorship"
        Me.Text = "Add Sponsorship"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAddSponsorship As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lstEventGolfer As ListBox
    Friend WithEvents lstSponsors As ListBox
    Friend WithEvents cboPaymentType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPaymentStatus As ComboBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cboSponsorshipType As ComboBox
    Friend WithEvents cboEventYears As ComboBox
    Friend WithEvents btnClose As Button
End Class
