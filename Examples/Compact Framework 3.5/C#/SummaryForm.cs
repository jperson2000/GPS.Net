using System;
using System.Windows.Forms;
using GeoFramework.Gps;
using GeoFramework.Gps.IO;

namespace Diagnostics
{
    /* This form takes all of the information we have about GPS devices and problems and
     * lists a series of suggestions.  The suggestions confirm that features are working properly,
     * and give clear in-English information if there are problems.  Furthermore, tapping a
     * suggestion will make an attempt to fix the problem if at all possible.
     * 
     * By making agressive attempts to fix errors, technical support can be reduced for all parties.
     */
    public partial class SummaryForm : Form
    {
        /* The "preferred" serial device is the serial GPS device with the highest reliability.
         * This device is often used first by GPS.NET, and also is commonly used as the source
         * device for the GPS Intermediate Driver if it is supported.
         */
        SerialDevice preferredSerialDevice = null;

        /* The GPS Intermediate Driver (GPSID) is a multiplexer which allows many applications to
         * share the same GPS device.  This only works if all applications connect to the GPSID
         * "Program Port" (usually GPD1:) instead of the "Hardware Part" for the actual GPS device.
         * Some older mobile devices do not support the GPSID, in which case this variable will be null.
         */
        GpsIntermediateDriver gpsid = GpsIntermediateDriver.Current;

        /* Bluetooth GPS devices can be configured to use a "virtual serial port" in order to make them
         * available for third-party GPS applications.  This variable stores the preferred virtual serial 
         * device if one is detected.
         */
        SerialDevice preferredVirtualSerialDevice = null;

        // Statistics are used to get a high-level opinion of how well things are working
        int okCount = 0;
        int warningCount = 0;
        int errorCount = 0;

