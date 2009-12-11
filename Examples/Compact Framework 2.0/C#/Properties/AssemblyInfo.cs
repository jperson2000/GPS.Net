using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GeoFramework.Licensing;


// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("GPS Diagnostics")]
[assembly: AssemblyDescription("Searches for GPS devices and helps solve connectivity issues.")]
[assembly: AssemblyConfiguration("Public Release")]
[assembly: AssemblyCompany("GeoFrameworks, LLC")]
[assembly: AssemblyProduct("GPS Diagnostics")]
[assembly: AssemblyCopyright("This utility is released to the public domain.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("6d4e0d84-acc5-4fbc-a48b-33031dd1b340")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.1.*")]

// Below attribute is to suppress FxCop warning "CA2232 : Microsoft.Usage : Add STAThreadAttribute to assembly"
// as Device app does not support STA thread.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")]
