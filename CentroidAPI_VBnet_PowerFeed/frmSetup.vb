Imports CentroidAPI.CNCPipe.State

'****************************************************************************
'
' Title:        frmSetup.vb
' Author(s):    Jacob Holes
' Start Date:   11-04-24
' Purpose: Setup panel that provides users access to configure the feedrate used for the power feed commands
'
' Environment/platform  ( Windows 10/11, Visual Basic .net)
'
' Last Update:  11-04-24 - JDH - Added header and comments
' Prior Update: 11-04-24 - JDH - Created frmSetup, built form, added logic
'****************************************************************************


Class frmSetup
    ' create pipe
    Dim m_pipe As CNCPipe

    ''' <summary>
    ''' This sub is used to initilize the form, let's set the txtFeedrate.text here by pulling from our app settings
    ''' </summary>
    Sub New(ByVal MainPipe As CNCPipe)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' set txtFeedrate.text to our setting dblFeedRate
        Me.txtFeedrate.Text = My.Settings.dblFeedRate
        ' pass main pipe so we can communicate with CNC12 using the same pipe
        m_pipe = MainPipe
    End Sub

    ''' <summary>
    ''' Handles our input from all buttons but clear, accept, and cancel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' This is the handler for btnClear_Click, it clears the txtFeedrate text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.txtFeedrate.Clear()
    End Sub

    ''' <summary>
    ''' Handler for btnAccept_Click, saves our feedrate value to settings where it will be called when running a power feed command
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        ' convert txtFeedrate.text to a double then save that value in our settings
        My.Settings.dblFeedRate = CDbl(Me.txtFeedrate.Text)
        ' save our settings
        My.Settings.Save()
        ' close this form
        Me.Close()
    End Sub

    ''' <summary>
    ''' Handler for btnCancel_Click, this closes our form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' When the form loads, check our units of measurement and display the corrent label text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim state As New CentroidAPI.CNCPipe.State(m_pipe)
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