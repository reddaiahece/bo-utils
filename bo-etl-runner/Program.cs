using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BusinessObjectsEtl.Runner
{
    class Program
    {
        enum ExitCode : int
        {
            Succeed = 0,
            FailedToLogin = 1,
            FailedToExtract = 2,
            FailedToSetDatabase = 3,
            FailedToLoadXml = 4,
            UnknownError = 8,
            InvalidArguments = 9,
        }

        private static void PrintHelper()
        {
            Console.WriteLine("\r\nUsage :     bo-etl.exe xml_config_file_path out_log_file_path");
            Console.WriteLine("\r\nExample :   bo-etl.exe c:\\config.xml c:\\out.log");
            Console.WriteLine("\r\nExit Code : Succeed = 0");
            Console.WriteLine("            FailedToExtract = 1");
            Console.WriteLine("            FailedToLogin = 3");
            Console.WriteLine("            FailedToSetDatabase = 2");
            Console.WriteLine("            FailedToLoadXml = 3");
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
                    Console.WriteLine("Error: Xml config file argument doesn't exist !");
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

                Config config;
                try{
                    logger.Log("Read Xml configuration file " + xmlFIlePath );
                    config = Config.ParseFromXml(xmlFIlePath);
                }catch(Exception ex){
                    logger.LogAndClose("Failed to parse Xml configuration file: " + ex.Message);
                    return (int)ExitCode.FailedToLoadXml;
                }

                List<IDataBase> databases = new List<IDataBase>();
                try{
                    foreach(Database db in config.Databases ){
                        if(db.Type == "Firebird"){
                            Firebird FbDb = new Firebird();
                            FbDb.Log += new Firebird.LogHandler(logger.Log);
                            FbDb.Initialise(db.Path, db.Username, db.Password, db.Multiload);
                            //FbDb.Initialise(db.Path, db.Username, Utils.XORcrypt(Utils.DecodeFrom64(db.Password)), db.Multiload);
                            databases.Add(FbDb);
                        }
                    }
                }catch(Exception ex){
                    logger.LogAndClose("Failed to initialise the database: " + ex.Message);
                    return (int)ExitCode.FailedToSetDatabase;
                }

                Etl etl;
                try{
                    etl = new Etl();
                    etl.Log += new Etl.LogHandler(logger.Log);
                    etl.Login(
                        config.WebService.WebServiceURL,
                        config.WebService.Domain,
                        config.WebService.Login,
                        //Utils.XORcrypt(Utils.DecodeFrom64(config.WebService.Password)),
                        config.WebService.Password,
                        config.WebService.AuthType
                    );
                }catch(Exception ex){
                    logger.LogAndClose("Failed to login to Business Objects Web Service: " + ex.Message);
                    return (int)ExitCode.FailedToLogin;
                }
                try{
                    bool succeed = etl.ExtractTo(databases.ToArray());
                    etl.Logout();
                    if(succeed == true ){
                        logger.LogAndClose("End of ETL. Data were successfully extrated ! ");
                    }else{
                        logger.LogAndClose("End of ETL. Some errors occured while extracting data ! ");
                    }
                    return (int)ExitCode.Succeed;
                }catch(Exception ex){
                    logger.Log("Exception : " + ex.Message);
                    etl.Logout();
                    logger.LogAndClose("End of ETL. Failed to extract data ! ");
                    return (int)ExitCode.FailedToExtract;
                }
            }catch(Exception){
                return (int)ExitCode.UnknownError;
            }
        }
    }

    public class Logger
    {
        FileStream fileStream;
        StreamWriter streamWriter;

        public Logger(string filename)
        {
            fileStream = new FileStream(filename, FileMode.Create);
            streamWriter = new StreamWriter(fileStream);
        }

        public void LogAndClose(string s)
        {
            Log(s);
            Close();
        }

        public void Log(string s)
        {
            streamWriter.WriteLine(getTime() + "  " + s.Replace("\r\n", " - ").Replace("\r", " - ").Replace("\n", " - "));
            Console.WriteLine(s);
        }

        public void Close()
        {
            streamWriter.Close();
            fileStream.Close();
        }

        private string getTime()
        {
            return DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss");
        }
    }



}
