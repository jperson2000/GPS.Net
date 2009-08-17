using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using GeoFramework.Gps.IO;

namespace Diagnostics
{
    public partial class LogForm : Form
    {
        private Device _Device;
        private string _Body;
        private string _Title;

        public LogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Controls the device whose log is being displayed.
        /// </summary>
        public Device Device
        {
            get
            {
                return _Device;
            }
            set
            {
                _Device = value;
                if(_Device != null)
                    titleLabel.Text = _Device.Name;
            }
        }

        /// <summary>
        /// Controls the title of the log file.
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                titleLabel.Text = value;
            }
        }

        /// <summary>
        /// Controls the body of the log file.
        /// </summary>
        public string Body
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;
                logBody.Text = value;
            }
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuSendLog_Click(object sender, EventArgs e)
        {
            /* GeoFrameworks welcomes log files from all developers and end-users.  This method will
             * transmit the contents of a log file to us via our web site.
             * 
             * PRIVACY NOTICE: No log files contain any personally identifiable information.  The information
             *                 is used strictly for troubleshooting GPS device issues and for building statistics
             *                 such as the most commonly-used GPS devices.
             */
            if (MessageBox.Show("Sending this log file to GeoFrameworks helps us improve your GPS software.  The information is anonymous and confidential.  An internet connection is required.  Would you like to continue?", "Send Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    // Show a wait cursor until we're finished
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();

                    // Make a new web request
                    HttpWebRequest request = null;
                    if (_Device != null)
                    {
                        // We're reporting a log file for a specific device
                        request = (HttpWebRequest)WebRequest.Create("http://www.geoframeworks.com/GPSDeviceDiagnostics.aspx");
                    }
                    else
                    {
                        // We're reporting a log file for the whole device detection process
                        request = (HttpWebRequest)WebRequest.Create("http://www.geoframeworks.com/GPSDiagnostics.aspx");
                    }

                    // Provide standard credentials for the web request
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.UserAgent = "GPS Diagnostics";
                    request.Method = "POST";

                    string data = ""; 

                    // Is a specific device being logged?
                    if (_Device != null)
                    {
                        // Yes.  Include some information about the device
                        GpsIntermediateDriver gpsid = _Device as GpsIntermediateDriver;
                        SerialDevice serialDevice = _Device as SerialDevice;
                        BluetoothDevice bluetoothDevice = _Device as BluetoothDevice;

                        data = "Device=" + _Device.Name;
                        data += "&IsGps=" + _Device.IsGpsDevice.ToString();
                        data += "&Reliability=" + _Device.Reliability.ToString();

                        if (gpsid != null)
                        {
                            data += "&Type=GPSID";
                            data += "&ProgramPort=" + gpsid.Port;

                            if (gpsid.HardwarePort == null)
                                data += "&HardwarePort=None&HardwareBaud=0";
                            else
                            {
                                data += "&HardwarePort=" + gpsid.HardwarePort.Port;
                                data += "&HardwareBaud=" + gpsid.HardwarePort.BaudRate;
                            }
                        }
                        else if (serialDevice != null)
                        {
                            data += "&Type=Serial";
                            data += "&Port=" + serialDevice.Port;
                            data += "&BaudRate=" + serialDevice.BaudRate.ToString();
                        }
                        else if (bluetoothDevice != null)
                        {
                            data += "&Type=Bluetooth";
                            data += "&Address=" + bluetoothDevice.Address.ToString();

                            BluetoothEndPoint endPoint = (BluetoothEndPoint)bluetoothDevice.EndPoint;
                            data += "&Service=" + endPoint.Name;
                        }
                    }

                    // Now append the log
                    data += "&Log=" + _Body;

                    // Get a byte array
                    byte[] buffer = System.Text.UTF8Encoding.UTF8.GetBytes(data);

                    // Transmit the request
                    request.ContentLength = buffer.Length;

                    // Get the request stream.
                    Stream dataStream = request.GetRequestStream();

                    // Write the data to the request stream.
                    dataStream.Write(buffer, 0, buffer.Length);

                    // Close the Stream object.
                    dataStream.Close();

                    // Get the response.
                    WebResponse response = request.GetResponse();

                    // Display the status.      
                    string result = ((HttpWebResponse)response).StatusDescription;

                    response.Close();
                    Cursor.Current = Cursors.Default;
                    Application.DoEvents();

                    if (result == "OK")
                    {
                        // Disable the menu now that we've received the file.
                        menuSendLog.Enabled = false;
                        MessageBox.Show("We've received your log and will study it further.  Thanks for taking the time to send it!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        // An error occurred while trying to transmit the log.
                        MessageBox.Show("The diagnostics server may not be responding.  Please check to see if you have an internet connection, then try again.", result, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                catch (WebException ex)
                {
                    string resultVerbose = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();

                    // Reset the cursor
                    Cursor.Current = Cursors.Default;
                    Application.DoEvents();



                    // Inform the user about the error.  What exactly happened?
                    MessageBox.Show("A log could not be sent.  " + ex.Message, "Unable to Send", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}