using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GeoFramework.Gps;
using GeoFramework.Gps.IO;

namespace Diagnostics
{
    /* This form performs a search for GPS devices using the GPS.NET 3.0 "Devices" class.
     * This class provides several events which report on the progress of GPS device detection,
     * including the device being tested, as well as any errors reported.
     */

    public partial class DetectForm : Form
    {
        public DetectForm()
        {
            InitializeComponent();

            // Show the form
            Show();
            Application.DoEvents();

            /* The detection process typically requires about 45-60 seconds to complete.  This
             * will be faster if Bluetooth is not enabled on the system.
             */
            Cursor.Current = Cursors.WaitCursor;

            /* Hook into GPS device detection events.  These events are static, allowing them to
             * be easily sunk by any other class or form.
             */
            Devices.DeviceDetectionStarted += new EventHandler(Devices_DeviceDetectionStarted);
            Devices.DeviceDetectionCompleted += new EventHandler(Devices_DeviceDetectionCompleted);
            Devices.DeviceDetected += new EventHandler<DeviceEventArgs>(Devices_DeviceDetected);
            Devices.DeviceDetectionAttempted += new EventHandler<DeviceEventArgs>(Devices_DeviceDetectionAttempted);
            Devices.DeviceDetectionAttemptFailed += new EventHandler<DeviceDetectionExceptionEventArgs>(Devices_DeviceDetectionAttemptFailed);

            // Add commonly-used graphics to the image list
            imageList1.Images.Add(Program.Question);
            imageList1.Images.Add(Program.Gps);
            imageList1.Images.Add(Program.Error);
            imageList1.Images.Add(Program.Warning);

            /* Start looking for GPS devices.  The "Diagnostics" class is new to GPS.NET 3.0
             * and provides a way for developers to quickly troubleshoot and log common connectivity issues.
             * The Diagnostics class performs a detection, generates a log file, and provides suggestions
             * on what can be done to improve GPS connectivity.  The idea here is that end-users can
             * generate a log file, send it to you, and from the log you can quickly provide helpful
             * tech support with minimal effort.
             */
            GeoFramework.Gps.Diagnostics.Run(new StreamWriter("GPS Diagnostics Log.txt"));
        }

        #region Menus

        private void menuCancel_Click(object sender, EventArgs e)
        {
            /* Device detection can be canceled at any time.  Show a message box to
             * make sure they didn't click the Cancel menu by accident.
             */

            // If the menu says "View Log" then open the log file
            if (menuCancel.Text == "View Log")
            {
                // Create a new form for the log
                LogForm form = new LogForm();
                form.Title = "GPS Device Detection Log";
                form.Device = null;

                // Read the entire contents of the log file
                StreamReader reader = File.OpenText("GPS Diagnostics Log.txt");
                form.Body = reader.ReadToEnd();
                reader.Close();

                form.Show();
                Application.DoEvents();
                return;
            }
            else
            {
                // Do they really want to cancel?
                if (MessageBox.Show("Do you want to stop searching for devices?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // Reset the cursor
                    Cursor.Current = Cursors.Default;
                    Application.DoEvents();
                    
                    // And close this form
                    Close();

                    // Yes.  Cancel device detection
                    Devices.CancelDetection();
                }
            }
        }

        private void menuNext_Click(object sender, EventArgs e)
        {
            /* After detection completes, we can summarize all of the devices detected
             * and provide some suggestions if any problems were found.  Show the summary
             * form (SummaryForm)
             */
            SummaryForm ok = new SummaryForm();
            ok.Show();

            // Close this form
            Close();
        }

        #endregion

        #region Displaying devices
        
        private void devicesListView_ItemActivate(object sender, EventArgs e)
        {
            /* The user can click on any listview item to display more information about
             * a device.  They can also connect to the device and see which features it
             * supports to make sure it's working properly.
             */

            // Which item was selected?
            ListViewItem selectedItem = devicesListView.Items[devicesListView.SelectedIndices[0]];

            // Get the device object associatede with this listview item
            Device selectedDevice = (Device)selectedItem.Tag;

            // Make a new device information form
            DeviceForm form = new DeviceForm();

            // Tell it to use this device
            form.CurrentDevice = selectedDevice;

            // And show it
            form.Show();
        }

        #endregion

        #region GPS Device Detection Events

        private void Devices_DeviceDetectionAttempted(object sender, DeviceEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate()
            {
                // Add the device
                AddDevice(e.Device);

                // Update the log
                Log("Testing " + e.Device.Name + "...");
            }));
        }

        private void AddDevice(Device device)
        {
            /* This method is called by the events DeviceDetectionAttempted and DeviceDiscovered.
             * A new item is added to the ListView.
             */

            // Create a new item
            ListViewItem item = new ListViewItem(device.Name);
            item.ImageIndex = 0;

            /* Link the item to the Device it represents.  We'll use this property later when
             * we have results on whether or not detection succeeded for this device.
             */
            item.Tag = device;

            /* GPS.NET supports many kinds of devices.  Classes such as BluetoothDevice and SerialDevice
             * inherit from the Device base class.  Try casting the device as one of these other types
             * so we can get more information.
             */
            BluetoothDevice bluetoothDevice = device as BluetoothDevice;
            SerialDevice serialDevice = device as SerialDevice;
            GpsIntermediateDriver gpsid = device as GpsIntermediateDriver;

            // Is this a Bluetooth device?
            if (bluetoothDevice != null)
            {
                // Yes.  Show the device's address
                item.SubItems.Add("Bluetooth (" + bluetoothDevice.Address.ToString() + ")");
            }
            // Is this the GPS Intermediate Driver (GPSID)?
            else if (gpsid != null)
            {
                // Yes.  Show its "program port," the port which all applications should use
                item.SubItems.Add("Multiplexer (" + gpsid.Port + ")");
            }
            // Is this a serial device?
            else if (serialDevice != null)
            {
                // Yes.  Show the device's serial port
                item.SubItems.Add("Serial (" + serialDevice.Port + ")");
            }          

            // Add a status message for this device
            item.SubItems.Add("Testing...");

            // Finally, add the item to the list view
            devicesListView.Items.Add(item);
        }

