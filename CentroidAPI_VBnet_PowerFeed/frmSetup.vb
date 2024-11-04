Imports CentroidAPI.CNCPipe.State

Class frmSetup

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.txtFeedrate.Text = My.Settings.dblFeedRate
    End Sub

    Private Sub HandleButtonPress_Click(sender As Object, e As EventArgs) Handles btnEnter1.Click, btnEnter2.Click, btnEnter3.Click, btnEnter4.Click,
        btnEnter5.Click, btnEnter6.Click, btnEnter7.Click, btnEnter8.Click, btnEnter9.Click, btnEnter0.Click, btnEnterDecimal.Click
        ' Get the button the user clicked, cast it as a button
        Dim ClickedButton As Button = DirectCast(sender, Button)
        ' if we clicked the decimal point...
        If ClickedButton.Text = "." Then
            ' check that we don't already have a decimal point
            If Me.txtFeedrate.Text.Contains(".") Then
                ' if we do, don't allow multiple decimal points
            Else
                ' otherwise, add the decimal point
                Me.txtFeedrate.Text = Me.txtFeedrate.Text & ClickedButton.Text
            End If
        Else
            ' allow everything else
            Me.txtFeedrate.Text = Me.txtFeedrate.Text & ClickedButton.Text
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.txtFeedrate.Clear()
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        My.Settings.dblFeedRate = CDbl(Me.txtFeedrate.Text)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim state As New CentroidAPI.CNCPipe.State(New CNCPipe)
        Dim uom As CNCPipe.State.UnitsOfMeasure
        If state.GetUnitsOfMeasureDro(uom) = CNCPipe.ReturnCode.SUCCESS Then
            If uom = UnitsOfMeasure.INCH_UNITS Then
                Me.lblUnits.Text = "Inches per minute"
            ElseIf uom = UnitsOfMeasure.METRIC_UNITS Then
                Me.lblUnits.Text = "Millimeters per minute"
            End If

        End If
    End Sub
End Class