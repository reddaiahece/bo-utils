using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsUtils.Lib.Scheduler;
using System.Xml;
using System.IO;

namespace Test120
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
            // DownloadReport();
            //  GetList();
            //ScheduleReport();

        }




        static void TestParse()
        {
            PlanSchedule sch = new PlanSchedule
            {
                Url = @"http://vform-boxi3:8080/dswsbobje/services",
                Domain = "vform-boxi3:6400",
                Login = "Administrator",
                Password = "",
                AuthType = "secEnterprise",
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
            frm.Url = @"http://vform-boxi3:8080/dswsbobje/services";
            frm.Domain = "vform-boxi3:6400";
            frm.Login = "Administrator";
            frm.Password = "";
            frm.AuthType = "secEnterprise";

            // frm.ReportsPath = "**/*";

            frm.ReportsPath = "1560";
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
            frm.Url = @"http://vform-boxi3:8080/dswsbobje/services";
            frm.Domain = "vform-boxi3:6400";
            frm.Login = "Administrator";
            frm.Password = "";
            frm.AuthType = "secEnterprise";
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
            frm.Url = @"http://vform-boxi3:8080/dswsbobje/services";
            frm.Domain = "vform-boxi3:6400";
            frm.Login = "Administrator";
            frm.Password = "";
            frm.AuthType = "secEnterprise";
            frm.SetReports(ref report);
            frm.Directory = @"c:\";
            frm.Show();
            frm.Close();

        }
    }
}
