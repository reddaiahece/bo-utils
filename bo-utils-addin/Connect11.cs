[assembly: System.Reflection.AssemblyDescription("BO-Utils11")]

namespace BOUtilsAddin
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Xml;
    using Core = Microsoft.Office.Core;
    using Excel = Microsoft.Office.Interop.Excel;

    [GuidAttribute("CB9AD7C2-DBA2-4CEB-BD80-50B23D4284F7"), ProgId("BOUtilsAddin.Connect"), ComVisible(true), ComDefaultInterface(typeof(IConnect)), ClassInterface(ClassInterfaceType.None)]
    public class Connect11 : Connect
	{
        private Dictionary<string, Core.CommandBarButton> _buttons;
        private Core.CommandBarPopup _btTab;

		public Connect11() {

        }
        
        public override void OnWorkbookActivate(Excel.Workbook Wb) {
            try {
                if (_btTab != null)
                    _btTab.Visible = false;
                if(Wb==null)
                    _btTab.Visible = false;
                else if (_commandList.ContainsKey(Wb)) {
                    _commands = _commandList[Wb];
                    _btTab.Visible = true;
                } else if (IsTemplateWb(Wb)) {
                    _commands = new WorkbookInstance(_excelapp, Wb);
                    _commands.OnLogInOut += OnLogInOut;
                    Wb.BeforeClose += _commands.OnWorkbookClose;
                    Wb.BeforeClose += OnWorkbookClose;
                    _commandList.Add(Wb, _commands);
                    if (_btTab == null) {
                        try {
                            _excelapp.ScreenUpdating = false;
                            var xmldoc = new XmlDocument();
                            xmldoc.LoadXml(Properties.Resources.Ribbon);
                            _buttons = AddCommandBarButtons(xmldoc.DocumentElement.FirstChild.FirstChild.ChildNodes);
                        } catch (Exception) { throw; } finally {
                            _excelapp.ScreenUpdating = true;
                        }
                    }
                    _btTab.Visible = true;
                }
            }catch(Exception ex){ new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, ex).ShowDialog(); }
        }

        public void OnWorkbookClose(ref bool Cancel) {
            _btTab.Visible = false;
        }

        public void OnLogInOut() {
            var btLogin = _buttons["btLogin_Click"];
            var imgname = GetLoginImage();
            btLogin.Caption = GetLoginLabel();
            btLogin.Picture = GetPicture(imgname);
            btLogin.Mask = GetPicture(imgname + "_msk");
            _buttons["btGetList_Click"].Enabled = GetEnabled();
            _buttons["btSchedule_Click"].Enabled = GetEnabled();
            _buttons["btRefresh_Click"].Enabled = GetEnabled();
            _buttons["btDownload_Click"].Enabled = GetEnabled();
            _buttons["btClean_Click"].Enabled = GetEnabled();
        }

        public string GetLoginImage() {
            if (_commands == null || _commands.IsLoggedIn == false)
                return "login16";
            return "logout16";
        }

        public string GetLoginLabel() {
            if (_commands == null || _commands.IsLoggedIn == false)
                return "Login";
            return "Logout";
        }

        public System.Drawing.Bitmap GetImage(string imageName) {
            var bitmap = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
            if (bitmap == null) return null;
            bitmap.MakeTransparent(System.Drawing.Color.Magenta);
            return bitmap;
        }

        public bool GetEnabled() {
            return _commands != null && _commands.IsLoggedIn;
        }

        private Dictionary<string, Core.CommandBarButton> AddCommandBarButtons(XmlNodeList nodes) {
            Dictionary<string, Core.CommandBarButton> buttons = new Dictionary<string, Core.CommandBarButton>();
            AddCommandBarButtons_recursive(nodes, buttons, null, false);
            return buttons;
        }

        private void AddCommandBarButtons_recursive(XmlNodeList nodes, Dictionary<string, Core.CommandBarButton> buttons, Core.CommandBarPopup cmdbar, bool beginGroup) {
            if (nodes == null) return;
            foreach (XmlNode node in nodes) {
                var nodeName = node.Name;
                string nodeLabel = string.Empty;
                var labelAtt = node.Attributes["label"];
                if (labelAtt != null) 
                    nodeLabel = labelAtt.Value;
                else {
                    var getlabelAtt = node.Attributes["getLabel"];
                    if (getlabelAtt != null)
                        nodeLabel = (string)typeof(Connect11).GetMethod(getlabelAtt.Value).Invoke(this, null);
                }
                switch(nodeName){
                    case "tab" :
                        var oCommandBars = (Core.CommandBars)_excelapp.GetType().InvokeMember("CommandBars", BindingFlags.GetProperty, null, _excelapp, null);
                        _btTab = (Core.CommandBarPopup)oCommandBars["Worksheet Menu Bar"].Controls.Add(Core.MsoControlType.msoControlPopup, Type.Missing, Type.Missing, Type.Missing, true);
                        _btTab.Caption = nodeLabel;
                        AddCommandBarButtons_recursive(node.ChildNodes, buttons, _btTab, false);
                        break;
                    case "group" :
                        AddCommandBarButtons_recursive(node.ChildNodes, buttons, cmdbar, true);
                        break;
                    case "menu" :
                        var btMenu = (Core.CommandBarPopup)cmdbar.Controls.Add(Core.MsoControlType.msoControlPopup, Type.Missing, Type.Missing, Type.Missing, true);
                        btMenu.Caption = nodeLabel;
                        if (beginGroup) {
                            btMenu.BeginGroup = true;
                            beginGroup = false;
                        }
                        AddCommandBarButtons_recursive(node.ChildNodes, buttons, btMenu, false);
                        break;
                    case "button" :
                        var nodeId = node.Attributes["id"].Value;
                        Core.CommandBarButton bt = (Core.CommandBarButton)cmdbar.Controls.Add(Core.MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);
                        buttons.Add(nodeId, bt);
                        bt.Caption = nodeLabel;
                        string imgName = null;
                        var imageAtt = node.Attributes["image"];
                        if (imageAtt != null)
                            imgName = imageAtt.Value;
                        else{
                            var getimageAtt = node.Attributes["getImage"];
                            if (getimageAtt != null)
                                imgName = (string)typeof(Connect11).GetMethod(getimageAtt.Value).Invoke(this, null);
                        }
                        if (imgName != null) {
                            var image = GetPicture(imgName);
                            if (image != null)
                                bt.Picture = image;
                            var imagemsk = GetPicture(imgName + "_msk");
                            if (imagemsk != null)
                                bt.Mask = imagemsk;
                        }
                            
                        var enabledAtt = node.Attributes["enabled"];
                        if (enabledAtt != null)
                            bt.Enabled = bool.Parse(enabledAtt.Value);
                        else {
                            var getenabledAtt = node.Attributes["getEnabled"];
                            if (getenabledAtt != null)
                                bt.Enabled = (bool)typeof(Connect11).GetMethod(getenabledAtt.Value).Invoke(this, null);
                        }
                            //_commands.SetControlEnabled(nodeId, bool.Parse(enabledAttribute.Value));
                        var screentip = node.Attributes["screentip"];
                        if (screentip != null) bt.TooltipText = node.Attributes["screentip"].Value;
                        if (beginGroup) {
                            bt.BeginGroup = true;
                            beginGroup = false;
                        }
                        bt.Click += delegate { _commands.OnActionInvoked(nodeId); };
                        break;
                }
            }
        }

        private stdole.IPictureDisp GetPicture(string imageName) {
            var image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
            return image != null ? PictureConverter.ImageToPictureDisp(image) : null;
        }

	}
}