Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("SmartDeviceProject2")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("Microsoft")>
<Assembly: AssemblyProduct("SmartDeviceProject2")>
<Assembly: AssemblyCopyright("Copyright © Microsoft 2009")>
<Assembly: AssemblyTrademark("")>

<Assembly: CLSCompliant(False)> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("adc469a2-a1d2-425b-91a3-7be6e09e5200")>

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

<Assembly: AssemblyVersion("1.0.0.0")>

'Below attribute is to suppress FxCop warning "CA2232 : Microsoft.Usage : Add STAThreadAttribute to assembly"
' as Device app does not support STA thread.
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")>
