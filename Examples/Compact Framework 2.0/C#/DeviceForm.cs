using System;
using System.IO;
using System.Windows.Forms;
using GeoFramework.Gps.IO;
using GeoFramework.Gps.Nmea;

namespace Diagnostics
{
    public partial class DeviceForm : Form
    {
        private Device _CurrentDevice;

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
            // Make a log file name from the name of the device
            string logName = _CurrentDevice.Name + ".txt";

            // Remove any invalid characters
            foreach (char badChar in Path.GetInvalidPathChars())
                logName = logName.Replace(badChar, '_');

            // Also remove colons
            logName = logName.Replace(":", String.Empty);

            // Are they requesting a log?
            if (menuAnalyze.Text == "View Log")
            {
                // Yes.  Create a form for the log
                LogForm form = new LogForm();

                // Tell the form which device to use
                form.Device = _CurrentDevice;

                // Read in the log file
                StreamReader reader = File.OpenText(logName);                
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
            StreamWriter logWriter = null;

            try
            {
                // Open the device
                _CurrentDevice.Open();

                // Create a log file for this device
                logWriter = new StreamWriter(logName);

                // Write a header
                logWriter.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                logWriter.WriteLine("GPS.NET 3.0 Diagnostics    Copyright © 2009  GeoFrameworks, LLC");
                logWriter.WriteLine("                                   http://www.geoframeworks.com");
                logWriter.WriteLine("");
                logWriter.WriteLine("A. RAW NMEA DATA FOR " + _CurrentDevice.Name.ToUpper());
                logWriter.WriteLine("");

                // Wrap the device's raw data stream in an NmeaReader
                NmeaReader stream = new NmeaReader(_CurrentDevice.BaseStream);
                bool isPositionSupported = false;
                bool isAltitudeSupported = false;
                bool isBearingSupported = false;
                bool isPrecisionSupported = false;
                bool isSpeedSupported = false;
                bool isSatellitesSupported = false;

                // Now analyze it for up to 100 sentences
                for (int index = 0; index < 100; index++)
                {
                    // Read a valid sentence
                    NmeaSentence sentence = stream.ReadTypedSentence();

                    // Write it to the log file
                    logWriter.WriteLine(sentence.Sentence);

                    // Get the command word for the sentence
                    if (!sentenceListBox.Items.Contains(sentence.CommandWord))
                        sentenceListBox.Items.Add(sentence.CommandWord);

                    // What features are supported?
                    IPositionSentence positionSentence = sentence as IPositionSentence;
                    if (positionSentence != null)
                        isPositionSupported = true;

                    IAltitudeSentence altitudeSentence = sentence as IAltitudeSentence;
                    if (altitudeSentence != null)
                        isAltitudeSupported = true;

                    IBearingSentence bearingSentence = sentence as IBearingSentence;
                    if (bearingSentence != null)
                        isBearingSupported = true;

                    IHorizontalDilutionOfPrecisionSentence hdopSentence = sentence as IHorizontalDilutionOfPrecisionSentence;
                    if (hdopSentence != null)
                        isPrecisionSupported = true;

                    ISpeedSentence speedSentence = sentence as ISpeedSentence;
                    if (speedSentence != null)
                        isSpeedSupported = true;

                    ISatelliteCollectionSentence satellitesSentence = sentence as ISatelliteCollectionSentence;
                    if (satellitesSentence != null)
                        isSatellitesSupported = true;

                    // Is everything supported?  If so, we have a healthy GPS device.  It's okay to exit
                    if (isPositionSupported && isAltitudeSupported && isBearingSupported && isPrecisionSupported && isSatellitesSupported && isSpeedSupported)
                        break;
                }

                // Summarize the log
                logWriter.WriteLine("");
                logWriter.WriteLine("B. SUMMARY");
                logWriter.WriteLine("");

                // Set images based on supported features
                if (isPositionSupported)
                {
                    logWriter.WriteLine("           Latitude and longitude are supported.");
                    pictureBoxPosition.Image = imageList1.Images[0];
                }
                else
                {
                    logWriter.WriteLine("WARNING    Latitude and longitude are not supported.");
                    pictureBoxPosition.Image = imageList1.Images[1];
                }
                if (isAltitudeSupported)
                {
                    logWriter.WriteLine("           Altitude is supported.");
                    pictureBoxAltitude.Image = imageList1.Images[0];
                }
                else
                {
                    logWriter.WriteLine("WARNING    Altitude is not supported.");
                    pictureBoxAltitude.Image = imageList1.Images[1];
                }
                if (isBearingSupported)
                {
                    logWriter.WriteLine("           Bearing is supported.");
                    pictureBoxBearing.Image = imageList1.Images[0];
                }
                else
                {
                    logWriter.WriteLine("WARNING    Bearing is not supported.");
                    pictureBoxBearing.Image = imageList1.Images[1];
                }
                if (isPrecisionSupported)
                {
                    logWriter.WriteLine("           Dilution of Precision is supported.");
                    pictureBoxPrecision.Image = imageList1.Images[0];
                }
                else
                {
                    logWriter.WriteLine("WARNING    Dilution of Precision is not supported.");
                    pictureBoxPrecision.Image = imageList1.Images[1];
                }
                if (isSpeedSupported)
                {
                    logWriter.WriteLine("           Speed is supported.");
                    pictureBoxSpeed.Image = imageList1.Images[0];
                }
                else
                {
                    logWriter.WriteLine("WARNING    Speed is not supported.");
                    pictureBoxSpeed.Image = imageList1.Images[1];
                }
                if (isSatellitesSupported)
                {
                    logWriter.WriteLine("           GPS satellite data is supported.");
                    pictureBoxSatellites.Image = imageList1.Images[0];
                }
                else
                {
                    logWriter.WriteLine("WARNING    GPS satellite data is not supported.");
                    pictureBoxSatellites.Image = imageList1.Images[1];
                }

                logWriter.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                logWriter.Close();

                // Close the device
                _CurrentDevice.Close();

                // Restore the cursor
                Cursor.Current = Cursors.Default;

                // change "Analyze" to "View Log"
                menuAnalyze.Text = "View Log";

                // Let them know which features are supported by their device
                if (isPositionSupported && isAltitudeSupported && isBearingSupported && isPrecisionSupported && isSatellitesSupported && isSpeedSupported)
                    MessageBox.Show(_CurrentDevice.Name + " fully supports all real-time GPS data.", "No Problems", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show(_CurrentDevice.Name + " does not appear to fully support real-time GPS data.  Try another analysis.  If the same problem persists, some NMEA sentences may need to be activated on the device.", "Problems Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                // Close the device
                _CurrentDevice.Close();
                if(logWriter != null)
                    logWriter.Close();

                // Restore the cursor
                Cursor.Current = Cursors.Default;

                // Explain the error
                MessageBox.Show(ex.Message, "Cannot Analyze", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // Re-enable the menu
                menuAnalyze.Enabled = true;
            }
        }
    }
}