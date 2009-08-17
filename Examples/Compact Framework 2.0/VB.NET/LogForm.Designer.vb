<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class LogForm
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
        Me.logBody = New System.Windows.Forms.TextBox
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.menuSendLog = New System.Windows.Forms.MenuItem
        Me.menuClose = New System.Windows.Forms.MenuItem
        Me.titleLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'logBody
        '
        Me.logBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.logBody.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.logBody.Location = New System.Drawing.Point(0, 52)
        Me.logBody.Multiline = True
        Me.logBody.Name = "logBody"
        Me.logBody.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.logBody.Size = New System.Drawing.Size(240, 214)
        Me.logBody.TabIndex = 2
        Me.logBody.WordWrap = False
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.menuSendLog)
        Me.mainMenu1.MenuItems.Add(Me.menuClose)
        '
        'menuSendLog
        '
        Me.menuSendLog.Text = "Send Log"
        '
        'menuClose
        '
        Me.menuClose.Text = "Close"
        '
        'titleLabel
        '
        Me.titleLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.titleLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.titleLabel.Location = New System.Drawing.Point(5, 3)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(234, 46)
        Me.titleLabel.Text = "..."
        '
        'LogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.logBody)
        Me.Controls.Add(Me.titleLabel)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "LogForm"
        Me.Text = "View Log"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents logBody As System.Windows.Forms.TextBox
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Private WithEvents menuSendLog As System.Windows.Forms.MenuItem
    Private WithEvents menuClose As System.Windows.Forms.MenuItem
    Private WithEvents titleLabel As System.Windows.Forms.Label
End Class
