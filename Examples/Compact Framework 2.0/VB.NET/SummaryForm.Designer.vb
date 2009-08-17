<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SummaryForm
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
        Me.imageList1 = New System.Windows.Forms.ImageList
        Me.imageList2 = New System.Windows.Forms.ImageList
        Me.label2 = New System.Windows.Forms.Label
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.menuRestart = New System.Windows.Forms.MenuItem
        Me.menuFinish = New System.Windows.Forms.MenuItem
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.gpsListView = New System.Windows.Forms.ListView
        Me.suggestionListView = New System.Windows.Forms.ListView
        Me.descriptionLabel = New System.Windows.Forms.Label
        Me.titleLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
        '
        'imageList2
        '
        Me.imageList2.ImageSize = New System.Drawing.Size(32, 32)
        '
        'label2
        '
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label2.Location = New System.Drawing.Point(4, 74)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(150, 14)
        Me.label2.Text = "Confirmed GPS Devices"
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.menuRestart)
        Me.mainMenu1.MenuItems.Add(Me.menuFinish)
        '
        'menuRestart
        '
        Me.menuRestart.Text = "Scan Again"
        '
        'menuFinish
        '
        Me.menuFinish.Text = "&Finish"
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Suggestions"
        Me.columnHeader1.Width = 900
        '
        'gpsListView
        '
        Me.gpsListView.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.gpsListView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpsListView.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.gpsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.gpsListView.LargeImageList = Me.imageList2
        Me.gpsListView.Location = New System.Drawing.Point(4, 91)
        Me.gpsListView.Name = "gpsListView"
        Me.gpsListView.Size = New System.Drawing.Size(232, 69)
        Me.gpsListView.SmallImageList = Me.imageList1
        Me.gpsListView.TabIndex = 12
        '
        'suggestionListView
        '
        Me.suggestionListView.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.suggestionListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.suggestionListView.Columns.Add(Me.columnHeader1)
        Me.suggestionListView.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.suggestionListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.suggestionListView.LargeImageList = Me.imageList2
        Me.suggestionListView.Location = New System.Drawing.Point(4, 163)
        Me.suggestionListView.Name = "suggestionListView"
        Me.suggestionListView.Size = New System.Drawing.Size(232, 101)
        Me.suggestionListView.SmallImageList = Me.imageList1
        Me.suggestionListView.TabIndex = 11
        Me.suggestionListView.View = System.Windows.Forms.View.Details
        '
        'descriptionLabel
        '
        Me.descriptionLabel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.descriptionLabel.Location = New System.Drawing.Point(4, 31)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(232, 43)
        Me.descriptionLabel.Text = "..."
        '
        'titleLabel
        '
        Me.titleLabel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.titleLabel.Location = New System.Drawing.Point(4, 4)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(232, 23)
        Me.titleLabel.Text = "..."
        '
        'SummaryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.gpsListView)
        Me.Controls.Add(Me.suggestionListView)
        Me.Controls.Add(Me.descriptionLabel)
        Me.Controls.Add(Me.titleLabel)
        Me.Menu = Me.mainMenu1
        Me.Name = "SummaryForm"
        Me.Text = "GPS Devices"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents imageList2 As System.Windows.Forms.ImageList
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Private WithEvents menuRestart As System.Windows.Forms.MenuItem
    Private WithEvents menuFinish As System.Windows.Forms.MenuItem
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents gpsListView As System.Windows.Forms.ListView
    Private WithEvents suggestionListView As System.Windows.Forms.ListView
    Private WithEvents descriptionLabel As System.Windows.Forms.Label
    Private WithEvents titleLabel As System.Windows.Forms.Label
End Class
