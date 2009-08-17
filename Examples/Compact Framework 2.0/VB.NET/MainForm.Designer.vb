<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.menuCancel = New System.Windows.Forms.MenuItem
        Me.menuNext = New System.Windows.Forms.MenuItem
        Me.titleLabel = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.menuCancel)
        Me.mainMenu1.MenuItems.Add(Me.menuNext)
        '
        'menuCancel
        '
        Me.menuCancel.Text = "Cancel"
        '
        'menuNext
        '
        Me.menuNext.Text = "&Next"
        '
        'titleLabel
        '
        Me.titleLabel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.titleLabel.Location = New System.Drawing.Point(4, 4)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(154, 23)
        Me.titleLabel.Text = "GPS Diagnostics"
        '
        'label1
        '
        Me.label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.label1.Location = New System.Drawing.Point(5, 27)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(231, 50)
        Me.label1.Text = "This utility can search for GPS devices and help you troubleshoot connectivity is" & _
            "sues.  To continue, tap ""Next."""
        '
        'pictureBox1
        '
        Me.pictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictureBox1.Location = New System.Drawing.Point(108, 136)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "GPS Diagnostics"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Private WithEvents menuCancel As System.Windows.Forms.MenuItem
    Private WithEvents menuNext As System.Windows.Forms.MenuItem
    Private WithEvents titleLabel As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox

End Class
