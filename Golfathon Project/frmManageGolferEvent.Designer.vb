<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageGolferEvent
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
        Me.cboEventYears = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstEventGolfer = New System.Windows.Forms.ListBox()
        Me.lstAvailableGolfers = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAddGolfer = New System.Windows.Forms.Button()
        Me.btnRemoveGolfer = New System.Windows.Forms.Button()
        Me.btnAddSponsorship = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboEventYears
        '
        Me.cboEventYears.FormattingEnabled = True
        Me.cboEventYears.Location = New System.Drawing.Point(18, 27)
        Me.cboEventYears.Name = "cboEventYears"
        Me.cboEventYears.Size = New System.Drawing.Size(121, 21)
        Me.cboEventYears.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Event Year:"
        '
        'lstEventGolfer
        '
        Me.lstEventGolfer.FormattingEnabled = True
        Me.lstEventGolfer.Location = New System.Drawing.Point(18, 76)
        Me.lstEventGolfer.Name = "lstEventGolfer"
        Me.lstEventGolfer.Size = New System.Drawing.Size(120, 121)
        Me.lstEventGolfer.TabIndex = 2
        '
        'lstAvailableGolfers
        '
        Me.lstAvailableGolfers.FormattingEnabled = True
        Me.lstAvailableGolfers.Location = New System.Drawing.Point(281, 76)
        Me.lstAvailableGolfers.Name = "lstAvailableGolfers"
        Me.lstAvailableGolfers.Size = New System.Drawing.Size(120, 121)
        Me.lstAvailableGolfers.TabIndex = 3
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(174, 223)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Close"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Current Golfer Roster:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(278, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "All Golfers:"
        '
        'btnAddGolfer
        '
        Me.btnAddGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddGolfer.Location = New System.Drawing.Point(174, 90)
        Me.btnAddGolfer.Name = "btnAddGolfer"
        Me.btnAddGolfer.Size = New System.Drawing.Size(75, 40)
        Me.btnAddGolfer.TabIndex = 7
        Me.btnAddGolfer.Text = "←"
        Me.btnAddGolfer.UseVisualStyleBackColor = True
        '
        'btnRemoveGolfer
        '
        Me.btnRemoveGolfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveGolfer.Location = New System.Drawing.Point(174, 136)
        Me.btnRemoveGolfer.Name = "btnRemoveGolfer"
        Me.btnRemoveGolfer.Size = New System.Drawing.Size(75, 40)
        Me.btnRemoveGolfer.TabIndex = 8
        Me.btnRemoveGolfer.Text = "→"
        Me.btnRemoveGolfer.UseVisualStyleBackColor = True
        '
        'btnAddSponsorship
        '
        Me.btnAddSponsorship.Location = New System.Drawing.Point(18, 223)
        Me.btnAddSponsorship.Name = "btnAddSponsorship"
        Me.btnAddSponsorship.Size = New System.Drawing.Size(120, 23)
        Me.btnAddSponsorship.TabIndex = 9
        Me.btnAddSponsorship.Text = "Add Sponsorship"
        Me.btnAddSponsorship.UseVisualStyleBackColor = True
        '
        'frmManageGolferEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 278)
        Me.Controls.Add(Me.btnAddSponsorship)
        Me.Controls.Add(Me.btnRemoveGolfer)
        Me.Controls.Add(Me.btnAddGolfer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstAvailableGolfers)
        Me.Controls.Add(Me.lstEventGolfer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEventYears)
        Me.Name = "frmManageGolferEvent"
        Me.Text = "Manage Golfer Event"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboEventYears As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lstEventGolfer As ListBox
    Friend WithEvents lstAvailableGolfers As ListBox
    Friend WithEvents btnExit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAddGolfer As Button
    Friend WithEvents btnRemoveGolfer As Button
    Friend WithEvents btnAddSponsorship As Button
End Class
