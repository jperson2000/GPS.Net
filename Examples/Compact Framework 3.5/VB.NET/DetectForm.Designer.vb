<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class DetectForm
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
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.logBox = New System.Windows.Forms.ListBox
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.devicesListView = New System.Windows.Forms.ListView
        Me.imageList1 = New System.Windows.Forms.ImageList
        Me.description = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.menuCancel)
        Me.mainMenu1.MenuItems.Add(Me.menuNext)
        '
        'menuCancel
        '
        Me.menuCancel.Enabled = False
        Me.menuCancel.Text = "&Cancel"
        '
        'menuNext
        '
        Me.menuNext.Enabled = False
        Me.menuNext.Text = "&Next"
        '
        'titleLabel
        '
        Me.titleLabel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.titleLabel.Location = New System.Drawing.Point(5, 3)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(234, 23)
        Me.titleLabel.Text = "Search In Progress..."
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Status"
        Me.columnHeader3.Width = 349
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Type"
        Me.columnHeader2.Width = 137
        '
        'logBox
        '
        Me.logBox.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.logBox.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.logBox.Location = New System.Drawing.Point(0, 188)
        Me.logBox.Name = "logBox"
        Me.logBox.Size = New System.Drawing.Size(240, 80)
        Me.logBox.TabIndex = 6
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Device"
        Me.columnHeader1.Width = 127
        '
        'devicesListView
        '
        Me.devicesListView.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.devicesListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.devicesListView.Columns.Add(Me.columnHeader1)
        Me.devicesListView.Columns.Add(Me.columnHeader2)
        Me.devicesListView.Columns.Add(Me.columnHeader3)
        Me.devicesListView.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.devicesListView.FullRowSelect = True
        Me.devicesListView.LargeImageList = Me.imageList1
        Me.devicesListView.Location = New System.Drawing.Point(0, 63)
        Me.devicesListView.Name = "devicesListView"
        Me.devicesListView.Size = New System.Drawing.Size(240, 123)
        Me.devicesListView.SmallImageList = Me.imageList1
        Me.devicesListView.TabIndex = 5
        Me.devicesListView.View = System.Windows.Forms.View.Details
        '
        'imageList1
        '
        Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
        '
        'description
        '
        Me.description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.description.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.description.Location = New System.Drawing.Point(4, 30)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(233, 27)
        Me.description.Text = "Please wait a moment while devices are tested..."
        '
        'DetectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.logBox)
        Me.Controls.Add(Me.devicesListView)
        Me.Controls.Add(Me.description)
        Me.Menu = Me.mainMenu1
        Me.Name = "DetectForm"
        Me.Text = "GPS Device Search"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Private WithEvents menuCancel As System.Windows.Forms.MenuItem
    Private WithEvents menuNext As System.Windows.Forms.MenuItem
    Private WithEvents titleLabel As System.Windows.Forms.Label
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents logBox As System.Windows.Forms.ListBox
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents devicesListView As System.Windows.Forms.ListView
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents description As System.Windows.Forms.Label
End Class
