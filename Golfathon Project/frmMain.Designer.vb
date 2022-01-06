<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnGolfer = New System.Windows.Forms.Button()
        Me.btnEvent = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnGolferEvent = New System.Windows.Forms.Button()
        Me.btnManageSponsor = New System.Windows.Forms.Button()
        Me.btnAddSponsorship = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnViewSponsorships = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGolfer
        '
        Me.btnGolfer.Location = New System.Drawing.Point(34, 23)
        Me.btnGolfer.Name = "btnGolfer"
        Me.btnGolfer.Size = New System.Drawing.Size(83, 45)
        Me.btnGolfer.TabIndex = 0
        Me.btnGolfer.Text = "Manage Golfer"
        Me.btnGolfer.UseVisualStyleBackColor = True
        '
        'btnEvent
        '
        Me.btnEvent.Location = New System.Drawing.Point(123, 23)
        Me.btnEvent.Name = "btnEvent"
        Me.btnEvent.Size = New System.Drawing.Size(83, 45)
        Me.btnEvent.TabIndex = 1
        Me.btnEvent.Text = "Manage Event"
        Me.btnEvent.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(72, 169)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(181, 42)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit Program"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnGolferEvent
        '
        Me.btnGolferEvent.Location = New System.Drawing.Point(212, 23)
        Me.btnGolferEvent.Name = "btnGolferEvent"
        Me.btnGolferEvent.Size = New System.Drawing.Size(83, 45)
        Me.btnGolferEvent.TabIndex = 3
        Me.btnGolferEvent.Text = "Manage Golfer/Event"
        Me.btnGolferEvent.UseVisualStyleBackColor = True
        '
        'btnManageSponsor
        '
        Me.btnManageSponsor.Location = New System.Drawing.Point(34, 108)
        Me.btnManageSponsor.Name = "btnManageSponsor"
        Me.btnManageSponsor.Size = New System.Drawing.Size(83, 45)
        Me.btnManageSponsor.TabIndex = 4
        Me.btnManageSponsor.Text = "Manage Sponsor"
        Me.btnManageSponsor.UseVisualStyleBackColor = True
        '
        'btnAddSponsorship
        '
        Me.btnAddSponsorship.Location = New System.Drawing.Point(123, 108)
        Me.btnAddSponsorship.Name = "btnAddSponsorship"
        Me.btnAddSponsorship.Size = New System.Drawing.Size(83, 45)
        Me.btnAddSponsorship.TabIndex = 5
        Me.btnAddSponsorship.Text = "Add Sponsorship"
        Me.btnAddSponsorship.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "--------------- Sponsorship Information -----------------"
        '
        'btnViewSponsorships
        '
        Me.btnViewSponsorships.Location = New System.Drawing.Point(212, 108)
        Me.btnViewSponsorships.Name = "btnViewSponsorships"
        Me.btnViewSponsorships.Size = New System.Drawing.Size(83, 45)
        Me.btnViewSponsorships.TabIndex = 7
        Me.btnViewSponsorships.Text = "View Sponsorhips"
        Me.btnViewSponsorships.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 226)
        Me.Controls.Add(Me.btnViewSponsorships)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAddSponsorship)
        Me.Controls.Add(Me.btnManageSponsor)
        Me.Controls.Add(Me.btnGolferEvent)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnEvent)
        Me.Controls.Add(Me.btnGolfer)
        Me.Name = "frmMain"
        Me.Text = "Golfathon Program"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGolfer As Button
    Friend WithEvents btnEvent As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnGolferEvent As Button
    Friend WithEvents btnManageSponsor As Button
    Friend WithEvents btnAddSponsorship As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnViewSponsorships As Button
End Class
