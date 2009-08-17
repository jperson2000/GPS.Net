<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class DeviceForm
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
        Me.isGPSLabel = New System.Windows.Forms.Label
        Me.isGPSLabelTitle = New System.Windows.Forms.Label
        Me.reliabilityLabel = New System.Windows.Forms.Label
        Me.reliabilityLabelTitle = New System.Windows.Forms.Label
        Me.sentenceListBox = New System.Windows.Forms.ListBox
        Me.label9 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.imageList1 = New System.Windows.Forms.ImageList
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.lastConnectLabel = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.portLabel = New System.Windows.Forms.Label
        Me.portLabelTitle = New System.Windows.Forms.Label
        Me.typeLabel = New System.Windows.Forms.Label
        Me.typeLabelTitle = New System.Windows.Forms.Label
        Me.devicePicture = New System.Windows.Forms.PictureBox
        Me.titleLabel = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.pictureBoxSatellites = New System.Windows.Forms.PictureBox
        Me.pictureBoxPrecision = New System.Windows.Forms.PictureBox
        Me.pictureBoxSpeed = New System.Windows.Forms.PictureBox
        Me.pictureBoxBearing = New System.Windows.Forms.PictureBox
        Me.pictureBoxAltitude = New System.Windows.Forms.PictureBox
        Me.pictureBoxPosition = New System.Windows.Forms.PictureBox
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage3 = New System.Windows.Forms.TabPage
        Me.menuClose = New System.Windows.Forms.MenuItem
        Me.menuAnalyze = New System.Windows.Forms.MenuItem
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.tabPage1.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'isGPSLabel
        '
        Me.isGPSLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.isGPSLabel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.isGPSLabel.Location = New System.Drawing.Point(73, 197)
        Me.isGPSLabel.Name = "isGPSLabel"
        Me.isGPSLabel.Size = New System.Drawing.Size(152, 20)
        Me.isGPSLabel.Text = "..."
        '
        'isGPSLabelTitle
        '
        Me.isGPSLabelTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.isGPSLabelTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.isGPSLabelTitle.Location = New System.Drawing.Point(8, 197)
        Me.isGPSLabelTitle.Name = "isGPSLabelTitle"
        Me.isGPSLabelTitle.Size = New System.Drawing.Size(59, 20)
        Me.isGPSLabelTitle.Text = "GPS?"
        Me.isGPSLabelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'reliabilityLabel
        '
        Me.reliabilityLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reliabilityLabel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.reliabilityLabel.Location = New System.Drawing.Point(73, 217)
        Me.reliabilityLabel.Name = "reliabilityLabel"
        Me.reliabilityLabel.Size = New System.Drawing.Size(152, 20)
        Me.reliabilityLabel.Text = "..."
        '
        'reliabilityLabelTitle
        '
        Me.reliabilityLabelTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.reliabilityLabelTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.reliabilityLabelTitle.Location = New System.Drawing.Point(8, 217)
        Me.reliabilityLabelTitle.Name = "reliabilityLabelTitle"
        Me.reliabilityLabelTitle.Size = New System.Drawing.Size(59, 20)
        Me.reliabilityLabelTitle.Text = "Reliability:"
        Me.reliabilityLabelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'sentenceListBox
        '
        Me.sentenceListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sentenceListBox.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.sentenceListBox.Location = New System.Drawing.Point(8, 134)
        Me.sentenceListBox.Name = "sentenceListBox"
        Me.sentenceListBox.Size = New System.Drawing.Size(217, 41)
        Me.sentenceListBox.TabIndex = 22
        '
        'label9
        '
        Me.label9.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.label9.Location = New System.Drawing.Point(125, 78)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(65, 15)
        Me.label9.Text = "Satellites"
        '
        'label8
        '
        Me.label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label8.Location = New System.Drawing.Point(8, 113)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(182, 17)
        Me.label8.Text = "Supported NMEA Sentences"
        '
        'label7
        '
        Me.label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.label7.Location = New System.Drawing.Point(125, 56)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(65, 15)
        Me.label7.Text = "Precision"
        '
        'imageList1
        '
        Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
        '
        'label6
        '
        Me.label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.label6.Location = New System.Drawing.Point(125, 32)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(65, 15)
        Me.label6.Text = "Speed"
        '
        'label5
        '
        Me.label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.label5.Location = New System.Drawing.Point(30, 78)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(65, 15)
        Me.label5.Text = "Bearing"
        '
        'label3
        '
        Me.label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.label3.Location = New System.Drawing.Point(30, 55)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(65, 15)
        Me.label3.Text = "Altitude"
        '
        'label1
        '
        Me.label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.label1.Location = New System.Drawing.Point(30, 31)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 16)
        Me.label1.Text = "Position"
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.lastConnectLabel)
        Me.tabPage1.Controls.Add(Me.label2)
        Me.tabPage1.Controls.Add(Me.portLabel)
        Me.tabPage1.Controls.Add(Me.portLabelTitle)
        Me.tabPage1.Controls.Add(Me.typeLabel)
        Me.tabPage1.Controls.Add(Me.typeLabelTitle)
        Me.tabPage1.Controls.Add(Me.devicePicture)
        Me.tabPage1.Controls.Add(Me.titleLabel)
        Me.tabPage1.Location = New System.Drawing.Point(0, 0)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Size = New System.Drawing.Size(240, 245)
        Me.tabPage1.Text = "General"
        '
        'lastConnectLabel
        '
        Me.lastConnectLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lastConnectLabel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lastConnectLabel.Location = New System.Drawing.Point(73, 91)
        Me.lastConnectLabel.Name = "lastConnectLabel"
        Me.lastConnectLabel.Size = New System.Drawing.Size(124, 20)
        Me.lastConnectLabel.Text = "..."
        '
        'label2
        '
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.label2.Location = New System.Drawing.Point(3, 91)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 20)
        Me.label2.Text = "Last Used:"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'portLabel
        '
        Me.portLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.portLabel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.portLabel.Location = New System.Drawing.Point(73, 71)
        Me.portLabel.Name = "portLabel"
        Me.portLabel.Size = New System.Drawing.Size(160, 20)
        Me.portLabel.Text = "..."
        '
        'portLabelTitle
        '
        Me.portLabelTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.portLabelTitle.Location = New System.Drawing.Point(8, 71)
        Me.portLabelTitle.Name = "portLabelTitle"
        Me.portLabelTitle.Size = New System.Drawing.Size(59, 20)
        Me.portLabelTitle.Text = "Port:"
        Me.portLabelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'typeLabel
        '
        Me.typeLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.typeLabel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.typeLabel.Location = New System.Drawing.Point(73, 51)
        Me.typeLabel.Name = "typeLabel"
        Me.typeLabel.Size = New System.Drawing.Size(160, 20)
        Me.typeLabel.Text = "..."
        '
        'typeLabelTitle
        '
        Me.typeLabelTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.typeLabelTitle.Location = New System.Drawing.Point(8, 51)
        Me.typeLabelTitle.Name = "typeLabelTitle"
        Me.typeLabelTitle.Size = New System.Drawing.Size(59, 20)
        Me.typeLabelTitle.Text = "Type:"
        Me.typeLabelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'devicePicture
        '
        Me.devicePicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.devicePicture.Location = New System.Drawing.Point(112, 117)
        Me.devicePicture.Name = "devicePicture"
        Me.devicePicture.Size = New System.Drawing.Size(128, 128)
        Me.devicePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'titleLabel
        '
        Me.titleLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.titleLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.titleLabel.Location = New System.Drawing.Point(5, 5)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(234, 46)
        Me.titleLabel.Text = "..."
        '
        'label4
        '
        Me.label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.label4.Location = New System.Drawing.Point(5, 5)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(226, 22)
        Me.label4.Text = "Features"
        '
        'pictureBoxSatellites
        '
        Me.pictureBoxSatellites.Location = New System.Drawing.Point(102, 77)
        Me.pictureBoxSatellites.Name = "pictureBoxSatellites"
        Me.pictureBoxSatellites.Size = New System.Drawing.Size(16, 16)
        '
        'pictureBoxPrecision
        '
        Me.pictureBoxPrecision.Location = New System.Drawing.Point(103, 54)
        Me.pictureBoxPrecision.Name = "pictureBoxPrecision"
        Me.pictureBoxPrecision.Size = New System.Drawing.Size(16, 16)
        '
        'pictureBoxSpeed
        '
        Me.pictureBoxSpeed.Location = New System.Drawing.Point(103, 30)
        Me.pictureBoxSpeed.Name = "pictureBoxSpeed"
        Me.pictureBoxSpeed.Size = New System.Drawing.Size(16, 16)
        '
        'pictureBoxBearing
        '
        Me.pictureBoxBearing.Location = New System.Drawing.Point(7, 77)
        Me.pictureBoxBearing.Name = "pictureBoxBearing"
        Me.pictureBoxBearing.Size = New System.Drawing.Size(16, 16)
        '
        'pictureBoxAltitude
        '
        Me.pictureBoxAltitude.Location = New System.Drawing.Point(7, 54)
        Me.pictureBoxAltitude.Name = "pictureBoxAltitude"
        Me.pictureBoxAltitude.Size = New System.Drawing.Size(16, 16)
        '
        'pictureBoxPosition
        '
        Me.pictureBoxPosition.Location = New System.Drawing.Point(7, 30)
        Me.pictureBoxPosition.Name = "pictureBoxPosition"
        Me.pictureBoxPosition.Size = New System.Drawing.Size(16, 16)
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(240, 268)
        Me.tabControl1.TabIndex = 5
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.isGPSLabel)
        Me.tabPage3.Controls.Add(Me.isGPSLabelTitle)
        Me.tabPage3.Controls.Add(Me.reliabilityLabel)
        Me.tabPage3.Controls.Add(Me.reliabilityLabelTitle)
        Me.tabPage3.Controls.Add(Me.sentenceListBox)
        Me.tabPage3.Controls.Add(Me.label9)
        Me.tabPage3.Controls.Add(Me.label8)
        Me.tabPage3.Controls.Add(Me.label7)
        Me.tabPage3.Controls.Add(Me.label6)
        Me.tabPage3.Controls.Add(Me.label5)
        Me.tabPage3.Controls.Add(Me.label3)
        Me.tabPage3.Controls.Add(Me.label1)
        Me.tabPage3.Controls.Add(Me.label4)
        Me.tabPage3.Controls.Add(Me.pictureBoxSatellites)
        Me.tabPage3.Controls.Add(Me.pictureBoxPrecision)
        Me.tabPage3.Controls.Add(Me.pictureBoxSpeed)
        Me.tabPage3.Controls.Add(Me.pictureBoxBearing)
        Me.tabPage3.Controls.Add(Me.pictureBoxAltitude)
        Me.tabPage3.Controls.Add(Me.pictureBoxPosition)
        Me.tabPage3.Location = New System.Drawing.Point(0, 0)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(232, 242)
        Me.tabPage3.Text = "Supported Features"
        '
        'menuClose
        '
        Me.menuClose.Text = "Close"
        '
        'menuAnalyze
        '
        Me.menuAnalyze.Text = "Analyze"
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.menuAnalyze)
        Me.mainMenu1.MenuItems.Add(Me.menuClose)
        '
        'DeviceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.tabControl1)
        Me.Menu = Me.mainMenu1
        Me.Name = "DeviceForm"
        Me.Text = "DeviceForm"
        Me.tabPage1.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents isGPSLabel As System.Windows.Forms.Label
    Private WithEvents isGPSLabelTitle As System.Windows.Forms.Label
    Private WithEvents reliabilityLabel As System.Windows.Forms.Label
    Private WithEvents reliabilityLabelTitle As System.Windows.Forms.Label
    Private WithEvents sentenceListBox As System.Windows.Forms.ListBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents lastConnectLabel As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents portLabel As System.Windows.Forms.Label
    Private WithEvents portLabelTitle As System.Windows.Forms.Label
    Private WithEvents typeLabel As System.Windows.Forms.Label
    Private WithEvents typeLabelTitle As System.Windows.Forms.Label
    Private WithEvents devicePicture As System.Windows.Forms.PictureBox
    Private WithEvents titleLabel As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents pictureBoxSatellites As System.Windows.Forms.PictureBox
    Private WithEvents pictureBoxPrecision As System.Windows.Forms.PictureBox
    Private WithEvents pictureBoxSpeed As System.Windows.Forms.PictureBox
    Private WithEvents pictureBoxBearing As System.Windows.Forms.PictureBox
    Private WithEvents pictureBoxAltitude As System.Windows.Forms.PictureBox
    Private WithEvents pictureBoxPosition As System.Windows.Forms.PictureBox
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents menuClose As System.Windows.Forms.MenuItem
    Private WithEvents menuAnalyze As System.Windows.Forms.MenuItem
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
End Class
