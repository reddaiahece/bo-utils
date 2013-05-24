using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System;
using System.IO;

[assembly: AssemblyTitle("BOUtils Library")]
[assembly: AssemblyDescription("BusinessObjectsUtils Type Library")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Florent Breheret")]
[assembly: AssemblyProduct("BOUtilsLibrary")]
[assembly: AssemblyCopyright("Copyright © Florent Breheret 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: Guid("9D089266-3BC1-4175-B0FE-BA080F13925E")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.1.3")]
[assembly: AssemblyFileVersion("1.0.1.3")]

namespace BusinessObjectsUtils
{
    [Guid("1E067DAB-20B8-48E4-8982-909197B0D6EB"), ComVisible(true)]
    public interface IAssembly
    {
        [Description("Get the assembly version")]
        string GetVersion();
        string GetFolder();
        string GetHelpFile();
    }

    [Description("Class to get informations about the regitered assembly"), ProgId("BusinessObjectsUtils.Assembly")]
    [Guid("CF9A6379-884C-4D21-B456-ACAB50BD0A17"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class Assembly : IAssembly
    {
        public string GetVersion()
        {
            try{
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }catch (Exception){
                return null;
            }
        }
    
        public string GetFolder()
        {
            try{
                return Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            }catch (Exception){
                return null;
            }
        }
    
        public string GetHelpFile()
        {
            try{
                return Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName + @"\help.chm";
            }catch (Exception){
                return null;
            }
        }

    }
}
