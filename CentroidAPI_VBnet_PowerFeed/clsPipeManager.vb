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
End Class
