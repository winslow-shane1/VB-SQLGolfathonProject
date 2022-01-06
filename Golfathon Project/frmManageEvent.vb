' ***********************************************************************************************
' Name: Shane Winslow
' Date: 03/30/2021
' Abstract: Form to select or add event year information
' ************************************************************************************************
Option Strict On

Public Class frmManageEvent
    'Event information to load automatically when the Event form is pulled up
    Private Sub frmEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try

            Dim strSelect As String = ""
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
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears ORDER BY intEventYear DESC"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the EventYear ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the event year data.
            ' We are binding the column name to the combo box display and value members. 
            cboEventYear.ValueMember = "intEventYearID"
            cboEventYear.DisplayMember = "intEventYear"
            cboEventYear.DataSource = dt

            ' Select the first item in the list by default
            If cboEventYear.Items.Count > 0 Then cboEventYear.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    'Procdure to occur when the event year combobox is toggled
    Private Sub cboEventYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventYear.SelectedIndexChanged
        Dim strSelect As String = "" 'select string to be used to speak with database
        Dim strName As String = ""
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
            strSelect = "SELECT intEventYear FROM TEventYears Where intEventYearID = " & cboEventYear.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load the data table from the reader
            dt.Load(drSourceTable)

            ' close the database connection
            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Procedure to be used with the Close button is toggled
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    'Procedure to occur when the add event button is toggled
    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click
        Dim AddEvent As New frmAddEvent
        AddEvent.ShowDialog()
        frmEvent_Load(sender, e)

    End Sub
End Class