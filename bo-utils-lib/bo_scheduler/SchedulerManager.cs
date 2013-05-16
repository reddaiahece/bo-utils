using System;
using System.Collections.Generic;
using BusinessObjectsUtils.bo_session;
using BusinessObjectsUtils.bo_scheduler.dsws;
using System.Windows.Forms;

namespace BusinessObjectsUtils.bo_scheduler
{
    public class SchedulerManager
    {
        private readonly IScheduler _scheduler;
        private readonly SessionManager _sessionmanager; 

        public SchedulerManager(SessionManager sessionmanager)
        {
            if (sessionmanager == null) throw new Exception("Session is null");
            switch (sessionmanager.Version)
            {
                case 11: _scheduler = new Scheduler115(sessionmanager); break;
                case 12: _scheduler = new Scheduler120(sessionmanager); break;
                case 14: _scheduler = new Scheduler140(sessionmanager); break;
                case 98: _scheduler = new SchedulerRand(sessionmanager); break;
                case 99: _scheduler = new SchedulerTest(sessionmanager); break;
                default: throw new NotSupportedException("Version " + sessionmanager.Version + " is not supported ! ");
            }
            _sessionmanager = sessionmanager;
        }

        public void Cancel()
        {
            _scheduler.Cancel();
        }

        public ExitCode GetReports(string pPath, bool pIncludePrompts, string pAssociatedInstance, out Report[] pReports)
        {
            try{
                return _scheduler.GetReports(pPath, pIncludePrompts, pAssociatedInstance, out pReports);
            }catch (Exception ex) {
                throw _sessionmanager.ParseException("Failed to get reports!", ex);
            }
        }

        public ExitCode DeleteReportsInstance(ref Report[] pReports, string pAssociatedInstance)
        {
            try{
                return _scheduler.DeleteReportsInstance(ref pReports, pAssociatedInstance);
            }catch (Exception ex) {
                throw _sessionmanager.ParseException("Failed to delete reports!", ex);
            }
        }

        public ExitCode DownloadReportsFile(ref Report[] pReports, string filePath, string pAssociatedInstance, string pFormat)
        {
            try{
                return _scheduler.DownloadReportsFile(ref pReports, filePath, pAssociatedInstance, pFormat);
            }catch (Exception ex) {
                throw _sessionmanager.ParseException("Failed to download reports!", ex);
            }
        }

        public ExitCode GetReportsSchedulStatus(ref Report[] pReports, string pAssociatedInstance)
        {
            try{
                return _scheduler.GetReportsSchedulStatus(ref pReports, pAssociatedInstance);
            }catch (Exception ex) {
                throw _sessionmanager.ParseException("Failed to get reports status!", ex);
            }
        }

        public ExitCode ScheduleReports(ref Report[] pReports, bool pWithPrompts, string pDate, string pServerDestinationPath, string pOutFormat, bool pWaitEndOfCreation, bool pClean, string pNotifEmail)
        {
            DateTime lDate = DateTime.MinValue;
            if(!string.IsNullOrEmpty(pDate)){
                try{
                    DateTime.TryParse(pDate, out lDate);
                }catch(Exception){
                    throw new Exception("Unable to parse datetime : " + pDate );
                }
            }
            try{
                return _scheduler.ScheduleReport(ref pReports, pWithPrompts, lDate, pServerDestinationPath, pOutFormat, pWaitEndOfCreation, pClean, pNotifEmail);
            }catch (Exception ex) {
                throw _sessionmanager.ParseException("Failed to schedule reports!", ex);
            }
        }

        public void CreateXmlPlan(PlanSchedule schedulerplan)
        {
            string lFilename;
            using(var saveDialog = new SaveFileDialog()){
                saveDialog.Filter = "XML FIle|*.xml";
                saveDialog.Title = "Save XML File";
                saveDialog.ShowDialog();
                lFilename = saveDialog.FileName;
            }
            if (string.IsNullOrEmpty(lFilename)) return;
            try{
                //Cursor = System.Windows.Forms.Cursors.WaitCursor;
                //Refresh();
                /*            PlanSchedule schedulerplan = new PlanSchedule{
                        Credentials = session.credentials,
                        WithPrompts = WithPrompts,
                        Destination = Destination,
                        Format = Format,
                        WaitEnd = WaitEnd,
                        CleanEnd = CleanEnd,
                        NotifEmail = NotifEmail,
                        Reports = Reports
                    };
         */
                schedulerplan.ParseToXml(lFilename);
                MsgBox.Show("Command line :", "\"" + Func.GetRunnerPath() + "\" \"" + lFilename + "\" \"" + lFilename.Replace(".xml", ".log") + "\"" );
            }catch{ 
                throw;
            }finally{
                //Cursor = System.Windows.Forms.Cursors.Default;
                //Close();
            }
        }

        public TreeNodeCollection EnumFolders()
        {
            return _scheduler.EnumFolders();    
        }

        public List<ListViewItem> EnumReports(string path)
        {
            return _scheduler.EnumReports(path);
        }
    }
}
