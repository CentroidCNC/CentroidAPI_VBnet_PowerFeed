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
End Class
