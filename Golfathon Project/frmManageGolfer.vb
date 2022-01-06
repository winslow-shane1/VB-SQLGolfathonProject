' ***********************************************************************************************
' Name: Shane Winslow
' Date: 03/30/2021
' Abstract: Form to modify or add golfer information
' ************************************************************************************************
Option Strict On

Public Class frmManageGolfer

    'Procedure to automatically load the various information stored in the SQL Server database
    Private Sub frmManageGolfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_ShirtSize() 'load shirt size combo box

            Load_Gender() 'load gender combo box

            Load_Names() 'load name combo box last so it pulls all the info for golfers including shirt size and gender

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    'Load the Shirt Size information stored within the SQL Server database
    Private Sub Load_ShirtSize()

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


            ' Build the select statement
            strSelect = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the shirt size ID associated with the description so 
            ' when we click on the name we can then use the ID to pull the rest of the shirt size data.
            ' We are binding the column name to the combo box display and value members. 
            cboShirtSize.ValueMember = "intShirtSizeID"
            cboShirtSize.DisplayMember = "strShirtSizeDesc"
            cboShirtSize.DataSource = dt

            ' Select the first item in the list by default
            ' comment this line out so actual shirt size is selected and not the first item
            If cboShirtSize.Items.Count > 0 Then cboShirtSize.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            'Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'Loads the Gender information from the database to be used in the application combobox dropdown
    Private Sub Load_Gender()
        Dim strSelect As String = "" 'string to be used as the select statement to speak with database
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


        ' Build the select statement
        strSelect = "SELECT intGenderID, strGenderDesc FROM TGenders"

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader

        ' load table from data reader
        dt.Load(drSourceTable)

        ' Add the item to the combo box. We need the Gender ID associated with the description so 
        ' when we click on the name we can then use the ID to pull the rest of the gender data.
        ' We are binding the column name to the combo box display and value members. 
        cboGender.ValueMember = "intGenderID"
        cboGender.DisplayMember = "strGenderDesc"
        cboGender.DataSource = dt

        ' Select the first item in the list by default
        ' comment this line out so actual shirt size is selected and not the first item
        'If cboShirtSize.Items.Count > 0 Then cboShirtSize.SelectedIndex = 0

        ' Clean up
        drSourceTable.Close()

        ' close the database connection
        CloseDatabaseConnection()

    End Sub

    'Load the golfer names to be used in the golfer selection combobox from the SQL Server database
    Private Sub Load_Names()

        Dim strSelect As String = "" 'string to be used as Select statement to speak to the database
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        ' loop through the textboxes and clear them in case they have data in them after a delete
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.Text = String.Empty
            End If
        Next

        ' open the DB
        If OpenDatabaseConnectionSQLServer() = False Then

            ' No, warn the user ...
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' and close the form/application
            Me.Close()

        End If

        ' Build the select statement
        strSelect = "SELECT intGolferID, strLastName FROM TGolfers"

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader

        ' load table from data reader
        dt.Load(drSourceTable)

        ' Add the item to the combo box. We need the Golfer ID associated with the name so 
        ' when we click on the name we can then use the ID to pull the rest of the golfers data.
        ' We are binding the column name to the combo box display and value members. 
        cboGolferLastName.ValueMember = "intGolferID"
        cboGolferLastName.DisplayMember = "strLastName"
        cboGolferLastName.DataSource = dt

        ' Select the first item in the list by default
        If cboGolferLastName.Items.Count > 0 Then cboGolferLastName.SelectedIndex = 0

        ' Clean up
        drSourceTable.Close()

        ' close the database connection
        CloseDatabaseConnection()

    End Sub

    'Procedure to be occur when the update golfer button is toggled
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Declare the different variables to store information about golfer for modification
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
                    strSelect = "Update TGolfers Set strFirstName = '" & strFirstName & "', " & "strLastName = '" & strLastName &
                    "', " & "strStreetAddress = '" & strStreetAddress & "', " & "strCity = '" & strCity & "', " &
                     "strState = '" & strState & "', " & "strZip = '" & strZip & "', " & "strPhoneNumber = '" & strPhoneNumber & "', " & "strEmail = '" & strEmail & "', " & "intShirtSizeID = " &
                     cboShirtSize.SelectedValue.ToString & ", " & "intGenderID = " & cboGender.SelectedValue.ToString & "Where intGolferID = " &
                     cboGolferLastName.SelectedValue.ToString

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
                    frmManageGolfer_Load(sender, e)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

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

    'Procedure to occur when a golfer is selected from the last name combobox at the top of the golfer form
    Private Sub cboGolferLastName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGolferLastName.SelectedIndexChanged
        'Declare the variable to be used when the golfer is selected from combobox
        Dim strSelect As String = "" 'string to store select statement to speak with the SQL Server database
        Dim strName As String = "" 'string to hold golfer name
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim intShirtSize As Integer 'integer to hold golfers shirt size primary key from database
        Dim intGender As Integer 'integer to hold golfers gender primary key from database

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
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID FROM TGolfers Where intGolferID = " & cboGolferLastName.SelectedValue.ToString

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

            intShirtSize = CInt(dt.Rows(0).Item(8)) 'put shirt size ID into variable
            cboShirtSize.SelectedValue = intShirtSize 'set selected value of shirt size combo box to correct size

            intGender = CInt(dt.Rows(0).Item(9)) 'put Gender ID into variable
            cboGender.SelectedValue = intGender 'set selected value of gender combo box to correct size

            ' close the database connection
            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCloseWindow.Click
        Close()
    End Sub

    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click

        'create a new instance of the add form
        Dim AddGolfer As New frmAddGolfer

        'show the new form so any past data is not still on the form
        AddGolfer.ShowDialog()

        'call the form load so the combo box refreshes with the current date
        frmManageGolfer_Load(sender, e)
    End Sub

    'Procedure to occur the delete golfer button is toggled
    Private Sub btnDeleteGolfer_Click(sender As Object, e As EventArgs) Handles btnDeleteGolfer.Click
        'Declare variables to be used to delete golfer from database
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
            result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & cboGolferLastName.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    ' delete  child record related to intGolferID
                    strDelete = "Delete FROM TGolferEventYearSponsors Where intGolferID = " & cboGolferLastName.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' delete  child record related to intGolferID
                    strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & cboGolferLastName.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' now we can delete the parent record
                    strDelete = "Delete FROM TGolfers Where intGolferID = " & cboGolferLastName.SelectedValue.ToString

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
            frmManageGolfer_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class