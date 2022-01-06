' ***********************************************************************************************
' Name: Shane Winslow
' Date: 03/30/2021
' Abstract: Form to add golfer
' ************************************************************************************************
Option Strict On

Public Class frmAddGolfer
    'Procedure to occur when the Add New Golfer button is toggled
    Private Sub btnAddNewGolfer_Click(sender As Object, e As EventArgs) Handles btnAddNewGolfer.Click

        ' variables for new golfers data and select and insert statements
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim intShirtSizeID As Integer
        Dim intGenderID As Integer

        'Validate the information provided by user to move on to adding information to database
        If Validation(strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID) = True Then
            'pass inputs, now validated to sub AddGolfer to enter in DB
            AddGolfer(strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID)

        End If
    End Sub

    'Procedure to occure when the button Add Golfer is toggled
    Private Sub AddGolfer(ByVal strFirstName As String, ByVal strLastName As String, ByVal strStreetAddress As String, ByVal strCity As String, ByVal strState As String, ByVal strZip As String, ByVal strPhoneNumber As String, ByVal strEmail As String, ByVal intShirtSizeID As Integer, ByVal intGenderID As Integer)

        'create command object and integer for number of returned rows
        Dim cmdAddGolfer As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intGolferID As Integer ' this is what we pass in as the stored procedure requires it

        Try
            'open the database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Execute command
            cmdAddGolfer.CommandText = "EXECUTE uspAddGolfer '" & intGolferID & "','" & strFirstName & "','" & strLastName & "','" & strStreetAddress & "','" & strCity & "','" & strState & "','" & strZip & "','" & strPhoneNumber & "','" & strEmail & "','" & intShirtSizeID & "','" & intGenderID & "'"
            cmdAddGolfer.CommandType = CommandType.StoredProcedure

            'Call stored procedure which will insert the record
            cmdAddGolfer = New OleDb.OleDbCommand(cmdAddGolfer.CommandText, m_conAdministrator)

            'this return is the # of rows affected
            intRowsAffected = cmdAddGolfer.ExecuteNonQuery()

            'close the database connection
            CloseDatabaseConnection()

            'have to let the user know what happened
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Golfer " & strLastName & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close() 'close the form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

    End Sub

    'Procedure used to validate the user defined entries
    Public Function Validation(ByRef strFirstName As String, ByRef strLastName As String, ByRef strStreetAddress As String, ByRef strCity As String, ByRef strState As String, ByRef strZip As String, ByRef strPhoneNumber As String, ByRef strEmail As String, ByRef intShirtSizeID As Integer, ByRef intGenderID As Integer) As Boolean

        ' loop through the textboxes and clear them in case they have data in them after a delete
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                    Exit Function
                End If
            End If
        Next

        'Enter user defined information in textboxes within the various strings defined
        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strStreetAddress = txtStreetAddress.Text
        strCity = txtCity.Text
        strState = txtState.Text
        strZip = txtZip.Text
        strPhoneNumber = txtPhoneNumber.Text
        strEmail = txtEmail.Text

        'Define the Shirt Size Primary Key utilizing the Selected Index method from combobox and adding 1 because index starts at 0
        intShirtSizeID = cboShirtSize.SelectedIndex + 1

        'Define the Gender Primary Key utilizing the Selected Index method from combobox and adding 1 because index starts at 0
        intGenderID = cboGender.SelectedIndex + 1

        'everything is good so return true
        Return True

    End Function

    'Loads the shirt size information from the connected database
    Private Sub Load_ShirtSize()
        Try

            Dim strSelect As String = ""
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

            ' Add the item to the combo box. We need the Shirt Size ID associated with the description so 
            ' when we click on the name we can then use the ID to pull the rest of the shirt size data.
            ' We are binding the column name to the combo box display and value members. 
            cboShirtSize.ValueMember = "intShirtSizeID"
            cboShirtSize.DisplayMember = "strShirtSizeDesc"
            cboShirtSize.DataSource = dt

            ' Select the first item in the list by default
            ' comment this line out so actual shirt size is selected and not the first item
            'If cboShirtSize.Items.Count > 0 Then cboShirtSize.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'Load Gender information from the connected SQL Server database
    Private Sub Load_Gender()
        Try

            Dim strSelect As String = ""
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

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'Loads various information from the SQL Server database to be used within the application
    Private Sub frmAddGolfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_ShirtSize()
            Load_Gender()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Procedure to close the form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnCloseWindow.Click

        ' close form
        Close()

    End Sub

End Class