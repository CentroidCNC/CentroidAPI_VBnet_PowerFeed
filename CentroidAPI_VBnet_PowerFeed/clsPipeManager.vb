Public Class clsPipeManager
    Private m_pipe As CNCPipe

    Sub New()
        m_pipe = New CNCPipe
    End Sub

    Public Property Pipe As CNCPipe
        Get
            Return m_pipe
        End Get
        Set(value As CNCPipe)
            m_pipe = value
        End Set
    End Property
End Class
