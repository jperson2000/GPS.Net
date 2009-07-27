using System;

namespace GeoFramework.Gps.Filters
{
    public abstract class PrecisionFilter
    {
        #region Static Members

        private static KalmanFilter _defaultFilter = new KalmanFilter();

        public static KalmanFilter Default
        {
            get { return _defaultFilter; }
        }

        #endregion

        public Position ObservedPosition { get { return new Position(ObservedLocation.Latitude, ObservedLocation.Longitude); } }

        public Position FilteredPosition { get { return new Position(FilteredLocation.Latitude, FilteredLocation.Longitude); ; } }

        public abstract Position3D ObservedLocation { get; }

        public abstract Position3D FilteredLocation { get; }

        public abstract bool IsInitialized { get; }

        public abstract TimeSpan Delay { get; }

        public abstract void Initialize(Position gpsPosition);

        public abstract void Initialize(Position3D gpsPosition);

        public abstract Position Filter(Position gpsPosition);

        public abstract Position Filter(Position gpsPosition, Distance deviceError, DilutionOfPrecision horizontalDOP, DilutionOfPrecision verticalDOP, Azimuth bearing, Speed speed);

        public abstract Position3D Filter(Position3D gpsPosition);

        public abstract Position3D Filter(Position3D gpsPosition, Distance deviceError, DilutionOfPrecision horizontalDOP, DilutionOfPrecision verticalDOP, Azimuth bearing, Speed speed);
    }
}
