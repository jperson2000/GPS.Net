Imports System.IO
Imports GeoFramework
Imports GeoFramework.Gps
Imports GeoFramework.Gps.IO

Public Class DetectForm

    ' This form performs a search for GPS devices using the GPS.NET 3.0 "Devices" class.
    ' This class provides several events which report on the progress of GPS device detection,
    ' including the device being tested, as well as any errors reported.

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Show the form
        Show()
        Application.DoEvents()

        ' The detection process typically requires about 45-60 seconds to complete.  This
        ' will be faster if Bluetooth is not enabled on the system.
        Cursor.Current = Cursors.WaitCursor

        ' Hook into GPS device detection events.  These events are static, allowing them to
        ' be easily sunk by any other class or form.
        AddHandler Devices.DeviceDetectionStarted, AddressOf Devices_DeviceDetectionStarted
        AddHandler Devices.DeviceDetectionCompleted, AddressOf Devices_DeviceDetectionCompleted
        AddHandler Devices.DeviceDetected, AddressOf Devices_DeviceDetected
        AddHandler Devices.DeviceDetectionAttempted, AddressOf Devices_DeviceDetectionAttempted
        AddHandler Devices.DeviceDetectionAttemptFailed, AddressOf Devices_DeviceDetectionAttemptFailed

        ' Add commonly-used graphics to the image list
        imageList1.Images.Add(My.Resources.Question)
        imageList1.Images.Add(My.Resources.Gps)
        imageList1.Images.Add(My.Resources.ErrorImage)
        imageList1.Images.Add(My.Resources.WarningImage)

        ' Start looking for GPS devices.  The "Diagnostics" class is new to GPS.NET 3.0
        ' and provides a way for developers to quickly troubleshoot and log common connectivity issues.
        ' The Diagnostics class performs a detection, generates a log file, and provides suggestions
        ' on what can be done to improve GPS connectivity.  The idea here is that end-users can
        ' generate a log file, send it to you, and from the log you can quickly provide helpful
        ' tech support with minimal effort.
        GeoFramework.Gps.Diagnostics.Run(New StreamWriter("GPS Diagnostics Log.txt"))
    End Sub

