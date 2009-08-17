<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.speedometer1 = New GeoFramework.Gps.Controls.Speedometer
        Me.satelliteViewer1 = New GeoFramework.Gps.Controls.SatelliteViewer
        Me.altimeter1 = New GeoFramework.Gps.Controls.Altimeter
        Me.startButton = New System.Windows.Forms.Button
        Me.compass1 = New GeoFramework.Gps.Controls.Compass
        Me.bearingTextBox = New System.Windows.Forms.TextBox
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.devicesListView = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.label5 = New System.Windows.Forms.Label
        Me.devicesTab = New System.Windows.Forms.TabPage
        Me.dataTab = New System.Windows.Forms.TabPage
        Me.altitudeTextBox = New System.Windows.Forms.TextBox
        Me.speedTextBox = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.dateTimeTextBox = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.positionTextBox = New System.Windows.Forms.TextBox
        Me.utcDateTimeTextBox = New System.Windows.Forms.TextBox
        Me.positionLabel = New System.Windows.Forms.Label
        Me.rawDataTab = New System.Windows.Forms.TabPage
        Me.sentenceListBox = New System.Windows.Forms.ListBox
        Me.satellitesTab = New System.Windows.Forms.TabPage
        Me.satellitesListView = New System.Windows.Forms.ListView
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.bluetoothCheckBox = New System.Windows.Forms.CheckBox
        Me.nmeaInterpreter1 = New GeoFramework.Gps.Nmea.NmeaInterpreter
        Me.serialCheckBox = New System.Windows.Forms.CheckBox
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.resumeButton = New System.Windows.Forms.Button
        Me.pauseButton = New System.Windows.Forms.Button
        Me.stopButton = New System.Windows.Forms.Button
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip
        Me.simulateCheckBox = New System.Windows.Forms.CheckBox
        Me.cancelDetectButton = New System.Windows.Forms.Button
        Me.detectButton = New System.Windows.Forms.Button
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.devicesTab.SuspendLayout()
        Me.dataTab.SuspendLayout()
        Me.rawDataTab.SuspendLayout()
        Me.satellitesTab.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'speedometer1
        '
        Me.speedometer1.AnalogFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.speedometer1.BackColor = System.Drawing.Color.Black
        Me.speedometer1.DigitalFont = New System.Drawing.Font("Arial", 8.0!)
        Me.speedometer1.IsCheckingTickIntersections = False
        Me.speedometer1.Location = New System.Drawing.Point(410, 189)
        Me.speedometer1.Name = "speedometer1"
        Me.speedometer1.Size = New System.Drawing.Size(128, 128)
        Me.speedometer1.TabIndex = 18
        Me.speedometer1.Text = "speedometer1"
        '
        'satelliteViewer1
        '
        Me.satelliteViewer1.Bearing = New GeoFramework.Azimuth(0)
        Me.satelliteViewer1.CardinalFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.satelliteViewer1.Location = New System.Drawing.Point(6, 186)
        Me.satelliteViewer1.Name = "satelliteViewer1"
        Me.satelliteViewer1.Size = New System.Drawing.Size(128, 128)
        Me.satelliteViewer1.TabIndex = 17
        Me.satelliteViewer1.Text = "satelliteViewer1"
        '
        'altimeter1
        '
        Me.altimeter1.AnalogFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.altimeter1.BackColor = System.Drawing.Color.Black
        Me.altimeter1.DigitalFont = New System.Drawing.Font("Arial", 8.0!)
        Me.altimeter1.DigitalReadoutOrientation = GeoFramework.Gps.Controls.AltimeterDigitalReadoutOrientation.Above
        Me.altimeter1.IsCheckingTickIntersections = False
        Me.altimeter1.Location = New System.Drawing.Point(274, 186)
        Me.altimeter1.Name = "altimeter1"
        Me.altimeter1.Size = New System.Drawing.Size(128, 128)
        Me.altimeter1.TabIndex = 14
        Me.altimeter1.Text = "altimeter1"
        '
        'startButton
        '
        Me.startButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startButton.Location = New System.Drawing.Point(578, 79)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(98, 23)
        Me.startButton.TabIndex = 15
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'compass1
        '
        Me.compass1.Bearing = New GeoFramework.Azimuth(0)
        Me.compass1.CardinalFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.compass1.DegreeFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.compass1.Location = New System.Drawing.Point(140, 186)
        Me.compass1.Name = "compass1"
        Me.compass1.Size = New System.Drawing.Size(128, 128)
        Me.compass1.TabIndex = 16
        Me.compass1.Text = "compass1"
        '
        'bearingTextBox
        '
        Me.bearingTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bearingTextBox.Location = New System.Drawing.Point(131, 156)
        Me.bearingTextBox.Name = "bearingTextBox"
        Me.bearingTextBox.Size = New System.Drawing.Size(407, 20)
        Me.bearingTextBox.TabIndex = 13
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.devicesListView)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.propertyGrid1)
        Me.splitContainer1.Size = New System.Drawing.Size(546, 448)
        Me.splitContainer1.SplitterDistance = 309
        Me.splitContainer1.TabIndex = 10
        '
        'devicesListView
        '
        Me.devicesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
        Me.devicesListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.devicesListView.LargeImageList = Me.imageList1
        Me.devicesListView.Location = New System.Drawing.Point(0, 0)
        Me.devicesListView.Name = "devicesListView"
        Me.devicesListView.Size = New System.Drawing.Size(309, 448)
        Me.devicesListView.SmallImageList = Me.imageList1
        Me.devicesListView.TabIndex = 8
        Me.devicesListView.UseCompatibleStateImageBehavior = False
        Me.devicesListView.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Device Name"
        Me.columnHeader1.Width = 148
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Status"
        Me.columnHeader2.Width = 641
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "Gps.png")
        Me.imageList1.Images.SetKeyName(1, "GpsRemove.png")
        Me.imageList1.Images.SetKeyName(2, "Configuration Tools.png")
        '
        'propertyGrid1
        '
        Me.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.propertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.propertyGrid1.Name = "propertyGrid1"
        Me.propertyGrid1.Size = New System.Drawing.Size(233, 448)
        Me.propertyGrid1.TabIndex = 9
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(20, 159)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(46, 13)
        Me.label5.TabIndex = 12
        Me.label5.Text = "Bearing:"
        '
        'devicesTab
        '
        Me.devicesTab.Controls.Add(Me.splitContainer1)
        Me.devicesTab.Location = New System.Drawing.Point(4, 22)
        Me.devicesTab.Name = "devicesTab"
        Me.devicesTab.Padding = New System.Windows.Forms.Padding(3)
        Me.devicesTab.Size = New System.Drawing.Size(552, 454)
        Me.devicesTab.TabIndex = 0
        Me.devicesTab.Text = "Devices"
        Me.devicesTab.UseVisualStyleBackColor = True
        '
        'dataTab
        '
        Me.dataTab.Controls.Add(Me.speedometer1)
        Me.dataTab.Controls.Add(Me.satelliteViewer1)
        Me.dataTab.Controls.Add(Me.compass1)
        Me.dataTab.Controls.Add(Me.altimeter1)
        Me.dataTab.Controls.Add(Me.bearingTextBox)
        Me.dataTab.Controls.Add(Me.label5)
        Me.dataTab.Controls.Add(Me.altitudeTextBox)
        Me.dataTab.Controls.Add(Me.speedTextBox)
        Me.dataTab.Controls.Add(Me.label3)
        Me.dataTab.Controls.Add(Me.label1)
        Me.dataTab.Controls.Add(Me.dateTimeTextBox)
        Me.dataTab.Controls.Add(Me.label4)
        Me.dataTab.Controls.Add(Me.label2)
        Me.dataTab.Controls.Add(Me.positionTextBox)
        Me.dataTab.Controls.Add(Me.utcDateTimeTextBox)
        Me.dataTab.Controls.Add(Me.positionLabel)
        Me.dataTab.Location = New System.Drawing.Point(4, 22)
        Me.dataTab.Name = "dataTab"
        Me.dataTab.Padding = New System.Windows.Forms.Padding(3)
        Me.dataTab.Size = New System.Drawing.Size(552, 454)
        Me.dataTab.TabIndex = 1
        Me.dataTab.Text = "Real-Time Data"
        Me.dataTab.UseVisualStyleBackColor = True
        '
        'altitudeTextBox
        '
        Me.altitudeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.altitudeTextBox.Location = New System.Drawing.Point(131, 102)
        Me.altitudeTextBox.Name = "altitudeTextBox"
        Me.altitudeTextBox.Size = New System.Drawing.Size(407, 20)
        Me.altitudeTextBox.TabIndex = 11
        '
        'speedTextBox
        '
        Me.speedTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.speedTextBox.Location = New System.Drawing.Point(131, 128)
        Me.speedTextBox.Name = "speedTextBox"
        Me.speedTextBox.Size = New System.Drawing.Size(407, 20)
        Me.speedTextBox.TabIndex = 7
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(20, 105)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(45, 13)
        Me.label3.TabIndex = 10
        Me.label3.Text = "Altitude:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(20, 19)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Date/Time:"
        '
        'dateTimeTextBox
        '
        Me.dateTimeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dateTimeTextBox.Location = New System.Drawing.Point(131, 16)
        Me.dateTimeTextBox.Name = "dateTimeTextBox"
        Me.dateTimeTextBox.Size = New System.Drawing.Size(407, 20)
        Me.dateTimeTextBox.TabIndex = 1
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(20, 131)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(41, 13)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Speed:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(20, 47)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(86, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "UTC Date/Time:"
        '
        'positionTextBox
        '
        Me.positionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.positionTextBox.Location = New System.Drawing.Point(131, 73)
        Me.positionTextBox.Name = "positionTextBox"
        Me.positionTextBox.Size = New System.Drawing.Size(407, 20)
        Me.positionTextBox.TabIndex = 5
        '
        'utcDateTimeTextBox
        '
        Me.utcDateTimeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.utcDateTimeTextBox.Location = New System.Drawing.Point(131, 44)
        Me.utcDateTimeTextBox.Name = "utcDateTimeTextBox"
        Me.utcDateTimeTextBox.Size = New System.Drawing.Size(407, 20)
        Me.utcDateTimeTextBox.TabIndex = 3
        '
        'positionLabel
        '
        Me.positionLabel.AutoSize = True
        Me.positionLabel.Location = New System.Drawing.Point(20, 76)
        Me.positionLabel.Name = "positionLabel"
        Me.positionLabel.Size = New System.Drawing.Size(47, 13)
        Me.positionLabel.TabIndex = 4
        Me.positionLabel.Text = "Position:"
        '
        'rawDataTab
        '
        Me.rawDataTab.Controls.Add(Me.sentenceListBox)
        Me.rawDataTab.Location = New System.Drawing.Point(4, 22)
        Me.rawDataTab.Name = "rawDataTab"
        Me.rawDataTab.Size = New System.Drawing.Size(552, 454)
        Me.rawDataTab.TabIndex = 2
        Me.rawDataTab.Text = "Raw Data"
        Me.rawDataTab.UseVisualStyleBackColor = True
        '
        'sentenceListBox
        '
        Me.sentenceListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sentenceListBox.FormattingEnabled = True
        Me.sentenceListBox.Location = New System.Drawing.Point(0, 0)
        Me.sentenceListBox.Name = "sentenceListBox"
        Me.sentenceListBox.Size = New System.Drawing.Size(552, 446)
        Me.sentenceListBox.TabIndex = 4
        '
        'satellitesTab
        '
        Me.satellitesTab.Controls.Add(Me.satellitesListView)
        Me.satellitesTab.Location = New System.Drawing.Point(4, 22)
        Me.satellitesTab.Name = "satellitesTab"
        Me.satellitesTab.Size = New System.Drawing.Size(552, 454)
        Me.satellitesTab.TabIndex = 3
        Me.satellitesTab.Text = "Satelllites"
        Me.satellitesTab.UseVisualStyleBackColor = True
        '
        'satellitesListView
        '
        Me.satellitesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader3, Me.columnHeader4, Me.columnHeader5, Me.columnHeader6, Me.columnHeader7})
        Me.satellitesListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.satellitesListView.Location = New System.Drawing.Point(0, 0)
        Me.satellitesListView.Name = "satellitesListView"
        Me.satellitesListView.Size = New System.Drawing.Size(552, 454)
        Me.satellitesListView.TabIndex = 0
        Me.satellitesListView.UseCompatibleStateImageBehavior = False
        Me.satellitesListView.View = System.Windows.Forms.View.Details
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Satellite ID"
        Me.columnHeader3.Width = 74
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Name"
        Me.columnHeader4.Width = 257
        '
        'columnHeader5
        '
        Me.columnHeader5.Text = "Azimuth"
        '
        'columnHeader6
        '
        Me.columnHeader6.Text = "Elevation"
        '
        'columnHeader7
        '
        Me.columnHeader7.Text = "Signal Strength"
        Me.columnHeader7.Width = 95
        '
        'bluetoothCheckBox
        '
        Me.bluetoothCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bluetoothCheckBox.AutoSize = True
        Me.bluetoothCheckBox.Checked = True
        Me.bluetoothCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.bluetoothCheckBox.Location = New System.Drawing.Point(585, 251)
        Me.bluetoothCheckBox.Name = "bluetoothCheckBox"
        Me.bluetoothCheckBox.Size = New System.Drawing.Size(99, 17)
        Me.bluetoothCheckBox.TabIndex = 24
        Me.bluetoothCheckBox.Text = "Allow Bluetooth"
        Me.bluetoothCheckBox.UseVisualStyleBackColor = True
        '
        'nmeaInterpreter1
        '
        Me.nmeaInterpreter1.IsFilterEnabled = False
        Me.nmeaInterpreter1.ThreadPriority = System.Threading.ThreadPriority.BelowNormal
        '
        'serialCheckBox
        '
        Me.serialCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialCheckBox.AutoSize = True
        Me.serialCheckBox.Checked = True
        Me.serialCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.serialCheckBox.Location = New System.Drawing.Point(585, 228)
        Me.serialCheckBox.Name = "serialCheckBox"
        Me.serialCheckBox.Size = New System.Drawing.Size(80, 17)
        Me.serialCheckBox.TabIndex = 23
        Me.serialCheckBox.Text = "Allow Serial"
        Me.serialCheckBox.UseVisualStyleBackColor = True
        '
        'tabControl1
        '
        Me.tabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl1.Controls.Add(Me.devicesTab)
        Me.tabControl1.Controls.Add(Me.dataTab)
        Me.tabControl1.Controls.Add(Me.rawDataTab)
        Me.tabControl1.Controls.Add(Me.satellitesTab)
        Me.tabControl1.Location = New System.Drawing.Point(12, 6)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(560, 480)
        Me.tabControl1.TabIndex = 22
        '
        'statusLabel
        '
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(29, 17)
        Me.statusLabel.Text = "Idle."
        '
        'resumeButton
        '
        Me.resumeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.resumeButton.Enabled = False
        Me.resumeButton.Location = New System.Drawing.Point(578, 180)
        Me.resumeButton.Name = "resumeButton"
        Me.resumeButton.Size = New System.Drawing.Size(98, 23)
        Me.resumeButton.TabIndex = 18
        Me.resumeButton.Text = "Resume"
        Me.resumeButton.UseVisualStyleBackColor = True
        '
        'pauseButton
        '
        Me.pauseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pauseButton.Enabled = False
        Me.pauseButton.Location = New System.Drawing.Point(578, 150)
        Me.pauseButton.Name = "pauseButton"
        Me.pauseButton.Size = New System.Drawing.Size(98, 23)
        Me.pauseButton.TabIndex = 17
        Me.pauseButton.Text = "Pause"
        Me.pauseButton.UseVisualStyleBackColor = True
        '
        'stopButton
        '
        Me.stopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stopButton.Enabled = False
        Me.stopButton.Location = New System.Drawing.Point(578, 108)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(98, 23)
        Me.stopButton.TabIndex = 16
        Me.stopButton.Text = "Stop"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 506)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(688, 22)
        Me.statusStrip1.TabIndex = 21
        Me.statusStrip1.Text = "statusStrip1"
        '
        'simulateCheckBox
        '
        Me.simulateCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.simulateCheckBox.AutoSize = True
        Me.simulateCheckBox.Location = New System.Drawing.Point(585, 274)
        Me.simulateCheckBox.Name = "simulateCheckBox"
        Me.simulateCheckBox.Size = New System.Drawing.Size(91, 17)
        Me.simulateCheckBox.TabIndex = 25
        Me.simulateCheckBox.Text = "Simulate GPS"
        Me.simulateCheckBox.UseVisualStyleBackColor = True
        '
        'cancelDetectButton
        '
        Me.cancelDetectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelDetectButton.Enabled = False
        Me.cancelDetectButton.Location = New System.Drawing.Point(578, 36)
        Me.cancelDetectButton.Name = "cancelDetectButton"
        Me.cancelDetectButton.Size = New System.Drawing.Size(98, 23)
        Me.cancelDetectButton.TabIndex = 20
        Me.cancelDetectButton.Text = "Cancel"
        Me.cancelDetectButton.UseVisualStyleBackColor = True
        '
        'detectButton
        '
        Me.detectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.detectButton.Location = New System.Drawing.Point(578, 7)
        Me.detectButton.Name = "detectButton"
        Me.detectButton.Size = New System.Drawing.Size(98, 23)
        Me.detectButton.TabIndex = 19
        Me.detectButton.Text = "Detect"
        Me.detectButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 528)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.bluetoothCheckBox)
        Me.Controls.Add(Me.serialCheckBox)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.resumeButton)
        Me.Controls.Add(Me.pauseButton)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.simulateCheckBox)
        Me.Controls.Add(Me.cancelDetectButton)
        Me.Controls.Add(Me.detectButton)
        Me.Name = "MainForm"
        Me.Text = "GPS.NET 3.0 Diagnostics"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.devicesTab.ResumeLayout(False)
        Me.dataTab.ResumeLayout(False)
        Me.dataTab.PerformLayout()
        Me.rawDataTab.ResumeLayout(False)
        Me.satellitesTab.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents speedometer1 As GeoFramework.Gps.Controls.Speedometer
    Private WithEvents satelliteViewer1 As GeoFramework.Gps.Controls.SatelliteViewer
    Private WithEvents altimeter1 As GeoFramework.Gps.Controls.Altimeter
    Private WithEvents startButton As System.Windows.Forms.Button
    Private WithEvents compass1 As GeoFramework.Gps.Controls.Compass
    Private WithEvents bearingTextBox As System.Windows.Forms.TextBox
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents devicesListView As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents propertyGrid1 As System.Windows.Forms.PropertyGrid
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents devicesTab As System.Windows.Forms.TabPage
    Private WithEvents dataTab As System.Windows.Forms.TabPage
    Private WithEvents altitudeTextBox As System.Windows.Forms.TextBox
    Private WithEvents speedTextBox As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents dateTimeTextBox As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents positionTextBox As System.Windows.Forms.TextBox
    Private WithEvents utcDateTimeTextBox As System.Windows.Forms.TextBox
    Private WithEvents positionLabel As System.Windows.Forms.Label
    Private WithEvents rawDataTab As System.Windows.Forms.TabPage
    Private WithEvents sentenceListBox As System.Windows.Forms.ListBox
    Private WithEvents satellitesTab As System.Windows.Forms.TabPage
    Private WithEvents satellitesListView As System.Windows.Forms.ListView
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader7 As System.Windows.Forms.ColumnHeader
    Private WithEvents bluetoothCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents nmeaInterpreter1 As GeoFramework.Gps.Nmea.NmeaInterpreter
    Private WithEvents serialCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents statusLabel As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents resumeButton As System.Windows.Forms.Button
    Private WithEvents pauseButton As System.Windows.Forms.Button
    Private WithEvents stopButton As System.Windows.Forms.Button
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents simulateCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents cancelDetectButton As System.Windows.Forms.Button
    Private WithEvents detectButton As System.Windows.Forms.Button

End Class
