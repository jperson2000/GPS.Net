using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GeoFramework.Gps
{
    /// <summary>
    /// Represents a base class for designing GPS data packets.
    /// </summary>
    public abstract class Packet : IFormattable
    {
        #region Licensing

        static Packet() { LicenseRoot.Activate(); }

        #endregion

        #region Abstract Properties

        /// <summary>
        /// Returns whether the pack data is well-formed.
        /// </summary>
        public abstract bool IsValid { get; }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Converts the packet into an array of bytes.
        /// </summary>
        /// <returns></returns>
        public abstract byte[] ToByteArray();

        #endregion

        #region Overrides

        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        #endregion

        #region IFormattable Members

        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            return base.ToString();
        }

        #endregion
    }
}
