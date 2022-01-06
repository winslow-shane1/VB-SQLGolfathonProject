' --------------------------------------------------------------------------------------------------
' Name: Shane Winslow
' Date: 04/07/2021
' Description: This form controls procedures to manage TGolferEventYears modifications
' --------------------------------------------------------------------------------------------------
Option Strict On

Public Class frmManageGolferEvent
    'Procedure automatically load and reloads information for golfers parcipation in the golfing events
    Private Sub frmManageEventGolfers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form load will load the combo box. If you setup the combo box with a
        ' selected index change (see below) it will load the golfers from the
        ' event year selected into to event golfer list box. Form load will also pull 
        ' golfers from the view in the DB that has golfers not on a team and load
        ' them into the Available golfers list box.

        Try

            ' *************************************************************************************
            ' LOAD Event Year COMBO BOX
            ' *************************************************************************************

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


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

            ' Show changes all at once at end (MUCH faster). 
            cboEventYears.BeginUpdate()

            ' Build the select statement for combo box for teams
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears ORDER BY intEventYear DESC"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboEventYears.ValueMember = "intEventYearID"
            cboEventYears.DisplayMember = "intEventYear"
            cboEventYears.DataSource = dt

            ' Select the first item in the list by default
            If cboEventYears.Items.Count > 0 Then cboEventYears.SelectedIndex = 0

            ' Show any changes
            cboEventYears.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()


            ' *************************************************************************************
            ' LOAD AVAILABLE GOLFERS LISTBOX
            ' *************************************************************************************
            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader

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

            ' Show changes all at once at end (MUCH faster). 
            lstAvailableGolfers.BeginUpdate()

            ' Build the select statement
            strSelect = "SELECT intGolferID, strLastName FROM vAvailableGolfers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt1.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstAvailableGolfers.ValueMember = "intGolferID"
            lstAvailableGolfers.DisplayMember = "strLastName"
            lstAvailableGolfers.DataSource = dt1



            ' Select the first item in the list by default
            If lstAvailableGolfers.Items.Count > 0 Then lstAvailableGolfers.SelectedIndex = 0

            ' Show any changes
            lstAvailableGolfers.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    'Procedure occurs when the Event Year combobox is modified
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventYears.SelectedIndexChanged
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


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

            'Show changes all at once at end
            lstEventGolfer.BeginUpdate()

            ' Build the select statement for listbox with golfers participating in the year selected
            strSelect = "SELECT intGolferID, strLastName FROM vEventGolfers WHERE intEventYearID = " & cboEventYears.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstEventGolfer.ValueMember = "intGolferID"
            lstEventGolfer.DisplayMember = "strLastName"
            lstEventGolfer.DataSource = dt

            ' Select the first item in the list by default
            If lstEventGolfer.Items.Count > 0 Then lstEventGolfer.SelectedIndex = 0

            ' Show any changes
            lstEventGolfer.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'Procedure occurs when user tries to add available golfer to the event selected
    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click
        ' this SUB will add an available golfer to the event year in the combo box. The 
        ' golfer will then show up in the Event Golfer list box when the Event Year is selected
        ' in the combo box.

        Try

            Dim cmdAddEventGolfer As New OleDb.OleDbCommand ' this will be used for our Select statement
            Dim intRowsAffected As Integer
            Dim intGolferEventYearID As Integer 'have to pass this in a stored procedure requirement
            Dim intEventYearID As Integer
            Dim intGolferID As Integer
            Dim strGolferName As String
            Dim strEventYear As String

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

            'variables defined based on the selected event year and available golfer
            intEventYearID = CInt(cboEventYears.SelectedValue)
            intGolferID = CInt(lstAvailableGolfers.SelectedValue)

            'Execute Command
            cmdAddEventGolfer.CommandText = "EXECUTE uspAddGolferEvent '" & intGolferEventYearID & "','" & intGolferID & "','" & intEventYearID & "'"
            cmdAddEventGolfer.CommandType = CommandType.StoredProcedure

            'Call stored procedure which will insert the record
            cmdAddEventGolfer = New OleDb.OleDbCommand(cmdAddEventGolfer.CommandText, m_conAdministrator)

            'this return is the # of rows affected
            intRowsAffected = cmdAddEventGolfer.ExecuteNonQuery()

            ' close the database connection
            CloseDatabaseConnection()

            'have to let the user know what happened
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Golfer has been added to Event.")

            Else
                MessageBox.Show("Insert failed")

            End If

            ' close the database connection
            CloseDatabaseConnection()

            ' reload the form so the changes are shown
            frmManageEventGolfers_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    'Procedure occurs when the user tries to remove the golfer from the golfer event
    Private Sub btnRemoveGolfer_Click(sender As Object, e As EventArgs) Handles btnRemoveGolfer.Click
        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult

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

            ' always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & lstEventGolfer.Text & " from " & cboEventYears.Text & " ?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' Build the delete statement using PK from name selected
                    strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & lstEventGolfer.SelectedValue.ToString & " AND intEventYearID = " & cboEventYears.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


            End Select


            ' close the database connection
            CloseDatabaseConnection()

            ' refresh the form so changes can be seen
            frmManageEventGolfers_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    'Procedure occurs when the user toggles the exit button
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnAddSponsorship_Click(sender As Object, e As EventArgs) Handles btnAddSponsorship.Click
        Dim frmAddSponsorship As New frmAddSponsorship

        frmAddSponsorship.ShowDialog()
    End Sub
End Class