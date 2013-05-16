using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsUtils.helper;
using BusinessObjectsUtils.bo_session;

namespace BusinessObjectsUtils.bo_scheduler.dsws
{
    class SchedulerRand : IScheduler
    {

        private readonly SessionManager _sessionmanager;
        private const bool _tstPageingException = false;
        private const bool _tstWrongSession = false;
        private Boolean _cancel = false;

        public SchedulerRand(SessionManager sessionmanager)
        {
            if (_tstWrongSession) throw new Exception("Wrong version between session and scheduler!");
            _sessionmanager = sessionmanager;
        }

        public void Cancel()
        {
            _cancel = true;
        }

        public ExitCode GetReports(string pPath, bool pWithPrompts, string pAssociatedInstance, out Report[] pReports)
        {
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            int reportid = 5000;
            pReports = new Report[] { };
            ExitCode exitcode = ExitCode.SUCCEED;
            List<Report> reports = new List<Report>();
            List<string[]> queries = new List<string[]>();
            string select = "SI_ID,SI_KIND,SI_NAME,SI_PARENT_CUID,SI_CHILDREN,SI_CREATION_TIME,SI_UPDATE_TS,SI_LAST_SUCCESSFUL_INSTANCE_ID,SI_PROCESSINFO,SI_PROCESSINFO.SI_HAS_PROMPTS,SI_PROCESSINFO.SI_PROMPTS,SI_PROCESSINFO.SI_WEBI_PROMPTS,SI_PROCESSINFO.SI_FULLCLIENT_PROMPTS";
            string where = "SI_KIND IN('Webi','Publication','CrystalReport','ObjectPackage') AND SI_INSTANCE=0";
            if (System.Text.RegularExpressions.Regex.Match(pPath, @"^[\d, ]+$").Success)
            {
                queries.Add(new string[2] { pPath, "query://{SELECT " + select + " FROM CI_INFOOBJECTS WHERE " + where + " AND SI_ID IN(" + pPath + ")}" });
            }
            else
            {
                foreach (string query in pPath.Split(','))
                {
                    queries.Add(new string[2] { query, "path://InfoObjects/*/" + query.TrimStart(new char[] { '/' }) + "[" + where + "]@" + select });
                }
            }
            _sessionmanager.InitProgress(3, 100, queries.Count);
            #region  Loop through queries
            foreach (string[] query in queries)
            {
                switch (pAssociatedInstance)
                {
                    case "LAST_SUCCEED": _sessionmanager.Log("Get reports with last succeed instances for " + query[0]); break;
                    case "LAST_FAILED": _sessionmanager.Log("Get reports with last failed instances for " + query[0]); break;
                    case "LAST_CREATED": _sessionmanager.Log("Get reports with last created instances for " + query[0]); break;
                    default: _sessionmanager.Log("Get reports without instance in " + query[0]); break;
                }
                object[] pages = new object[Rand.Number(0, 10)];
                object[] objects = new object[Rand.Number(0, 100)];

                _sessionmanager.Log("Nb Pages: " + pages.Length.ToString());
                _sessionmanager.Log("Nb objects: " + objects.Length.ToString());

                if (objects.Length == 0)
                    throw new Exception("Query didn't return any objects ! ");

                _sessionmanager.InitSubProgress(pages.Length * objects.Length);
                if (_cancel) return ExitCode.CANCELED;
                int nbPages = pages.Length;
                int nbReports = 0;
                #region Loop through pages
                for (int p = 0; p < nbPages; p++)
                {
                    nbReports = objects.Length;
                    if (nbReports != 0){
                        if (_tstPageingException){
                            throw new Exception("Web service paging failed !");
                        }
                    }
                    #region Loop through reports                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        #region Loop through reports
                    for (int r = 0; r < nbReports; r++)
                    {
                        string loginfo = string.Empty;
                        _sessionmanager.Log("Get report " + Rand.String(10));
                        Instance instance = new Instance();
                        Prompt[] prompts = new Prompt[Rand.Number(0, 8)];
                        try
                        {
                            instance.Cuid = Rand.String(10);
                            instance.Id = Rand.Number(1, 10000);
                            instance.Date = Rand.Date("2010/01/01", "2012/12/30", "yyyy/MM/dd HH:mm");
                            instance.Status = Rand.List("FAILURE", "COMPLETE", "OTHER");
                            instance.Time = Rand.Time("00:00:00", "00:10:00");
                            for (int i = 0; i < prompts.Length; i++)
                            {
                                prompts[i] = new Prompt
                                {
                                    Name = "Prompt" + i.ToString(),
                                    Value = Rand.String(10)
                                };
                            }
                            Rand.Exception(5, "Failed to get object!");
                        }
                        catch (Exception ex)
                        {
                            loginfo = _sessionmanager.ParseException(ex);
                            _sessionmanager.Log(" Error: " + _sessionmanager.ParseException(ex));
                            exitcode = ExitCode.HASERROR;
                        }
                        reports.Add(new Report
                        {
                            LOG = loginfo,
                            Instance = instance,
                            Cuid = Rand.String(10),
                            Id = reportid++,
                            Type = Rand.List("Webi", "Publication", "CrystalReport", "ObjectPackage"),
                            Name = "Name" + Rand.String(5),
                            Folder = "//" + Rand.String(9) + "/" + Rand.String(4),
                            NbChild = Rand.Number(0, 4),
                            Prompts = prompts
                        });
                        _sessionmanager.IncSubProgress();
                        if (_cancel) return ExitCode.CANCELED;
                    }
                    #endregion
                }
                #endregion  Loop through pages
                _sessionmanager.IncProgress();
            }
            #endregion  Loop through queries
            pReports = reports.ToArray();
            return exitcode;
        }

