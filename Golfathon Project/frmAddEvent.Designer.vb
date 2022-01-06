<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEvent
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
        Me.btnEnterYear = New System.Windows.Forms.Button()
        Me.btnCloseWindow = New System.Windows.Forms.Button()
        Me.txtEnterYear = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnEnterYear
        '
        Me.btnEnterYear.Location = New System.Drawing.Point(48, 66)
        Me.btnEnterYear.Name = "btnEnterYear"
        Me.btnEnterYear.Size = New System.Drawing.Size(75, 34)
        Me.btnEnterYear.TabIndex = 2
        Me.btnEnterYear.Text = "Add Year"
        Me.btnEnterYear.UseVisualStyleBackColor = True
        '
        'btnCloseWindow
        '
        Me.btnCloseWindow.Location = New System.Drawing.Point(129, 66)
        Me.btnCloseWindow.Name = "btnCloseWindow"
        Me.btnCloseWindow.Size = New System.Drawing.Size(75, 34)
        Me.btnCloseWindow.TabIndex = 3
        Me.btnCloseWindow.Text = "Close Window"
        Me.btnCloseWindow.UseVisualStyleBackColor = True
        '
        'txtEnterYear
        '
        Me.txtEnterYear.Location = New System.Drawing.Point(48, 40)
        Me.txtEnterYear.Name = "txtEnterYear"
        Me.txtEnterYear.Size = New System.Drawing.Size(156, 20)
        Me.txtEnterYear.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enter Year:"
        '
        'frmAddEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(255, 119)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEnterYear)
        Me.Controls.Add(Me.btnCloseWindow)
        Me.Controls.Add(Me.btnEnterYear)
        Me.Name = "frmAddEvent"
        Me.Text = "Add Event"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnEnterYear As Button
    Friend WithEvents btnCloseWindow As Button
    Friend WithEvents txtEnterYear As TextBox
    Friend WithEvents Label1 As Label
End Class