        private void Devices_DeviceDetectionAttemptFailed(object sender, DeviceDetectionExceptionEventArgs e)
        {
            /* This event gets raised any time an attempt to test a device for GPS data has failed.
             * Failures can occur for many reasons.  The device may be powered off or the device may not
             * qualify for testing at all.  Some devices such as computers will not be tested.
             * 
             * When a failure occurs, the device is colored red (or yellow), and its icon is changed.
             */
            BeginInvoke(new MethodInvoker(delegate()
            {
                // Look through the listview for the device
                foreach (ListViewItem item in devicesListView.Items)
                {
                    /* The Tag property stores a Device object.  Check to see if the
                     * device matches the device which just failed.  Do we have a match?
                     */
                    if (object.ReferenceEquals(item.Tag, e.Device))
                    {
                        // Yes.  The device failed, but has it ever been successfully detected before?
                        if (e.Device.SuccessfulDetectionCount > 0)
                        {
                            /* It has been detected, so it's a GPS device.  It's just not working right now.
                             * Change the icon to a "warning" and color it yellow.
                             */
                            item.ImageIndex = 3;
                            item.ForeColor = Color.DarkGoldenrod;
                        }
                        else
                        {
                            // The device has never been confirmed as a GPS device.  Color it red.
                            item.ImageIndex = 2;
                            item.ForeColor = Color.Red;
                        }

                        // Set the third column of the listview item to the error message
                        item.SubItems[2].Text = e.Exception.Message;

                        // Update the log with the message
                        Log(e.Device.Name + ": " + e.Exception.Message);
                        return;
                    }
                }
            }));
        }

        private void Devices_DeviceDiscovered(object sender, DeviceEventArgs e)
        {
            /* This event will get raised if a Bluetooth device has just been found.  Bluetooth
             * needs several seconds to locate nearby wireless devices; as a result, a device may
             * not be discovered until several seconds into the device detection process.
             */
            BeginInvoke(new MethodInvoker(delegate()
            {
                Log(e.Device.Name + " has been discovered.");
            }));
        }

        private void Devices_DeviceDetected(object sender, DeviceEventArgs e)
        {
            /* This event is raised when a device has been confirmed as a GPS device.  The
             * listview item is colored green and it's icon is set to a GPS device icon.
             */
            BeginInvoke(new MethodInvoker(delegate()
            {
                // Change the main form label to indicate success.
                titleLabel.Text = "A GPS Device Was Found.";

                // Update the log to show the success
                Log(e.Device.Name + " is a GPS device.");

                // Look through the listview for the device
                foreach (ListViewItem item in devicesListView.Items)
                {
                    /* The Tag property stores a Device object.  Check to see if the
                     * device matches the device which just failed.  Do we have a match?
                     */
                    if (object.ReferenceEquals(item.Tag, e.Device))
                    {
                        // Yes.  Update its color and icon
                        item.ImageIndex = 1;
                        item.ForeColor = Color.DarkGreen;

                        // In the third column, indicate that the device is working properly
                        item.SubItems[2].Text = "GPS is working properly";
                        return;
                    }
                }
            }));
        }

        private void Devices_DeviceDetectionCompleted(object sender, EventArgs e)
        {
            /* This event is raised when all known devices have been tested.  At this point,
             * we have enough information to look for problems and make intelligent suggestions
             * on how to resolve them.
             */
            BeginInvoke(new MethodInvoker(delegate()
            {
                // Change the cursor back to normal
                Cursor.Current = Cursors.Default;

                // Update the main form label to show that the search is over
                titleLabel.Text = "Search Complete.";
                description.Text = "Tap \"Next\" to view suggestions and a summary of devices.";                

                // Update the log to show that the search has completed
                Log("Device detection has completed.");

                // Enable the Next button, letting them continue to the summary form
                menuNext.Enabled = true;

                // Change "Cancel" to "View Log"
                menuCancel.Text = "View Log";
                menuCancel.Enabled = true;
            }));
        }

        private void Devices_DeviceDetectionStarted(object sender, EventArgs e)
        {
            /* This event is raised when the GPS device detection thread has started.
             * No devices have been tested yet, but it will start immediately after this event.
             */
            BeginInvoke(new MethodInvoker(delegate()
            {
                // Enable the Cancel menu
                menuCancel.Enabled = true;

                // Show that detection has been started
                Log("Device detection has started.");
            }));
        }

        #endregion

        private void Log(string message)
        {
            /* This method is called by various events in the form.  A message is added to a
             * ListBox, and its index is set to the last item to ensure that the new item is visible.
             */
            logBox.Items.Add(message);
            logBox.SelectedIndex = logBox.Items.Count - 1;
        }
    }
}