        public ExitCode ScheduleReport(ref Report[] pReports, bool pSetPrompts, DateTime pDate, string pPath, string pOutFormat, bool pWaitEnd, bool pCleanup, string pNotifEmail)
        {
            _cancel = false;
            _sessionmanager.InitProgress(3, pWaitEnd ? 50 : 80, pReports.Length);
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            _sessionmanager.Log("Starts to Schedule reports " + Func.getTime());
            ExitCode exitcode = ExitCode.SUCCEED;
            List<Report> waitreports = new List<Report>();
            pOutFormat = pOutFormat == null ? string.Empty : pOutFormat.ToLower();
            foreach (Report report in pReports)
            {
                string instanceCuid = null;
                try
                {
                    _sessionmanager.Log("Schedule report " + report.ToLongName());
                    report.Instance = new Instance { Cuid = instanceCuid };
                    waitreports.Add(report);
                }
                catch (Exception ex)
                {
                    exitcode = ExitCode.HASERROR;
                    if (report.Instance == null) report.Instance = new Instance();
                    report.LOG = _sessionmanager.ParseException(ex);
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }

            _sessionmanager.InitProgress(pWaitEnd ? 51 : 81, 100, waitreports.Count);
            if (pWaitEnd)
            {
                _sessionmanager.Log("Wait for reports to be created...");
            }
            else
            {
                _sessionmanager.Log("Get reports status for created reports...");
            }

            if (_cancel) return ExitCode.CANCELED;
            while (waitreports.Count != 0)
            {
                for (int i = waitreports.Count - 1; i != -1; i--)
                {
                    try
                    {
                        waitreports[i].Instance.Id = Rand.Number(1, 10000);
                        waitreports[i].Instance.Date = Rand.DateFromNow(-1, "yyyy/MM/dd");
                        waitreports[i].Instance.Status = Rand.List("PENDING", "COMPLETE", "RUNNING", "COMPLETE", "FAILURE", "COMPLETE");
                        if (waitreports[i].Instance.Status != "PENDING" && waitreports[i].Instance.Status != "RUNNING")
                        {
                            if (pWaitEnd) _sessionmanager.IncProgress();
                            if (_cancel) return ExitCode.CANCELED;
                            if (waitreports[i].Instance.Status == "FAILURE")
                            {
                                waitreports[i].Instance.Status += ": [ErrorMessage]";
                                _sessionmanager.Log(waitreports[i].Instance.Status);
                                exitcode = ExitCode.HASERROR;
                            }
                            else if (waitreports[i].Instance.Status == "COMPLETE")
                            {
                                waitreports[i].Instance.Time = Rand.Time("00:00:01", "00:10:00");
                            }
                            waitreports.Remove(waitreports[i]);
                            _sessionmanager.Log("Done for report " + Rand.String(10));
                        }
                    }
                    catch (Exception ex)
                    {
                        exitcode = ExitCode.HASERROR;
                        waitreports[i].LOG = _sessionmanager.ParseException(ex);
                        waitreports[i].Instance.Status = _sessionmanager.ParseException(ex);
                        _sessionmanager.Log(" Error: " + _sessionmanager.ParseException(ex));

                        exitcode = ExitCode.HASERROR;
                        _sessionmanager.Log("Failed for report " + Rand.String(10));
                    }
                    if (!pWaitEnd) _sessionmanager.IncProgress();
                    if (_cancel) return ExitCode.CANCELED;
                }
                if (pWaitEnd == false) break;

                Waiter.Wait(1000 + (waitreports.Count * 100), ref _cancel);
                if (_cancel) return ExitCode.CANCELED;
                waitreports.RemoveAt(0);
                _sessionmanager.ResetSessionTimeOut();
            }
            if (pWaitEnd)
            {
                _sessionmanager.Log("Remaining reports : " + waitreports.Count);
            }
            _sessionmanager.Log("End of reports scheduling - " + Func.getTime());
            if (pNotifEmail != string.Empty)
            {
                string msg = _sessionmanager.GetLogText();
                _sessionmanager.Log("  Email=" + pNotifEmail);
                _sessionmanager.Log("  Subject=" + "[Business Objects] Scheduling result: " + exitcode.ToString());
                _sessionmanager.Log("  Message=" + msg);
            }
            return exitcode;
        }

        public ExitCode GetReportsSchedulStatus(ref Report[] pReports, string pAssociatedInstance)
        {
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            ExitCode exitcode = ExitCode.SUCCEED;
            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach (Report report in pReports)
            {
                try
                {
                    switch (pAssociatedInstance)
                    {
                        case "LAST_SUCCEED":
                            _sessionmanager.Log("Get last succeed instance of " + report.ToLongName());
                            break;
                        case "LAST_FAILED":
                            _sessionmanager.Log("Get last failed instance of " + report.ToLongName());
                            break;
                        case "LAST_CREATED":
                            _sessionmanager.Log("Get last created instance of " + report.ToLongName());
                            break;
                        case "SPECIFIED":
                            if (report.Instance == null || report.Instance.Cuid == String.Empty) throw new Exception("The instance <Cuid> argument is missing for report " + report.ToLongName());
                            _sessionmanager.Log("Get instance " + report.Instance.Id + " of " + report.ToLongName());
                            break;
                        default:
                            throw new Exception("Option " + pAssociatedInstance + " is not available ! ");
                    }
                    if (pAssociatedInstance != "SPECIFIED") report.Instance = new Instance();
                    Rand.Exception(10, "Test exception!");
                    report.Instance.Cuid = Rand.String(10);
                    report.Instance.Id = Rand.Number(20, 10000);
                    report.Instance.Date = Rand.DateFromNow(-20, "yyyy/MM/dd HH:mm");
                    report.Instance.Time = Rand.Time("00:00:00", "00:10:00");
                    report.Instance.Status = Rand.List("PENDING", "COMPLETE", "RUNNING", "COMPLETE", "FAILURE", "COMPLETE"); ;
                }
                catch (Exception ex)
                {
                    exitcode = ExitCode.HASERROR;
                    report.LOG = _sessionmanager.ParseException(ex);
                    _sessionmanager.Log(" Error: " + _sessionmanager.ParseException(ex));
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }
            return exitcode;
        }

        public ExitCode DeleteReportsInstance(ref Report[] pReports, string pAssociatedInstance)
        {
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            ExitCode exitcode = ExitCode.SUCCEED;
            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach (Report report in pReports)
            {
                try
                {
                    switch (pAssociatedInstance)
                    {
                        case "SPECIFIED":
                            if (report.Instance == null || report.Instance.Cuid == String.Empty) throw new Exception("The instance <Cuid> argument is missing for report " + report.ToLongName());
                            _sessionmanager.Log("Delete instance " + report.Instance.Id + " of " + report.ToLongName());
                            break;
                        case "ALL_FAILED":
                            _sessionmanager.Log("Delete failed instances of " + report.ToLongName());
                            break;
                        case "ALL_SUCCEED":
                            _sessionmanager.Log("Delete succeed instances of " + report.ToLongName());
                            break;
                        case "ALL_STATUS":
                            _sessionmanager.Log("Delete all instances of " + report.ToLongName());
                            break;
                        default:
                            throw new Exception("Option " + pAssociatedInstance + " is not available ! ");
                    }

                    Rand.Exception(10, "Test exception!");
                    report.LOG = "DELETED";
                }
                catch (Exception ex)
                {
                    exitcode = ExitCode.HASERROR;
                    report.LOG = _sessionmanager.ParseException(ex);
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }
            return exitcode;
        }

        //http://devlibrary.businessobjects.com/businessobjectsxir2/en/en/WS_SDK/wssdk_consumer/doc/wssdk_net_consumer_apiRef/html/wslrfBusinessObjectsDSWSReportEngineViewModeTypeClassTopic.htm

        public ExitCode DownloadReportsFile(ref Report[] pReports, string pFolder, string pAssociatedInstance, string pFormat)
        {
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            pAssociatedInstance = pAssociatedInstance.ToUpper();
            pFormat = pFormat.ToUpper();
            pFolder = pFolder.TrimEnd('\\') + '\\';

            ExitCode exitcode = ExitCode.SUCCEED;
            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach (Report report in pReports)
            {
                try
                {
                    if (report.Cuid == null || report.Cuid == string.Empty) throw new Exception("Report Cuid is empty");
                    switch (pAssociatedInstance)
                    {
                        case "SPECIFIED":
                            if (report.Instance.Cuid == null || report.Instance.Cuid == string.Empty) throw new Exception("Instance Cuid is empty");
                            if (report.Instance == null || report.Instance.Cuid == String.Empty) throw new Exception("The instance <Cuid> argument is missing for report " + report.ToLongName());
                            _sessionmanager.Log("Download instance " + report.Instance.Id + " of " + report.ToLongName());
                            break;
                        case "LAST_SUCCEED":
                            if (report.Instance.Cuid == null || report.Instance.Cuid == string.Empty) throw new Exception("Instance Cuid is empty");
                            _sessionmanager.Log("Download last succeed instance of " + report.ToLongName());
                            break;
                        case "NONE":
                            _sessionmanager.Log("Download report " + report.ToLongName());
                            break;
                        default:
                            throw new Exception("Option " + pAssociatedInstance + " is not available ! ");
                    }
                    switch (pFormat)
                    {
                        case "DEFAULT":
                            report.Instance.Time = Rand.Time("00:00:10", "00:10:00");
                            string filePath = pFolder + Rand.Number(1, 10000).ToString() + "-" + Rand.String(10) + ".ext";
                            System.Threading.Thread.Sleep(1000);
                            report.LOG = "DOWNLOADED as BINARY";
                            break;
                        case "XML":
                            System.Xml.XmlWriterSettings xmlSettingsWithIndentation = new System.Xml.XmlWriterSettings { Indent = true };
                            object[] docInfoReports = new object[Rand.Number(1, 4)];
                            _sessionmanager.InitSubProgress(docInfoReports.Length);
                            foreach (object docReport in docInfoReports)
                            {
                                System.Threading.Thread.Sleep(1000);
                                _sessionmanager.IncSubProgress();
                            }
                            report.LOG = "DOWNLOADED as Xml";
                            break;
                        case "HTML":
                            object[] docInfo = new object[Rand.Number(1, 4)];
                            _sessionmanager.InitSubProgress(docInfo.Length);
                            foreach (object docReport in docInfo)
                            {
                                System.Threading.Thread.Sleep(1000);
                                _sessionmanager.IncSubProgress();
                            }
                            report.LOG = "DOWNLOADED as Html";
                            break;
                        case "PDF":
                            System.Threading.Thread.Sleep(1000);
                            report.LOG = "DOWNLOADED as Pdf";
                            break;
                        case "EXCEL":
                            System.Threading.Thread.Sleep(1000);
                            report.LOG = "DOWNLOADED as Excel";
                            break;
                    }
                    Rand.Exception(10, "Test exception!");
                }
                catch (Exception ex)
                {
                    exitcode = ExitCode.HASERROR;
                    report.LOG = _sessionmanager.ParseException(ex);
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }
            return exitcode;
        }

        public System.Windows.Forms.TreeNodeCollection EnumFolders()
        {

            var nodes = new System.Windows.Forms.TreeNode();

            object[] paths = new object[]{
                new object[]{ "FolderA", new []{"1", "11"}},
                new object[]{ "FolderB", new []{"2", "21", "211"}},
                new object[]{ "FolderC", new []{"1", "11", "112"}},
                new object[]{ "FolderD", new []{"2", "22", "221"}}
            };

            for (int p = 0; p < paths.Length; p++) {
                System.Windows.Forms.TreeNode node = nodes;
                var obj = (object[])paths[p];
                for (int f = ((string[])obj[1]).Length - 1; f != -1; f--) {
                    node = Func.AddTreeNode(node, ((string[])obj[1])[f]);
                }
                Func.AddTreeNode(node, (string)obj[0]);
            }
            return nodes.Nodes;
        }

        private System.Windows.Forms.TreeNode AddTreeNode(System.Windows.Forms.TreeNode treenode, string key) {
            if(treenode!=null && treenode.Nodes.Count > 0){
                foreach (System.Windows.Forms.TreeNode subNode in treenode.Nodes) {
                    if (subNode.Text == key) {
                        return subNode;
                    }
                }
            }
            var node = new System.Windows.Forms.TreeNode(key);;
            if (treenode != null) treenode.Nodes.Add(node);
            return node;
        }

        public List<System.Windows.Forms.ListViewItem> EnumReports(string path)
        {
            throw new NotImplementedException();
        }

    }
}
