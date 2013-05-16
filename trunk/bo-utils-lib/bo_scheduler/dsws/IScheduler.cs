using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BusinessObjectsUtils.bo_session;

namespace BusinessObjectsUtils.bo_scheduler.dsws
{
    public interface IScheduler
    {
        ExitCode GetReports(string pPath, bool pIncludePrompts, string pAssociatedInstance, out Report[] pReports);
        ExitCode DeleteReportsInstance(ref Report[] pReports, string pAssociatedInstance);
        ExitCode DownloadReportsFile(ref Report[] pReports, string pFolder, string pAssociatedInstance, string pFormat);
        ExitCode GetReportsSchedulStatus(ref Report[] pReports, string pAssociatedInstance);
        ExitCode ScheduleReport(ref Report[] pReports, bool pSetPrompts, DateTime pDate, string pPath, string pOutFormat, bool pWaitEnd, bool pCleanup, string pNotifEmail);
        TreeNodeCollection EnumFolders();
        List<ListViewItem> EnumReports(string path);
        void Cancel();
    }
}
