' ***********************************************************************************************
' Name: Shane Winslow
' Date: 03/30/2021
' Abstract: Form to add event years
' ************************************************************************************************
Option Strict On

Public Class frmAddEvent
    'Procedure to occur when Enter Year button is toggled
    Private Sub btnEnterYear_Click(sender As Object, e As EventArgs) Handles btnEnterYear.Click
        ' variables for new events data
        Dim intEventYear As Integer

        ' validate data is entered
        If Validation(intEventYear) = True Then
            'pass inputs, now validated to sub AddEventYear to enter in the DB
            AddEventYear(intEventYear)
        End If

    End Sub

    Private Sub AddEventYear(ByVal intEventYear As Integer)
        'create command object and integer for number of returned rows
        Dim cmdAddEventYear As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intEventYearID As Integer

        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' text to call stored procedure
            cmdAddEventYear.CommandText = "EXECUTE uspAddEvent '" & intEventYearID & "','" & intEventYear & "'"
            cmdAddEventYear.CommandType = CommandType.StoredProcedure

            ' Call stored procedure which will insert the record
            cmdAddEventYear = New OleDb.OleDbCommand(cmdAddEventYear.CommandText, m_conAdministrator)

            ' this return is the # of rows affected
            intRowsAffected = cmdAddEventYear.ExecuteNonQuery()

            'close database connection
            CloseDatabaseConnection()

            ' have to let the user know what happened 
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Event Year " & intEventYear & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close()  ' close the form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    Public Function Validation(ByRef intEventYear As Integer) As Boolean

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

        intEventYear = CInt(txtEnterYear.Text)

        'every this is good so return true
        Return True
    End Function

    Private Sub btnCloseWindow_Click(sender As Object, e As EventArgs) Handles btnCloseWindow.Click
        Close()
    End Sub
End Class