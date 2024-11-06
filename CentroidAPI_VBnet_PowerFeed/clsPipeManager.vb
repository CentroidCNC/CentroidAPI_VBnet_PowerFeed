'****************************************************************************
'
' Title:        clsPipeManager.vb
' Author(s):    Jacob Holes
' Start Date:   11-04-24
' Purpose: Class than manages a single pipe connection so we don't exceed the CNC12 pipe limit by reconnecting 
'
' Environment/platform  ( Windows 10/11, Visual Basic .net)
'
' Last Update:  11-05-24 - JDH - Added header and comments
' Prior Update: 11-04-24 - JDH - Created clsPipeManager
'****************************************************************************
Imports System.IO

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
    ''' Checks the connection status of the CNC12 pipe.
    ''' </summary>
    ''' <returns>True if connected to CNC12 Pipe; False otherwise.</returns>
    Public Function ConnectedToCNC12() As Boolean
        ' IMPORTANT: On Error Resume Next tells the compiler to ignore errors, be careful as it may cause unintended side effects
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

End Class
