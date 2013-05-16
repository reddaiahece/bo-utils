[assembly: System.Reflection.AssemblyDescription("BO-Utils12")]

namespace BOUtilsAddin
{
	using System;
	using Extensibility;
	using System.Runtime.InteropServices;
    using Core = Microsoft.Office.Core;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;

    [GuidAttribute("6219167D-F8AF-41B1-B9D9-172D298EC2F2"), ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IConnect12 : IConnect, Core.IRibbonExtensibility
    {
        void Ribbon_Load(Core.IRibbonUI ribbonUi);
        bool GetTabVisible(Core.IRibbonControl control);
        Bitmap GetLoginImage(Core.IRibbonControl control);
        string GetLoginLabel(Core.IRibbonControl control);
        Bitmap GetImage(string imageName);
        bool GetEnabled(Core.IRibbonControl control);
        void OnClick(Core.IRibbonControl control);
    }

	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
    [GuidAttribute("CB9AD7C2-DBA2-4CEB-BD80-50B23D4284F7"), ProgId("BOUtilsAddin.Connect"), ComVisible(true), ComDefaultInterface(typeof(IConnect12)), ClassInterface(ClassInterfaceType.None)]
    public class Connect12 : Connect, IConnect12
	{
        private Core.IRibbonUI _ribbon;
        private bool _tabVisible;
        private System.Drawing.Bitmap _imgLogin;
        private System.Drawing.Bitmap _imgLogout;

		public Connect12() {

		}

        public override void OnWorkbookActivate(Excel.Workbook Wb) {
            try{
                _tabVisible = false;
                if (Wb == null)
                    return;
                if (Wb == null)
                    _tabVisible = false;
                else if (_commandList.ContainsKey(Wb)) {
                    _commands = _commandList[Wb];
                    _tabVisible = true;
                } else if (IsTemplateWb(Wb)) {
                    _commands = new WorkbookInstance(_excelapp, Wb);
                    _commands.OnLogInOut += OnLogInOut;
                    Wb.BeforeClose += _commands.OnWorkbookClose;
                    Wb.BeforeClose += OnWorkbookClose;
                    _commandList.Add(Wb, _commands);
                    _tabVisible = true;
                }
                if (_ribbon != null)
                    _ribbon.Invalidate();
            } catch (Exception ex) { new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, ex).ShowDialog(); }
        }

        public void OnWorkbookClose(ref bool Cancel) {
            _tabVisible = false;
            _ribbon.Invalidate();
        }

        public void OnLogInOut() {
            _ribbon.Invalidate();
        }

        public void Ribbon_Load(Core.IRibbonUI ribbonUi) {
            _ribbon = ribbonUi;
        }

        string Core.IRibbonExtensibility.GetCustomUI(string ribbonId) {
            return Properties.Resources.Ribbon;
        }

        public bool GetTabVisible(Core.IRibbonControl control) {
            return _tabVisible;
        }

        public System.Drawing.Bitmap GetLoginImage(Core.IRibbonControl control) {
            if (_imgLogin == null) {
                _imgLogin = Properties.Resources.login;
                _imgLogout = Properties.Resources.logout;
                _imgLogin.MakeTransparent(System.Drawing.Color.Magenta);
                _imgLogout.MakeTransparent(System.Drawing.Color.Magenta);
            }
            if (_commands == null || _commands.IsLoggedIn == false)
                return _imgLogin;
            return _imgLogout;
        }

        public string GetLoginLabel(Core.IRibbonControl control) {
            if(_commands == null || _commands.IsLoggedIn == false)
                return "Login";
            return "Logout";
        }

        public System.Drawing.Bitmap GetImage(string imageName) {
            var bitmap = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
            if (bitmap == null) return null;
            bitmap.MakeTransparent(System.Drawing.Color.Magenta);
            return bitmap;
        }

        public bool GetEnabled(Core.IRibbonControl control) {
            return _commands != null && _commands.IsLoggedIn;
        }

        public void OnClick(Core.IRibbonControl control) {
            if(_commands == null)
                return;
            _commands.OnActionInvoked(control.Id);
        }

    }
}