
Public Class Program

    <MTAThread()> _
    Public Shared Sub Main()

        ' Run the application
        Application.Run(New MainForm())

    End Sub

End Class

' The GPS.NET device detection process is multithreaded.  As a result, we must
' use the Invoke and BeginInvoke methods to ensure that any updates to the form
' occur on the form's own thread.  This delegate is used by such methods.
Public Delegate Sub MethodInvoker(ByVal sender As Object, ByVal e As EventArgs)

Public Delegate Sub Action(Of T, U)(ByVal a As T, ByVal b As U)