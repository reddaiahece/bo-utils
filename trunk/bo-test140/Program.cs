using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsUtils.Lib.Scheduler;
using System.Xml;
using System.IO;
using BusinessObjectsUtils.Lib;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace Test140
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
        
            GetList();
           // ISchToXML frm = new SchToXML();
           // frm.SetReports(ref (Report[])report);
           // frm.Show();
         //   DownloadReport2();
          //  GetList();
          //  ScheduleReport();
          //  ScheduleReport2();
        }

        static void DownloadReport2()
        {

            Report[] report = new Report[]{
                new Report{
                    Instance = new Instance{ Cuid="ASisoidlZUtCiuG0tQ8A51s", Id="6226" },
                    Id="4990",
                }
            };

            SchDownload frm = new SchDownload();
            frm.Url = @"http://trishna:8080/dswsbobje/services";
            frm.Domain = "TRISHNA:6400";
            frm.Login = "Administrator";
            frm.Password = "TMA_2012";
            frm.AuthType = "secEnterprise";
            frm.SetReports(ref report);
            frm.Directory = @"c:\";
            frm.Show();
            frm.Close();

        }




        static void GetList2()
        {
            SchGetList frm = new SchGetList();
            frm.Url = @"http://trishna:8080/dswsbobje/services";
            frm.Domain = "TRISHNA:6400";
            frm.Login = "Administrator";
            frm.Password = "TMA_2012";
            frm.AuthType = "secEnterprise";

            frm.ReportsPath = "**/*";
            // frm.ReportsPath = "4992";
            frm.Show();

            Report[] ret = frm.Reports;
            frm.Close();

        }

        static void ScheduleReport2()
        {

            Report[] report = new Report[]{
                new Report{ 
                    Id="5007",
                    Prompts = new Prompt[]{ 
                        new Prompt{ Name="Column1 - type", Value="Actuals"},
                        new Prompt{ Name="Column1 - mm/yyyy", Value="032004"},
                        new Prompt{ Name="Column2 - type", Value="Budget"},
                        new Prompt{ Name="Column2 - mm/yyyy", Value="032004"}
                    }
                }
            };

            SchSchedule frm = new SchSchedule();
            frm.Url = @"http://trishna:8080/dswsbobje/services";
            frm.Domain = "TRISHNA:6400";
            frm.Login = "Administrator";
            frm.Password = "TMA_2012";
            frm.AuthType = "secEnterprise";
            frm.Password = "CCBO";
            frm.SetReports(ref report);
            frm.Show();
            frm.Close();

        }

        static void TestParse()
        {
            PlanSchedule sch = new PlanSchedule
            {
                Url = @"http://treelife.dev.micropole.com/dswsbobje/services",
                Domain = "treelife",
                Login = "CCBO",
                AuthType = "secEnterprise",
                Password = "CCBO",
                Destination = @"c:\",
                Format = "Excel",
                WaitEnd = true,
                Reports = new Report[]{
                    new Report{ 
                        Id="4767",
                        Name = "Report A",
                        Cuid = "AAAAAAAAAAAAAAAAAAAé",
                        Type = "Webi",
                        Prompts = new Prompt[]{ 
                            new Prompt{ Name="Begin Date", Value="01/01/2009"},
                            new Prompt{ Name="End Date", Value="01/02/2009"}
                        }
                    }
                }
            };

            sch.ParseToXml(@"c:\out2.xml");
            PlanSchedule reports2 = PlanSchedule.ParseFromXml(@"c:\out2.xml");  
        }

        static void GetList()
        {
            SchGetList frm = new SchGetList();
            frm.Url = @"http://treelife:8080/dswsbobje/services";
            frm.Domain = "treelife";
            frm.Login = "CCBO";
            frm.Password = "CCBO";
            frm.AuthType = "secEnterprise";

           // frm.ReportsPath = "19940";
         //   frm.ReportsPath = "4839";
            frm.ReportsPath = "**/*";
           // frm.ReportsPath = "4992";
            frm.Show();

            Report[] ret = frm.Reports;
            frm.Close();

        }


        static void ScheduleReport()
        {

            Report[] report = new Report[]{
                new Report{ 
                    Id="1041",
                    Prompts = new Prompt[]{ 
                     //   new Prompt{ Value="01/01/2009"},
                      //  new Prompt{ Value="01/02/2009"}
                    }
                }
            };

            SchSchedule frm = new SchSchedule();
            frm.Url = @"http://treelife.dev.micropole.com/dswsbobje/services";
            frm.Domain = "treelife";
            frm.Login = "CCBO";
            frm.AuthType = "CCBO";
            frm.Password = "CCBO";
            frm.SetReports(ref report);
            frm.Show();
            frm.Close();

        }
        static void DownloadReport()
        {

            Report[] report = new Report[]{
                new Report{
                    Instance = new Instance{ Cuid="AU1vn__iWJdBnnl0RDgI4zs" },
                    Id="12792",
                }
            };

            SchDownload frm = new SchDownload();
            frm.Url = @"http://treelife.dev.micropole.com/dswsbobje/services";
            frm.Domain = "treelife";
            frm.Login = "CCBO";
            frm.AuthType = "secEnterprise";
            frm.Password = "CCBO";
            frm.SetReports(ref report);
            frm.Directory = @"c:\";
            frm.Show();
            frm.Close();

        }

        
    }
}
