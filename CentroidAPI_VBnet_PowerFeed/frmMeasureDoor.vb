Imports System.Threading
Imports CentroidAPI
Imports CentroidAPI.CNCPipe

'****************************************************************************
'
' Title:        frmMeasureDoor.vb
' Author(s):    Jacob Holes
' Start Date:   10-31-24
' Purpose: Custom Application for Customer with custom panel cutting machine
'
' Environment/platform  ( Windows 10/11, Visual Basic .net)
'
' Last Update:  11-1-24 - JDH - Added error handling
' Prior Update: 10-31-24 - JDH - Created Project and Solution, added Form, populated form with buttons, wrote logic for X move and Cycle Cancel
'****************************************************************************

Public Class frmMeasureDoor
    ' create pipe
    Dim m_pipe As CNCPipe
    ' create thread for monitoring if cnc12 is running
    Dim cnc12_isRunning_thread As Threading.Thread

    ''' <summary>
    ''' This sub is called when this form is created, we use it to initialize the cnc pipe
    ''' </summary>
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' initialize pipe so we can communicate with CNC12
        m_pipe = New CentroidAPI.CNCPipe
    End Sub

    ''' <summary>
    ''' When the Form Loads, check that the pipe is good, if its not assume CNC12 is not running, inform the user then exit the app. 
    ''' If we can communicate with CNC12 then start the background thread for checking if CNC12 is running
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMeasureDoor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If m_pipe IsNot Nothing Then
            If Not m_pipe.IsConstructed Then
                MessageBox.Show("Could not connect to CNC12. Please make sure CNC12 is running before using this application.", "Could not connect to CNC12")
                Application.Exit()
            End If
        End If

        ' create new thread that calls IsCNC12Running
        cnc12_isRunning_thread = New Threading.Thread(AddressOf IsCNC12Running)
        ' set is as a background thread
        cnc12_isRunning_thread.IsBackground = True
        ' start the thread
        cnc12_isRunning_thread.Start()
    End Sub

    ''' <summary>
    ''' This sub handles all of the btnEnter[Val] button.click events, it appends the button text to the 
    ''' txtDoorMeasurment textbox and does not allow users to enter two decimal places
    ''' </summary>
    ''' <param name="sender">object which called the sub</param>
    ''' <param name="e">arguments for event</param>
    Private Sub HandleButtonPress_Click(sender As Object, e As EventArgs) Handles btnEnter1.Click, btnEnter2.Click, btnEnter3.Click, btnEnter4.Click,
            btnEnter5.Click, btnEnter6.Click, btnEnter7.Click, btnEnter8.Click, btnEnter9.Click, btnEnter0.Click, btnEnterDecimal.Click
        ' Get the button the user clicked, cast it as a button
        Dim ClickedButton As Button = DirectCast(sender, Button)
        ' if we clicked the decimal point...
        If ClickedButton.Text = "." Then
            ' check that we don't already have a decimal point
            If Me.txtDoorMeasurement.Text.Contains(".") Then
                ' if we do, don't allow multiple decimal points
            Else
                ' otherwise, add the decimal point
                Me.txtDoorMeasurement.Text = Me.txtDoorMeasurement.Text & ClickedButton.Text
            End If
        Else
            ' allow everything else
            Me.txtDoorMeasurement.Text = Me.txtDoorMeasurement.Text & ClickedButton.Text
        End If

    End Sub

    ''' <summary>
    ''' Clears the text in the txtDoorMeasurement text box
    ''' </summary>
    ''' <param name="sender">object which called the sub</param>
    ''' <param name="e">arguments for event</param>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.txtDoorMeasurement.Clear()
    End Sub

    ''' <summary>
    ''' Sends a G1 command using xDistance as X axis distance and FeedRate as desired FeedRate
    ''' </summary>
    ''' <param name="xDistance">Distance to move X Axis</param>
    ''' <param name="FeedRate">Speed at which to move X Axis</param>
    ''' <returns></returns>
    Function SendXMoveCommand(ByVal xDistance As Double, Optional ByVal FeedRate As Double = 50)
        ' check that pipe is initialized
        If m_pipe IsNot Nothing Then
            ' then check that it is constructed
            If m_pipe.IsConstructed Then
                ' reference to Job class
                Dim cmd As New CentroidAPI.CNCPipe.Job(m_pipe)
                ' return the result of the command after building the command and sending it to cnc12
                Return cmd.RunCommand("G1 X" & xDistance & " F" & FeedRate, "C:/cncm", False)
            End If
        End If
        ' if we failed, send back an unknown error
        Return CentroidAPI.CNCPipe.ReturnCode.ERROR_UNKNOWN
    End Function

    ''' <summary>
    ''' Sends Cycle Stop Command
    ''' </summary>
    ''' <returns>ReturnCode</returns>
    Function SendCycleStopCommand()
        If m_pipe IsNot Nothing Then
            If m_pipe.IsConstructed Then
                Dim cmd As New CentroidAPI.CNCPipe.Job(m_pipe)
                Return cmd.CancelExecution()
            End If
        End If

        Return CentroidAPI.CNCPipe.ReturnCode.ERROR_UNKNOWN
    End Function

    ''' <summary>
    ''' This sub checks if CNC12 is running and updates the title bar text depending on the result
    ''' </summary>
    Private Sub IsCNC12Running()
        ' called from a background thread and we want it to continue forever, so while true...
        While True
            Try
                ' we are testing if we are connected to CNC12 by checking if Parameter 1 has any value.
                ' If we successfully grab the value, we are connected
                Dim Param1Val As Double = 0
                Dim Param As New CentroidAPI.CNCPipe.Parameter(m_pipe)
                Dim ParamTest As CentroidAPI.CNCPipe.ReturnCode = Param.GetMachineParameterValue(1, Param1Val)
                ' if we got success then we are connected
                If ParamTest = CNCPipe.ReturnCode.SUCCESS Then
                    ' set the title bar text to connected to cnc12
                    ChangeTitleBarText("Power Feed App - Connected to CNC12")
                ElseIf ParamTest = CNCPipe.ReturnCode.ERROR_PIPE_IS_BROKEN Then
                    ' if the pipe is broken, try to recreate it.
                    m_pipe = New CNCPipe
                Else
                    ' otherwise assume we are disconnected. 
                    ChangeTitleBarText("Power Feed App - Disconnected from CNC12")
                End If
            Catch ex As Exception
                ' if we get an exception when checking then assume we are disconnected
                ChangeTitleBarText("Power Feed App - Disconnected from CNC12")
            End Try
            ' sleep for half a second so we don't use up a CPU core
            Threading.Thread.Sleep(500)
        End While
    End Sub

    ''' <summary>
    ''' This sub handles the cycle start click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub picCycleStart_Click(sender As Object, e As EventArgs) Handles picCycleStart.Click
        ' don't send an empty string as an x value
        If Me.txtDoorMeasurement.Text.Trim IsNot "" Then
            ' get our X value from txtDoorMeasurement.Text as a double
            Dim XVal As Double = CDbl(Me.txtDoorMeasurement.Text)
            ' try to send the move command, if it was successful then clear our input box
            If SendXMoveCommand(XVal) = CentroidAPI.CNCPipe.ReturnCode.SUCCESS Then
                Me.txtDoorMeasurement.Clear()
            Else
                ' if we get any message other than success, then something went wrong. 
                ' TODO: Add more robust error handling, but this should be fine for this basic example. 
                MessageBox.Show("An error has occured...")
            End If
        End If

    End Sub

    ''' <summary>
    ''' This sub handles the cycle cancel click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub picCycleCancel_Click(sender As Object, e As EventArgs) Handles picCycleCancel.Click
        ' Try to send the cycle stop command, throw a message if we return anything but success
        If Not SendCycleStopCommand() = CentroidAPI.CNCPipe.ReturnCode.SUCCESS Then
            MessageBox.Show("An error has occured...")
        End If
    End Sub

    ''' <summary>
    ''' This sub allows us to interact with the title bar text from another thread safely
    ''' </summary>
    ''' <param name="text">The text to display in the title bar</param>
    Private Sub ChangeTitleBarText(ByVal text As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(Sub()
                               Me.Text = text
                           End Sub)
        Else
            Me.Text = text
        End If
    End Sub

    ''' <summary>
    ''' This sub is called when a key press is detected in the txtDoorMeasurement textbox. It prevents multiple periods from being typed by keyboard.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtDoorMeasurement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDoorMeasurement.KeyPress
        ' if using keyboard, don't allow for multiple decimal points
        If Me.txtDoorMeasurement.Text.Contains(".") Then
            ' check that our entered character is a period
            If e.KeyChar = "."c Then
                ' this prevents the character from being typed
                e.Handled = True
            Else
                ' this allows the character to be typed
                e.Handled = False
            End If

        End If
    End Sub
End Class
