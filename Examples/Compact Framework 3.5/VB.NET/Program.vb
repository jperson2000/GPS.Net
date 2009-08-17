
Public Class Program

#Region "  Frequenly-Used Images  "

    ' This utility uses the same graphics across multiple forms.  To minimize the size
    ' of the executable, these images are reused.
    Public Shared Gps As Image = My.Resources.Gps
    Public Shared WarningShield = My.Resources.WarningShield
    Public Shared Problem As Image = My.Resources.Problem
    Public Shared Ok As Image = My.Resources.Ok
    Public Shared Question As Image = My.Resources.Question
    Public Shared Computer As Image = My.Resources.Computer

#End Region

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

