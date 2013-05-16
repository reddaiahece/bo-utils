using System;
using System.IO;
using BusinessObjectsUtils.bo_scheduler;
using BusinessObjectsUtils.bo_session;

namespace BusinessObjectsUtils.Runner
{
    class Program
    {
        enum ExitCode : int {
            Succeed = 0,
            FailedToCreateReports = 1,
            FailedToSchedule = 2,
            FailedToLogin = 3,
            FailedToLoadXml = 4,
            UnknownError = 8,
            InvalidArguments = 9
        }

        private static void PrintHelper(){
            Console.WriteLine("\r\nUsage :     bo-utils.exe xml_file_path out_log_file_path");
            Console.WriteLine("\r\nExample :   bo-utils.exe c:\\scheduleplan.xml c:\\out.log");
            Console.WriteLine("\r\nExit Code : Succeed = 0");
            Console.WriteLine("            FailedToCreateReports = 1");
            Console.WriteLine("            FailedToSchedule = 2");
            Console.WriteLine("            FailedToLogin = 3");
            Console.WriteLine("            FailedToLoadXml = 4");
            Console.WriteLine("            UnknownError = 8");
            Console.WriteLine("            InvalidArguments = 9");
        }

        static int Main(string[] args)
        {
            try{
                Console.WriteLine("");
                if (args.Length != 2){
                    Console.WriteLine("Error: Number of argument is invalid !");
                    PrintHelper();
                    return (int)ExitCode.InvalidArguments;
                }

                string xmlFIlePath = args[0];
                string logFIlePath = args[1];

                if(!File.Exists(xmlFIlePath)){
                    Console.WriteLine("Error: Xml file argument doesn't exist !");
                    PrintHelper();
                    return (int)ExitCode.InvalidArguments;
                }

                if(!Directory.Exists(Path.GetDirectoryName(logFIlePath))){
                    Console.WriteLine("Error: The directory of the log file argument doesn't exist !");
                    PrintHelper();
                    return (int)ExitCode.InvalidArguments;
                }

                Logger logger;
                try{
                    logger = new Logger(args[1]);
                }catch(Exception ex){
                    Console.WriteLine("Failed to create log file: " + ex.Message);
                    return (int)ExitCode.InvalidArguments;
                }

                PlanSchedule data;
                try{
                    logger.Log("Parse xml file to get reports (" + xmlFIlePath + ")");
                    data = PlanSchedule.ParseFromXml(xmlFIlePath);
                    logger.Log("\tVersion : " + data.Credentials.Version);
                    logger.Log("\tUrl : " + data.Credentials.Url);
                    logger.Log("\tDomain : " + data.Credentials.Domain);
                    logger.Log("\tAuthType : " + data.Credentials.AuthType);
                    logger.Log("\tLogin : " + data.Credentials.Login);
                    logger.Log("\tWithPrompts : " + data.WithPrompts);
                    logger.Log("\tDestination : " + data.Destination);
                    logger.Log("\tFormat : " + data.Format);
                    logger.Log("\tWaitEnd : " + data.WaitEnd);
                    logger.Log("\tCleanEnd : " + data.CleanEnd);
                    logger.Log("\tReport Count : " + data.Reports.Length);
                }catch(Exception ex){
                    logger.LogAndClose("Failed to parse Xml file: " + ex.Message);
                    return (int)ExitCode.FailedToLoadXml;
                }

                SessionManager session;
                try{
                    session = new SessionManager();
                    session.LogEvent += new LogHandler(logger.Log);
                    session.Login(data.Credentials);
                }catch(Exception ex){
                    logger.LogAndClose(ex.Message);
                    return (int)ExitCode.FailedToLogin;
                }

                BusinessObjectsUtils.ExitCode succeed;
                try{
                    Report[] reports = data.Reports;
                    var scheduler = new SchedulerManager(session);
                    succeed = BusinessObjectsUtils.ExitCode.SUCCEED;
                    succeed = scheduler.ScheduleReports(ref reports, data.WithPrompts, null, data.Destination, data.Format, data.WaitEnd, data.CleanEnd, data.NotifEmail);
                    session.Logout();
                }catch(Exception ex){
                    session.Logout();
                    logger.LogAndClose("Failed to schedule reports: " + ex.Message);
                    return (int)ExitCode.FailedToSchedule;
                }

                if (succeed == BusinessObjectsUtils.ExitCode.SUCCEED) {
                    logger.LogAndClose("End of scheduling. All repports were successfully scheduled ! ");
                    return (int)ExitCode.Succeed;
                }else{
                    logger.LogAndClose("End of scheduling. Failed to schedule some reports ! ");
                    return (int)ExitCode.FailedToCreateReports;
                }
            }catch(Exception){
                return (int)ExitCode.UnknownError;
            }
            
        }

        public class Logger
        {
            FileStream fileStream;
            StreamWriter streamWriter;

            public Logger(string filename){

                fileStream = new FileStream(filename, FileMode.Create);
                streamWriter = new StreamWriter(fileStream);
            }

            public void LogAndClose(Exception ex){
                Log(" Exception : " + ex.Message);
                while( ex.InnerException!=null){
                    ex = ex.InnerException;
                    Log(" " + ex.Message);
                }
                Close();
            }

            public void LogAndClose(string s){
                Log(s);
                Close();
            }

            public void Log(string s){
                streamWriter.WriteLine(getTime() + "  " + s);
                Console.WriteLine(s);
            }

            public void Close(){
                streamWriter.Close();
                fileStream.Close();
            }

            private string getTime(){
                return DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss");
            }
        }

    }
}
