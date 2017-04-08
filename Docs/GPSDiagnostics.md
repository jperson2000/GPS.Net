## GPS Diagnostics for .NET

[GPS Diagnostics Screen Shots](ScreenShots.md#GPS-Diagnostics)

GPS.NET 3.0 includes source code for a project which is used to detect and resolve common GPS connectivity issues.  After running GeoFrameworks for four years, I found that customers ran into a small list of connectivity issues:

- Users' Windows Mobile 5.0+ devices frequently have incorrect GPS Intermediate Driver settings.

- Users are unaware that Bluetooth is turned off, or do not know how to configure a virtual serial port for their GPS device.

During the development of GPS.NET 3.0, I wanted to try and minimize common connectivity issues, and this utility is the result.  Built using GPS.NET 3.0, the utility will scan the local machine for GPS devices then make suggestions on what could be improved.  Suggestions are in clear English and can be clicked to attempt a fix.  This utility can:

- Configure the GPS Intermediate Driver to correct COM: port and baud rate settings.

- Detect when Microsoft Bluetooth is installed but turned off.

- Suggest ideal COM port and baud rate settings to use.

- Recommend one device as "most reliable" when multiple devices are detected.

- Generate log files which can (with some tweaking of code) be sent to you for further study.

The source code for this utility is provided in both C# and VB.NET for .NET Framework 2.0/3.5 and .NET Compact Framework 2.0/3.5.  It can be found in the "Examples" folder.
