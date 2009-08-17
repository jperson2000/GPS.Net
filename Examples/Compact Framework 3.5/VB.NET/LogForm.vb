Imports System.IO
Imports System.Net
Imports GeoFramework
Imports GeoFramework.Gps
Imports GeoFramework.Gps.IO

Public Class LogForm

    Private _Device As Device
    Private _Body As String
    Private _Title As String

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary>
    ''' Controls the device whose log is being displayed.
    ''' </summary>
    Public Property Device() As Device
        Get
            Return _Device
        End Get
        Set(ByVal value As Device)

            _Device = value

            If Not _Device Is Nothing Then
                titleLabel.Text = _Device.Name
            End If

        End Set
    End Property

    ''' <summary>
    ''' Controls the title of the log file.
    ''' </summary>
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
            titleLabel.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Controls the body of the log file.
    ''' </summary>
    Public Property Body() As String
        Get
            Return _Body
        End Get
        Set(ByVal value As String)
            _Body = Value
            logBody.Text = Value
        End Set
    End Property

    Private Sub menuClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuClose.Click
        Close()
    End Sub

    Private Sub menuSendLog_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuSendLog.Click

        ' GeoFrameworks welcomes log files from all developers and end-users.  This method will
        ' transmit the contents of a log file to us via our web site.
        ' 
        ' PRIVACY NOTICE: No log files contain any personally identifiable information.  The information
        '                 is used strictly for troubleshooting GPS device issues and for building statistics
        '                 such as the most commonly-used GPS devices.

        If MessageBox.Show("Sending this log file to GeoFrameworks helps us improve your GPS software.  The information " _
                           + "is anonymous and confidential.  An internet connection is required.  Would you like to continue?", _
                           "Send Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            Try

                ' Show a wait cursor until we're finished
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()

                ' Make a new web request
                Dim request As HttpWebRequest = Nothing

                If Not _Device Is Nothing Then
                    ' We're reporting a log file for a specific device
                    request = CType(WebRequest.Create("http:'www.geoframeworks.com/GPSDeviceDiagnostics.aspx"), HttpWebRequest)
                Else
                    ' We're reporting a log file for the whole device detection process
                    request = CType(WebRequest.Create("http:'www.geoframeworks.com/GPSDiagnostics.aspx"), HttpWebRequest)
                End If

                ' Provide standard credentials for the web request
                request.ContentType = "application/x-www-form-urlencoded"
                request.Credentials = CredentialCache.DefaultCredentials
                request.UserAgent = "GPS Diagnostics"
                request.Method = "POST"

                Dim data As String = ""

                ' Is a specific device being logged?
                If Not _Device Is Nothing Then

                    ' Yes.  Include some information about the device

                    data = "Device=" + _Device.Name
                    data += "&IsGps=" + _Device.IsGpsDevice.ToString()
                    data += "&Reliability=" + _Device.Reliability.ToString()

                    If _Device.GetType() Is GetType(GpsIntermediateDriver) Then

                        Dim gpsid As GpsIntermediateDriver = CType(_Device, GpsIntermediateDriver)

                        data += "&Type=GPSID"
                        data += "&ProgramPort=" + gpsid.Port

                        If Not gpsid.HardwarePort Is Nothing Then
                            data += "&HardwarePort=None&HardwareBaud=0"
                        Else
                            data += "&HardwarePort=" + gpsid.HardwarePort.Port
                            data += "&HardwareBaud=" + gpsid.HardwarePort.BaudRate
                        End If


                    ElseIf _Device.GetType() Is GetType(SerialDevice) Then

                        Dim serialDevice As SerialDevice = CType(_Device, SerialDevice)

                        data += "&Type=Serial"
                        data += "&Port=" + serialDevice.Port
                        data += "&BaudRate=" + serialDevice.BaudRate.ToString()

                    ElseIf _Device.GetType() Is GetType(BluetoothDevice) Then

                        Dim bluetoothDevice As BluetoothDevice = CType(_Device, BluetoothDevice)

                        data += "&Type=Bluetooth"
                        data += "&Address=" + bluetoothDevice.Address.ToString()

                        Dim endPoint As BluetoothEndPoint = CType(bluetoothDevice.EndPoint, BluetoothEndPoint)
                        data += "&Service=" + endPoint.Name
                    End If

                End If

                ' Now append the log
                data += "&Log=" + _Body

                ' Get a byte array
                Dim buffer As Byte() = System.Text.UTF8Encoding.UTF8.GetBytes(data)

                ' Transmit the request
                request.ContentLength = Buffer.Length

                ' Get the request stream.
                Dim dataStream As Stream = request.GetRequestStream()

                ' Write the data to the request stream.
                dataStream.Write(Buffer, 0, Buffer.Length)

                ' Close the Stream object.
                dataStream.Close()

                ' Get the response.
                Dim response As WebResponse = request.GetResponse()

                ' Display the status.      
                Dim result As String = CType(response, HttpWebResponse).StatusDescription

                response.Close()
                Cursor.Current = Cursors.Default
                Application.DoEvents()

                If result = "OK" Then

                    ' Disable the menu now that we've received the file.
                    menuSendLog.Enabled = False
                    MessageBox.Show("We've received your log and will study it further.  Thanks for taking the time to send it!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

                Else

                    ' An error occurred while trying to transmit the log.
                    MessageBox.Show("The diagnostics server may not be responding.  Please check to see if you have an internet connection, then try again.", result, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception

                ' Reset the cursor
                Cursor.Current = Cursors.Default
                Application.DoEvents()

                ' Inform the user about the error.  What exactly happened?
                MessageBox.Show("A log could not be sent.  " + ex.Message, "Unable to Send", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End Try

        End If

    End Sub

End Class