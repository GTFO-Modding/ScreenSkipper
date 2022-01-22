Imports BepInEx.Logging
''' <summary>
''' Logger Instance of the ScreenSkipper mod.
''' </summary>
NotInheritable Class VbLogger

    Public Shared Logger As ManualLogSource
    Public Shared DebugMessagesActive As Boolean


    ''' <summary>
    ''' Prevent Instantiation for NotInheritable class.
    ''' </summary>
    Private Sub New()
    End Sub

    Public Shared Sub Debug(message As String)
        If DebugMessagesActive Then
            Logger.LogDebug(message)
        End If
    End Sub

    Public Shared Sub Warn(message As String)
        If DebugMessagesActive Then
            Logger.LogWarning(message)
        End If
    End Sub

End Class
