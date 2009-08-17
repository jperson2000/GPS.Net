Imports System.IO
Imports GeoFramework
Imports GeoFramework.Gps
Imports GeoFramework.Gps.IO
Imports GeoFramework.Gps.Nmea

Public Class DeviceForm

    Private _CurrentDevice As Device

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add images to the image list
        imageList1.Images.Add(My.Resources.Ok)
        imageList1.Images.Add(My.Resources.ErrorImage)
    End Sub

    ''' <summary>
    ''' Controls the GPS device being displayed.
    ''' </summary>
    Public Property CurrentDevice() As Device
        Get
            Return _CurrentDevice
        End Get
        Set(ByVal value As Device)

            _CurrentDevice = value

            ' Set the name of the device
            titleLabel.Text = value.Name

            ' What kind of device is this?
            Dim gpsid As GpsIntermediateDriver = Nothing
            Dim serialDevice As SerialDevice = Nothing
            Dim bluetoothDevice As BluetoothDevice = Nothing

            If value.GetType() Is GetType(GpsIntermediateDriver) Then

                ' Is this the GPS Intermediate Driver?
                gpsid = CType(value, GpsIntermediateDriver)
                typeLabel.Text = "GPS Sharing Service"

                ' Some GPSID's don't have a hardware port :P
                If gpsid.HardwarePort Is Nothing Then
                    portLabel.Text = gpsid.Port
                Else
                    portLabel.Text = gpsid.Port + " (" + gpsid.HardwarePort.Port + " at " + gpsid.HardwarePort.BaudRate.ToString() + ")"
                End If

            ElseIf value.GetType() Is GetType(SerialDevice) Then

                ' A serial device
                serialDevice = CType(value, SerialDevice)

                typeLabel.Text = "Serial Device"
                portLabel.Text = serialDevice.Port + " at " + serialDevice.BaudRate.ToString() + " baud"

            ElseIf value.GetType() Is GetType(BluetoothDevice) Then

                ' A Bluetooth device
                bluetoothDevice = CType(value, BluetoothDevice)

                typeLabel.Text = "Bluetooth Device"
                portLabelTitle.Text = "Address:"
                portLabel.Text = bluetoothDevice.Address.ToString()

            Else

                typeLabel.Text = value.GetType().ToString() + " Device"
                portLabelTitle.Visible = False
                portLabel.Visible = False

            End If


            ' Was this device detected?
            If _CurrentDevice.IsDetectionCompleted Then

                ' Is it a GPS device?
                If _CurrentDevice.IsGpsDevice Then
                    ' Yes
                    isGPSLabel.Text = "Yes"
                    devicePicture.Image = My.Resources.Gps
                Else
                    ' No.  But has it succeeded before?
                    If _CurrentDevice.SuccessfulDetectionCount > 0 Then
                        ' Yes
                        isGPSLabel.Text = "Yes (not responding)"
                        devicePicture.Image = My.Resources.WarningImage
                    Else
                        ' No
                        isGPSLabel.Text = "No"

                        ' Is it a computer?
                        If Not bluetoothDevice Is Nothing AndAlso bluetoothDevice.Class = DeviceClass.Computer Then
                            devicePicture.Image = My.Resources.Computer
                        Else
                            devicePicture.Image = My.Resources.ErrorImage
                        End If
                    End If
                End If
            Else
                ' Detection is still in progress
                isGPSLabel.Text = "Not sure yet"
                devicePicture.Image = My.Resources.Question

                ' Set the reliability
                reliabilityLabel.Text = value.Reliability.ToString()

                ' When was it last connected?
                If value.DateConnected.Equals(DateTime.MinValue) Then
                    lastConnectLabel.Text = "Never"
                Else
                    lastConnectLabel.Text = value.DateConnected.ToShortDateString() + " " + value.DateConnected.ToShortTimeString()
                End If
            End If
        End Set
    End Property


    Private Sub menuClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuClose.Click        
        Close()
    End Sub

    Private Sub menuAnalyze_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuAnalyze.Click
        ' Make a log file name from the name of the device
        Dim logName As String = _CurrentDevice.Name + ".txt"

        ' Remove any invalid characters
        Dim badChar As Char
        For Each badChar In Path.GetInvalidPathChars()
            logName = logName.Replace(badChar, "_")
        Next

        ' Also remove colons
        logName = logName.Replace(":", String.Empty)

        ' Are they requesting a log?
        If menuAnalyze.Text = "View Log" Then

            ' Yes.  Create a form for the log
            Dim Form As New LogForm

            ' Tell the form which device to use
            Form.Device = _CurrentDevice

            ' Read in the log file
            Dim reader As StreamReader = File.OpenText(logName)
            Form.Body = reader.ReadToEnd
            reader.Close()

            ' Show the log file form
            Form.Show()
            Application.DoEvents()
            Exit Sub

        End If

        ' This feature will examine the NMEA data from a device and
        ' report on what features it supports.

        menuAnalyze.Enabled = False
        tabControl1.SelectedIndex = 1

        ' Show a busy cursor until analysis completes
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Dim logWriter As StreamWriter = Nothing

        Try

            ' Open the device
            _CurrentDevice.Open()

            ' Create a log file for this device
            logWriter = New StreamWriter(logName)

            ' Write a header
            logWriter.WriteLine("------------------------------------------------------------------------------------------------------------------------------")
            logWriter.WriteLine("GPS.NET 3.0 Diagnostics    Copyright © 2009  GeoFrameworks, LLC")
            logWriter.WriteLine("                                   http:'www.geoframeworks.com")
            logWriter.WriteLine("")
            logWriter.WriteLine("A. RAW NMEA DATA FOR " + _CurrentDevice.Name.ToUpper())
            logWriter.WriteLine("")

            ' Wrap the device's raw data stream in an NmeaReader
            Dim stream As New NmeaReader(_CurrentDevice.BaseStream)
            Dim isPositionSupported As Boolean = False
            Dim isAltitudeSupported As Boolean = False
            Dim isBearingSupported As Boolean = False
            Dim isPrecisionSupported As Boolean = False
            Dim isSpeedSupported As Boolean = False
            Dim isSatellitesSupported As Boolean = False

            ' Now analyze it for up to 100 sentences
            Dim index As Integer
            For index = 0 To 99

                ' Read a valid sentence
                Dim sentence As NmeaSentence = stream.ReadTypedSentence()

                ' Write it to the log file
                logWriter.WriteLine(sentence.Sentence)

                ' Get the command word for the sentence
                If Not sentenceListBox.Items.Contains(sentence.CommandWord) Then
                    sentenceListBox.Items.Add(sentence.CommandWord)
                End If

                ' What features are supported?
                If sentence.GetType() Is GetType(IPositionSentence) Then
                    isPositionSupported = True
                End If

                If sentence.GetType() Is GetType(IAltitudeSentence) Then
                    isAltitudeSupported = True
                End If

                If sentence.GetType() Is GetType(IBearingSentence) Then
                    isBearingSupported = True
                End If

                If sentence.GetType() Is GetType(IHorizontalDilutionOfPrecisionSentence) Then
                    isPrecisionSupported = True
                End If

                If sentence.GetType() Is GetType(ISpeedSentence) Then
                    isSpeedSupported = True
                End If

                If sentence.GetType() Is GetType(ISatelliteCollectionSentence) Then
                    isSatellitesSupported = True
                End If

                ' Is everything supported?  If so, we have a healthy GPS device.  It's okay to exit
                If isPositionSupported And isAltitudeSupported And isBearingSupported And isPrecisionSupported And isSatellitesSupported And isSpeedSupported Then
                    Exit For
                End If
            Next

            ' Summarize the log
            logWriter.WriteLine("")
            logWriter.WriteLine("B. SUMMARY")
            logWriter.WriteLine("")

            ' Set images based on supported features
            If isPositionSupported Then
                logWriter.WriteLine("           Latitude and longitude are supported.")
                pictureBoxPosition.Image = imageList1.Images(0)
            Else
                logWriter.WriteLine("WARNING    Latitude and longitude are not supported.")
                pictureBoxPosition.Image = imageList1.Images(1)
            End If

            If isAltitudeSupported Then                
                logWriter.WriteLine("           Altitude is supported.")
                pictureBoxAltitude.Image = imageList1.Images(0)
            Else
                logWriter.WriteLine("WARNING    Altitude is not supported.")
                pictureBoxAltitude.Image = imageList1.Images(1)
            End If

            If isBearingSupported Then
                logWriter.WriteLine("           Bearing is supported.")
                pictureBoxBearing.Image = imageList1.Images(0)
            Else
                logWriter.WriteLine("WARNING    Bearing is not supported.")
                pictureBoxBearing.Image = imageList1.Images(1)
            End If

            If isPrecisionSupported Then
                logWriter.WriteLine("           Dilution of Precision is supported.")
                pictureBoxPrecision.Image = imageList1.Images(0)
            Else
                logWriter.WriteLine("WARNING    Dilution of Precision is not supported.")
                pictureBoxPrecision.Image = imageList1.Images(1)
            End If

            If isSpeedSupported Then
                logWriter.WriteLine("           Speed is supported.")
                pictureBoxSpeed.Image = imageList1.Images(0)
            Else
                logWriter.WriteLine("WARNING    Speed is not supported.")
                pictureBoxSpeed.Image = imageList1.Images(1)
            End If

            If isSatellitesSupported Then
                logWriter.WriteLine("           GPS satellite data is supported.")
                pictureBoxSatellites.Image = imageList1.Images(0)
            Else
                logWriter.WriteLine("WARNING    GPS satellite data is not supported.")
                pictureBoxSatellites.Image = imageList1.Images(1)
            End If

            logWriter.WriteLine("------------------------------------------------------------------------------------------------------------------------------")
            logWriter.Close()

            ' Close the device
            _CurrentDevice.Close()

            ' Restore the cursor
            Cursor.Current = Cursors.Default

            ' change "Analyze" to "View Log"
            menuAnalyze.Text = "View Log"

            ' Let them know which features are supported by their device
            If isPositionSupported And isAltitudeSupported And isBearingSupported And isPrecisionSupported And isSatellitesSupported And isSpeedSupported Then
                MessageBox.Show(_CurrentDevice.Name + " fully supports all real-time GPS data.", "No Problems", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show(_CurrentDevice.Name + " does not appear to fully support real-time GPS data.  Try another analysis.  If the same problem persists, some NMEA sentences may need to be activated on the device.", "Problems Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception

            ' Close the device
            _CurrentDevice.Close()

            If Not logWriter Is Nothing Then
                logWriter.Close()
            End If

            ' Restore the cursor
            Cursor.Current = Cursors.Default

            ' Explain the error
            MessageBox.Show(ex.Message, "Cannot Analyze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Finally

            ' Re-enable the menu
            menuAnalyze.Enabled = True

        End Try
    End Sub

End Class