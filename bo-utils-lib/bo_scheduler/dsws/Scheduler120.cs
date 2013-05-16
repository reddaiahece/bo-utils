extern alias DSWS120;

using System;
using System.Collections.Generic;
using BusinessObjectsUtils.bo_session.dsws;
using BusinessObjectsUtils.helper;

using BIPlatform = DSWS120::BusinessObjects.DSWS.BIPlatform.BIPlatform;
using ReportEngine = DSWS120::BusinessObjects.DSWS.ReportEngine.ReportEngine;
using FixedCUIDs = DSWS120::BusinessObjects.DSWS.BIPlatform.Constants.FixedCUIDs;
using ResponseHolder = DSWS120::BusinessObjects.DSWS.BIPlatform.ResponseHolder;
using InfoObjects = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.InfoObjects;
using InfoObject = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.InfoObject;
using PageInfo = DSWS120::BusinessObjects.DSWS.BIPlatform.PageInfo;
using PagingDetails = DSWS120::BusinessObjects.DSWS.BIPlatform.PagingDetails;
using DownloadStatus = DSWS120::BusinessObjects.DSWS.BIPlatform.DownloadStatus;
using PromptValue = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.PromptValue;
using PromptValueR = DSWS120::BusinessObjects.DSWS.ReportEngine.PromptValue;
using DiscretePromptValue = DSWS120::BusinessObjects.DSWS.ReportEngine.DiscretePromptValue;
using RangePromptValue = DSWS120::BusinessObjects.DSWS.ReportEngine.RangePromptValue;
using DiskUnmanaged = DSWS120::BusinessObjects.DSWS.BIPlatform.Dest.DiskUnmanaged;
using DiskUnmanagedScheduleOptions = DSWS120::BusinessObjects.DSWS.BIPlatform.Dest.DiskUnmanagedScheduleOptions;
using SMTPScheduleOptions = DSWS120::BusinessObjects.DSWS.BIPlatform.Dest.SMTPScheduleOptions;
using ManagedScheduleOptions = DSWS120::BusinessObjects.DSWS.BIPlatform.Dest.ManagedScheduleOptions;
using GetOptions = DSWS120::BusinessObjects.DSWS.BIPlatform.GetOptions;
using RetrievePromptsInfo = DSWS120::BusinessObjects.DSWS.ReportEngine.RetrievePromptsInfo;
using RetrieveReportList = DSWS120::BusinessObjects.DSWS.ReportEngine.RetrieveReportList;
using Action = DSWS120::BusinessObjects.DSWS.ReportEngine.Action;
using Close = DSWS120::BusinessObjects.DSWS.ReportEngine.Close;
using PromptInfo = DSWS120::BusinessObjects.DSWS.ReportEngine.PromptInfo;
using DocumentInformation = DSWS120::BusinessObjects.DSWS.ReportEngine.DocumentInformation;
using RetrieveMustFillInfo = DSWS120::BusinessObjects.DSWS.ReportEngine.RetrieveMustFillInfo;
using RetrieveViewSupport = DSWS120::BusinessObjects.DSWS.ReportEngine.RetrieveViewSupport;
using Report_ = DSWS120::BusinessObjects.DSWS.ReportEngine.Report;
using XMLView = DSWS120::BusinessObjects.DSWS.ReportEngine.XMLView;
using CharacterView = DSWS120::BusinessObjects.DSWS.ReportEngine.CharacterView;
using RetrieveData = DSWS120::BusinessObjects.DSWS.ReportEngine.RetrieveData;
using RetrieveView = DSWS120::BusinessObjects.DSWS.ReportEngine.RetrieveView;
using OutputFormatType = DSWS120::BusinessObjects.DSWS.ReportEngine.OutputFormatType;
using ViewModeType = DSWS120::BusinessObjects.DSWS.ReportEngine.ViewModeType;
using NavigateToPath = DSWS120::BusinessObjects.DSWS.ReportEngine.NavigateToPath;
using ViewType = DSWS120::BusinessObjects.DSWS.ReportEngine.ViewType;
using ViewSupport = DSWS120::BusinessObjects.DSWS.ReportEngine.ViewSupport;
using RetrieveXMLView = DSWS120::BusinessObjects.DSWS.ReportEngine.RetrieveXMLView;
using RetrieveBinaryView = DSWS120::BusinessObjects.DSWS.ReportEngine.RetrieveBinaryView;
using BinaryView = DSWS120::BusinessObjects.DSWS.ReportEngine.BinaryView;
using Folder = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Folder;
using Inbox = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Inbox;
using FavoritesFolder = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.FavoritesFolder;
using PathFolder = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.PathFolder;
using Pdf = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Pdf;
using Excel = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Excel;
using Webi = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Webi;
using WebiPrompt = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.WebiPrompt;
using WebiFormatEnum = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.WebiFormatEnum;
using WebiFormatOptions = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.WebiFormatOptions;
using WebiProcessingInfo = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.WebiProcessingInfo;
using CrystalReport = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.CrystalReport;
using CrystalReportFormatOptions = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.CrystalReportFormatOptions;
using DataProvider = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.DataProvider;
using ScheduleTypeEnum = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.ScheduleTypeEnum;
using SchedulingInfo = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.SchedulingInfo;
using ReportFormatEnum = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.ReportFormatEnum;
using Destination = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Destination;
using Program = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Program;
using Smtp = DSWS120::BusinessObjects.DSWS.BIPlatform.Dest.Smtp;
using Notifications = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Notifications;
using ReportParameter = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.ReportParameter;
using DeletionCriteria = DSWS120::BusinessObjects.DSWS.BIPlatform.DeletionCriteria;
using Publication = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Publication;
using FormatTypeEnum = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.FormatTypeEnum;
using OutputFormat = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.OutputFormat;
using ScheduleStatusEnum = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.ScheduleStatusEnum;
using ScheduleOutcomeEnum = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.ScheduleOutcomeEnum;
using File = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.File;
using Path = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.Path;
using FileProperties = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.FileProperties;
using CustomProperties = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.CustomProperties;
using CustomPropertiesString = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.CustomPropertiesString;
using FullClient = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.FullClient;
using FullClientProcessingInfo = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.FullClientProcessingInfo;
using FullClientPrompt = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.FullClientPrompt;
using FullClientFormatOptions = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.FullClientFormatOptions;
using FullClientFormatEnum = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.FullClientFormatEnum;
using ObjectPackage = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.ObjectPackage;
using CurrentValues = DSWS120::BusinessObjects.DSWS.BIPlatform.Desktop.CurrentValues;
using BusinessObjectsUtils.bo_session;

namespace BusinessObjectsUtils.bo_scheduler.dsws
{
    public class Scheduler120 : IScheduler
	{
        private readonly SessionManager _sessionmanager;
        private readonly BIPlatform _biplatform;
        private readonly ReportEngine _reportengine;
        private bool _cancel;

        public Scheduler120(SessionManager sessionmanager)
        {
            if (!(sessionmanager.Session is Session120)) throw new Exception("Wrong version between session and scheduler!");
            _sessionmanager = sessionmanager;
            _biplatform = (sessionmanager.Session as Session120).BIPlatform;
            _reportengine = (sessionmanager.Session as Session120).ReportEngine;
        }

        public void Cancel()
        {
            _cancel = true;
        }

