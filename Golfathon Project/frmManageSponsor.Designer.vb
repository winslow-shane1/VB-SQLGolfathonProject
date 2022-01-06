<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageSponsor
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtStreetAddress = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSponsorLastName = New System.Windows.Forms.ComboBox()
        Me.btnDeleteSponsor = New System.Windows.Forms.Button()
        Me.btnAddSponsor = New System.Windows.Forms.Button()
        Me.btnCloseWindow = New System.Windows.Forms.Button()
        Me.btnUpdateSponsor = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Last Name"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(129, 117)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(170, 20)
        Me.txtLastName.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Select Sponsor Last Name:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(129, 304)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(170, 20)
        Me.txtEmail.TabIndex = 40
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(129, 272)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(170, 20)
        Me.txtPhoneNumber.TabIndex = 38
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(129, 242)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(170, 20)
        Me.txtZip.TabIndex = 37
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(129, 211)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(170, 20)
        Me.txtState.TabIndex = 35
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(129, 179)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(170, 20)
        Me.txtCity.TabIndex = 33
        '
        'txtStreetAddress
        '
        Me.txtStreetAddress.Location = New System.Drawing.Point(129, 148)
        Me.txtStreetAddress.Name = "txtStreetAddress"
        Me.txtStreetAddress.Size = New System.Drawing.Size(170, 20)
        Me.txtStreetAddress.TabIndex = 31
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(129, 87)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(170, 20)
        Me.txtFirstName.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 311)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Email"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 279)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Phone Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 249)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Zip"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 218)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "State"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "City"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Street Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "First Name"
        '
        'cboSponsorLastName
        '
        Me.cboSponsorLastName.FormattingEnabled = True
        Me.cboSponsorLastName.Location = New System.Drawing.Point(29, 39)
        Me.cboSponsorLastName.Name = "cboSponsorLastName"
        Me.cboSponsorLastName.Size = New System.Drawing.Size(258, 21)
        Me.cboSponsorLastName.TabIndex = 25
        '
        'btnDeleteSponsor
        '
        Me.btnDeleteSponsor.Location = New System.Drawing.Point(203, 346)
        Me.btnDeleteSponsor.Name = "btnDeleteSponsor"
        Me.btnDeleteSponsor.Size = New System.Drawing.Size(82, 42)
        Me.btnDeleteSponsor.TabIndex = 49
        Me.btnDeleteSponsor.Text = "Delete Sponsor"
        Me.btnDeleteSponsor.UseVisualStyleBackColor = True
        '
        'btnAddSponsor
        '
        Me.btnAddSponsor.Location = New System.Drawing.Point(115, 346)
        Me.btnAddSponsor.Name = "btnAddSponsor"
        Me.btnAddSponsor.Size = New System.Drawing.Size(82, 42)
        Me.btnAddSponsor.TabIndex = 48
        Me.btnAddSponsor.Text = "Add Sponsor"
        Me.btnAddSponsor.UseVisualStyleBackColor = True
        '
        'btnCloseWindow
        '
        Me.btnCloseWindow.Location = New System.Drawing.Point(27, 394)
        Me.btnCloseWindow.Name = "btnCloseWindow"
        Me.btnCloseWindow.Size = New System.Drawing.Size(258, 42)
        Me.btnCloseWindow.TabIndex = 50
        Me.btnCloseWindow.Text = "Close Window"
        Me.btnCloseWindow.UseVisualStyleBackColor = True
        '
        'btnUpdateSponsor
        '
        Me.btnUpdateSponsor.Location = New System.Drawing.Point(27, 346)
        Me.btnUpdateSponsor.Name = "btnUpdateSponsor"
        Me.btnUpdateSponsor.Size = New System.Drawing.Size(82, 42)
        Me.btnUpdateSponsor.TabIndex = 47
        Me.btnUpdateSponsor.Text = "Update Sponsor"
        Me.btnUpdateSponsor.UseVisualStyleBackColor = True
        '
        'frmManageSponsor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 449)
        Me.Controls.Add(Me.btnDeleteSponsor)
        Me.Controls.Add(Me.btnAddSponsor)
        Me.Controls.Add(Me.btnCloseWindow)
        Me.Controls.Add(Me.btnUpdateSponsor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.txtState)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtStreetAddress)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSponsorLastName)
        Me.Name = "frmManageSponsor"
        Me.Text = "Manage Sponsor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtZip As TextBox
    Friend WithEvents txtState As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtStreetAddress As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSponsorLastName As ComboBox
    Friend WithEvents btnDeleteSponsor As Button
    Friend WithEvents btnAddSponsor As Button
    Friend WithEvents btnCloseWindow As Button
    Friend WithEvents btnUpdateSponsor As Button
End Class
