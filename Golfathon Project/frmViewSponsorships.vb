Public Class frmViewSponsorships
    Private Sub frmViewSponsorships_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_EventYears()
            Load_EventTotal()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Load_EventYears()
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

        Catch excError As Exception
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub Load_GolferEventYears()
        Try

            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader
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
            lstEventGolfer.BeginUpdate()

            ' Build the select statement
            strSelect = "SELECT intGolferID, strLastName FROM vEventGolfers Where intEventYearID = " & cboEventYears.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt1.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstEventGolfer.ValueMember = "intGolferID"
            lstEventGolfer.DisplayMember = "strLastName"
            lstEventGolfer.DataSource = dt1



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

    Private Sub Load_Sponsors()
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
            lstSponsors.BeginUpdate()

            ' Build the select statement for listbox with golfers participating in the year selected
            strSelect = "SELECT Sponsor, intSponsorID FROM vSponsorships WHERE intEventYearID = " & cboEventYears.SelectedValue.ToString
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstGolferEventSponsor.ValueMember = "intSponsorID"
            lstGolferEventSponsor.DisplayMember = "Sponsor"
            lstGolferEventSponsor.DataSource = dt

            ' Select the first item in the list by default
            If lstSponsors.Items.Count > 0 Then lstSponsors.SelectedIndex = 0

            ' Show any changes
            lstSponsors.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub Load_EventTotal()
        lblEventTotal.DataBindings.Clear()

        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim strModLabel As String = ""
            Dim dblModLabel As Double = 0.0

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

            ' Build the select statement for listbox with golfers participating in the year selected
            strSelect = "SELECT TotalEvent FROM vEventTotal WHERE intEventYearID = " & cboEventYears.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            'load the information into text for label
            lblEventTotal.DataBindings.Add("Text", dt, "TotalEvent")
            strModLabel = lblEventTotal.Text

            dblModLabel = CDbl(lblEventTotal.Text)
            strModLabel = dblModLabel.ToString("C")

            lblEventTotal.Text = strModLabel

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)
        End Try
    End Sub

    'Procedure to occur when Event Year combobox is toggled
    Private Sub cboEventYears_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventYears.SelectedIndexChanged
        lblEventTotal.DataBindings.Clear()
        lblGolferTotal.DataBindings.Clear()
        lblGolferTotal.Text = String.Empty
        lblTotalSponsored.DataBindings.Clear()
        lblTotalSponsored.Text = String.Empty

        Try

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

            Load_lstEventGolfer()
            Load_lstSponsors()
            Load_EventTotal()

        Catch exc As Exception
            MessageBox.Show(exc.Message)
        End Try

    End Sub


    Private Sub Load_lstEventGolfer()
        Try
            '###############################################################################################
            'BEGIN UPDATE FOR GOLFERS IN SELECTED YEAR
            '###############################################################################################
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

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

        Catch exc As Exception

            MessageBox.Show(exc.Message)

        End Try

        '###############################################################################################
        'END UPDATE FOR GOLFERS IN SELECTED YEAR
        '###############################################################################################
    End Sub


    Private Sub Load_lstSponsors()
        '###############################################################################################
        '!!!!!!!!BEGIN UPDATE FOR SPONSORS IN SELECTED YEAR
        '###############################################################################################

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        Try
            'Show changes all at once at end
            lstSponsors.BeginUpdate()

            ' Build the select statement for listbox with golfers participating in the year selected
            strSelect = "SELECT DISTINCT Sponsor, intSponsorID FROM vParticipatingSponsors WHERE intEventYearID = " & cboEventYears.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstSponsors.ValueMember = "intSponsorID"
            lstSponsors.DisplayMember = "Sponsor"
            lstSponsors.DataSource = dt

            ' Select the first item in the list by default
            If lstSponsors.Items.Count > 0 Then lstSponsors.SelectedIndex = 0

            ' Show any changes
            lstSponsors.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'Procedure to occur when View Funding Button is toggled
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click

        CheckSponsors()
        CalculateTotal()

    End Sub

    Private Sub CheckSponsors()

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
            lstGolferEventSponsor.BeginUpdate()

            ' Build the select statement for listbox with golfers participating in the year selected
            strSelect = "SELECT Sponsor, intSponsorID FROM vSponsorshipsGolfer WHERE intEventYearID = " & cboEventYears.SelectedValue.ToString & " and intGolferID = " & lstEventGolfer.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstGolferEventSponsor.ValueMember = "intSponsorID"
            lstGolferEventSponsor.DisplayMember = "Sponsor"
            lstGolferEventSponsor.DataSource = dt

            ' Select the first item in the list by default
            If lstGolferEventSponsor.Items.Count > 0 Then lstGolferEventSponsor.SelectedIndex = 0

            ' Show any changes
            lstGolferEventSponsor.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub CalculateTotal()
        lblGolferTotal.DataBindings.Clear()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim strModLabel As String = ""
            Dim dblModLabel As Double = 0.0

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

            ' Build the select statement for listbox with golfers participating in the year selected
            strSelect = "SELECT TotalCollected FROM vSponsorshipTotalCollected WHERE intEventYearID = " & cboEventYears.SelectedValue.ToString & " and intGolferID = " & lstEventGolfer.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            'load the information into text for label
            lblGolferTotal.DataBindings.Add("Text", dt, "TotalCollected")
            strModLabel = lblGolferTotal.Text

            dblModLabel = CDbl(lblGolferTotal.Text)
            strModLabel = dblModLabel.ToString("C")

            lblGolferTotal.Text = strModLabel

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try


    End Sub

    Private Sub btnTotalSponsored_Click(sender As Object, e As EventArgs) Handles btnTotalSponsored.Click
        lblTotalSponsored.DataBindings.Clear()

        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim strModLabel As String = ""
            Dim dblModLabel As Double = 0.0

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

            ' Build the select statement for listbox with golfers participating in the year selected
            strSelect = "SELECT TotalSponsored FROM vSponsorshipTotalSponsored WHERE intEventYearID = " & cboEventYears.SelectedValue.ToString & " AND intSponsorID = " & lstSponsors.SelectedValue

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            'load the information into text for label
            lblTotalSponsored.DataBindings.Add("Text", dt, "TotalSponsored")
            strModLabel = lblGolferTotal.Text

            dblModLabel = CDbl(lblTotalSponsored.Text)
            strModLabel = dblModLabel.ToString("C")

            lblTotalSponsored.Text = strModLabel

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class