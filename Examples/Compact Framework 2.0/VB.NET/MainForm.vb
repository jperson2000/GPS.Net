Public Class MainForm

    ' This form serves as a splash screen for the diagnostics utility.  The user
    ' can click "Next" to launch the detection form (DetectForm), or "Cancel"
    ' to exit the utility.

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Set the splash screen to use the GPS icon
        pictureBox1.Image = My.Resources.Gps
    End Sub

    Private Sub menuNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuNext.Click

        ' Launch the device detection form
        Dim Form As New DetectForm
        Form.Show()

    End Sub

    Private Sub menuCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuCancel.Click

        ' Exit the utility
        Application.Exit()

    End Sub


End Class