#Region "  Menus  "

    Private Sub menuCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuCancel.Click
        ' Device detection can be canceled at any time.  Show a message box to
        ' make sure they didn't click the Cancel menu by accident.

        ' If the menu says "View Log" then open the log file
        If menuCancel.Text = "View Log" Then
            ' Create a new form for the log
            Dim Form As New LogForm
            Form.Title = "GPS Device Detection Log"
            Form.Device = Nothing

            ' Read the entire contents of the log file
            Dim reader As StreamReader = File.OpenText("GPS Diagnostics Log.txt")
            Form.Body = reader.ReadToEnd
            reader.Close()

            Form.Show()
            Application.DoEvents()
            Exit Sub            
        Else            
            ' Do they really want to cancel?
            If MessageBox.Show("Do you want to stop searching for devices?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                ' Reset the cursor
                Cursor.Current = Cursors.Default
                Application.DoEvents()

                ' And close this form
                Close()

                ' Yes.  Cancel device detection
                Devices.CancelDetection()
            End If
        End If
    End Sub

    Private Sub menuNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuNext.Click

        ' After detection completes, we can summarize all of the devices detected
        ' and provide some suggestions if any problems were found.  Show the summary
        ' form (SummaryForm)
        Dim ok As New SummaryForm
        ok.Show()

        ' Close this form
        Close()
    End Sub

#End Region

#Region "  Displaying devices  "

    Private Sub devicesListView_ItemActivate(ByVal sender As Object, ByVal e As EventArgs) Handles devicesListView.ItemActivate

        ' The user can click on any listview item to display more information about
        ' a device.  They can also connect to the device and see which features it
        ' supports to make sure it's working properly.

        ' Which item was selected?
        Dim selectedItem As ListViewItem = devicesListView.Items(devicesListView.SelectedIndices(0))

        ' Get the device object associatede with this listview item
        Dim selectedDevice As Device = CType(selectedItem.Tag, Device)

        ' Make a new device information form
        Dim Form As New DeviceForm

        ' Tell it to use this device
        Form.CurrentDevice = selectedDevice

        ' And show it
        Form.Show()
    End Sub

#End Region

#Region "  GPS Device Detection Events  "

    Private Sub Devices_DeviceDetectionAttempted(ByVal sender As Object, ByVal e As DeviceEventArgs)
        BeginInvoke(New Action(Of Object, DeviceEventArgs)(AddressOf DeviceDetectionAttempted), sender, e)
    End Sub

    Private Sub DeviceDetectionAttempted(ByVal sender As Object, ByVal e As DeviceEventArgs)
        ' Add the device
        AddDevice(e.Device)

        ' Update the log
        Log("Testing " + e.Device.Name + "...")
    End Sub

    Private Sub AddDevice(ByVal device As Device)

        ' This method is called by the events DeviceDetectionAttempted and DeviceDiscovered.
        ' A new item is added to the ListView.

        ' Create a new item
        Dim item As New ListViewItem(device.Name)
        item.ImageIndex = 0

        ' Link the item to the Device it represents.  We'll use this property later when
        ' we have results on whether or not detection succeeded for this device.
        item.Tag = device

        ' GPS.NET supports many kinds of devices.  Classes such as BluetoothDevice and SerialDevice
        ' inherit from the Device base class.  Try casting the device as one of these other types
        ' so we can get more information.

        If device.GetType() Is GetType(BluetoothDevice) Then
            ' Is this a Bluetooth device?
            Dim bluetoothDevice As BluetoothDevice = CType(device, BluetoothDevice)

            ' Yes.  Show the device's address
            item.SubItems.Add("Bluetooth (" + bluetoothDevice.Address.ToString() + ")")

        ElseIf device.GetType() Is GetType(GpsIntermediateDriver) Then
            ' Is this the GPS Intermediate Driver (GPSID)?
            Dim gpsid As GpsIntermediateDriver = CType(device, GpsIntermediateDriver)

            ' Yes.  Show its "program port," the port which all applications should use
            item.SubItems.Add("Multiplexer (" + gpsid.Port + ")")

        ElseIf device.GetType() Is GetType(SerialDevice) Then
            ' Is this a serial device?
            Dim serialDevice As SerialDevice = CType(device, SerialDevice)

            ' Yes.  Show the device's serial port
            item.SubItems.Add("Serial (" + serialDevice.Port + ")")

        End If

        ' Add a status message for this device
        item.SubItems.Add("Testing...")

        ' Finally, add the item to the list view
        devicesListView.Items.Add(item)
    End Sub

    Private Sub Devices_DeviceDetectionAttemptFailed(ByVal sender As Object, ByVal e As DeviceDetectionExceptionEventArgs)
        BeginInvoke(New Action(Of Object, DeviceDetectionExceptionEventArgs)(AddressOf DeviceDetectionAttemptFailed), sender, e)
    End Sub

    Private Sub DeviceDetectionAttemptFailed(ByVal sender As Object, ByVal e As DeviceDetectionExceptionEventArgs)
        ' This event gets raised any time an attempt to test a device for GPS data has failed.
        ' Failures can occur for many reasons.  The device may be powered off or the device may not
        ' qualify for testing at all.  Some devices such as computers will not be tested.
        ' 
        ' When a failure occurs, the device is colored red (or yellow), and its icon is changed.

        ' Look through the listview for the device
        Dim item As ListViewItem
        For Each item In devicesListView.Items

            ' The Tag property stores a Device object.  Check to see if the
            ' device matches the device which just failed.  Do we have a match?

            If Object.ReferenceEquals(item.Tag, e.Device) Then

                ' Yes.  The device failed, but has it ever been successfully detected before?
                If e.Device.SuccessfulDetectionCount > 0 Then

                    ' It has been detected, so it's a GPS device.  It's just not working right now.
                    ' Change the icon to a "warning" and color it yellow.
                    item.ImageIndex = 3
                    item.ForeColor = Color.DarkGoldenrod
                Else
                    ' The device has never been confirmed as a GPS device.  Color it red.
                    item.ImageIndex = 2
                    item.ForeColor = Color.Red
                End If

                ' Set the third column of the listview item to the error message
                item.SubItems(2).Text = e.Exception.Message

                ' Update the log with the message
                Log(e.Device.Name + ": " + e.Exception.Message)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub Devices_DeviceDiscovered(ByVal sender As Object, ByVal e As DeviceEventArgs)
        BeginInvoke(New Action(Of Object, DeviceEventArgs)(AddressOf DeviceDiscovered), sender, e)
    End Sub

    Private Sub DeviceDiscovered(ByVal sender As Object, ByVal e As DeviceEventArgs)

        ' This event will get raised if a Bluetooth device has just been found.  Bluetooth
        ' needs several seconds to locate nearby wireless devices as a result, a device may
        ' not be discovered until several seconds into the device detection process.
        Log(e.Device.Name + " has been discovered.")
    End Sub

    Private Sub Devices_DeviceDetected(ByVal sender As Object, ByVal e As DeviceEventArgs)
        BeginInvoke(New Action(Of Object, DeviceEventArgs)(AddressOf DeviceDetected), sender, e)
    End Sub

    Private Sub DeviceDetected(ByVal sender As Object, ByVal e As DeviceEventArgs)
        ' This event is raised when a device has been confirmed as a GPS device.  The
        ' listview item is colored green and it's icon is set to a GPS device icon.

        ' Change the main form label to indicate success.
        titleLabel.Text = "A GPS Device Was Found."

        ' Update the log to show the success
        Log(e.Device.Name + " is a GPS device.")

        ' Look through the listview for the device
        Dim item As ListViewItem
        For Each item In devicesListView.Items
            ' The Tag property stores a Device object.  Check to see if the
            ' device matches the device which just failed.  Do we have a match?
            If Object.ReferenceEquals(item.Tag, e.Device) Then

                ' Yes.  Update its color and icon
                item.ImageIndex = 1
                item.ForeColor = Color.DarkGreen

                ' In the third column, indicate that the device is working properly
                item.SubItems(2).Text = "GPS is working properly"
                Exit Sub
            End If
        Next
    End Sub

    Private Sub Devices_DeviceDetectionCompleted(ByVal sender As Object, ByVal e As EventArgs)
        BeginInvoke(New Action(Of Object, EventArgs)(AddressOf DeviceDetectionCompleted), sender, e)
    End Sub

    Private Sub DeviceDetectionCompleted(ByVal sender As Object, ByVal e As EventArgs)

        ' This event is raised when all known devices have been tested.  At this point,
        ' we have enough information to look for problems and make intelligent suggestions
        ' on how to resolve them.

        ' Change the cursor back to normal
        Cursor.Current = Cursors.Default

        ' Update the main form label to show that the search is over
        titleLabel.Text = "Search Complete."
        description.Text = "Tap ""Next"" to view suggestions and a summary of devices."

        ' Update the log to show that the search has completed
        Log("Device detection has completed.")

        ' Enable the Next button, letting them continue to the summary form
        menuNext.Enabled = True

        ' Change "Cancel" to "View Log"
        menuCancel.Text = "View Log"
        menuCancel.Enabled = True
    End Sub

    Private Sub Devices_DeviceDetectionStarted(ByVal sender As Object, ByVal e As EventArgs)
        BeginInvoke(New Action(Of Object, EventArgs)(AddressOf DeviceDetectionStarted), sender, e)
    End Sub

    Private Sub DeviceDetectionStarted(ByVal sender As Object, ByVal e As EventArgs)

        ' This event is raised when the GPS device detection thread has started.
        ' No devices have been tested yet, but it will start immediately after this event.

        ' Enable the Cancel menu
        menuCancel.Enabled = True

        ' Show that detection has been started
        Log("Device detection has started.")
    End Sub

#End Region

    Private Sub Log(ByVal message As String)

        ' This method is called by various events in the form.  A message is added to a
        ' ListBox, and its index is set to the last item to ensure that the new item is visible.
        logBox.Items.Add(message)
        logBox.SelectedIndex = logBox.Items.Count - 1
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class