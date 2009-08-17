Imports GeoFramework
Imports GeoFramework.Gps
Imports GeoFramework.Gps.IO

' This form takes all of the information we have about GPS devices and problems and
' lists a series of suggestions.  The suggestions confirm that features are working properly,
' and give clear in-English information if there are problems.  Furthermore, tapping a
' suggestion will make an attempt to fix the problem if at all possible.
' 
' By making agressive attempts to fix errors, technical support can be reduced for all parties.

Public Class SummaryForm

    ' The "preferred" serial device is the serial GPS device with the highest reliability.
    ' This device is often used first by GPS.NET, and also is commonly used as the source
    ' device for the GPS Intermediate Driver if it is supported.
    Dim preferredSerialDevice As SerialDevice = Nothing

    ' The GPS Intermediate Driver (GPSID) is a multiplexer which allows many applications to
    ' share the same GPS device.  This only works if all applications connect to the GPSID
    ' "Program Port" (usually GPD1:) instead of the "Hardware Part" for the actual GPS device.
    ' Some older mobile devices do not support the GPSID, in which case this variable will be Nothing.
    Dim gpsid As GpsIntermediateDriver = GpsIntermediateDriver.Current

    ' Bluetooth GPS devices can be configured to use a "virtual serial port" in order to make them
    ' available for third-party GPS applications.  This variable stores the preferred virtual serial 
    ' device if one is detected.
    Dim preferredVirtualSerialDevice As SerialDevice = Nothing

    ' Statistics are used to get a high-level opinion of how well things are working
    Dim okCount As Integer = 0
    Dim warningCount As Integer = 0
    Dim errorCount As Integer = 0

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add images to our image lists
        imageList1.Images.Add(My.Resources.Gps)
        imageList1.Images.Add(My.Resources.ErrorImage)
        imageList1.Images.Add(My.Resources.WarningImage)
        imageList1.Images.Add(My.Resources.Ok)
        imageList2.Images.Add(My.Resources.Gps)

        ' Get the current GPS Intermediate Driver
        Dim gpsid As GpsIntermediateDriver = GpsIntermediateDriver.Current

        ' Was any device detected?
        If Devices.IsDeviceDetected Then

            ' Yes.  Add all confirmed devices to a listview
            Dim device As Device
            For Each device In Devices.GpsDevices

                AddDevice(device)

                ' Is this the GPS Intermediate Driver?  We only want plain serial devices, so skip it
                If device.GetType() Is GetType(GpsIntermediateDriver) Then
                    Continue For
                End If

                ' The "preferred" device is serial, but not the GPSID
                If device.GetType() Is GetType(SerialDevice) Then
                    preferredSerialDevice = CType(device, SerialDevice)
                End If

            Next device

            ' If we have more than two GPS devices, use a smaller ListView view
            If Devices.GpsDevices.Count > 2 Then
                gpsListView.View = View.SmallIcon
            End If

            ' A GPS device was found.  Most third-party applications
            ' require a serial connection.  Is one available for them?

            If preferredSerialDevice Is Nothing AndAlso (gpsid Is Nothing OrElse Not gpsid.IsGpsDevice) Then

                ' No.  GPS.NET can still work with Bluetooth, but for most end-users
                ' this can still be a problem.  They'll appreciate help with solving it.
                AddWarning("Third-party GPS programs may have trouble connecting.", "ConfigureGpsid")

            End If

        Else

            ' Show that no devices were found
            AddError("No GPS devices could be found.", "NoDevices")

        End If

        ' Let's make a summary of good things and bad things.
        If Not gpsid Is Nothing Then

            ' Was the GPS Intermediate Driver detected?
            If gpsid.IsGpsDevice Then

                ' Make an item confirming the GPSID
                AddMessage("Use the port """ + gpsid.Port + """ whenever possible for GPS programs.", "UseGpsidPort")

            Else

                ' The GPSID may need to be configured properly.  Let's look at its settings
                If Not gpsid.HardwarePort Is Nothing Then

                    ' If there's a serial device but the GPSID isn't using it, the GPSID should be reconfigured
                    If Not preferredSerialDevice Is Nothing AndAlso gpsid.HardwarePort.Port.Equals(preferredSerialDevice.Port) Then

                        AddMessage("The GPS Intermediate Driver was reconfigured to use " + preferredSerialDevice.Name + " on " + preferredSerialDevice.Port + " at " + preferredSerialDevice.BaudRate.ToString() + " baud.", "GpsidReconfigured")
                        AddMessage("Use " + preferredSerialDevice.Port + " at " + preferredSerialDevice.BaudRate.ToString() + " baud for third-party GPS programs.", "ThirdPartyGpsPort")

                    Else

                        AddWarning("The GPS Intermediate Driver is not working on " + gpsid.HardwarePort.Port + " at " + gpsid.HardwarePort.BaudRate.ToString() + " baud.", "GpsidIncorrectPort")

                        ' The current hardware port isn't working, so let's suggest a working device
                        If Not preferredSerialDevice Is Nothing Then

                            AddWarning("Change the GPS Intermediate Driver to use " + preferredSerialDevice.Port + " at " + preferredSerialDevice.BaudRate.ToString() + " baud.", "GpsidFixHardwarePort")

                        Else

                            ' Do we have a Bluetooth device with a virtual port?
                            Dim isVirtualPortFound As Boolean = False
                            Dim bluetooth As BluetoothDevice
                            For Each bluetooth In Devices.BluetoothDevices

                                ' Is this a Bluetooth GPS device?
                                If bluetooth.IsGpsDevice Then

                                    ' Yes.  Does it also have a virtual serial port bound to it?
                                    If Not bluetooth.VirtualSerialPort Is Nothing Then

                                        ' Yes.
                                        preferredVirtualSerialDevice = bluetooth.VirtualSerialPort
                                        isVirtualPortFound = True

                                        ' The GPSID could be configured to use this port
                                        AddWarning("Change the GPS Intermediate Driver to use the " + bluetooth.Name + " GPS device on " _
                                                + bluetooth.VirtualSerialPort.Port + " at " + bluetooth.VirtualSerialPort.BaudRate.ToString() + " baud.", _
                                                "GpsidUseVirtualBluetoothPort")
                                        Exit For
                                    End If
                                End If
                            Next

                            If Not isVirtualPortFound Then

                                ' Do we have a BT device we could pair with?
                                Dim isBluetoothPossible As Boolean = False
                                Dim device As BluetoothDevice
                                For Each device In Devices.BluetoothDevices

                                    If device.IsGpsDevice Then

                                        ' Suggest that they create a virtual serial port for a Bluetooth device
                                        isBluetoothPossible = True
                                        AddWarning("Use the Bluetooth Manager to create a virtual serial port for the " + device.Name + ".", "BluetoothCreateVirtualPort")

                                    End If

                                Next

                                If Not isBluetoothPossible Then

                                    AddError("No devices are available for the GPS Intermediate Driver.", "GpsidNoDevice")

                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else

            ' The GPSID is not supported on this machine
            AddWarning("The GPS Intermediate Driver is not supported.", "GpsidNotSupported")

        End If

        ' Is Bluetooth supported?
        If Not Devices.IsBluetoothSupported Then

            ' Bluetooth is not supported
            AddWarning("Microsoft® Bluetooth is not supported on this device.", "BluetoothNotSupported")

        Else

            ' Is Bluetooth on?
            If Devices.IsBluetoothEnabled Then

                ' Bluetooth is on
                AddMessage("Bluetooth is on and working properly.", "BluetoothOk")

            Else

                ' Bluetooth is off
                AddWarning("Turn Bluetooth on.", "TurnBluetoothOn")

            End If
        End If

        ' Let's look for devices which aren't detected, but WERE detected at least once before
        If Devices.IsBluetoothSupported AndAlso Devices.IsBluetoothEnabled Then

            Dim device As BluetoothDevice
            For Each device In Devices.BluetoothDevices

                ' Is the success count above zero?
                If Not device.SuccessfulDetectionCount = 0 AndAlso Not device.IsGpsDevice Then

                    ' Here's a device which worked before, but not now
                    AddWarning("Turn the " + device.Name + " off and back on again.", "TurnDeviceOn")

                End If

            Next

        End If

        ' Do we have a serial GPS device to use?
        If Not preferredSerialDevice Is Nothing Then

            ' Yes.  The port is different from the GPSID, so help the user know they have an alternative they can try.
            If Not gpsid Is Nothing AndAlso gpsid.IsGpsDevice AndAlso Not gpsid.Port.Equals(preferredSerialDevice.Port) Then

                AddMessage("Though less preferred, you can also use " + preferredSerialDevice.Port + " at " + preferredSerialDevice.BaudRate.ToString() + " baud for third-party GPS programs.", _
                        "AlternativeSerialPort")

            End If
        End If

        ' Were there any errors?
        If errorCount > 0 Then

            ' Yes.  How many devices were found?
            If Devices.GpsDevices.Count = 0 Then

                ' None.
                titleLabel.Text = "Errors Were Found"
                descriptionLabel.Text = "Some problems were found.  Click on an error below to try and fix it."

            Else

                ' A device was found, so they can at least use GPS
                titleLabel.Text = "Some Problems Were Found"
                descriptionLabel.Text = "GPS is responding, but some problems were found, too.  Check out the suggestions below."

            End If

            ' Were any warnings encountered?
        ElseIf warningCount > 0 Then

            ' Yes.  
            titleLabel.Text = "Minor Problems Were Found"
            descriptionLabel.Text = "GPS is responding, but some things could be improved.  Check out the suggestions below."

        Else

            ' No errors or warnings.  That's great!
            titleLabel.Text = "You Are Awesome"
            descriptionLabel.Text = "GPS is working properly and no problems were found."

        End If

    End Sub

    Private Sub gpsListView_ItemActivate(ByVal sender As Object, ByVal e As EventArgs) Handles gpsListView.ItemActivate

        ' Get the device
        Dim selectedItem As ListViewItem = gpsListView.Items(gpsListView.SelectedIndices(0))
        Dim selectedDevice As Device = CType(selectedItem.Tag, Device)

        ' And show a new form
        Dim Form As New DeviceForm
        Form.CurrentDevice = selectedDevice
        Form.Show()

    End Sub

    Private Sub menuFinish_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuFinish.Click
        Application.Exit()
    End Sub

    Private Sub menuRestart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuRestart.Click
        ' Restart the detection process
        Dim Form As New DetectForm
        Form.Show()
        Close()
    End Sub

    Private Sub suggestionListView_ItemActivate(ByVal sender As Object, ByVal e As EventArgs) Handles suggestionListView.ItemActivate

        ' What kind of suggestion is this?
        Dim item As ListViewItem = suggestionListView.Items(suggestionListView.SelectedIndices(0))
        Dim command As String = Convert.ToString(item.Tag)

        Select command

            Case "ConfigureGpsid"
                If Devices.IsBluetoothSupported Then
                    MessageBox.Show("No serial devices could be found.  You can ""pair"" a Bluetooth GPS device to give it a serial port for your software to use.", "Use a Bluetooth Device", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("No serial devices could be found.  If you have a GPS device to plug in to your PDA, plug it in now and try the scan again.", "Plug In a GPS Device", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If

            Case "NoDevices"
                MessageBox.Show("No GPS devices were found.  They may be turned off, out of range, or ""stuck open"".  If the device is on but shows a constant light, turn the device off then back on again.", "No Devices Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Case "UseGpsidPort"
                MessageBox.Show("Using the GPS Intermediate Driver is preferred because it will share your GPS device with multiple applications.", "Share Your GPS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

            Case "WindowsMobileFirmware"
                MessageBox.Show("The .NET Compact Framework is unable to connect to the GPS Intermediate Driver.  A firmware update for your device may resolve this issue.", "Update Your Firmware", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Case "ThirdPartyGpsPort"
                MessageBox.Show("You can use the port " + preferredSerialDevice.Port + " and baud rate " + preferredSerialDevice.BaudRate.ToString() + " for your third-party GPS applications.", "Use " + preferredSerialDevice.Port, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

            Case "GpsidFixHardwarePort"
            Case "GpsidIncorrectPort"

                If MessageBox.Show("Would you like to configure the GPS Intermediate Driver (GPSID) to use a better device?", "Update Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    ' Update the setting
                    gpsid.HardwarePort = preferredSerialDevice

                    ' Restart the GPSID
                    gpsid.Restart()

                    If MessageBox.Show("The GPSID has been updated to use \"" + preferredSerialDevice.Port + " \ " at baud rate \"" + preferredSerialDevice.BaudRate.ToString() + " \ ".  Do you want to verify that it's working?", "Confirm Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                        ' Restart the scan
                        menuRestart_Click(Me, EventArgs.Empty)

                    End If
                End If
            Case "GpsidUseVirtualBluetoothPort"

                If MessageBox.Show("Would you like to configure the GPS Intermediate Driver (GPSID) to use a better device?", "Update Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    ' Update the setting
                    gpsid.HardwarePort = preferredVirtualSerialDevice

                    ' Restart the GPSID
                    gpsid.Restart()

                    If MessageBox.Show("The GPSID has been updated to use \"" + preferredSerialDevice.Port + " \ " at baud rate \"" + preferredSerialDevice.BaudRate.ToString() + " \ ".  Do you want to verify that it's working?", "Confirm Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                        ' Restart the scan
                        menuRestart_Click(Me, EventArgs.Empty)

                    End If
                End If

            Case "BluetoothCreateVirtualPort"
                If MessageBox.Show("Setting up a virtual serial port can make your Bluetooth GPS device available to programs.  Would you like to set this up now?", "Virtual Serial Port", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    System.Diagnostics.Process.Start("\windows\ctlpnl.exe", "cplmain.cpl,23")
                End If

            Case "GpsidNoDevice"
                MessageBox.Show("Your device supports sharing a GPS device with multiple applications, but no GPS devices were found.  Try hooking one up and running the scan again.", "No Devices Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Case "GpsidNotSupported"
                MessageBox.Show("This device runs an older operating system.  You can take advantage of GPS device sharing if you upgrade to Windows Mobile 5.0 or later.", "Consider Upgrading", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

            Case "BluetoothNotSupported"
                MessageBox.Show("The Bluetooth software on this device is not by Microsoft.  Everything may be working fine, but it limits the use of Bluetooth by some third-party applications.", "Other Bluetooth Stack", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

            Case "BluetoothOk"
                MessageBox.Show("Microsoft® Bluetooth software was found on this device, which is good.", "Microsoft® Bluetooth", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

            Case "TurnBluetoothOn"

                If MessageBox.Show("Would you like to turn Bluetooth on now?", "Enable Bluetooth", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    ' Enable Bluetooth
                    Devices.IsBluetoothEnabled = True

                    ' Was it actually enabled?
                    If Devices.IsBluetoothEnabled Then

                        If MessageBox.Show("Bluetooth is now enabled.  Would you like to look for GPS devices again?", "Bluetooth Enabled", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                            menuRestart_Click(Me, EventArgs.Empty)

                        End If

                    Else

                        MessageBox.Show("Bluetooth could not be turned on.  You can turn Bluetooth on manually look for a Bluetooth icon from the main Today screen, or from your Settings.", "Bluetooth Not Enabled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If

                End If

            Case "TurnDeviceOn"
                MessageBox.Show("The device is a GPS device, but it may be turned off or ""stuck open.""  Turn the device off then back on again.", "GPS Not Responding", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Case "AlternativeSerialPort"
                MessageBox.Show("You should use \"" + gpsid.Port + " \ " in your software, but you could also use \"" + preferredSerialDevice.Port + " \ " at \"" + preferredSerialDevice.BaudRate.ToString() + " \ " baud.", "Alternative GPS Device", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

        End Select

    End Sub

    Private Sub AddDevice(ByVal device As Device)

        Dim item As New ListViewItem(device.Name)
        item.ImageIndex = 0
        item.Tag = Device
        gpsListView.Items.Add(item)

    End Sub

    Private Sub AddError(ByVal message As String, ByVal tag As String)

        Dim item As New ListViewItem(message)
        item.ImageIndex = 1
        item.Tag = Tag
        suggestionListView.Items.Add(item)
        errorCount = errorCount + 1

    End Sub

    Private Sub AddWarning(ByVal message As String, ByVal tag As String)

        Dim item As New ListViewItem(message)
        item.ImageIndex = 2
        item.Tag = Tag
        suggestionListView.Items.Add(item)
        warningCount = warningCount + 1

    End Sub

    Private Sub AddMessage(ByVal message As String, ByVal tag As String)

        Dim item As New ListViewItem(message)
        item.ImageIndex = 3
        item.Tag = Tag
        suggestionListView.Items.Add(item)
        okCount = okCount + 1

    End Sub

End Class