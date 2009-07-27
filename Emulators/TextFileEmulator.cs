using System;
using System.Text;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace GeoFramework.Gps.Emulators
{
    public class TextFileEmulator : Emulator 
    {
        private string _FilePath;
        private StreamReader _Reader;
        private TimeSpan _ReadInterval;

        public TextFileEmulator(string filePath)
            : this(filePath, TimeSpan.FromSeconds(400))
        {}

        public TextFileEmulator(string filePath, TimeSpan readInterval)
        {
            _FilePath = filePath;
            _ReadInterval = readInterval;
        }

        public TimeSpan ReadInterval
        {
            get { return _ReadInterval; }
            set { _ReadInterval = value; }
        }

        protected override void OnEmulation()
        {
            // Are we at the end of the file?
            if (_Reader == null || _Reader.EndOfStream)
            {
                // Yes.  Re-open it from the beginning
                FileStream stream = new FileStream(_FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                _Reader = new StreamReader(stream);
            }

            // Read a line from the file
            string line = _Reader.ReadLine();

            // Don't write to the buffer if it's full
            if (ReadBuffer.Count + line.Length > ReadBuffer.Capacity)
                return;

            // Write the string
            ReadBuffer.AddRange(ASCIIEncoding.ASCII.GetBytes(line));

            // Sleep
            Thread.Sleep(_ReadInterval);
        }

        // TODO: We should be able to get rid of this. Not used internally anymore.
        //public override Emulator Clone()
        //{
        //    // Return a copy of this emulator
        //    return new TextFileEmulator(_FilePath);
        //}
    }
}
