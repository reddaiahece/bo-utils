using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using BusinessObjectsUtils;
using BusinessObjectsUtils.bo_scheduler;
using BusinessObjectsUtils.bo_session;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace BOUtilsAddin
{
    class WorkbookInstance
    {
        public delegate void Event_Delegate();

        private readonly Excel.Application _excelapp;
        private ReportParser _parser;
        private Settings _settings;
        private SessionManager _session;

        public Event_Delegate OnLogInOut;
        public bool IsLoggedIn { get; private set; }


        public WorkbookInstance(Excel.Application application, Excel.Workbook Wb) {
            _excelapp = application;
            _settings = new Settings(Wb);
            _parser = new ReportParser();
        }

        public void OnWorkbookClose(ref bool Cancel) {
            if (IsLoggedIn) {
                _session.Logout();
                IsLoggedIn = false;
            }
        }

        public void OnActionInvoked(string methodeName) {
            var methodeInfo = typeof(WorkbookInstance).GetMethod(methodeName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (methodeInfo == null) throw new Exception("Missing methode : " + methodeName);
            methodeInfo.Invoke(this, null);
        }

        private void btLogin_Click() {
            try{
                    if (!IsLoggedIn) {
                    _session = new SessionManager();
                    using (var lForm = new FrmLogin(_excelapp.Hwnd)) {
                        var logdata = new LoginData() {
                            Url = _settings.GetWorkbookParam("Url", ""),
                            Version = _settings.GetWorkbookParam("Version", 0),
                            AuthType = _settings.GetWorkbookParam("AuthType", ""),
                            Domain = _settings.GetWorkbookParam("Domain", ""),
                            Login = _settings.GetWorkbookParam("Login", ""),
                            Password = _settings.GetWorkbookParam("Password", ""),
                            Proxy = new Proxy {
                                Host = _settings.GetWorkbookParam("ProxyHost", ""),
                                Port = _settings.GetWorkbookParam("ProxyPort", 0),
                                User = _settings.GetWorkbookParam("ProxyUser", ""),
                                Password = _settings.GetWorkbookParam("ProxyPassword", ""),
                            }
                        };
                        try {
                            lForm.LogHistory = (Dictionary<string, LoginData>)_settings.LoadFromFile("credentials");
                        } catch { }
                        lForm.LoginData = logdata;
                        while (lForm.ShowDialog() == DialogResult.OK) {
                            var runner = new FrmRunner(_session.Logger, _session.Cancel);
                            var exitcode = runner.Execute(() => _session.Login(lForm.LoginData));
                            if (exitcode == ExitCode.CANCELED) return;
                            if (exitcode == ExitCode.SUCCEED) {
                                IsLoggedIn = true;
                                OnLogInOut();
                                _settings.SaveToFile("credentials", lForm.LogHistory);
                                logdata = lForm.LoginData;
                                _settings.SetWorkbookParam("Url", logdata.Url);
                                _settings.SetWorkbookParam("Version", logdata.Version);
                                _settings.SetWorkbookParam("AuthType", logdata.AuthType);
                                _settings.SetWorkbookParam("Domain", logdata.Domain);
                                _settings.SetWorkbookParam("Login", logdata.Login);
                                _settings.SetWorkbookParam("Password", logdata.Password);
                                if (logdata.Proxy != null) {
                                    _settings.SetWorkbookParam("ProxyHost", logdata.Proxy.Host);
                                    _settings.SetWorkbookParam("ProxyPort", logdata.Proxy.Port);
                                    _settings.SetWorkbookParam("ProxyUser", logdata.Proxy.User);
                                    _settings.SetWorkbookParam("ProxyPassword", logdata.Proxy.Password);
                                }
                                return;
                            };
                        }
                    }
                } else {
                    _session.Logout();
                    IsLoggedIn = false;
                    OnLogInOut();
                }
            } catch (Exception ex) { new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, ex).ShowDialog(); }
        }
        
        private void btGetList_Click() {
            try{
                var scheduler = new SchedulerManager(_session);
                using (var lForm = new FrmGetList(_excelapp.Hwnd, scheduler.EnumFolders, scheduler.EnumReports)) {
                    lForm.ReportsPath = _settings.GetWorksheetParam("ReportsPath", "");
                    lForm.AssociatedInstance = _settings.GetWorksheetParam("AssociatedInstance", "");
                    lForm.IncludePrompts = _settings.GetWorksheetParam("IncludePrompts", false);
                    if (lForm.ShowDialog() == DialogResult.OK) {
                        _settings.SetWorksheetParam("ReportsPath", lForm.ReportsPath);
                        _settings.SetWorksheetParam("AssociatedInstance", lForm.AssociatedInstance);
                        _settings.SetWorksheetParam("IncludePrompts", lForm.IncludePrompts);
                        var runner = new FrmRunner(_session.Logger, scheduler.Cancel);
                        Report[] reports = null;
                        var exitcode = runner.Execute(() =>
                            scheduler.GetReports(lForm.ReportsPath, lForm.IncludePrompts, lForm.AssociatedInstance, out reports)
                        );
                        if (exitcode == ExitCode.FAILED || exitcode == ExitCode.CANCELED) return;
                        var worksheet = (Excel.Worksheet)_excelapp.ActiveSheet;
                        SwitchExcelToIdle(_excelapp, false);

                        worksheet.Cells.EntireColumn.Hidden = false;
                        worksheet.Cells.EntireRow.Hidden = false;
                        foreach (Excel.ListObject lo in worksheet.ListObjects)
                            lo.Delete();

                        var data = _parser.ParseReportsToDataArray(reports);
                        var title = _parser.ParseReportsToTitleArray(reports);
                        var nbRow = data.GetLength(0);
                        var nbCol = title.GetLength(1);
                        var listobject = worksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, worksheet.Cells.Resize[Math.Max(nbRow + 1, 2), nbCol], Type.Missing, Excel.XlYesNoGuess.xlYes);
                        listobject.HeaderRowRange.Value = title;
                        if (nbRow > 0) {
                            listobject.DataBodyRange.NumberFormat = "@";
                            _parser.FormatListObject(listobject);
                            listobject.DataBodyRange.Value = data;
                            listobject.DataBodyRange.WrapText = false;
                            _parser.AddPromptsNameAsComment(listobject, reports);
                        }
                        SwitchExcelToIdle(_excelapp, true);
                    }
                }
            } catch (Exception ex) { new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, ex).ShowDialog(); }
        }

        private void btRefresh_Click() {
            try{
                var activesheet = (Excel.Worksheet)_excelapp.ActiveSheet;
                if (!_parser.checkTablePresent(activesheet)) return;
                using (var lForm = new FrmGetStatus(_excelapp.Hwnd)) {
                    lForm.Reports = _parser.GetReportsList(activesheet.ListObjects[1]);
                    lForm.AssociatedInstance = _settings.GetWorksheetParam("RefInstance", "SPECIFIED");
                    if (lForm.ShowDialog() != DialogResult.OK) return;
                    var reports = _parser.ParseListObjectToReports(activesheet.ListObjects[1], false);
                    _settings.SetWorksheetParam("RefInstance", lForm.AssociatedInstance);
                    var scheduler = new SchedulerManager(_session);
                    var runner = new FrmRunner(_session.Logger, scheduler.Cancel);
                    var exitcode = runner.Execute(() => scheduler.GetReportsSchedulStatus(ref reports, lForm.AssociatedInstance));
                    if (exitcode == ExitCode.FAILED || exitcode == ExitCode.CANCELED) return;
                    SwitchExcelToIdle(_excelapp, false);
                    _parser.UpdateListObjectStatus(activesheet.ListObjects[1], reports);
                    SwitchExcelToIdle(_excelapp, true);
                }
            } catch (Exception ex) { new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, ex).ShowDialog(); }
        }

        private void btDownload_Click() {
            try{
                var activesheet = (Excel.Worksheet)_excelapp.ActiveSheet;
                if (!_parser.checkTablePresent(activesheet)) return;
                using (var lForm = new FrmDownload(_excelapp.Hwnd)) {
                    lForm.Reports = _parser.GetReportsList(activesheet.ListObjects[1]);
                    lForm.Directory = _settings.GetWorksheetParam("Directory", @"C:\");
                    lForm.AssociatedInstance = _settings.GetWorksheetParam("DownInstance", "SPECIFIED");
                    lForm.Format = _settings.GetWorksheetParam("DownFormat", "DEFAULT");
                    if (lForm.ShowDialog() != DialogResult.OK) return;
                    var reports = _parser.ParseListObjectToReports(activesheet.ListObjects[1], false);
                    _settings.SetWorksheetParam("Directory", lForm.Directory);
                    _settings.SetWorksheetParam("DownInstance", lForm.AssociatedInstance);
                    _settings.SetWorksheetParam("DownFormat", lForm.Format);
                    var scheduler = new SchedulerManager(_session);
                    var runner = new FrmRunner(_session.Logger, scheduler.Cancel);
                    var exitcode = runner.Execute(() =>
                        scheduler.DownloadReportsFile(ref reports, lForm.Directory, lForm.AssociatedInstance, lForm.Format)
                    );
                    if (exitcode == ExitCode.FAILED || exitcode == ExitCode.CANCELED) return;
                    _parser.UpdateListObjectStatus(activesheet.ListObjects[1], reports);
                }
            } catch (Exception ex) { new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, ex).ShowDialog(); }
        }

        private void btClean_Click() {
            try{
                var activesheet = (Excel.Worksheet)_excelapp.ActiveSheet;
                if (!_parser.checkTablePresent(activesheet)) return;
                using (var lForm = new FrmDelete(_excelapp.Hwnd)) {
                    lForm.Reports = _parser.GetReportsList(activesheet.ListObjects[1]);
                    lForm.AssociatedInstance = _settings.GetWorksheetParam("DelInstance", "SPECIFIED");
                    if (lForm.ShowDialog() != DialogResult.OK) return;
                    var reports = _parser.ParseListObjectToReports(activesheet.ListObjects[1], true);
                    _settings.SetWorksheetParam("DelInstance", lForm.AssociatedInstance);
                    var scheduler = new SchedulerManager(_session);
                    var runner = new FrmRunner(_session.Logger, scheduler.Cancel);
                    var exitcode = runner.Execute(() =>
                        scheduler.DeleteReportsInstance(ref reports, lForm.AssociatedInstance)
                    );
                    if (exitcode == ExitCode.FAILED || exitcode == ExitCode.CANCELED) return;
                    _parser.UpdateListObjectStatus(activesheet.ListObjects[1], reports);
                }
            } catch (Exception ex) { new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, ex).ShowDialog(); }
        }

        private void btSchedule_Click() {
            try{
                var activesheet = (Excel.Worksheet)_excelapp.ActiveSheet;
                if (!_parser.checkTablePresent(activesheet)) return;
                using (var lForm = new FrmSchedule(_excelapp.Hwnd)) {
                    lForm.Reports = _parser.GetReportsList(activesheet.ListObjects[1]);
                    lForm.Destination = _settings.GetWorksheetParam("Destination", "");
                    lForm.Format = _settings.GetWorksheetParam("Format", "");
                    lForm.NotifEmail = _settings.GetWorksheetParam("NotifEmail", "");
                    if (lForm.ShowDialog() != DialogResult.OK) return;
                    var reports = _parser.ParseListObjectToReports(activesheet.ListObjects[1], true);
                    if (lForm.Schedule) {
                        _settings.SetWorksheetParam("Destination", lForm.Destination);
                        _settings.SetWorksheetParam("Format", lForm.Format);
                        _settings.SetWorksheetParam("NotifEmail", lForm.NotifEmail);
                        var scheduler = new SchedulerManager(_session);
                        var runner = new FrmRunner(_session.Logger, scheduler.Cancel);
                        var exitcode = runner.Execute(() =>
                            scheduler.ScheduleReports(
                                ref reports,
                                lForm.WithPrompts,
                                lForm.Date,
                                lForm.Destination,
                                lForm.Format,
                                lForm.WaitEnd,
                                lForm.CleanEnd,
                                lForm.NotifEmail
                            )
                        );
                        if (exitcode == ExitCode.FAILED || exitcode == ExitCode.CANCELED) return;
                        _parser.UpdateListObjectStatus(activesheet.ListObjects[1], reports);
                    } else if (lForm.CreateXML) {
                        string lFilename = String.Empty;
                        using (SaveFileDialog saveDialog = new SaveFileDialog()) {
                            saveDialog.Filter = "XML FIle|*.xml";
                            saveDialog.Title = "Save XML File";
                            saveDialog.ShowDialog();
                            lFilename = saveDialog.FileName;
                        }
                        if (lFilename != String.Empty) {
                            try {
                                Application.UseWaitCursor = true;
                                PlanSchedule schedulerplan = new PlanSchedule {
                                    Credentials = this._session.Credentials,
                                    WithPrompts = lForm.WithPrompts,
                                    Destination = lForm.Destination,
                                    Format = lForm.Format,
                                    WaitEnd = lForm.WaitEnd,
                                    CleanEnd = lForm.CleanEnd,
                                    NotifEmail = lForm.NotifEmail,
                                    Reports = reports
                                };
                                schedulerplan.ParseToXml(lFilename);
                                MsgBox.Show("Command line :", "\"" + Func.GetRunnerPath() + "\" \"" + lFilename + "\" \"" + lFilename.Replace(".xml", ".log") + "\"");
                            } catch{ throw; } finally {
                                Application.UseWaitCursor = false;
                            }
                        }
                    }
                }
            } catch (Exception ex) { new BusinessObjectsUtils.FrmException(_excelapp.Hwnd, ex).ShowDialog(); }
        }

        static public void SwitchExcelToIdle(Excel.Application excelapp, bool on) {
            excelapp.ScreenUpdating = @on;
            excelapp.DisplayAlerts = @on;
            excelapp.Calculation = @on ? Excel.XlCalculation.xlCalculationAutomatic : Excel.XlCalculation.xlCalculationManual;
            excelapp.UserControl = @on;
            excelapp.EnableEvents = @on;
            excelapp.Cursor = @on == false ? Excel.XlMousePointer.xlWait : Excel.XlMousePointer.xlDefault;
        }

        private void btHelp_Click() {

        }

        private void btAbout_Click() {
            new FrmAbout(_excelapp.Hwnd).ShowDialog();
        }

        private void btUninstall_Click() {
            if (IsLoggedIn) {
                _session.Logout();
                OnLogInOut();
            }
            new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                string path = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\BusinessObjectsUtils_is1", "UnInstallString", null);
                if (string.IsNullOrEmpty(path))
                    path = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\BusinessObjectsUtils_is1", "UnInstallString", null);
                if (!string.IsNullOrEmpty(path))
                    System.Diagnostics.Process.Start(path);
                //System.Diagnostics.Process.Start("msiexec", "/x {2716F623-C875-4D95-BE72-88A8E37ED9E1}");
            }).Start();
        }

    }
}