        public ExitCode GetReports(string pPath, bool pWithPrompts, string pAssociatedInstance, out Report[] pReports){
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            pReports = new Report[]{};
            var exitcode = ExitCode.SUCCEED;
            var reports = new List<Report>();
            var queries = new List<string[]>();
            const string @select = "SI_ID,SI_KIND,SI_NAME,SI_PARENT_CUID,SI_CHILDREN,SI_CREATION_TIME,SI_UPDATE_TS,SI_LAST_SUCCESSFUL_INSTANCE_ID,SI_PROCESSINFO,SI_PROCESSINFO.SI_HAS_PROMPTS,SI_PROCESSINFO.SI_PROMPTS,SI_PROCESSINFO.SI_WEBI_PROMPTS,SI_PROCESSINFO.SI_FULLCLIENT_PROMPTS";
            const string @where = "SI_KIND IN('Webi','Publication','CrystalReport','ObjectPackage') AND SI_INSTANCE=0";
            if ( System.Text.RegularExpressions.Regex.Match(pPath, @"^[\d, ]+$").Success)
                queries.Add(new string[2]{ pPath, "query://{SELECT " + select + " FROM CI_INFOOBJECTS WHERE " + where + " AND SI_ID IN(" + pPath + ")}" });
            else{
                foreach(string query in pPath.Split(','))
                    queries.Add(new string[2] { query, "cuid://<" + FixedCUIDs.RootFolder.FOLDERS + ">/" + query + "[" + where + "]@" + select });
            }
            _sessionmanager.InitProgress(3, 100, queries.Count);
            #region  Loop through queries
            foreach(var query in queries){
                switch (pAssociatedInstance) {
                    case "LAST_SUCCEED": _sessionmanager.Log("Get reports with last succeed instances for " + query[0]); break;
                    case "LAST_FAILED": _sessionmanager.Log("Get reports with last failed instances for " + query[0]); break;
                    case "LAST_CREATED": _sessionmanager.Log("Get reports with last created instances for " + query[0]); break;
                    default: _sessionmanager.Log("Get reports without instance in " + query[0]); break;
                }
                var opt = new GetOptions { PageSize = 99999, PageSizeSpecified = true };
                var boResponse = _biplatform.Get(query[1], opt);
                if( boResponse==null || boResponse.InfoObjects==null || boResponse.InfoObjects.InfoObject==null || boResponse.InfoObjects.InfoObject.Length == 0)
                    throw new Exception("Query didn't return any objects ! ");
                var pagingDetails = boResponse.PagingDetails;
                var pageInfos = pagingDetails.PageInfo;
                _sessionmanager.InitSubProgress(pagingDetails.ResultSize);
                if (_cancel) return ExitCode.CANCELED;
			    var nbPages = pageInfos.Length;
                const string selectInst = "SI_ID,SI_KIND,SI_CREATION_TIME,SI_SCHEDULE_STATUS,SI_STATUSINFO,SI_STARTTIME,SI_UPDATE_TS,SI_SCHEDULEINFO,SI_SCHEDULEINFO.SI_UISTATUS,SI_SCHEDULEINFO.SI_OUTCOME,SI_PROCESSINFO,SI_PROCESSINFO.SI_HAS_PROMPTS,SI_PROCESSINFO.SI_WEBI_PROMPTS,SI_PROCESSINFO.SI_PROMPTS,SI_PROCESSINFO.SI_FULLCLIENT_PROMPTS";
                var boMustFill = new RetrieveMustFillInfo { RetrievePromptsInfo = new RetrievePromptsInfo() };
                var boActionClose = new Action[] { new Close() };
                #region Loop through pages
                var ciud = "";
                for (var p=0; p < nbPages; p++){
                    InfoObjects boInfoObjects = p==0 ? boResponse.InfoObjects : _biplatform.Get(pageInfos[p].PageURI, opt).InfoObjects;
				    var nbReports = boInfoObjects.InfoObject.Length;
                    if (nbReports!=0){
                        if(boInfoObjects.InfoObject[0].CUID == ciud) throw new Exception("Web service paging failed !");
                        ciud = boInfoObjects.InfoObject[0].CUID;
                    }
                    #region Loop through reports                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        #region Loop through reports
                    for(var r=0; r < nbReports; r++){
                        var boInfoObject = boInfoObjects.InfoObject[r];
                        _sessionmanager.Log("Get report " + GetObjectLongName( boInfoObject) );
                        var instance = new Instance();
                        var tPrompt = new List<Prompt>();
                        string parentFolder = null;
                        string loginfo = null;
					    try{
                            InfoObjects boInstanceInfoObjects = null;
                            InfoObject boInfoObjectPrompts;
                            switch(pAssociatedInstance){
                                case "LAST_SUCCEED":
                                    if( boInfoObject.LastSuccessfulInstanceCUID != null)
                                        boInstanceInfoObjects = _biplatform.Get("cuid://<" + boInfoObject.LastSuccessfulInstanceCUID + ">@" + selectInst, null).InfoObjects;
                                    break;
                                case "LAST_FAILED" :
                                    boInstanceInfoObjects = _biplatform.Get("query://{SELECT TOP 1 " + selectInst + " FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + boInfoObject.CUID + "' AND SI_SCHEDULEINFO.SI_OUTCOME>1 ORDER BY SI_CREATION_TIME DESC}", null).InfoObjects;
                                    break;
                                case "LAST_CREATED" :
                                    boInstanceInfoObjects = _biplatform.Get("query://{SELECT TOP 1 " + selectInst + " FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + boInfoObject.CUID + "' ORDER BY SI_CREATION_TIME DESC}", null).InfoObjects;
                                    break;
                            }
                            if( boInstanceInfoObjects != null && boInstanceInfoObjects.InfoObject != null &&  boInstanceInfoObjects.InfoObject.Length != 0){
                                var boInstanceInfoObject = boInstanceInfoObjects.InfoObject[0];
                                instance.Cuid = boInstanceInfoObject.CUID;
                                instance.Id = boInstanceInfoObject.ID;
                                instance.Date = boInstanceInfoObject.CreationTime.ToLocalTime().ToString("yyyy/MM/dd HH:mm");
                                var scheduleinfo = GetSchedulingInfo(boInstanceInfoObject);
                                instance.Status = scheduleinfo.Status.ToString();
                                if( scheduleinfo.Status == ScheduleStatusEnum.FAILURE)
                                    instance.Status += ": " + scheduleinfo.ErrorMessage;
                                else if(scheduleinfo.Status == ScheduleStatusEnum.COMPLETE)
                                    instance.Time = GetExecutionTime(boInstanceInfoObject);
                                boInfoObjectPrompts = boInstanceInfoObject;
                            }else
                                boInfoObjectPrompts = boInfoObject;

                            parentFolder = GetInfoObjectLocation(boInfoObject.ParentCUID);

                            if(boInfoObjectPrompts is Pdf){
                                var reportPdf = (Pdf)boInfoObjectPrompts;
                                ParseCustomPropertiesToPrompt( reportPdf.CustomProperties, ref tPrompt);
                            }else if(boInfoObjectPrompts is Excel){
                                var reportPdf = (Excel)boInfoObjectPrompts;
                                ParseCustomPropertiesToPrompt( reportPdf.CustomProperties, ref tPrompt);
                            }else if(boInfoObjectPrompts is Webi){
							    var reportWebi = (Webi)boInfoObjectPrompts;
							    if (pWithPrompts && reportWebi.WebiProcessingInfo!=null && reportWebi.WebiProcessingInfo.HasPrompts){
                                    if (reportWebi.WebiProcessingInfo.Prompts == null || reportWebi.WebiProcessingInfo.Prompts.Length == 0){
                                            var documentInformation = _reportengine.GetDocumentInformation(reportWebi.CUID, boMustFill, boActionClose, null, null);
                                            if( documentInformation!=null && documentInformation.PromptInfo!=null) {
                                                var srcPromptInfo = documentInformation.PromptInfo;
                                                if(srcPromptInfo != null){
                                                    foreach (var info in srcPromptInfo){
                                                        var values = string.Empty;
                                                        if (info.DefaultValues != null){
                                                            foreach( var val in info.DefaultValues){
                                                                if (values != string.Empty) values += ";";
                                                                if(val is DiscretePromptValue)
                                                                    values += (val as DiscretePromptValue).Value;
                                                                else if(val is RangePromptValue)
                                                                    values += RangePromptValueToString(val as RangePromptValue);
                                                            }
                                                        }
                                                        tPrompt.Add(new Prompt { Name = info.Name, Value = values });
                                                    }
                                                }
                                            }
							        }else{
									    var webiPrompts = reportWebi.WebiProcessingInfo.Prompts;
									    for (var i = 0; i < webiPrompts.Length; i++)
										    tPrompt.Add(new Prompt { Name = webiPrompts[i].Name, Value = Func.Join( webiPrompts[i].Values) });
                                    }
                                }
						    }else if(boInfoObjectPrompts is ObjectPackage){
                                var objectPackage = (ObjectPackage)boInfoObject;
						    }else if(boInfoObjectPrompts is FullClient){
							    var reportDeski = (FullClient)boInfoObjectPrompts;
							    if (pWithPrompts && reportDeski.FullClientProcessingInfo!=null && reportDeski.FullClientProcessingInfo.HasPrompts 
                                        && reportDeski.FullClientProcessingInfo.Prompts!=null ){
								    var deskiPrompts = reportDeski.FullClientProcessingInfo.Prompts;
								    for (var i = 0; i < deskiPrompts.Length; i++)
                                        tPrompt.Add(new Prompt { Name = deskiPrompts[i].Name, Value = Func.Join(deskiPrompts[i].Values) });
							    }
						    }else if(boInfoObjectPrompts is CrystalReport){
							    var reportCrystal = (CrystalReport)boInfoObjectPrompts;
                                if(pWithPrompts && reportCrystal.PluginProcessingInterface!=null 
                                    && reportCrystal.PluginProcessingInterface.ReportParameters!=null){
								    var reportParam = reportCrystal.PluginProcessingInterface.ReportParameters;
								    for (var i = 0; i < reportParam.Length; i++){
									    var values = string.Empty;
                                        if (reportParam[i].CurrentValues.CurrentValue != null){
									        foreach( var val in reportParam[i].CurrentValues.CurrentValue){
                                                if (values != string.Empty) values += ";";
										        values += val.Data;
									        }
                                        }else if(reportParam[i].DefaultValues != null){
									        foreach( var val in reportParam[i].DefaultValues){
                                                if (values != string.Empty) values += ";";
										        values += val.Data;
									        }
                                        }
                                        tPrompt.Add(new Prompt { Name = reportParam[i].ParameterName, Value = values });
								    }
                                }
						    }
					    }catch(Exception ex){
                            loginfo = _sessionmanager.ParseException(ex);
                            _sessionmanager.Log( " Error: " + _sessionmanager.ParseException(ex));
                            exitcode = ExitCode.HASERROR;
					    }
					    reports.Add(new Report {
                            LOG = loginfo,
                            Instance = instance,
                            Cuid = boInfoObject.CUID,
						    Id = boInfoObject.ID,
						    Type = boInfoObject.Kind,
						    Name = boInfoObject.Name,
                            Folder = parentFolder,
                            NbChild = boInfoObject.ChildrenObjectsSpecified ? (int)boInfoObject.ChildrenObjects : 0,
                            Prompts = tPrompt.ToArray()
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

        public ExitCode ScheduleReport(ref Report[] pReports, bool pSetPrompts, DateTime pDate, string pPath, string pOutFormat, bool pWaitEnd, bool pCleanup, string pNotifEmail){
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            _sessionmanager.InitProgress(3, pWaitEnd ? 50 : 80, pReports.Length);
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            _sessionmanager.Log("Starts to Schedule reports " + Func.getTime());
            var exitcode = ExitCode.SUCCEED;
            var waitreports = new List<Report>();
            var boCloseAction = new Action[] { new Close() };
            var boMustFill = new RetrieveMustFillInfo { RetrievePromptsInfo = new RetrievePromptsInfo() };
            Destination[] lDestinationDisk;
            pOutFormat = pOutFormat==null? string.Empty: pOutFormat.ToLower();
            if (!string.IsNullOrEmpty(pPath) ){
                lDestinationDisk = new[]{ new Destination{
                    Name = "CrystalEnterprise.DiskUnmanaged",
                    DestinationScheduleOptions = new DiskUnmanagedScheduleOptions { DestinationFiles = new string[] { pPath } }
                }};
            }else{
                lDestinationDisk = new[]{ new Destination{
                    DestinationScheduleOptions = new ManagedScheduleOptions {  }
                }};
            }
            var scheduleInfo = new SchedulingInfo{
                // OutcomeSpecified = true,
                BeginDate = pDate.ToUniversalTime(),
                BeginDateSpecified = (pDate != DateTime.MinValue),
                Cleanup = pCleanup && !pWaitEnd,
                CleanupSpecified = pCleanup && !pWaitEnd,
                ScheduleType = ScheduleTypeEnum.ONCE,
                ScheduleTypeSpecified = true,
                RightNow = (pDate == DateTime.MinValue),
                RightNowSpecified = (pDate == DateTime.MinValue),
                Destinations = lDestinationDisk
            };
            foreach (var report in pReports ){
                var instanceCuid = string.Empty;
                try{
                    _sessionmanager.Log("Schedule report " + report.ToLongName());
                    // "query://{SELECT SI_ID, SI_NAME, SI_KIND FROM CI_INFOOBJECTS WHERE SI_ID=" + pReportId + "}";
                    var boInfoObjects = GetInfoObject( "query://{SELECT * FROM CI_INFOOBJECTS WHERE SI_INSTANCE=0 AND SI_ID=" + report.Id + "}");
                    var boInfoObject = boInfoObjects.InfoObject[0];
                    switch(boInfoObject.Kind){
					    case "Webi":
						    var reportWebi = (Webi)boInfoObject;
						    WebiFormatEnum webiFormat;
						    switch(pOutFormat){
							    case "excel": webiFormat = WebiFormatEnum.EXCEL; break;
							    case "pdf": webiFormat = WebiFormatEnum.PDF; break;
							    default : webiFormat = WebiFormatEnum.WEBI; break ;
						    }
                            if(pSetPrompts && reportWebi.WebiProcessingInfo.HasPrompts ){
                                var documentInformation = _reportengine.GetDocumentInformation(reportWebi.CUID, boMustFill, boCloseAction, null, null); 
						        var srcPromptInfo = documentInformation.PromptInfo;
						        if(reportWebi.WebiProcessingInfo==null) reportWebi.WebiProcessingInfo = new WebiProcessingInfo();
						        if (null != srcPromptInfo && 0 != srcPromptInfo.Length){
							        reportWebi.WebiProcessingInfo.Prompts = new WebiPrompt[srcPromptInfo.Length];
                                    reportWebi.WebiProcessingInfo.HasPrompts = true;
                                    if (report.Prompts.Length != srcPromptInfo.Length) throw new Exception( "Number of prompts is incorrect. provided=" + report.Prompts.Length + "  expected=" + srcPromptInfo.Length );
                                    for (var cp = 0; cp < srcPromptInfo.Length; cp++){
                                        var found = false;
                                        for(var mp=0; mp<report.Prompts.Length; mp++){
                                            if(report.Prompts[mp].Name != srcPromptInfo[cp].Name) continue;
                                            found = true;
                                            reportWebi.WebiProcessingInfo.Prompts[mp] = new WebiPrompt{
                                                Name = report.Prompts[mp].Name,
                                                Values = report.Prompts[mp].Value.Split(';'),
                                                DataProviders = new DataProvider[srcPromptInfo[cp].DataProviderIDs.Length]
                                            };
                                            for (var d = 0; d < srcPromptInfo[cp].DataProviderIDs.Length; d++)
                                                reportWebi.WebiProcessingInfo.Prompts[mp].DataProviders[d] = new DataProvider{ ID=srcPromptInfo[cp].DataProviderIDs[d] };
                                            break;
                                        }
                                        if(found==false) throw new Exception("Prompt name <" + srcPromptInfo[cp].Name + "> is missing ! ");
							        }
						        }
                                documentInformation = _reportengine.GetDocumentInformation(reportWebi.CUID, null, boCloseAction, null, null);
                            }
						    reportWebi.WebiProcessingInfo.WebiFormatOptions = new WebiFormatOptions { Format = webiFormat, FormatSpecified = true };
						    reportWebi.SchedulingInfo = scheduleInfo;
						    reportWebi = (Webi)_biplatform.Schedule( boInfoObjects).InfoObject[0];
                            instanceCuid = reportWebi.NewJobID;
                            break;
					    case "CrystalReport":
						    var reportCrystal = (CrystalReport)boInfoObject;
						    ReportFormatEnum reportFormat;
						    switch(pOutFormat){
							    case "excel": reportFormat = ReportFormatEnum.EXCEL; break;
							    case "pdf": reportFormat = ReportFormatEnum.PDF; break;
							    default: reportFormat = ReportFormatEnum.CRYSTAL_REPORT; break;
						    }
						    reportCrystal.PluginProcessingInterface.ReportFormatOptions = new CrystalReportFormatOptions{
							    Format = reportFormat, FormatSpecified = true
						    };
                            if(pSetPrompts && reportCrystal.PluginProcessingInterface.ReportParameters != null){
						        var reportParam = reportCrystal.PluginProcessingInterface.ReportParameters;
                                if(reportParam.Length !=0){
                                    if (report.Prompts.Length != reportParam.Length)  throw new Exception( "Number of prompts is incorrect. provided=" + report.Prompts.Length + "  expected=" + reportParam.Length );
						            for(var cp = 0; cp < reportParam.Length; cp++){
                                        reportParam[cp].CurrentValues.CurrentValue = null;
                                        foreach(var prompt in report.Prompts){
                                            if (prompt.Name != reportParam[cp].ParameterName) continue;
                                            var myPrompts = report.Prompts[cp].Value.Split(';');
                                            reportParam[cp].CurrentValues.CurrentValue = new PromptValue[myPrompts.Length];
                                            for(var v = 0; v < myPrompts.Length; v++)
                                                reportParam[cp].CurrentValues.CurrentValue[v] = new PromptValue { Data = myPrompts[v] };
                                            break;
                                        }
                                        if (reportParam[cp].CurrentValues == null) throw new Exception("Prompt name <" + reportParam[cp].ParameterName + "> is missing ! ");
						            }
                                }
                            }
                            reportCrystal.SchedulingInfo = scheduleInfo;
						    reportCrystal = (CrystalReport)_biplatform.Schedule(boInfoObjects).InfoObject[0];
                            instanceCuid = reportCrystal.NewJobID;
                            break;
					    case "FullClient":
                            var reportDeski = (FullClient)boInfoObject;
						    FullClientFormatEnum deskiFormat;
						    switch(pOutFormat){
                                case "excel": deskiFormat = FullClientFormatEnum.EXCEL; break;
                                case "pdf": deskiFormat = FullClientFormatEnum.PDF; break;
                                default: deskiFormat = FullClientFormatEnum.FULL_CLIENT; break;
						    }
			    			if(pSetPrompts && reportDeski.FullClientProcessingInfo.HasPrompts){
			    				var deskiPrompts = reportDeski.FullClientProcessingInfo.Prompts;
                                if (report.Prompts.Length != deskiPrompts.Length) throw new Exception( "EXCEPTION : Number of prompts is incorrect. provided=" + report.Prompts.Length + "  expected=" + deskiPrompts.Length );
                                for (int p = 0; p < deskiPrompts.Length; p++){
                                    deskiPrompts[p].Values = null;
                                    foreach (var prompt in report.Prompts){
                                        if (prompt.Name == deskiPrompts[p].Name){
                                            deskiPrompts[p].Values = report.Prompts[p].Value.Split(';');
                                            break;
                                        }
                                    }
                                    if (deskiPrompts[p].Name == null) throw new Exception("Prompt name <" + deskiPrompts[p].Name + "> is missing ! ");
                                }
			    			}
				    		reportDeski.FullClientProcessingInfo.FullClientFormatOptions = new FullClientFormatOptions{ Format = deskiFormat, FormatSpecified = true };
	    				    reportDeski.SchedulingInfo = scheduleInfo;
				    		reportDeski = (FullClient)_biplatform.Schedule( boInfoObjects).InfoObject[0];
                            instanceCuid = reportDeski.NewJobID;
                            break;
					    default:
						    throw new Exception( boInfoObject.Kind + " reports are not supported");
				    }
                    report.NbChild = (int)boInfoObject.ChildrenObjects + 1;
                    report.Instance = new Instance { Cuid = instanceCuid };
                    waitreports.Add(report);
                }catch(Exception ex){
                    exitcode = ExitCode.HASERROR;
                    report.LOG = _sessionmanager.ParseException(ex);
                    _sessionmanager.Log(" Error: " + _sessionmanager.ParseException(ex));
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }

            _sessionmanager.InitProgress(pWaitEnd ? 51 : 81, 100, waitreports.Count);
            if(pWaitEnd)
                _sessionmanager.Log("Wait for reports to be created...");
            else
                _sessionmanager.Log("Get reports status for created reports...");

            if (_cancel) return ExitCode.CANCELED;
            while (waitreports.Count != 0){
                for (var i = waitreports.Count -1 ; i != -1; i--){
                    try{
                        var boInfoObjects = GetInfoObject("cuid://<" + waitreports[i].Cuid + ">@SI_ID,SI_NAME,SI_KIND,SI_CREATION_TIME,SI_SCHEDULEINFO,SI_SCHEDULEINFO.SI_PROGRESS,SI_SCHEDULEINFO.SI_OUTCOME,SI_SCHEDULE_STATUS,SI_STARTTIME,SI_UPDATE_TS");
                        var boInfoObject = boInfoObjects.InfoObject[0];
                        var scheduleinfo = GetSchedulingInfo(boInfoObject);
                        waitreports[i].Instance.Id = boInfoObject.ID;
                        waitreports[i].Instance.Date = boInfoObject.CreationTime.ToLocalTime().ToString("yyyy/MM/dd HH:mm");
                        waitreports[i].Instance.Status = scheduleinfo.Status.ToString();
                        if( scheduleinfo.Status != ScheduleStatusEnum.PENDING && scheduleinfo.Status != ScheduleStatusEnum.RUNNING){
                            if (pWaitEnd) _sessionmanager.IncProgress();
                            if (_cancel) return ExitCode.CANCELED;
                             if( scheduleinfo.Status == ScheduleStatusEnum.FAILURE){
                                waitreports[i].Instance.Status += ": " + scheduleinfo.ErrorMessage;
                                _sessionmanager.Log(waitreports[i].Instance.Status);
                                exitcode = ExitCode.HASERROR;
                             }else if(scheduleinfo.Status == ScheduleStatusEnum.COMPLETE){
                                 waitreports[i].Instance.Time = GetExecutionTime(boInfoObject);
                             }
                             waitreports.Remove(waitreports[i]);
                             if(pCleanup && pWaitEnd) _biplatform.Delete(boInfoObjects);
                             _sessionmanager.Log("Done for report " + GetObjectLongName(boInfoObject));
                        }
                    }catch(Exception ex){
                        exitcode = ExitCode.HASERROR;
                        waitreports[i].LOG = _sessionmanager.ParseException(ex);
                        _sessionmanager.Log(" Error: " + _sessionmanager.ParseException(ex));
                    }
                    if (!pWaitEnd) _sessionmanager.IncProgress();
                    if (_cancel) return ExitCode.CANCELED;
                }
                if (pWaitEnd == false) break;
                if( ! Waiter.Wait(500 + (waitreports.Count * 100), ref _cancel) )
                    return ExitCode.CANCELED;
                _sessionmanager.ResetSessionTimeOut();
            }
            if(pWaitEnd)
                _sessionmanager.Log("Remaining reports : " + waitreports.Count);
            _sessionmanager.Log("End of reports scheduling - " + Func.getTime());
            if (pNotifEmail!=string.Empty)
                SendEmail(pNotifEmail, "[Business Objects] Scheduling result: " + exitcode.ToString() , _sessionmanager.GetLogText());
            return exitcode;
		}

        public ExitCode GetReportsSchedulStatus(ref Report[] pReports, string pAssociatedInstance){
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            var exitcode = ExitCode.SUCCEED;
            _sessionmanager.InitProgress(3, 100, pReports.Length);
            const string StatusFields = "SI_ID,SI_KIND,SI_CREATION_TIME,SI_SCHEDULEINFO,SI_SCHEDULE_STATUS,SI_STARTTIME,SI_UPDATE_TS";
            foreach (var report in pReports){
                try{
                    ResponseHolder boResponse;
                    switch (pAssociatedInstance){
                        case "LAST_SUCCEED" :
                            _sessionmanager.Log("Get last succeed instance of " + report.ToLongName());
                            boResponse = _biplatform.Get("query://{SELECT TOP 1 " + StatusFields + " FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + report.Cuid + "' AND SI_SCHEDULEINFO.SI_OUTCOME<2 ORDER BY SI_CREATION_TIME DESC}", null);
                            break;
                        case "LAST_FAILED":
                            _sessionmanager.Log("Get last failed instance of " + report.ToLongName());
                            boResponse = _biplatform.Get("query://{SELECT TOP 1 " + StatusFields + " FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + report.Cuid + "' AND SI_SCHEDULEINFO.SI_OUTCOME>1 ORDER BY SI_CREATION_TIME DESC}", null);
                            break;
                        case "LAST_CREATED":
                            _sessionmanager.Log("Get last created instance of " + report.ToLongName());
                            boResponse = _biplatform.Get("query://{SELECT TOP 1 " + StatusFields + " FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + report.Cuid + "' ORDER BY SI_CREATION_TIME DESC}", null);
                            break;
                        case "SPECIFIED":
                            if (report.Instance == null || report.Instance.Cuid == String.Empty) throw new Exception("The instance <Cuid> argument is missing for report " + report.ToLongName());
                            _sessionmanager.Log("Get instance " + report.Instance.Id + " of " + report.ToLongName());
                            boResponse = _biplatform.Get("cuid://<" + report.Instance.Cuid + ">@" + StatusFields, null);
                            break;
                        default:
                            throw new Exception("Option " + pAssociatedInstance + " is not available ! ");
                    }
                    if(pAssociatedInstance != "SPECIFIED") report.Instance = new Instance();
                    if (boResponse != null && boResponse.InfoObjects != null && boResponse.InfoObjects.InfoObject != null && boResponse.InfoObjects.InfoObject.Length != 0){
                        var boInfoObject = boResponse.InfoObjects.InfoObject[0];
                        var scheduleinfo = GetSchedulingInfo(boInfoObject);
                        report.Instance.Cuid = boInfoObject.CUID;
                        report.Instance.Id = boInfoObject.ID;
                        report.Instance.Date = boInfoObject.CreationTime.ToLocalTime().ToString("yyyy/MM/dd HH:mm");
                        report.Instance.Status = scheduleinfo.Status.ToString();
                        if( scheduleinfo.Status == ScheduleStatusEnum.FAILURE)
                            report.Instance.Status += ": " + scheduleinfo.ErrorMessage;
                        else if(scheduleinfo.Status == ScheduleStatusEnum.COMPLETE)
                            report.Instance.Time = GetExecutionTime(boInfoObject);
                    }
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

		public ExitCode DeleteReportsInstance(ref Report[] pReports, string pAssociatedInstance){
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            var exitcode = ExitCode.SUCCEED;
            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach (var report in pReports ){
                try{
                    InfoObjects boInfoObjects;
                    switch (pAssociatedInstance){
                        case "SPECIFIED":
                            if (report.Instance == null || report.Instance.Cuid == String.Empty) throw new Exception("The instance <Cuid> argument is missing for report " + report.ToLongName());
                            _sessionmanager.Log("Delete instance " + report.Instance.Id + " of " + report.ToLongName());
                            boInfoObjects = _biplatform.Get("cuid://<" + report.Instance.Cuid + ">", null).InfoObjects;
                            break;
                        case "ALL_FAILED":
                            _sessionmanager.Log("Delete failed instances of " + report.ToLongName());
                            boInfoObjects = _biplatform.Get("query://{SELECT SI_ID FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + report.Cuid + "' AND SI_SCHEDULEINFO.SI_OUTCOME>1 AND SI_RECURRING=0 }", null).InfoObjects;
                            break;
                        case "ALL_SUCCEED":
                            _sessionmanager.Log("Delete succeed instances of " + report.ToLongName());
                            boInfoObjects = _biplatform.Get("query://{SELECT SI_ID FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + report.Cuid + "' AND SI_SCHEDULEINFO.SI_OUTCOME<2 AND SI_RECURRING=0 }", null).InfoObjects;
                            break;
                        case "ALL_STATUS":
                            _sessionmanager.Log("Delete all instances of " + report.ToLongName());
                            boInfoObjects = _biplatform.Get("query://{SELECT SI_ID FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + report.Cuid + "' AND SI_RECURRING=0 }", null).InfoObjects;
                            break;
                        default:
                            throw new Exception("Option " + pAssociatedInstance + " is not available ! ");
                    }
                    if(boInfoObjects!=null && boInfoObjects.InfoObject!=null && boInfoObjects.InfoObject.Length != 0){
                        int nbDeleted = _biplatform.Delete(boInfoObjects);
                        report.Instance.Id = 0;
                        report.LOG = "DELETED " + nbDeleted + " instance(s)";
                        report.Instance.Cuid = null;
                        report.Instance.Date = null;
                        report.Instance.Time = null;
                        report.NbChild = report.NbChild - nbDeleted;
                    }
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

        //http://devlibrary.businessobjects.com/businessobjectsxir2/en/en/WS_SDK/wssdk_consumer/doc/wssdk_net_consumer_apiRef/html/wslrfBusinessObjectsDSWSReportEngineViewModeTypeClassTopic.htm

        public ExitCode DownloadReportsFile(ref Report[] pReports, string pFolder, string pAssociatedInstance, string pFormat){
            _cancel = false;
            _sessionmanager.ResetSessionTimeOut();
            if (pReports == null) throw new Exception("The <Reports> argument is null ! ");
            pAssociatedInstance = pAssociatedInstance.ToUpper();
            pFormat = pFormat.ToUpper();
            pFolder = pFolder.TrimEnd('\\') + '\\';
            var boActionClose = new Action[] { new Close() };
            var navigateToPath = new NavigateToPath();
            var retReportList = new RetrieveData{ RetrieveReportList = new RetrieveReportList() };
            var retPdfData = new RetrieveData{ RetrieveView = new RetrieveBinaryView { ViewSupport = new ViewSupport{
                OutputFormat = OutputFormatType.PDF, ViewType = ViewType.BINARY, ViewMode = ViewModeType.DOCUMENT
            }}};
            var retExcelData = new RetrieveData{ RetrieveView = new RetrieveBinaryView { ViewSupport = new ViewSupport{
                OutputFormat = OutputFormatType.EXCEL, ViewType = ViewType.BINARY, ViewMode = ViewModeType.DOCUMENT
            }}};
            var retXmlData = new RetrieveData{ RetrieveView = new RetrieveXMLView{ ViewSupport = new ViewSupport{
                OutputFormat = OutputFormatType.XML, ViewType = ViewType.XML, ViewMode = ViewModeType.REPORT
            }}};
            var retHtmlData = new RetrieveData{  RetrieveView = new RetrieveView{ ViewSupport = new ViewSupport{
                OutputFormat = OutputFormatType.HTML, ViewType = ViewType.CHARACTER, ViewMode = ViewModeType.REPORT
            }}};
            var exitcode = ExitCode.SUCCEED;
            _sessionmanager.InitProgress(3, 100, pReports.Length);
            foreach (var report in pReports ){
                try{
                    InfoObjects boInfoObjects;
                    if (string.IsNullOrEmpty(report.Cuid)) throw new Exception("Report Cuid is empty");
                    switch (pAssociatedInstance){
                        case "SPECIFIED":
                            if (string.IsNullOrEmpty(report.Instance.Cuid)) throw new Exception("Instance Cuid is empty");
                            if (report.Instance == null || report.Instance.Cuid == String.Empty) throw new Exception("The instance <Cuid> argument is missing for report " + report.ToLongName());
                            _sessionmanager.Log("Download instance " + report.Instance.Id + " of " + report.ToLongName());
                            boInfoObjects = _biplatform.Get("cuid://<" + report.Instance.Cuid + ">@SI_ID,SI_KIND,SI_NAME,SI_FILES,SI_STARTTIME,SI_UPDATE_TS", null).InfoObjects;
                            break;
                        case "LAST_SUCCEED":
                            if (string.IsNullOrEmpty(report.Instance.Cuid)) throw new Exception("Instance Cuid is empty");
                            _sessionmanager.Log("Download last succeed instance of " + report.ToLongName());
                            boInfoObjects = _biplatform.Get("query://{SELECT TOP 1 SI_ID,SI_KIND,SI_NAME,SI_FILES,SI_STARTTIME,SI_UPDATE_TS FROM CI_INFOOBJECTS WHERE SI_INSTANCE!=0 AND SI_PARENT_CUID='" + report.Cuid + "' AND SI_SCHEDULEINFO.SI_OUTCOME<2 ORDER BY SI_CREATION_TIME DESC}", null).InfoObjects;
                            break;
                        case "NONE":
                            _sessionmanager.Log("Download report " + report.ToLongName());
                            boInfoObjects = _biplatform.Get("cuid://<" + report.Cuid + ">@SI_ID,SI_KIND,SI_NAME,SI_FILES,SI_STARTTIME,SI_UPDATE_TS", null).InfoObjects;
                            break;
                        default:
                            throw new Exception("Option " + pAssociatedInstance + " is not available ! ");
                    }
                    if(boInfoObjects!=null && boInfoObjects.InfoObject!=null && boInfoObjects.InfoObject.Length != 0){
                        var boInfoObject = boInfoObjects.InfoObject[0];
                        DocumentInformation docInfo;
                        DocumentInformation repInfo;
                        switch (pFormat){
                            case "DEFAULT":
                                report.Instance.Time = GetExecutionTime(boInfoObject);
                                var file = GetFile(boInfoObject);
                                var filePath = pFolder + boInfoObject.ID + "-" + boInfoObject.Name + System.IO.Path.GetExtension(file.Name);
                                var downloadId = _biplatform.StartSingleDownload(boInfoObject.CUID, 0);
                                using( var fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)){
                                    var status = _biplatform.DownloadFile(downloadId, 0);
                                    fs.Write(status.BinaryData, 0, status.BinaryData.Length);
                                    while (status.EndOfFile != true){
                                        status = _biplatform.DownloadFile(downloadId, status.NextReferencePosition);
                                        fs.Write(status.BinaryData, 0, status.BinaryData.Length);
                                    }
                                    fs.Close();
                                }
                                _biplatform.FinishDownload(downloadId);
                                report.LOG = "DOWNLOADED as " + boInfoObject.Kind;
                                break;
                            case "XML":
                                docInfo = _reportengine.GetDocumentInformation(boInfoObject.CUID, null, null, null, retReportList);
                                var xmlSettingsWithIndentation = new System.Xml.XmlWriterSettings { Indent = true};
                                _sessionmanager.InitSubProgress(docInfo.Reports.Length);
                                foreach( var docReport  in docInfo.Reports){
                                    navigateToPath.Path = docReport.Path;
                                    repInfo = _reportengine.GetDocumentInformation(docInfo.DocumentReference, null, null, navigateToPath, retXmlData);
                                    var xmlContent = (string)(repInfo.View as XMLView).Content;
                                    var reader = System.Xml.XmlReader.Create(
                                        new System.IO.StringReader(xmlContent),
                                        new System.Xml.XmlReaderSettings {IgnoreWhitespace = true}
                                    );
                                    using (var writer = System.Xml.XmlWriter.Create(pFolder + boInfoObject.ID + "-" + repInfo.Name + "_" + docReport.Path + "-" + docReport.Name + ".xml", xmlSettingsWithIndentation)){
                                        writer.WriteNode(reader, true);
                                        writer.Close();
                                    }
                                    _sessionmanager.IncSubProgress();
                                }
                                _reportengine.GetDocumentInformation(docInfo.DocumentReference, null, boActionClose, null, null);
                                report.LOG = "DOWNLOADED as Xml";
                                break;
                            case "HTML":
                                docInfo = _reportengine.GetDocumentInformation(boInfoObject.CUID, null, null, null, retReportList);
                                _sessionmanager.InitSubProgress(docInfo.Reports.Length);
                                foreach( var docReport  in docInfo.Reports){
                                    navigateToPath.Path = docReport.Path;
                                    repInfo = _reportengine.GetDocumentInformation(docInfo.DocumentReference, null, null, navigateToPath, retHtmlData);
                                    var htmlContent = (repInfo.View as CharacterView).Content;
                                    using (var sw = new System.IO.StreamWriter(pFolder + boInfoObject.ID + "-" + repInfo.Name + "_" + docReport.Path + "-" + docReport.Name + ".html", false, System.Text.Encoding.Unicode)){
                                        sw.Write(htmlContent);
                                        sw.Close();
                                    }
                                    _sessionmanager.IncSubProgress();
                                }
                                _reportengine.GetDocumentInformation(docInfo.DocumentReference, null, boActionClose, null, null);
                                report.LOG = "DOWNLOADED as Html";
                                break;
                            case "PDF":
                                docInfo = _reportengine.GetDocumentInformation(boInfoObject.CUID, null, boActionClose, null, retPdfData);
                                var pdfContent = (docInfo.View as BinaryView).Content;
                                using (var sw = new System.IO.FileStream(pFolder  + boInfoObject.ID + "-" + docInfo.Name + ".pdf", System.IO.FileMode.Create)){
                                    sw.Write(pdfContent, 0, pdfContent.Length);
                                    sw.Close();
                                }
                                report.LOG = "DOWNLOADED as Pdf";
                                break;
                            case "EXCEL":
                                docInfo = _reportengine.GetDocumentInformation(boInfoObject.CUID, null, boActionClose, null, retExcelData);
                                var excelContent = (docInfo.View as BinaryView).Content;
                                using (var sw = new System.IO.FileStream(pFolder  + boInfoObject.ID + "-" + docInfo.Name + ".xls", System.IO.FileMode.Create)){
                                    sw.Write(excelContent, 0, excelContent.Length);
                                    sw.Close();
                                }
                                report.LOG = "DOWNLOADED as Excel";
                                break;
                        }
                    }
                }catch(Exception ex){
                    exitcode = ExitCode.HASERROR;
                    report.LOG = _sessionmanager.ParseException( ex );
                    _sessionmanager.Log(" Error: " + _sessionmanager.ParseException(ex));
                }
                _sessionmanager.IncProgress();
                if (_cancel) return ExitCode.CANCELED;
            }
            return exitcode;
		}

        public System.Windows.Forms.TreeNodeCollection EnumFolders(){

            var nodes = new System.Windows.Forms.TreeNode();
            var select = new []{"SI_CUID", "SI_ID", "SI_KIND", "SI_NAME", "SI_PATH"};
            var queries = new []{"cuid://<" + FixedCUIDs.RootFolder.FOLDERS + ">/**/*[SI_KIND='Folder']"};
            for(var i=0;i<queries.Length;i++){
                var boInfoObjects = _biplatform.Get(queries[i], null).InfoObjects;
                Path folderPath = null;
                string folderName = null;
                foreach(var infoObject in boInfoObjects.InfoObject){
                    if(infoObject is Folder){
                        var folder = (Folder)infoObject;
                        folderPath = folder.Path;
                        folderName = folder.Name;
                    }else if(infoObject is FavoritesFolder){
                        var favoritesFolder = (FavoritesFolder)infoObject;
                        folderPath = favoritesFolder.Path;
                        folderName = favoritesFolder.Name;
                    }

                    System.Windows.Forms.TreeNode node = nodes;
                    if(folderPath != null && folderPath.PathFolder!=null){
                        for (int f = folderPath.PathFolder.Length - 1; f != -1; f--)
                            node = Func.AddTreeNode(node, folderPath.PathFolder[f].Name);
                    }
                    Func.AddTreeNode(node, folderName);
                }
            }
            return nodes.Nodes;
        }

        public List<System.Windows.Forms.ListViewItem> EnumReports(string path)
        {
            var collection = new List<System.Windows.Forms.ListViewItem>();
            const string @select = "SI_CUID,SI_ID,SI_KIND,SI_NAME";
            const string @where = "SI_KIND IN('Webi','Publication','CrystalReport','ObjectPackage') AND SI_INSTANCE=0";
            var queries = new[]{ "path://InfoObjects/*/" + path + "[" + where + "]@" + select };
            for (int i = 0; i < queries.Length; i++){
                var boInfoObjects = _biplatform.Get(queries[i], null).InfoObjects;
                if(boInfoObjects!=null && boInfoObjects.InfoObject!=null){
                    foreach (var infoObject in boInfoObjects.InfoObject)
                        collection.Add(new System.Windows.Forms.ListViewItem( new[] { infoObject.ID.ToString(), infoObject.Kind, infoObject.Name}, 0) );
                }
            }
            return collection;
        }

        private void SendEmail(string pEmail, String pSubject, string pMessage){
            InfoObjects newInfoObjects = null;
            try{
                string[] emails = pEmail.Replace(',',';').Split(';');
                var objProgram = new Program{
                    Name = "bo-utils-send-email",
                    Description = "Send a notification email at the end of scheduling",
                    ParentCUID = FixedCUIDs.RootFolder.TEMPORARY_STORAGE_FOLDERS,
                    CUID = _biplatform.GenerateCuids(1)[0],
                    SchedulingInfo = new SchedulingInfo{
                        Cleanup = true,
                        CleanupSpecified = true,
                        ScheduleType = ScheduleTypeEnum.ONCE,
                        Notifications = new Notifications{
                            DestinationsOnSuccess = new []{
                                new Destination{
                                    Name = "CrystalEnterprise.SMTP",
                                    DestinationScheduleOptions = new SMTPScheduleOptions {
                                        ToAddresses = emails,
                                        SenderAddress = emails[0],
                                        Subject = pSubject,
                                        Message = pMessage
                                    }
                                }
                            }
                        }
                    }
                };
                objProgram.SchedulingInfo.Notifications.DestinationsOnFailure = objProgram.SchedulingInfo.Notifications.DestinationsOnSuccess;
                newInfoObjects = new InfoObjects{ InfoObject = new InfoObject[]{ objProgram } };
                _biplatform.Create(newInfoObjects, null);
                newInfoObjects = _biplatform.Schedule(newInfoObjects);
            }catch{
            }finally{
                try{ if(newInfoObjects!=null) _biplatform.Delete(newInfoObjects); }catch{}
            }
        }

        private void ParseCustomPropertiesToPrompt(CustomProperties pCustomProperties, ref List<Prompt> oPrompts){
            if (pCustomProperties  == null) return;
            foreach(object objA in pCustomProperties.Items){
                if (!(objA is CustomProperties) || !(objA as CustomProperties).nameID.EndsWith("_PROMPTS")) continue;
                foreach(var objB in (objA  as CustomProperties).Items){
                    if (!(objB is CustomProperties)) continue;
                    var promptName = string.Empty;
                    var promptValue = string.Empty;
                    foreach(var objC in (objB  as CustomProperties).Items){
                        if (objC is CustomPropertiesString && (objC as CustomPropertiesString).nameID=="SI_NAME"){
                            promptName = (objC as CustomPropertiesString).Value;
                        }else if(objC is CustomProperties){
                            if( (objC as CustomProperties).nameID=="SI_VALUES" ){
                                foreach(object objD in (objC  as CustomProperties).Items){
                                    if (!(objD is CustomPropertiesString)) continue;
                                    if(promptValue!=String.Empty) promptValue+=";";
                                    promptValue+=(objD  as CustomPropertiesString).Value;
                                }
                            }else if( (objC as CustomProperties).nameID == "SI_CURRENT_VALUES" ){
                                foreach(object objD in (objC  as CustomProperties).Items){
                                    if (!(objD is CustomProperties)) continue;
                                    foreach(var objE in (objD  as CustomProperties).Items){
                                        if (!(objE is CustomPropertiesString) || (objE as CustomPropertiesString).nameID != "SI_DATA") continue;
                                        if(promptValue!=String.Empty) promptValue+=";";
                                        promptValue+=(objE  as CustomPropertiesString).Value;
                                    }
                                }
                            }
                        }
                    }
                    oPrompts.Add(new Prompt{ Name=promptName, Value=promptValue });
                }
            }
        }

        private string GetInfoObjectLocation(string pParentCuid ){
            string lFolder = null;
            var boInfoObjects = _biplatform.Get("cuid://<" + pParentCuid + ">@SI_Name,SI_KIND,SI_PATH", null).InfoObjects;
            if (boInfoObjects != null && boInfoObjects.InfoObject != null && boInfoObjects.InfoObject.Length != 0){
                var boInfoObject = boInfoObjects.InfoObject[0];
                switch (boInfoObject.Kind){
                    case "Folder":
                        if (((Folder)boInfoObject).Path.PathFolder != null){
                            foreach (var f in ((Folder)boInfoObject).Path.PathFolder)
                                lFolder = f.Name + "/" + lFolder;
                        }
                        lFolder = lFolder + boInfoObject.Name;
                        break;
                    case "FavoritesFolder":
                        if (((FavoritesFolder)boInfoObject).Path.PathFolder != null){
                            foreach (var f in ((FavoritesFolder)boInfoObject).Path.PathFolder)
                                lFolder = f.Name + "/" + lFolder;
                        }
                        lFolder = "FavoritesFolder:" + lFolder + boInfoObject.Name;
                        break;
                    default:
                        lFolder = boInfoObject.Kind + ":" + boInfoObject.Name;
                        break;
                }
            }
            return lFolder;
        }

        private File GetFile(InfoObject pInfoObject){
            FileProperties fileProperties;
            switch (pInfoObject.Kind){
                case "Webi": fileProperties = ((Webi)pInfoObject).FileProperties;break;
                case "CrystalReport": fileProperties = ((CrystalReport)pInfoObject).FileProperties; break;
                case "FullClient": fileProperties = ((FullClient)pInfoObject).FileProperties; break;
                case "Pdf": fileProperties = ((Pdf)pInfoObject).FileProperties; break;
                case "Excel": fileProperties = ((Excel)pInfoObject).FileProperties; break;
                default: throw new Exception(pInfoObject.Kind + " object is not supported !");
			}
            if (fileProperties == null || fileProperties.Files == null || fileProperties.Files.Length == 0)
                throw new Exception("There is no file attached to instance " + pInfoObject.ID);
            return fileProperties.Files[0];
		}
        
        private SchedulingInfo GetSchedulingInfo(InfoObject pInfoObject){
            SchedulingInfo schedulingInfo;
            switch (pInfoObject.Kind){
                case "Webi": schedulingInfo = ((Webi)pInfoObject).SchedulingInfo;break;
                case "CrystalReport": schedulingInfo = ((CrystalReport)pInfoObject).SchedulingInfo; break;
                case "FullClient": schedulingInfo = ((FullClient)pInfoObject).SchedulingInfo; break;
                case "ObjectPackage": schedulingInfo = ((ObjectPackage)pInfoObject).SchedulingInfo; break;
                case "Pdf": schedulingInfo = ((Pdf)pInfoObject).SchedulingInfo; break;
                case "Excel": schedulingInfo = ((Excel)pInfoObject).SchedulingInfo; break;
                default: throw new Exception(pInfoObject.Kind + " object is not supported !");
            }
            if (schedulingInfo == null) throw new Exception("SchedulingInfo is null in document " + GetObjectLongName(pInfoObject));
            return schedulingInfo;
		}

        private string RangePromptValueToString(RangePromptValue pRangePromptValue){
            var ret=pRangePromptValue.StartValueInclusive ? "[" : "(";
            if(!pRangePromptValue.StartValueUnbound) ret += pRangePromptValue.StartValue;
            ret += "..";
            if (!pRangePromptValue.EndValueUnbound) ret += pRangePromptValue.EndValue;
            ret += pRangePromptValue.EndValueInclusive ? "]" : ")";
            return ret;
        }
        
        private RangePromptValue RangePromptStringToValue(string pRangePromptString){
            try{
                var posPeriods = pRangePromptString.IndexOf("..");
                var len = pRangePromptString.Length;
                var ret = new RangePromptValue{
                    StartValueInclusive = pRangePromptString.StartsWith("["),
                    EndValueInclusive = pRangePromptString.EndsWith("]"),
                    StartValueUnbound = posPeriods==1,
                    EndValueUnbound = ((len - posPeriods)==3)
                };
                if (!ret.StartValueUnbound) ret.StartValue = pRangePromptString.Substring(1, posPeriods - 1).Trim();
                if (!ret.EndValueUnbound) ret.EndValue = pRangePromptString.Substring(posPeriods + 2, len - posPeriods - 3).Trim();
                return ret;
            }catch(Exception){
                throw new Exception("Failed to parse range prompt value <" + pRangePromptString + ">");
            }
        }

        private string GetObjectLongName(InfoObject pInfoObject){
            return  pInfoObject.ID + "-" + pInfoObject.Name;
        }

        private InfoObjects GetInfoObject(string pQuery){
            var boResponseHolder = _biplatform.Get(pQuery, null);
            if( boResponseHolder == null
                || boResponseHolder.InfoObjects == null
                || boResponseHolder.InfoObjects.InfoObject == null
                || boResponseHolder.InfoObjects.InfoObject.Length == 0) throw new Exception("Query returned no object !");
            return boResponseHolder.InfoObjects;
        }

        private string GetExecutionTime(InfoObject pInfoObject){
            if (pInfoObject.StartTimeSpecified && pInfoObject.UpdateTimeSpecified){
                return new DateTime(pInfoObject.UpdateTime.Subtract(pInfoObject.StartTime).Ticks).ToString(@"mm:ss");
            }
            return null;
        }
	}
}
