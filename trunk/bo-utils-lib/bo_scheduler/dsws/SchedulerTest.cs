using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsUtils.helper;
using System.Threading;
using BusinessObjectsUtils.bo_session;

namespace BusinessObjectsUtils.bo_scheduler.dsws
{
    class SchedulerTest : IScheduler
    {
        private SessionManager _sessionmanager;
        private Boolean _cancel = false;
        private bool _tstWrongSession = false;

        public SchedulerTest(SessionManager sessionmanager)
        {
            if (_tstWrongSession) throw new Exception("Wrong version between session and scheduler!");
            _sessionmanager = sessionmanager;
        }

        public void Cancel()
        {
            _cancel = true;
        }

        private Report[] GetTestReports(){
            return new Report[]{
                new Report(){
                    LOG = "Well done",
                    Cuid = "cuid1",
                    Id = 10001,
                    Type = "Webi",
                    Name = "First report",
                    Folder = "//folder/subfolder",
                    NbChild = 3,
                    Instance = new Instance(){
                        Cuid = "cuid11",
                        Id = 310001,
                        Date = "2012/12/01 10:15",
                        Status = "PENDING",
                        Time = "00:10:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt1", Value="Value1"},
                        new  Prompt(){ Name= "Prompt2", Value="Value2"},
                        new  Prompt(){ Name= "Prompt3", Value="Value3"},
                        new  Prompt(){ Name= "Prompt4", Value="Value4"}
                    }
                },
                new Report(){
                    Cuid = "cuid2",
                    Id = 10002,
                    Type = "Webi",
                    Name = "Second report",
                    Folder = "//folder/subfolder",
                    NbChild = 6,
                    Instance = new Instance(){
                        Cuid = "cuid22",
                        Id = 310023,
                        Date = "2012/12/01 10:15",
                        Status = "Failed",
                        Time = "00:20:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt1", Value="Value1"},
                        new  Prompt(){ Name= "Prompt2", Value="Value2"},
                        new  Prompt(){ Name= "Prompt3", Value="Value3"},
                        new  Prompt(){ Name= "Prompt4", Value="Value4"},
                        new  Prompt(){ Name= "Prompt5", Value="Value5"},
                        new  Prompt(){ Name= "Prompt6", Value="Value6"},
                    }
                },
                new Report(){
                    Cuid = "cuid3",
                    Id = 10003,
                    Type = "Webi",
                    Name = "Third report",
                    Folder = "//folder/subfolder",
                    NbChild = 14,
                    Instance = new Instance(){
                        Cuid = "cuid30",
                        Id = 10453,
                        Date = "2012/12/01 10:15",
                        Status = "PENDING",
                        Time = "00:30:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt31", Value="Value31"},
                        new  Prompt(){ Name= "Prompt32", Value="Value32"}
                    }
                }
            };
        }

        public ExitCode GetReports(string pPath, bool pWithPrompts, string pAssociatedInstance, out Report[] pReports)
        {
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            pReports = new Report[]{
                new Report(){
                    Cuid = "cuid1",
                    Id = 10001,
                    Type = "Webi",
                    Name = "First report",
                    Folder = "//folder/subfolder",
                    NbChild = 3,
                    Instance = new Instance(){
                        Cuid = "cuid11",
                        Id = 310001,
                        Date = "2012/12/01 10:15",
                        Status = "PENDING",
                        Time = "00:10:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt1", Value="Value1"},
                        new  Prompt(){ Name= "Prompt2", Value="Value2"},
                        new  Prompt(){ Name= "Prompt3", Value="Value3"},
                        new  Prompt(){ Name= "Prompt4", Value="Value4"}
                    }
                },
                new Report(){
                    Cuid = "cuid2",
                    Id = 10002,
                    Type = "Webi",
                    Name = "Second report",
                    Folder = "//folder/subfolder",
                    NbChild = 6,
                    Instance = new Instance(){
                        Cuid = "cuid22",
                        Id = 310023,
                        Date = "2012/12/01 10:15",
                        Status = "FAILED",
                        Time = "00:20:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt1", Value="Value1"},
                        new  Prompt(){ Name= "Prompt2", Value="Value2"},
                        new  Prompt(){ Name= "Prompt3", Value="Value3"},
                        new  Prompt(){ Name= "Prompt4", Value="Value4"},
                        new  Prompt(){ Name= "Prompt5", Value="Value5"},
                        new  Prompt(){ Name= "Prompt6", Value="Value6"},
                    }
                },
                new Report(){
                    Cuid = "cuid3",
                    Id = 10003,
                    Type = "Webi",
                    Name = "Third report",
                    Folder = "//folder/subfolder",
                    NbChild = 14,
                    Instance = new Instance(){
                        Cuid = "cuid30",
                        Id = 310453,
                        Date = "2012/12/01 10:15",
                        Status = "PENDING",
                        Time = "00:30:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt31", Value="Value31"},
                        new  Prompt(){ Name= "Prompt32", Value="Value32"}
                    }
                }
            };

            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach(Report report in pReports){
                _sessionmanager.Log("Get report " + report.Id + " - " + report.Name);
                System.Threading.Thread.Sleep(100);
                _sessionmanager.IncProgress();
            }

            return ExitCode.SUCCEED;
        }

        public ExitCode ScheduleReport(ref Report[] pReports, bool pSetPrompts, DateTime pDate, string pPath, string pOutFormat, bool pWaitEnd, bool pCleanup, string pNotifEmail){
            _cancel = false;
            _sessionmanager.InitProgress(3, pWaitEnd ? 50 : 80, pReports.Length);
            _sessionmanager.ResetSessionTimeOut();

            pReports = GetTestReports();


            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            _sessionmanager.Log("Starts to Schedule reports " + Func.getTime());
            ExitCode exitcode = ExitCode.SUCCEED;
            List<Instance> waitinstances = new List<Instance>();
            pOutFormat = pOutFormat==null? string.Empty: pOutFormat.ToLower();
            foreach (Report report in pReports ){
                string instanceCuid=null;
                try{
                    _sessionmanager.Log("Schedule report " + report.ToLongName());
                    report.Instance = new Instance { Cuid = instanceCuid };
                    waitinstances.Add(report.Instance);
                }catch(Exception ex){
                    exitcode = ExitCode.HASERROR;
                    if(report.Instance == null) report.Instance = new Instance();
                    report.LOG = _sessionmanager.ParseException(ex);
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }

            _sessionmanager.InitProgress(pWaitEnd ? 51 : 81, 100, waitinstances.Count);
            if(pWaitEnd){
                _sessionmanager.Log("Wait for reports to be created...");
            }else{
                _sessionmanager.Log("Get reports status for created reports...");
            }

            if (_cancel) return ExitCode.CANCELED;
            while (waitinstances.Count != 0){
                for (int i = waitinstances.Count -1 ; i != -1; i--){
                    try{
                        waitinstances[i].Id = Rand.Number(1, 10000);
                        waitinstances[i].Date = Rand.DateFromNow(-1, "yyyy/MM/dd");
                        waitinstances[i].Status = Rand.List("PENDING","COMPLETE","RUNNING","COMPLETE","FAILURE","COMPLETE");
                        if( waitinstances[i].Status != "PENDING" && waitinstances[i].Status != "RUNNING"){
                            if (pWaitEnd) _sessionmanager.IncProgress();
                            if (_cancel) return ExitCode.CANCELED;
                             if( waitinstances[i].Status == "FAILURE"){
                                waitinstances[i].Status += ": [ErrorMessage]";
                                _sessionmanager.Log(waitinstances[i].Status);
                                exitcode = ExitCode.HASERROR;
                             }else if(waitinstances[i].Status == "COMPLETE"){
                                 waitinstances[i].Time = Rand.Time("00:00:01","00:10:00");
                             }
                             waitinstances.Remove(waitinstances[i]);
                             _sessionmanager.Log("Done for report " + Rand.String(10));
                        }
                    }catch(Exception ex){
                        exitcode = ExitCode.HASERROR;
                        _sessionmanager.Log("Failed for report " + Rand.String(10));
                        waitinstances[i].Status = _sessionmanager.ParseException(ex);
                    }
                    if (!pWaitEnd) _sessionmanager.IncProgress();
                    if (_cancel) return ExitCode.CANCELED;
                }
                if (pWaitEnd == false) break;

                Waiter.Wait( 1000 + (waitinstances.Count * 100), ref _cancel );
                if (_cancel) return ExitCode.CANCELED;
                waitinstances.RemoveAt(0);
                _sessionmanager.ResetSessionTimeOut();
            }
            if(pWaitEnd){
                _sessionmanager.Log("Remaining reports : " + waitinstances.Count);
            }
            _sessionmanager.Log("End of reports scheduling - " + Func.getTime());
            if (pNotifEmail!=string.Empty){
                string msg = _sessionmanager.GetLogText();
                _sessionmanager.Log("  Email=" + pNotifEmail);
                _sessionmanager.Log("  Subject=" + "[Business Objects] Scheduling result: " + exitcode.ToString());
                _sessionmanager.Log("  Message=" + msg);
            }
            return exitcode;
		}

        public ExitCode GetReportsSchedulStatus(ref Report[] pReports, string pAssociatedInstance ){
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            pReports = new Report[]{
                new Report(){
                    Cuid = "cuid1",
                    Id = 10001,
                    Type = "Webi",
                    Name = "First report",
                    Folder = "//folder/subfolder",
                    NbChild = 3,
                    Instance = new Instance(){
                        Cuid = "cuid11",
                        Id = 310001,
                        Date = "2012/12/01 10:15",
                        Status = "PENDING",
                        Time = "00:10:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt1", Value="Value1"},
                        new  Prompt(){ Name= "Prompt2", Value="Value2"},
                        new  Prompt(){ Name= "Prompt3", Value="Value3"},
                        new  Prompt(){ Name= "Prompt4", Value="Value4"}
                    }
                },
                new Report(){
                    Cuid = "cuid2",
                    Id = 10002,
                    Type = "Webi",
                    Name = "Second report",
                    Folder = "//folder/subfolder",
                    NbChild = 6,
                    Instance = new Instance(){
                        Cuid = "cuid22",
                        Id = 310023,
                        Date = "2012/12/01 10:15",
                        Status = "COMPLETE",
                        Time = "00:20:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt1", Value="Value1"},
                        new  Prompt(){ Name= "Prompt2", Value="Value2"},
                        new  Prompt(){ Name= "Prompt3", Value="Value3"},
                        new  Prompt(){ Name= "Prompt4", Value="Value4"},
                        new  Prompt(){ Name= "Prompt5", Value="Value5"},
                        new  Prompt(){ Name= "Prompt6", Value="Value6"},
                    }
                },
                new Report(){
                    LOG = "Log message",
                    Cuid = "cuid3",
                    Id = 10003,
                    Type = "Webi",
                    Name = "Third report",
                    Folder = "//folder/subfolder",
                    NbChild = 14,
                    Instance = new Instance(){
                        Cuid = "cuid30",
                        Id = 310453,
                        Date = "2012/12/01 10:15",
                        Status = "ERROR : failed to open the report!",
                        Time = "00:30:00"
                    },
                    Prompts = new Prompt[]{
                        new  Prompt(){ Name= "Prompt31", Value="Value31"},
                        new  Prompt(){ Name= "Prompt32", Value="Value32"}
                    }
                }
            };

            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach (Report report in pReports){
                switch (pAssociatedInstance){
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
                System.Threading.Thread.Sleep(100);
                _sessionmanager.IncProgress();
            }

            return ExitCode.SUCCEED;
		}

		public ExitCode DeleteReportsInstance(ref Report[] pReports, string pAssociatedInstance){
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            ExitCode exitcode = ExitCode.SUCCEED;
            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach (Report report in pReports ){
                try{
                    switch (pAssociatedInstance){
                        case "SPECIFIED":
                            if (report.Instance == null || report.Instance.Cuid == String.Empty) throw new Exception("The instance <Cuid> argument is missing for report " + report.ToLongName());
                            _sessionmanager.Log("Delete instance " + report.Instance.Id + " of " + report.ToLongName());
                            Thread.Sleep(100);
                            break;
                        case "ALL_FAILED":
                            _sessionmanager.Log("Delete failed instances of " + report.ToLongName());
                            Thread.Sleep(100);
                            break;
                        case "ALL_SUCCEED":
                            _sessionmanager.Log("Delete succeed instances of " + report.ToLongName());
                            Thread.Sleep(100);
                            break;
                        case "ALL_STATUS":
                            _sessionmanager.Log("Delete all instances of " + report.ToLongName());
                            Thread.Sleep(100);
                            break;
                        default:
                            throw new Exception("Option " + pAssociatedInstance + " is not available ! ");
                    }
                    if(true){
                        report.Instance.Id = 0;
                        report.LOG = "DELETED 2 instances";
                        report.Instance.Cuid = null;
                        report.Instance.Date = null;
                        report.Instance.Time = null;
                        report.NbChild = report.NbChild - 1;
                    }
                }catch(Exception ex){
                    exitcode = ExitCode.HASERROR;
                    report.Instance.Status = _sessionmanager.ParseException(ex);
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }
            return exitcode;
		}

        //http://devlibrary.businessobjects.com/businessobjectsxir2/en/en/WS_SDK/wssdk_consumer/doc/wssdk_net_consumer_apiRef/html/wslrfBusinessObjectsDSWSReportEngineViewModeTypeClassTopic.htm

        public ExitCode DownloadReportsFile(ref Report[] pReports, string pFolder, string pAssociatedInstance, string pFormat){
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            pAssociatedInstance = pAssociatedInstance.ToUpper();
            pFormat = pFormat.ToUpper();
            pFolder = pFolder.TrimEnd('\\') + '\\';

            ExitCode exitcode = ExitCode.SUCCEED;
            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach (Report report in pReports ){
                try{
                    if (report.Cuid == null || report.Cuid == string.Empty) throw new Exception("Report Cuid is empty");
                    switch (pAssociatedInstance){
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
                    switch (pFormat){
                        case "DEFAULT":
                            report.Instance.Time = Rand.Time("00:00:10","00:10:00") ;
                            string filePath = pFolder + Rand.Number(1, 10000).ToString() + "-" + Rand.String(10) + ".ext";
                            SaveTestFile(pFolder  + report.Id + "-" + report.Name + ".rpt");
                            report.LOG = "DOWNLOADED as BINARY";
                            break;
                        case "XML":
                            System.Xml.XmlWriterSettings xmlSettingsWithIndentation = new System.Xml.XmlWriterSettings { Indent = true};
                            object[] docInfoReports = new object[Rand.Number(1, 4)];
                            _sessionmanager.InitSubProgress(docInfoReports.Length);
                            foreach( object docReport  in docInfoReports){
                                System.Threading.Thread.Sleep(1000);
                                _sessionmanager.IncSubProgress();
                            }
                            SaveTestFile(pFolder  + report.Id + "-" + report.Name + ".xml");
                            break;
                        case "HTML":
                            object[] docInfo = new object[Rand.Number(1, 4)];
                            _sessionmanager.InitSubProgress(docInfo.Length);
                            foreach( object docReport  in docInfo){
                                System.Threading.Thread.Sleep(1000);
                                _sessionmanager.IncSubProgress();
                            }
                            SaveTestFile(pFolder + report.Id + "-" + report.Name + ".html");
                            report.LOG = "DOWNLOADED as Html";
                            break;
                        case "PDF":
                            SaveTestFile(pFolder + report.Id + "-" + report.Name + ".pdf");
                            report.LOG = "DOWNLOADED as Pdf";
                            break;
                        case "EXCEL":
                            SaveTestFile(pFolder + report.Id + "-" + report.Name + ".xls");
                            report.LOG = "DOWNLOADED as Excel";
                            break;
                    }
                    Rand.Exception(10, "Test exception!");
                }catch(Exception ex){
                    exitcode = ExitCode.HASERROR;
                    report.LOG = _sessionmanager.ParseException(ex);
                    _sessionmanager.Log(" Error: " + _sessionmanager.ParseException(ex));
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }
            return exitcode;
		}

        private void SaveTestFile(string path)
        {
            using (System.IO.TextWriter tw = new System.IO.StreamWriter(path))
            {
                tw.WriteLine("Empty file");
                tw.Close();
            }

        }


        public System.Windows.Forms.TreeNodeCollection EnumFolders()
        {

            System.Windows.Forms.TreeNode nodes = new System.Windows.Forms.TreeNode();

            object[] paths = new object[]{
                new object[]{ "FolderA", new string[]{"1", "11"}},
                new object[]{ "FolderB", new string[]{"2", "21", "211"}},
                new object[]{ "FolderC", new string[]{"1", "11", "112"}},
                new object[]{ "FolderD", new string[]{"2", "22", "221"}}
            };

            for(int p=0; p<paths.Length; p++){
                System.Windows.Forms.TreeNode node = nodes;
                object[] obj = (object[])paths[p];
                for (int f = ((string[])obj[1]).Length-1; f != -1; f--)
                {
                    node = Func.AddTreeNode(node, ((string[])obj[1])[f]);
                }
                Func.AddTreeNode(node, (string)obj[0]);
            }
            return nodes.Nodes;
        }


        public List<System.Windows.Forms.ListViewItem> EnumReports(string path)
        {
            object[] paths = new object[]{
                new string[]{ "1","Name1", "Webi"},
                new string[]{ "2","Name2", "Crystal"},
                new string[]{ "3","Name3", "Webi"},
                new string[]{ "4","Name4", "Deski"}
            };

            List<System.Windows.Forms.ListViewItem> collection = new List<System.Windows.Forms.ListViewItem>();

            foreach (string[] ele in paths){
                collection.Add(new System.Windows.Forms.ListViewItem(new string[] { ele[0], ele[1], ele[2] }, 0));
            }
            return collection;
        }



    }
}
