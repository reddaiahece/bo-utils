using System;
using System.Collections.Generic;
using Core = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace BOUtilsAddin
{

    public interface IConnect : Extensibility.IDTExtensibility2
    {

    }

    public class Connect : Object, IConnect
    {
        internal Excel.Application _excelapp;
        internal object _addInInstance;
        internal WorkbookInstance _commands;
        internal Dictionary<Excel.Workbook, WorkbookInstance> _commandList;

		public Connect() {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
            System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += (sender, ex) => new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, (Exception)ex.ExceptionObject).ShowDialog();
            System.Windows.Forms.Application.ThreadException += (sender, ex) => new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, (Exception)ex.Exception).ShowDialog();
        }

        private System.Reflection.Assembly MyResolveEventHandler(object sender, ResolveEventArgs args) {
            string name = args.Name.Substring(0, args.Name.IndexOf(','));
            foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (assembly.FullName.StartsWith(name)) return assembly;
            return null;
        }

        public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom) {
            if (application is Excel.Application) {
                _excelapp = (Excel.Application)application;
                _addInInstance = addInInst;
                _commandList = new Dictionary<Excel.Workbook, WorkbookInstance>();
                _excelapp.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(OnWorkbookActivate);
                OnWorkbookActivate(_excelapp.ActiveWorkbook);
            }
        }

        internal bool IsTemplateWb(Excel.Workbook Wb) {
            if (Wb == null || (Core.DocumentProperties)Wb.CustomDocumentProperties == null) return false;
            foreach (Core.DocumentProperty property in (Core.DocumentProperties)Wb.CustomDocumentProperties)
                if (property.Name == "TemplateId" && property.Value is string && (string)property.Value == "CB9AD7C2")
                    return true;
            return false;
        }

        public virtual void OnWorkbookActivate(Excel.Workbook Wb) {

        }

        public void OnAddInsUpdate(ref Array custom) {

        }

        public void OnBeginShutdown(ref Array custom) {

        }

        public void OnDisconnection(Extensibility.ext_DisconnectMode RemoveMode, ref Array custom) {

        }

        public void OnStartupComplete(ref Array custom) {

        }
    }
}
