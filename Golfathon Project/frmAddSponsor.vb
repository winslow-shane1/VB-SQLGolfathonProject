' ************************************************************************************************************
' Name: Shane Winslow
' Date: 04/20/2021
' Abstract: Form to add sponsor information as new entry to database
' ************************************************************************************************************
Option Strict On


Public Class frmAddSponsor
    'procedure to occur when button close is toggled
    Private Sub btnCloseWindow_Click(sender As Object, e As EventArgs) Handles btnCloseWindow.Click
        Close()
    End Sub

    'procedure to occur when Add Sponsor button is toggled
    Private Sub btnAddNewSponsor_Click(sender As Object, e As EventArgs) Handles btnAddNewSponsor.Click
        ' variables for new golfers data and select and insert statements
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""

        'Validate the information provided by user to move on to adding information to database
        If Validation(strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail) = True Then
            'pass inputs, now validated to sub AddGolfer to enter in DB
            AddSponsor(strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail)

        End If
    End Sub

    'Procedure to occure when the button Add Golfer is toggled
    Private Sub AddSponsor(ByVal strFirstName As String, ByVal strLastName As String, ByVal strStreetAddress As String, ByVal strCity As String, ByVal strState As String, ByVal strZip As String, ByVal strPhoneNumber As String, ByVal strEmail As String)

        'create command object and integer for number of returned rows
        Dim cmdAddSponsor As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intSponsorID As Integer ' this is what we pass in as the stored procedure requires it

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
            cmdAddSponsor.CommandText = "EXECUTE uspAddSponsor '" & intSponsorID & "','" & strFirstName & "','" & strLastName & "','" & strStreetAddress & "','" & strCity & "','" & strState & "','" & strZip & "','" & strPhoneNumber & "','" & strEmail & "'"
            cmdAddSponsor.CommandType = CommandType.StoredProcedure

            'Call stored procedure which will insert the record
            cmdAddSponsor = New OleDb.OleDbCommand(cmdAddSponsor.CommandText, m_conAdministrator)

            'this return is the # of rows affected
            intRowsAffected = cmdAddSponsor.ExecuteNonQuery()

            'close the database connection
            CloseDatabaseConnection()

            'have to let the user know what happened
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Sponsor " & strLastName & " has been added.")

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
    Public Function Validation(ByRef strFirstName As String, ByRef strLastName As String, ByRef strStreetAddress As String, ByRef strCity As String, ByRef strState As String, ByRef strZip As String, ByRef strPhoneNumber As String, ByRef strEmail As String) As Boolean

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

        'everything is good so return true
        Return True

    End Function

End Class