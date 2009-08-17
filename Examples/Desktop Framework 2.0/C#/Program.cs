using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GeoFramework;
using GeoFramework.Shapes;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static Distance Perimeter(Polygon polygon)
        {
            Distance result = Distance.Empty;

            // Is this a line or a point?  If so, complain
            if (polygon.Count < 3)
                return Distance.Empty;

            // We have multiple points.  Get the distance for each segment
            for (int i = 0; i < polygon.Count - 2; i++)
                result = result.Add(polygon[i].DistanceTo(polygon[i + 1]));

            // Finally, add the distance of the segment from the last to the first point
            result = result.Add(polygon[0].DistanceTo(polygon[polygon.Count - 1]));

            // Return the result
            return result.ToLocalUnitType();
        }

        public static void TestSquare()
        {
            Polygon poly = new Polygon();
            poly.Add(new Position("36.60987854N,88.30194711W"));
            poly.Add(new Position("36.60989999N,88.30430746W"));
            poly.Add(new Position("36.60797953N,88.30428600W"));
            poly.Add(new Position("36.60796880N,88.30190420W"));

            // Built-in formula
            Console.WriteLine("GeoFrameworks new calc: " + poly.Perimeter.ToString());
            // Custom formula
            Console.WriteLine("GeoFrameworks old calc: " + Perimeter(poly));
        }
    }
}