        public SummaryForm()
        {
            InitializeComponent();

            // Add images to our image lists
            imageList1.Images.Add(Program.Gps);
            imageList1.Images.Add(Program.Error);
            imageList1.Images.Add(Program.Warning);
            imageList1.Images.Add(Program.Ok);
            imageList2.Images.Add(Program.Gps);


            // Was any device detected?
            if (Devices.IsDeviceDetected)
            {
                // Yes.  Add all confirmed devices to a listview
                foreach (Device device in Devices.GpsDevices)
                {
                    AddDevice(device);

                    // Is this the GPS Intermediate Driver?  We only want plain serial devices, so skip it
                    GpsIntermediateDriver gpsidDevice = device as GpsIntermediateDriver;
                    if (gpsidDevice != null)
                        continue; 

                    // The "preferred" device is serial, but not the GPSID
                    SerialDevice serialDevice = device as SerialDevice;
                    if (serialDevice != null)
                        preferredSerialDevice = serialDevice;
                }

                // If we have more than two GPS devices, use a smaller ListView view
                if (Devices.GpsDevices.Count > 2)
                    gpsListView.View = View.SmallIcon;

                /* A GPS device was found.  Most third-party applications
                 * require a serial connection.  Is one available for them?
                 */
                if (preferredSerialDevice == null && (gpsid == null || !gpsid.IsGpsDevice))
                {
                    /* No.  GPS.NET can still work with Bluetooth, but for most end-users
                     * this can still be a problem.  They'll appreciate help with solving it.
                     */
                    AddWarning("Third-party GPS programs may have trouble connecting.", "ConfigureGpsid");
                }
            }
            else
            {
                // Show that no devices were found
                AddError("No GPS devices could be found.", "NoDevices");
            }

            // Let's make a summary of good things and bad things.
            if(gpsid != null)
            {
                // Was the GPS Intermediate Driver detected?
                if(gpsid.IsGpsDevice)
                {
                    // Make an item confirming the GPSID
                    AddMessage("Use the port \"" + gpsid.Port + "\" whenever possible for GPS programs.", "UseGpsidPort");
                }
                else
                {
                    // The GPSID may need to be configured properly.  Let's look at its settings
                    if (gpsid.HardwarePort != null)
                    {
                        if (preferredSerialDevice != null && gpsid.HardwarePort.Port.Equals(preferredSerialDevice.Port))
                        {
                            AddMessage("The GPS Intermediate Driver was reconfigured to use " + preferredSerialDevice.Name + " on " + preferredSerialDevice.Port + " at " + preferredSerialDevice.BaudRate.ToString() + " baud.", "GpsidReconfigured");
                            AddMessage("Use " + preferredSerialDevice.Port + " at " + preferredSerialDevice.BaudRate.ToString() + " baud for third-party GPS programs.", "ThirdPartyGpsPort");
                        }
                        else
                        {
                            AddWarning("The GPS Intermediate Driver is not working on " + gpsid.HardwarePort.Port + " at " + gpsid.HardwarePort.BaudRate.ToString() + " baud.", "GpsidIncorrectPort");

                            // The current hardware port isn't working, so let's suggest a working device
                            if (preferredSerialDevice != null)
                            {
                                AddWarning("Change the GPS Intermediate Driver to use " + preferredSerialDevice.Port + " at " + preferredSerialDevice.BaudRate.ToString() + " baud.", "GpsidFixHardwarePort");
                            }
                            else
                            {
                                // Do we have a Bluetooth device with a virtual port?
                                bool isVirtualPortFound = false;
                                foreach (BluetoothDevice bluetooth in Devices.BluetoothDevices)
                                {
                                    // Is this a Bluetooth GPS device?
                                    if (bluetooth.IsGpsDevice)
                                    {
                                        // Yes.  Does it also have a virtual serial port bound to it?
                                        if (bluetooth.VirtualSerialPort != null)
                                        {
                                            // Yes.
                                            preferredVirtualSerialDevice = bluetooth.VirtualSerialPort;
                                            isVirtualPortFound = true;

                                            AddWarning("Change the GPS Intermediate Driver to use the " + bluetooth.Name + " GPS device on "
                                                    + bluetooth.VirtualSerialPort.Port + " at " + bluetooth.VirtualSerialPort.BaudRate.ToString() + " baud.",
                                                    "GpsidUseVirtualBluetoothPort");
                                            break;
                                        }
                                    }
                                }

                                if (!isVirtualPortFound)
                                {
                                    // Do we have a BT device we could pair with?
                                    bool isBluetoothPossible = false;
                                    foreach (BluetoothDevice device in Devices.BluetoothDevices)
                                    {
                                        if (device.IsGpsDevice)
                                        {
                                            isBluetoothPossible = true;
                                            AddWarning("Use the Bluetooth Manager to create a virtual serial port for the " + device.Name + ".", "BluetoothCreateVirtualPort");
                                        }
                                    }

                                    if (!isBluetoothPossible)
                                    {
                                        AddError("No devices are available for the GPS Intermediate Driver.", "GpsidNoDevice");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // The GPSID may need to be configured
                AddWarning("The GPS Intermediate Driver is not supported.", "GpsidNotSupported");
            }

            // Is Bluetooth supported?
            if (!Devices.IsBluetoothSupported)
            {
                // Bluetooth is not supported
                AddWarning("Microsoft® Bluetooth is not supported on this device.", "BluetoothNotSupported");
            }
            else
            {
                // Is Bluetooth on?
                if (Devices.IsBluetoothEnabled)
                {
                    // Bluetooth is on
                    AddMessage("Bluetooth is on and working properly.", "BluetoothOk");
                }
                else
                {
                    // Bluetooth is off
                    AddWarning("Turn Bluetooth on.", "TurnBluetoothOn");
                }
            }

            // Let's look for devices which were previously detected, but not this time
            if (Devices.IsBluetoothSupported && Devices.IsBluetoothEnabled)
            {
                foreach (BluetoothDevice device in Devices.BluetoothDevices)
                {
                    if (device.SuccessfulDetectionCount != 0
                        && !device.IsGpsDevice)
                    {
                        // Here's a device which worked before, but not now
                        AddWarning("Turn the " + device.Name + " off and back on again.", "TurnDeviceOn");
                    }
                }
            }

            // Do we have a serial GPS device to use?
            if (preferredSerialDevice != null)
            {
                // Yes.  The port is different from the GPSID, so help the user know they have an alternative they can try.
                if (gpsid != null && gpsid.IsGpsDevice && !gpsid.Port.Equals(preferredSerialDevice.Port))
                {
                    AddMessage("Though less preferred, you can also use " + preferredSerialDevice.Port + " at " + preferredSerialDevice.BaudRate.ToString() + " baud for third-party GPS programs.", 
                        "AlternativeSerialPort");
                }               
            }
 
            // Were there any errors?
            if (errorCount > 0)
            {
                // Yes.  How many devices were found?
                if(Devices.GpsDevices.Count == 0)
                {
                    // None.
                    titleLabel.Text = "Errors Were Found";
                    descriptionLabel.Text = "Some problems were found.  Click on an error below to try and fix it.";
                }
                else
                {
                    // A device was found, so they can at least use GPS
                    titleLabel.Text = "Some Problems Were Found";
                    descriptionLabel.Text = "GPS is responding, but some problems were found, too.  Check out the suggestions below.";
                }
            }
            // Were any warnings encountered?
            else if (warningCount > 0)
            {
                // Yes.  
                titleLabel.Text = "Minor Problems Were Found";
                descriptionLabel.Text = "GPS is responding, but some things could be improved.  Check out the suggestions below.";
            }
            else
            {
                // No errors or warnings.  That's great!
                titleLabel.Text = "You Are Awesome";
                descriptionLabel.Text = "GPS is working properly and no problems were found.";
            }
        }

        private void gpsListView_ItemActivate(object sender, EventArgs e)
        {
            // Get the device
            ListViewItem selectedItem = gpsListView.Items[gpsListView.SelectedIndices[0]];
            Device selectedDevice = (Device)selectedItem.Tag;

            // And show a new form
            DeviceForm form = new DeviceForm();
            form.CurrentDevice = selectedDevice;
            form.Show();
        }

        private void menuFinish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuRestart_Click(object sender, EventArgs e)
        {
            // Restart the detection process
            DetectForm form = new DetectForm();
            form.Show();
            Close();
        }

        private void suggestionListView_ItemActivate(object sender, EventArgs e)
        {
            // What kind of suggestion is this?
            ListViewItem item = suggestionListView.Items[suggestionListView.SelectedIndices[0]];
            string command = Convert.ToString(item.Tag);

            switch (command)
            {
                case "ConfigureGpsid":
                    if(Devices.IsBluetoothSupported)
                        MessageBox.Show("No serial devices could be found.  You can \"pair\" a Bluetooth GPS device to give it a serial port for your software to use.", "Use a Bluetooth Device", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("No serial devices could be found.  If you have a GPS device to plug in to your PDA, plug it in now and try the scan again.", "Plug In a GPS Device", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    break;
                case "NoDevices":
                    MessageBox.Show("No GPS devices were found.  They may be turned off, out of range, or \"stuck open\".  If the device is on but shows a constant light, turn the device off then back on again.", "No Devices Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    break;
                case "UseGpsidPort":
                    MessageBox.Show("Using the GPS Intermediate Driver is preferred because it will share your GPS device with multiple applications.", "Share Your GPS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    break;
                case "WindowsMobileFirmware":
                    MessageBox.Show("The .NET Compact Framework is unable to connect to the GPS Intermediate Driver.  A firmware update for your device may resolve this issue.", "Update Your Firmware", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    break;
                case "ThirdPartyGpsPort":
                    MessageBox.Show("You can use the port \"" + preferredSerialDevice.Port + "\" and baud rate \"" + preferredSerialDevice.BaudRate.ToString() + "\" for your third-party GPS applications.", "Use " + preferredSerialDevice.Port, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    break;
                case "GpsidFixHardwarePort":
                case "GpsidIncorrectPort":
                    if (MessageBox.Show("Would you like to configure the GPS Intermediate Driver (GPSID) to use a better device?", "Update Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        // Update the setting
                        gpsid.HardwarePort = preferredSerialDevice;

                        // Restart the GPSID
                        gpsid.Restart();

                        if (MessageBox.Show("The GPSID has been updated to use \"" + preferredSerialDevice.Port + "\" at baud rate \"" + preferredSerialDevice.BaudRate.ToString() + "\".  Do you want to verify that it's working?", "Confirm Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            // Restart the scan
                            menuRestart_Click(this, EventArgs.Empty);
                        } 
                    }
                    break;
                case "GpsidUseVirtualBluetoothPort":
                    if (MessageBox.Show("Would you like to configure the GPS Intermediate Driver (GPSID) to use a better device?", "Update Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        // Update the setting
                        gpsid.HardwarePort = preferredVirtualSerialDevice;

                        // Restart the GPSID
                        gpsid.Restart();

                        if (MessageBox.Show("The GPSID has been updated to use \"" + preferredSerialDevice.Port + "\" at baud rate \"" + preferredSerialDevice.BaudRate.ToString() + "\".  Do you want to verify that it's working?", "Confirm Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            // Restart the scan
                            menuRestart_Click(this, EventArgs.Empty);
                        }
                    }
                    break;
                case "BluetoothCreateVirtualPort":
                    if (MessageBox.Show("Setting up a virtual serial port can make your Bluetooth GPS device available to programs.  Would you like to set this up now?", "Virtual Serial Port", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"\windows\ctlpnl.exe", "cplmain.cpl,23");
                    }
                    break;
                case "GpsidNoDevice":
                    MessageBox.Show("Your device supports sharing a GPS device with multiple applications, but no GPS devices were found.  Try hooking one up and running the scan again.", "No Devices Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    break;
                case "GpsidNotSupported":
                    MessageBox.Show("This device runs an older operating system.  You can take advantage of GPS device sharing if you upgrade to Windows Mobile 5.0 or later.", "Consider Upgrading", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    break;
                case "BluetoothNotSupported":
                    MessageBox.Show("The Bluetooth software on this device is not by Microsoft.  Everything may be working fine, but it limits the use of Bluetooth by some third-party applications.", "Other Bluetooth Stack", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    break;
                case "BluetoothOk":
                    MessageBox.Show("Microsoft® Bluetooth software was found on this device, which is good.", "Microsoft® Bluetooth", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    break;
                case "TurnBluetoothOn":
                    if (MessageBox.Show("Would you like to turn Bluetooth on now?", "Enable Bluetooth", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        // Enable Bluetooth
                        Devices.IsBluetoothEnabled = true;

                        // Was it actually enabled?
                        if (Devices.IsBluetoothEnabled)
                        {
                            if (MessageBox.Show("Bluetooth is now enabled.  Would you like to look for GPS devices again?", "Bluetooth Enabled", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                menuRestart_Click(this, EventArgs.Empty);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bluetooth could not be turned on.  You can turn Bluetooth on manually; look for a Bluetooth icon from the main Today screen, or from your Settings.", "Bluetooth Not Enabled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                    }
                    break;
                case "TurnDeviceOn":
                    MessageBox.Show("The device is a GPS device, but it may be turned off or \"stuck open.\"  Turn the device off then back on again.", "GPS Not Responding", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    break;
                case "AlternativeSerialPort":
                    MessageBox.Show("You should use \"" + gpsid.Port + "\" in your software, but you could also use \"" + preferredSerialDevice.Port + "\" at \"" + preferredSerialDevice.BaudRate.ToString() + "\" baud.", "Alternative GPS Device", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    break;
            }
        }

        private void AddDevice(Device device)
        {
            ListViewItem item = new ListViewItem(device.Name);
            item.ImageIndex = 0;
            item.Tag = device;
            gpsListView.Items.Add(item);
        }

        private void AddError(string message, string tag)
        {
            ListViewItem item = new ListViewItem(message);
            item.ImageIndex = 1;
            item.Tag = tag;
            suggestionListView.Items.Add(item);
            errorCount++;
        }

        private void AddWarning(string message, string tag)
        {
            ListViewItem item = new ListViewItem(message);
            item.ImageIndex = 2;
            item.Tag = tag;
            suggestionListView.Items.Add(item);
            warningCount++;
        }

        private void AddMessage(string message, string tag)
        {
            ListViewItem item = new ListViewItem(message);
            item.ImageIndex = 3;
            item.Tag = tag;
            suggestionListView.Items.Add(item);
            okCount++;
        }
    }
}