using System;
using System.Windows.Forms;

namespace Diagnostics
{
    public partial class MainForm : Form
    {
        /* This form serves as a splash screen for the diagnostics utility.  The user
         * can click "Next" to launch the detection form (DetectForm), or "Cancel"
         * to exit the utility.
         */

        public MainForm()
        {
            InitializeComponent();
            
            // Set the splash screen to use the GPS icon
            pictureBox1.Image = Program.Gps;
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            // Launch the device detection form
            DetectForm form = new DetectForm();
            form.Show();
        }

        private void menuCancel_Click(object sender, EventArgs e)
        {
            // Exit the utility
            Application.Exit();
        }
    }
}