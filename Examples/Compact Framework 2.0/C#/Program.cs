using System;
using System.Drawing;
using System.Windows.Forms;

namespace Diagnostics
{
    /* The GPS Diagnostics utility can help you and your customers to quickly identify and troubleshoot
     * connectivity issues related to GPS devices.  This source code is free for you to modify and redistribute
     * as you see fit; the only requirement is that this assembly needs to use your purchased license keys
     * in order to be redistributed.
     */

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            // Run the application
            Application.Run(new MainForm());
        }

        #region Frequenly-Used Images

        /* This utility uses the same graphics across multiple forms.  To minimize the size
         * of the executable, these images are reused.
         */

        public static Bitmap Gps = Properties.Resources.Gps;
        public static Bitmap Warning = Properties.Resources.Warning;
        public static Bitmap Error = Properties.Resources.Error;
        public static Bitmap Ok = Properties.Resources.Ok;
        public static Bitmap Question = Properties.Resources.Question;
        public static Bitmap Computer = Properties.Resources.Computer;

        #endregion
    }
    
    /* The GPS.NET device detection process is multithreaded.  As a result, we must
     * use the Invoke and BeginInvoke methods to ensure that any updates to the form
     * occur on the form's own thread.  This delegate is used by such methods.
     */
    public delegate void MethodInvoker();

}