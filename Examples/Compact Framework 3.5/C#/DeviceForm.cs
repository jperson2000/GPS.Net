using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using GeoFramework.Gps.IO;
using GeoFramework.Gps.Nmea;

namespace Diagnostics
{
    public partial class DeviceForm : Form
    {
        private string _LogName;
        private Device _CurrentDevice;
        private DeviceAnalysis _Analysis;
        private ManualResetEvent _AnalysisCompleteWaitHandle = new ManualResetEvent(false);

        public DeviceForm()
        {
            InitializeComponent();

            // Add images to the image list
            imageList1.Images.Add(Program.Ok);
            imageList1.Images.Add(Program.Error);
        }

        /// <summary>
        /// Controls the GPS device being displayed.
        /// </summary>
        public Device CurrentDevice
        {
            get
            {
                return _CurrentDevice;
            }
            set
            {
                _CurrentDevice = value;

                // Set the name of the device
                titleLabel.Text = value.Name;

                // Make a log file name from the name of the device
                _LogName = value.Name + ".txt";

                // Remove any invalid characters
                foreach (char badChar in Path.GetInvalidPathChars())
                    _LogName = _LogName.Replace(badChar, '_');

                // Also remove colons
                _LogName = _LogName.Replace(":", String.Empty);

                // What kind of device is this?
                GpsIntermediateDriver gpsid = value as GpsIntermediateDriver;
                SerialDevice serialDevice = value as SerialDevice;
                BluetoothDevice bluetoothDevice = value as BluetoothDevice;

                if (gpsid != null)
                {
                    typeLabel.Text = "GPS Sharing Service";

                    // Some GPSID's don't have a hrdware port :P
                    if(gpsid.HardwarePort == null)
                        portLabel.Text = gpsid.Port;
                    else
                        portLabel.Text = gpsid.Port + " (" + gpsid.HardwarePort.Port + " at " + gpsid.HardwarePort.BaudRate.ToString() + ")";
                }
                else if (serialDevice != null)
                {
                    typeLabel.Text = "Serial Device";
                    portLabel.Text = serialDevice.Port + " at " + serialDevice.BaudRate.ToString() + " baud";
                }
                else if (bluetoothDevice != null)
                {
                    typeLabel.Text = "Bluetooth Device";
                    portLabelTitle.Text = "Address:";
                    portLabel.Text = bluetoothDevice.Address.ToString();
                }
                else
                {
                    typeLabel.Text = value.GetType().ToString() + " Device";
                    portLabelTitle.Visible = false;
                    portLabel.Visible = false;
                }

                // Was this device detected?
                if (_CurrentDevice.IsDetectionCompleted)
                {
                    if (_CurrentDevice.IsGpsDevice)
                    {
                        isGPSLabel.Text = "Yes";
                        devicePicture.Image = Program.Gps;
                    }
                    else
                    {
                        // Has it succeeded before?
                        if (_CurrentDevice.SuccessfulDetectionCount > 0)
                        {
                            isGPSLabel.Text = "Yes (not responding)";
                            devicePicture.Image = Program.Warning;
                        }
                        else
                        {
                            isGPSLabel.Text = "No";

                            // Is it a computer?
                            if (bluetoothDevice != null && bluetoothDevice.Class == DeviceClass.Computer)
                                devicePicture.Image = Program.Computer;
                            else
                                devicePicture.Image = Program.Error;
                        }
                    }
                }
                else
                {
                    isGPSLabel.Text = "Not sure yet";
                    devicePicture.Image = Program.Question;
                }

                // Set the reliability
                reliabilityLabel.Text = value.Reliability.ToString();

                // When was it last connected?
                if(value.DateConnected.Equals(DateTime.MinValue))
                    lastConnectLabel.Text = "Never";
                else
                    lastConnectLabel.Text = value.DateConnected.ToShortDateString() + " " + value.DateConnected.ToShortTimeString();
            }
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuAnalyze_Click(object sender, EventArgs e)
        {
            // Are they requesting a log?
            if (menuAnalyze.Text == "View Log")
            {
                // Yes.  Create a form for the log
                LogForm form = new LogForm();

                // Tell the form which device to use
                form.Device = _CurrentDevice;

                // Read in the log file
                StreamReader reader = File.OpenText(_LogName);
                form.Body = reader.ReadToEnd();
                reader.Close();

                // Show the log file form
                form.Show();
                Application.DoEvents();
                return;
            }

            /* This feature will examine the NMEA data from a device and
             * report on what features it supports.
             */

            menuAnalyze.Enabled = false;
            tabControl1.SelectedIndex = 1;

            // Show a busy cursor until analysis completes
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();

            // Test the device
            _Analysis = _CurrentDevice.Test();

            // Write the analysis to a log file
            StreamWriter writer = new StreamWriter(_LogName);
            writer.Write(_Analysis.Log);
            writer.Close();

            // Show supported sentences
            foreach (string sentence in _Analysis.SupportedSentences)
                sentenceListBox.Items.Add(sentence);

            // Set images based on supported features
            if (_Analysis.IsPositionSupported)
                pictureBoxPosition.Image = imageList1.Images[0];
            else
                pictureBoxPosition.Image = imageList1.Images[1];

            if (_Analysis.IsAltitudeSupported)
                pictureBoxAltitude.Image = imageList1.Images[0];
            else
                pictureBoxAltitude.Image = imageList1.Images[1];

            if (_Analysis.IsBearingSupported)
                pictureBoxBearing.Image = imageList1.Images[0];
            else
                pictureBoxBearing.Image = imageList1.Images[1];

            if (_Analysis.IsPrecisionSupported)
                pictureBoxPrecision.Image = imageList1.Images[0];
            else
                pictureBoxPrecision.Image = imageList1.Images[1];

            if (_Analysis.IsSpeedSupported)
                pictureBoxSpeed.Image = imageList1.Images[0];
            else
                pictureBoxSpeed.Image = imageList1.Images[1];

            if (_Analysis.IsSatellitesSupported)
                pictureBoxSatellites.Image = imageList1.Images[0];
            else
                pictureBoxSatellites.Image = imageList1.Images[1];

            // change "Analyze" to "View Log"
            menuAnalyze.Text = "View Log";

            // Re-enable the menu
            menuAnalyze.Enabled = true;

            // Restore the cursor
            Cursor.Current = Cursors.Default;

            // Let them know which features are supported by their device
            if (_Analysis.IsWorkingProperly)
                MessageBox.Show(_CurrentDevice.Name + " fully supports all real-time GPS data.", "No Problems", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show(_CurrentDevice.Name + " does not appear to fully support real-time GPS data.  Try another analysis.  If the same problem persists, some NMEA sentences may need to be activated on the device.", "Problems Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }
}