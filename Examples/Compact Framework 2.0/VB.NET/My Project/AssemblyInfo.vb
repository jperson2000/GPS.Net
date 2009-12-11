Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("GPS Diagnostics")> 
<Assembly: AssemblyDescription("Searches for GPS devices and helps solve connectivity issues.")> 
<Assembly: AssemblyConfiguration("Public Release")> 
<Assembly: AssemblyCompany("GeoFrameworks, LLC")> 
<Assembly: AssemblyProduct("GPS Diagnostics")> 
<Assembly: AssemblyCopyright("This utility is released to the public domain.")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: AssemblyCulture("")> 

<Assembly: CLSCompliant(False)> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("b4d0b849-5b8d-46f0-b202-abbb17cac581")>

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")>

<Assembly: AssemblyVersion("1.0.1.*")>

'Below attribute is to suppress FxCop warning "CA2232 : Microsoft.Usage : Add STAThreadAttribute to assembly"
' as Device app does not support STA thread.
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")>
