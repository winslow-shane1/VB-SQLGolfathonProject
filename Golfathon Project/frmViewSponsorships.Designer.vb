<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewSponsorships
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
        Me.lstGolferEventSponsor = New System.Windows.Forms.ListBox()
        Me.cboEventYears = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstEventGolfer = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblGolferTotal = New System.Windows.Forms.Label()
        Me.lblEventTotal = New System.Windows.Forms.Label()
        Me.lstSponsors = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotalSponsored = New System.Windows.Forms.Label()
        Me.btnTotalSponsored = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstGolferEventSponsor
        '
        Me.lstGolferEventSponsor.FormattingEnabled = True
        Me.lstGolferEventSponsor.Location = New System.Drawing.Point(295, 32)
        Me.lstGolferEventSponsor.Name = "lstGolferEventSponsor"
        Me.lstGolferEventSponsor.Size = New System.Drawing.Size(177, 108)
        Me.lstGolferEventSponsor.TabIndex = 0
        '
        'cboEventYears
        '
        Me.cboEventYears.FormattingEnabled = True
        Me.cboEventYears.Location = New System.Drawing.Point(13, 32)
        Me.cboEventYears.Name = "cboEventYears"
        Me.cboEventYears.Size = New System.Drawing.Size(141, 21)
        Me.cboEventYears.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select Event Year:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(292, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Golfer Sponsors for Event Year:"
        '
        'lstEventGolfer
        '
        Me.lstEventGolfer.FormattingEnabled = True
        Me.lstEventGolfer.Location = New System.Drawing.Point(13, 83)
        Me.lstEventGolfer.Name = "lstEventGolfer"
        Me.lstEventGolfer.Size = New System.Drawing.Size(141, 121)
        Me.lstEventGolfer.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Golfers for Event Year:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(292, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Total Amount Collected:"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(189, 121)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 31)
        Me.btnView.TabIndex = 8
        Me.btnView.Text = "‬→"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(170, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 58)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "View Selected Golfer's Sponsorships per Event:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGolferTotal
        '
        Me.lblGolferTotal.BackColor = System.Drawing.SystemColors.Window
        Me.lblGolferTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGolferTotal.Location = New System.Drawing.Point(295, 173)
        Me.lblGolferTotal.Name = "lblGolferTotal"
        Me.lblGolferTotal.Size = New System.Drawing.Size(177, 31)
        Me.lblGolferTotal.TabIndex = 10
        Me.lblGolferTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEventTotal
        '
        Me.lblEventTotal.BackColor = System.Drawing.SystemColors.Window
        Me.lblEventTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEventTotal.Location = New System.Drawing.Point(154, 398)
        Me.lblEventTotal.Name = "lblEventTotal"
        Me.lblEventTotal.Size = New System.Drawing.Size(163, 31)
        Me.lblEventTotal.TabIndex = 12
        Me.lblEventTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstSponsors
        '
        Me.lstSponsors.FormattingEnabled = True
        Me.lstSponsors.Location = New System.Drawing.Point(11, 241)
        Me.lstSponsors.Name = "lstSponsors"
        Me.lstSponsors.Size = New System.Drawing.Size(143, 121)
        Me.lstSponsors.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Sponsors for Event Year:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(165, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 60)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "View Selected Sponsors Total Contributions per Event:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(151, 385)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Total Amount Raised for Event:"
        '
        'lblTotalSponsored
        '
        Me.lblTotalSponsored.BackColor = System.Drawing.SystemColors.Window
        Me.lblTotalSponsored.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalSponsored.Location = New System.Drawing.Point(295, 277)
        Me.lblTotalSponsored.Name = "lblTotalSponsored"
        Me.lblTotalSponsored.Size = New System.Drawing.Size(177, 31)
        Me.lblTotalSponsored.TabIndex = 19
        Me.lblTotalSponsored.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnTotalSponsored
        '
        Me.btnTotalSponsored.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTotalSponsored.Location = New System.Drawing.Point(189, 277)
        Me.btnTotalSponsored.Name = "btnTotalSponsored"
        Me.btnTotalSponsored.Size = New System.Drawing.Size(75, 31)
        Me.btnTotalSponsored.TabIndex = 20
        Me.btnTotalSponsored.Text = "‬→"
        Me.btnTotalSponsored.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(292, 264)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Total Amount Sponsored:"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(189, 432)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(93, 31)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Close Window"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmViewSponsorships
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 475)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnTotalSponsored)
        Me.Controls.Add(Me.lblTotalSponsored)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lstSponsors)
        Me.Controls.Add(Me.lblEventTotal)
        Me.Controls.Add(Me.lblGolferTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstEventGolfer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEventYears)
        Me.Controls.Add(Me.lstGolferEventSponsor)
        Me.Name = "frmViewSponsorships"
        Me.Text = "View Golfer Sponsors"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstGolferEventSponsor As ListBox
    Friend WithEvents cboEventYears As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lstEventGolfer As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnView As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lblGolferTotal As Label
    Friend WithEvents lblEventTotal As Label
    Friend WithEvents lstSponsors As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTotalSponsored As Label
    Friend WithEvents btnTotalSponsored As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents btnClose As Button
End Class
