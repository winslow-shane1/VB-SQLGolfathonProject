' ----------------------------------------------------
' Assignment: GolfathonProject_IT102_SRW
' Name: Shane Winslow
' -----------------------------------------------------
Option Strict On
Public Class frmMain
    'Closure procedure for program
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    'Procedure to call to new Golfer edit/entry form
    Private Sub btnGolfer_Click(sender As Object, e As EventArgs) Handles btnGolfer.Click
        Dim frmGolfer As New frmManageGolfer

        frmGolfer.ShowDialog()
    End Sub

    'Procedure to call new Event selection/entry form
    Private Sub btnEvent_Click(sender As Object, e As EventArgs) Handles btnEvent.Click
        Dim frmEvent As New frmManageEvent

        frmEvent.ShowDialog()
    End Sub

    'Procedure to call new Golfer-Event selection/entry form
    Private Sub btnGolferEvent_Click(sender As Object, e As EventArgs) Handles btnGolferEvent.Click
        Dim frmGolferEvent As New frmManageGolferEvent

        frmGolferEvent.ShowDialog()
    End Sub

    'Procedure to call new Sponsor selection/entry form
    Private Sub btnManageSponsor_Click(sender As Object, e As EventArgs) Handles btnManageSponsor.Click
        Dim frmManageSponsor As New frmManageSponsor

        frmManageSponsor.ShowDialog()
    End Sub

    'Procedure to call add sponsorship entry form
    Private Sub btnAddSponsorship_Click(sender As Object, e As EventArgs) Handles btnAddSponsorship.Click
        Dim frmAddSponsorship As New frmAddSponsorship

        frmAddSponsorship.ShowDialog()
    End Sub

    'Procedure to call View Sponsorship form
    Private Sub btnViewSponsorships_Click(sender As Object, e As EventArgs) Handles btnViewSponsorships.Click
        Dim frmViewSponsorships As New frmViewSponsorships

        frmViewSponsorships.ShowDialog()
    End Sub

End Class
