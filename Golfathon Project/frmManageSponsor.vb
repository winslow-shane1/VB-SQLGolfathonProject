' ************************************************************************************************************
' Name: Shane Winslow
' Date: 04/20/2021
' Abstract: Form to modify or add sponsor information
' ************************************************************************************************************
Option Strict On

Public Class frmManageSponsor
    'Procedure to automatically load the various information stored in the SQL Server
    Private Sub frmManageSponsor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_SponsorNames() 'load name combobox to call information from the database on current sponsors listed

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    'Load the Sponsor Name information stored within the SQL Server database
    Private Sub Load_SponsorNames()

        Try
            Dim strSelect As String = "" 'create string that will be the select statement for SQL Server
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            ' open the DB this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            'Build the select statement
            strSelect = "SELECT intSponsorID, strLastName FROM TSponsors"

            'Retrieve all the reocrds
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the sponsor ID associated with the description so 
            ' when we click on the name we can then use the ID to pull the rest of the sponsor data.
            ' We are binding the column name to the combo box display and value members. 
            cboSponsorLastName.ValueMember = "intSponsorID"
            cboSponsorLastName.DisplayMember = "strLastName"
            cboSponsorLastName.DataSource = dt

            ' Select the first item in the list by default
            ' comment this line out so actual shirt size is selected and not the first item
            If cboSponsorLastName.Items.Count > 0 Then cboSponsorLastName.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            'Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'validation procedure to ensure all textboxes within the Manage Sponsor are answered for updates
    Public Function Validation() As Boolean
        ' loop through the textboxes and check to make sure there is data in them
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
            End If
        Next

        'every this is good so return true
        Return True

    End Function

    'Procedure to occur when the update sponsor button is toggled
    Private Sub btnUpdateSponsor_Click(sender As Object, e As EventArgs) Handles btnUpdateSponsor.Click
        'Declare the different variables to store information about sponsor for modification
        Dim strSelect As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim intRowsAffected As Integer

        Try

            ' this will hold our Update statement
            Dim cmdUpdate As OleDb.OleDbCommand

            ' check to make sure all text boxes have data. No data no update!
            If Validation() = True Then
                ' open database
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                ' after you validate there is data put values into variables
                If Validation() = True Then

                    'set the variables according to the entries found in the different textboxes on the golfer form
                    strFirstName = txtFirstName.Text
                    strLastName = txtLastName.Text
                    strStreetAddress = txtStreetAddress.Text
                    strCity = txtCity.Text
                    strState = txtState.Text
                    strZip = txtZip.Text
                    strPhoneNumber = txtPhoneNumber.Text
                    strEmail = txtEmail.Text

                    ' Build the select statement using PK from name selected
                    strSelect = "Update TSponsors Set strFirstName = '" & strFirstName & "', " & "strLastName = '" & strLastName &
                    "', " & "strStreetAddress = '" & strStreetAddress & "', " & "strCity = '" & strCity & "', " &
                    "strState = '" & strState & "', " & "strZip = '" & strZip & "', " & "strPhoneNumber = '" & strPhoneNumber & "', " & "strEmail = '" & strEmail & "' " & "Where intSponsorID = " &
                    cboSponsorLastName.SelectedValue.ToString

                    ' uncomment out the following message box line to use as a tool to check your sql statement
                    ' remember anything not a numeric value going into SQL Server must have single quotes '
                    ' around it, including dates.

                    'MessageBox.Show(strSelect)

                    ' make the connection
                    cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                    ' IUpdate the row with execute the statement
                    intRowsAffected = cmdUpdate.ExecuteNonQuery()

                    ' have to let the user know what happened 
                    If intRowsAffected = 1 Then
                        MessageBox.Show("Update successful")
                    Else
                        MessageBox.Show("Update failed")
                    End If

                    ' close the database connection
                    CloseDatabaseConnection()

                    ' call the Form Load sub to refresh the combo box data after a delete
                    frmManageSponsor_Load(sender, e)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Procedure to occur when a golfer is selected from the last name combobox at the top of the golfer form
    Private Sub cboSponsorLastName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSponsorLastName.SelectedIndexChanged
        'Declare the variable to be used when the golfer is selected from combobox
        Dim strSelect As String = "" 'string to store select statement to speak with the SQL Server database
        Dim strName As String = "" 'string to hold golfer name
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        Try

            ' open the database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement using PK from name selected
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail FROM TSponsors Where intSponsorID = " & cboSponsorLastName.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt.Load(drSourceTable)

            ' populate the text boxes with the data
            txtFirstName.Text = dt.Rows(0).Item(0).ToString
            txtLastName.Text = dt.Rows(0).Item(1).ToString
            txtStreetAddress.Text = dt.Rows(0).Item(2).ToString
            txtCity.Text = dt.Rows(0).Item(3).ToString
            txtState.Text = dt.Rows(0).Item(4).ToString
            txtZip.Text = dt.Rows(0).Item(5).ToString
            txtPhoneNumber.Text = dt.Rows(0).Item(6).ToString
            txtEmail.Text = dt.Rows(0).Item(7).ToString

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Procedure to be called when Add Sponsor button is toggled
    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click
        Dim frmAddSponsor As New frmAddSponsor
        frmAddSponsor.ShowDialog()

        Load_SponsorNames()
    End Sub

    'Procedure to be called when Delete Sponsor button is toggled
    Private Sub btnDeleteSponsor_Click(sender As Object, e As EventArgs) Handles btnDeleteSponsor.Click
        'Declare variables to be used to delete sponsor from database
        Dim strDelete As String = "" 'string to hold delete statement to speak with database
        Dim strSelect As String = String.Empty 'string to hold select statement for database
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects

        Try
            ' open the database this is in module
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Sponsor: Last Name-" & cboSponsorLastName.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    ' delete  child record related to intGolferID
                    strDelete = "Delete FROM TGolferEventYearSponsors Where intSponsorID = " & cboSponsorLastName.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' now we can delete the parent record
                    strDelete = "Delete FROM TSponsors Where intSponsorID = " & cboSponsorLastName.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' Did it work?
                    If intRowsAffected > 0 Then

                        ' Yes, success
                        MessageBox.Show("Delete successful")

                    End If

            End Select


            ' close the database connection
            CloseDatabaseConnection()

            ' call the Form Load sub to refresh the combo box data after a delete
            frmManageSponsor_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Procedure will close the form
    Private Sub btnCloseWindow_Click(sender As Object, e As EventArgs) Handles btnCloseWindow.Click
        Close()
    End Sub
End Class