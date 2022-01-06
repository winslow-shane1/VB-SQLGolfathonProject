Public Class frmAddSponsorship

    'Procedure automatically load and reloads information for golfers parcipation in the golfing events
    Private Sub frmAddSponsorship_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form load will load the combo box. If you setup the combo box with a
        ' selected index change (see below) it will load the golfers from the
        ' event year selected into to event golfer list box. Form load will also pull 
        ' golfers from the view in the DB that has golfers not on a team and load
        ' them into the Available golfers list box.

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


            Load_EventYears()
            Load_EventGolfers()
            Load_Sponsors()
            Load_SponsorshipType()
            Load_PaymentType()
            Load_PaymentStatus()

            ' close the database connection
            CloseDatabaseConnection()

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

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    'Procedure occurs when the Event Year combobox is modified
    Private Sub cboEventYears_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventYears.SelectedIndexChanged
        Try

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

            ' Clean up
            drSourceTable.Close()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'Procedure to load the participating Golfers for a specific event year
    Private Sub Load_EventGolfers()
        ' *************************************************************************************
        Try

            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

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

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    'Procedure to load sponsors 
    Private Sub Load_Sponsors()
        ' *************************************************************************************
        ' LOAD AVAILABLE SPONSORS LISTBOX
        ' *************************************************************************************
        Try

            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to

            ' Show changes all at once at end (MUCH faster). 
            lstSponsors.BeginUpdate()

            ' Build the select statement
            strSelect = "SELECT intSponsorID, strLastName, strFirstName FROM vSponsors"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt1.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstSponsors.ValueMember = "intSponsorID"
            lstSponsors.DisplayMember = "strLastName"
            lstSponsors.DataSource = dt1



            ' Select the first item in the list by default
            If lstSponsors.Items.Count > 0 Then lstSponsors.SelectedIndex = 0

            ' Show any changes
            lstSponsors.EndUpdate()

            ' Clean up
            drSourceTable.Close()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'Procedure to Load Sponsorship Type
    Private Sub Load_SponsorshipType()
        Try

            ' *************************************************************************************
            ' LOAD Sponsorship Type COMBO BOX
            ' *************************************************************************************

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            ' Show changes all at once at end (MUCH faster). 
            cboSponsorshipType.BeginUpdate()

            ' Build the select statement for combo box for teams
            strSelect = "SELECT intSponsorTypeID, strSponsorTypeDesc FROM TSponsorTypes ORDER BY intSponsorTypeID DESC"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboSponsorshipType.ValueMember = "intSponsorTypeID"
            cboSponsorshipType.DisplayMember = "strSponsorTypeDesc"
            cboSponsorshipType.DataSource = dt

            ' Select the first item in the list by default
            If cboSponsorshipType.Items.Count > 0 Then cboSponsorshipType.SelectedIndex = 0

            ' Show any changes
            cboSponsorshipType.EndUpdate()

            ' Clean up
            drSourceTable.Close()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'Procedure to Load Payment Type
    Private Sub Load_PaymentType()
        Try

            ' *************************************************************************************
            ' LOAD Payment Type COMBO BOX
            ' *************************************************************************************

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            ' Show changes all at once at end (MUCH faster). 
            cboPaymentType.BeginUpdate()

            ' Build the select statement for combo box for teams
            strSelect = "SELECT intPaymentTypeID, strPaymentTypeDesc FROM TPaymentTypes ORDER BY intPaymentTypeID DESC"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboPaymentType.ValueMember = "intPaymentTypeID"
            cboPaymentType.DisplayMember = "strPaymentTypeDesc"
            cboPaymentType.DataSource = dt

            ' Select the first item in the list by default
            If cboPaymentType.Items.Count > 0 Then cboPaymentType.SelectedIndex = 0

            ' Show any changes
            cboPaymentType.EndUpdate()

            ' Clean up
            drSourceTable.Close()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub Load_PaymentStatus()

        cboPaymentStatus.SelectedItem = "Paid"

    End Sub

    Private Sub btnAddSponsorship_Click(sender As Object, e As EventArgs) Handles btnAddSponsorship.Click
        ' variables for new golfers data and select and insert statements
        Dim intGolferID As Integer
        Dim intEventYearID As Integer
        Dim intSponsorID As Integer
        Dim monPledgeAmount As Double
        Dim intSponsorTypeID As Integer
        Dim intPaymentTypeID As Integer
        Dim intPaymentStatusID As Integer
        Dim blnValidate As Boolean = True

        'Validate the information provided by user to move on to adding information to database
        ValidateSelections(intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, intPaymentStatusID, blnValidate)

        If blnValidate = True Then
            'pass inputs, now validated to sub AddGolfer to enter in DB
            AddSponsorship(intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, intPaymentStatusID)

        End If


    End Sub

    'Procedure to occure when the button Add Golfer is toggled
    Private Sub AddSponsorship(ByVal intGolferID As Integer, ByVal intEventYearID As Integer, ByVal intSponsorID As Integer, ByVal monPledgeAmount As Double, ByVal intSponsorTypeID As Integer, ByVal intPaymentTypeID As Integer, ByVal intPaymentStatusID As Integer)

        'create command object and integer for number of returned rows
        Dim cmdAddSponsorship As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intGolferEventYearSponsorID As Integer ' this is what we pass in as the stored procedure requires it

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
            cmdAddSponsorship.CommandText = "EXECUTE uspAddGolferEventYearSponsor " & intGolferEventYearSponsorID & ", " & intGolferID & ", " & intEventYearID & ", " & intSponsorID & ", " & monPledgeAmount & ", " & intSponsorTypeID & ", " & intPaymentTypeID & ", " & intPaymentStatusID
            cmdAddSponsorship.CommandType = CommandType.StoredProcedure

            'MessageBox.Show(cmdAddSponsorship.CommandText)

            'Call stored procedure which will insert the record
            cmdAddSponsorship = New OleDb.OleDbCommand(cmdAddSponsorship.CommandText, m_conAdministrator)

            'this return is the # of rows affected
            intRowsAffected = cmdAddSponsorship.ExecuteNonQuery()

            'close the database connection
            CloseDatabaseConnection()

            'have to let the user know what happened
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Sponsorship for Golfer.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close() 'close the form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    Private Sub ValidateSelections(ByRef intGolferID As Integer, ByRef intEventYearID As Integer, ByRef intSponsorID As Integer, ByRef monPledgeAmount As Double, ByRef intSponsorTypeID As Integer, ByRef intPaymentTypeID As Integer, ByRef intPaymentStatusID As Integer, ByRef blnValidate As Boolean)
        Try

            If txtAmount.Text = String.Empty Then
                blnValidate = False
                MessageBox.Show("Please enter a value for the amount donated")
            ElseIf IsNumeric(txtAmount.Text) = False Then
                blnValidate = False
                MessageBox.Show("Sponsorship Amount must be numeric")
            ElseIf txtAmount.Text Then
            End If

            If blnValidate = False Then
                Throw New System.Exception
            Else
                intGolferID = lstEventGolfer.SelectedValue
                intSponsorID = lstSponsors.SelectedValue
                intEventYearID = cboEventYears.SelectedValue
                intSponsorTypeID = cboSponsorshipType.SelectedValue
                intPaymentTypeID = cboPaymentType.SelectedValue
                intPaymentStatusID = cboPaymentStatus.SelectedIndex
                monPledgeAmount = txtAmount.Text

            End If

        Catch ex As Exception

            MessageBox.Show("Please modify your response and resubmit")
            Exit Sub

        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class