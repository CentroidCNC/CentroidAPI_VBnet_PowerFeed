'****************************************************************************
'
' Title:        clsPipeManager.vb
' Author(s):    Jacob Holes
' Start Date:   11-04-24
' Purpose: Class that manages a single pipe connection so we don't exceed the CNC12 pipe limit by reconnecting 
'                and offers some helpful functions when working with cnc12
'
' Environment/platform  ( Windows 10/11, Visual Basic .net)
'
' Last Update: 10-18-24 - JDH - Added IsInputOn and IsOutputOn
' Prior Update: 10-17-24 - JDH - Added RunJob, LoadJob, and IsRunningJob
' Prior Update: 11-06-24 - JDH - Added GetCNC12WorkingDirectory() 
' Prior Update: 11-05-24 - JDH - Added header and comments
' Prior Update: 11-04-24 - JDH - Created clsPipeManager, added Pipe and GetCNC12WorkingDirectory()
'****************************************************************************

Imports System.IO
' Import class to avoid ambiguous issue
Imports CentroidAPI.CNCPipe.Plc
Imports CentroidAPI.CNCPipe.Dro
Imports CentroidAPI.CNCPipe.Job
Imports CentroidAPI.CNCPipe


Public Class PipeManager
    ' our pipe holder
    Private m_pipe As CNCPipe

    ''' <summary>
    ''' Class New() Initilization, creates new pipe for communicating with CNC12
    ''' </summary>
    Sub New()
        ' when we initilize a new pipe manager, give it a new pipe
        m_pipe = New CNCPipe
    End Sub

    ''' <summary>
    ''' Gets the currently active cnc pipe
    ''' </summary>
    ''' <returns>Returns the currently active cnc pipe</returns>
    Public Property Pipe As CNCPipe
        Get
            ' return our pipe holder
            Return m_pipe
        End Get
        Set(value As CNCPipe)
            ' assign the set value to our pipe holder
            m_pipe = value
        End Set
    End Property

    ''' <summary>
    ''' This function checks to see if any of oour known processes are running, then extracts the working directory from the process
    ''' </summary>
    ''' <returns>The directory our current version of CNC12 (Normal, or Offline) is running from</returns>
    Public Function GetCNC12WorkingDirectory() As String
        ' Define the list of process names to check
        Dim processNames As String() = {"cncm", "cnct", "cncr", "cncp", "MillDemo", "LatheDemo"}

        Dim allProcesses As Process() = Process.GetProcesses
        For Each processName As String In processNames

            ' Get all processes with the specified name
            Dim processes As Process() = Process.GetProcessesByName(processName)

            ' Loop through each instance of the process
            For Each proc As Process In processes
                Try
                    ' Attempt to get the executable path and working directory
                    Dim executablePath As String = proc.MainModule.FileName
                    Dim workingDirectory As String = Path.GetDirectoryName(executablePath)
                    Return workingDirectory
                Catch ex As Exception

                End Try
            Next
        Next
        Return "Unknown"
    End Function

    ''' <summary>
    ''' Checks the connection status of the CNC12 pipe and tries to recreate it when it fails. 
    ''' </summary>
    ''' <returns>True if connected to CNC12 Pipe; False otherwise.</returns>
    Public Function ConnectedToCNC12() As Boolean
        ' IMPORTANT: On Error Resume Next tells the compiler to ignore errors, be careful as it may cause unintended side effects.
        ' A Try Catch would be better here but the debugger breaks on errors inside of the try catch and this bypasses that
        ' Since param.GetMachineParameterValue(1, paramValue) will cause an 'object reference not set to instance of an object'
        ' error when called on a dead pipe. 
        On Error Resume Next
        ' Check if the pipe exists and is constructed
        If m_pipe IsNot Nothing AndAlso m_pipe.IsConstructed Then
            Dim paramValue As Double = 0
            Dim param As New CentroidAPI.CNCPipe.Parameter(m_pipe)
            Dim returnCode As CentroidAPI.CNCPipe.ReturnCode = param.GetMachineParameterValue(1, paramValue)

            Select Case returnCode
                Case CNCPipe.ReturnCode.SUCCESS
                    ' Successfully connected to CNC12
                    Return True
                Case CNCPipe.ReturnCode.ERROR_PIPE_IS_BROKEN
                    ' Recreate the pipe if it is broken
                    m_pipe = New CentroidAPI.CNCPipe()
                Case CNCPipe.ReturnCode.ERROR_CLIENT_LOCKED
                    ' client locked means we are still connected but the client is locked, don't treat this as a disconnection
                    Return True
                Case Else
                    ' Any other error means disconnection
                    Return False
            End Select
        Else
            ' Pipe is not constructed; try to recreate it
            m_pipe = New CentroidAPI.CNCPipe()
        End If


        ' Return false if connection is not established
        Return False
    End Function
    ''' <summary>
    ''' This function checks the PLC to see if a program is running
    ''' </summary>
    ''' <returns>Returns true if program is running per pc system variable bit</returns>
    Function IsRunningJob() As Boolean
        If ConnectedToCNC12() Then
            Dim CNCPLC As New CentroidAPI.CNCPipe.Plc(m_pipe)
            Dim programRunning As CentroidAPI.CNCPipe.Plc.IOState
            CNCPLC.GetPcSystemVariableBit(PcToMpuSysVarBit.SV_PROGRAM_RUNNING, programRunning)
            Select Case programRunning
                Case IOState.IO_LOGICAL_0
                    ' return false if we aren't running a job
                    Return False
                Case IOState.IO_LOGICAL_1
                    ' return true if we are running a job
                    Return True
                Case IOState.IO_STATE_UNKNOWN
                    ' return true for safety
                    Return True
            End Select
        End If
        ' return false because we're not connected
        Return False
    End Function


    ' --------------------------------------------------------------------------------------------'
    ' This section below includes samples to help you accomplish your goals using the CentroidAPI '
    ' --------------------------------------------------------------------------------------------'


    ''' <summary>
    ''' Loads a job into CNC12 but does not start the job.
    ''' </summary>
    ''' <param name="jobLocation">The full or relative path of the file</param>
    ''' <returns>Returns a ReturnCode</returns>
    Function LoadJob(ByVal jobLocation As String) As CentroidAPI.CNCPipe.ReturnCode
        ' check that the file exists and that we are connected to CNC12
        If IO.File.Exists(jobLocation) Then
            If ConnectedToCNC12() Then
                ' reference to Job class
                Dim cmd As New CentroidAPI.CNCPipe.Job(m_pipe)
                ' return the return code for Load, check it for SUCCESS
                Return cmd.Load(jobLocation, GetCNC12WorkingDirectory)
            Else
                ' warn that we aren't connected to cnc12
                MessageBox.Show("Error: Not Connected to CNC12")
                ' return error code if we want to check against SUCCESS or other code instead of handling error with a messagebox here
                Return CNCPipe.ReturnCode.ERROR_SEND_COMMAND
            End If
        Else
            ' warn that file not found
            MessageBox.Show("Error: Job File Not Found")
            ' return error code if we want to check against SUCCESS or other code instead of handling error with a messagebox here
            Return CNCPipe.ReturnCode.ERROR_SEND_COMMAND
        End If
    End Function

    ''' <summary>
    ''' Uses Skinning Events to emulate cycle start, warning this will start the job if CNC12 is on a screen that allows cycle start. 
    ''' Use with Caution. Operators should have to press cycle start to being machine motion.
    ''' </summary>
    ''' <returns>Returns a ReturnCode</returns>
    Function RunJob() As CentroidAPI.CNCPipe.ReturnCode
        ' reference to Job class
        Dim cncPLC As New CentroidAPI.CNCPipe.Plc(m_pipe)
        ' we are using SetSkinEventState to simulate a button press of cycle start by passing the state of 1 (pressed)
        If cncPLC.SetSkinEventState(50, 1) = CNCPipe.ReturnCode.SUCCESS Then
            'then we sleep for 50 miliseconds so the PLC has a chance to see the button press
            Threading.Thread.Sleep(50)
            ' then we return the result of setting the state to 0 (unpressed)
            Return cncPLC.SetSkinEventState(50, 0)
        End If
        Return ReturnCode.ERROR_UNKNOWN
    End Function

    ''' <summary>
    ''' Returns the Dro Machine Position for the axis index passed, 0-7
    ''' </summary>
    ''' <param name="axis">Specify the Axis index you want to get the Dro Machine Position of</param>
    ''' <returns>A string value of the Axis position</returns>
    Function GetDroReadout(ByVal axis As Integer) As String
        ' new dro class wrapping our pipe
        Dim cncDro As New CentroidAPI.CNCPipe.Dro(m_pipe)
        ' what coordinate type do we want to return
        Dim droType As CentroidAPI.CNCPipe.Dro.DroCoordinates = DroCoordinates.DRO_MACHINE
        ' placeholder tuple for the values we get from GetDro
        Dim droStrings As Tuple(Of String, String, String)() = Nothing
        ' get result
        If cncDro.GetDro(droType, droStrings) = ReturnCode.SUCCESS Then
            Return droStrings(axis).Item2
        End If
        ' return nothing if we fail
        Return Nothing
    End Function

    ''' <summary>
    ''' Gets the state of a given input
    ''' </summary>
    ''' <param name="iInput">The Index of the input, please see operator manuals for more details as outputs vary between system and expansion boards</param>
    ''' <returns>True if Input is On, False otherwise.</returns>
    Function IsInputOn(ByVal iInput As Integer) As Boolean
        ' use your own method of checking for a connection if not using the PipeManager class. 
        If ConnectedToCNC12() Then
            ' new plc class wrapping our pipe
            Dim cncPlc As New CentroidAPI.CNCPipe.Plc(m_pipe)
            ' placeholder for getting state
            Dim inputState As CentroidAPI.CNCPipe.Plc.IOState
            ' this call returns the input state for whatever iInput is
            If cncPlc.GetInputState(iInput, inputState) = ReturnCode.SUCCESS Then
                Select Case inputState
                    ' 0 is false, 1 is true
                    Case IOState.IO_LOGICAL_0
                        Return False
                    Case IOState.IO_LOGICAL_1
                        Return True
                End Select
            End If
        End If
        ' return nothing if we fail
        Return Nothing
    End Function

    ''' <summary>
    ''' Gets the state of a given output
    ''' </summary>
    ''' <param name="iOutput">The Index of the output, please see operator manuals for more details as outputs vary between system and expansion boards</param>
    ''' <returns>True if Output is On, False otherwise</returns>
    Function IsOutputOn(ByVal iOutput As Integer) As Boolean
        ' use your own method of checking for a connection if not using the PipeManager class. 
        If ConnectedToCNC12() Then
            ' new plc class wrapping our pipe
            Dim cncPlc As New CentroidAPI.CNCPipe.Plc(m_pipe)
            ' placeholder for getting state
            Dim outputState As CentroidAPI.CNCPipe.Plc.IOState
            ' checks returncode and puts state in outputState
            If cncPlc.GetOutputState(iOutput, outputState) = ReturnCode.SUCCESS Then
                Select Case outputState
                    ' 0 is false, 1 is true
                    Case IOState.IO_LOGICAL_0
                        Return False
                    Case IOState.IO_LOGICAL_1
                        Return True
                End Select
            End If
        End If
        ' return nothing if we fail
        Return Nothing
    End Function


End Class