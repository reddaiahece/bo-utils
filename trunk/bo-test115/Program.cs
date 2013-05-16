using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsUtils.Lib.Scheduler;
using BusinessObjectsUtils.Lib.Database;

namespace Test115
{
    class Program
    {
        [STAThread]

        static void Main()
        {
            GetUsers();
          //  About();
           //TestSession();
          //  GetList();
         //   ScheduleReport();
         //   GetStatus();
         //  Download();
        }

        static void GetUsers()
        {
   /*         Etl115 sch = new Etl115(@"http://watchmen:8080/dswsbobje/services/session");
            sch.Login(
                "watchmen",
                "Administrator",
                "",
                "secEnterprise"
            );
*/

          //  sch.GetServerGroups();
         //   sch.GetServers();
         //   sch.GetGroups();
//            sch.GetUsers();
      //      sch.Logout();


        }

        static void TestSession()
        {
            SchScheduler sch = new SchScheduler();

            sch.Login(
                11,
                @"http://watchmen:8080/dswsbobje/services/session",
                "watchmen",
                "Administrator",
                "",
                "secEnterprise"
            );

            sch.Logout();


        }

        static void About()
        {


            BusinessObjectsUtils.Lib.About frm = new BusinessObjectsUtils.Lib.About();
            frm.Show();
            frm.Close();

        }
        static void Download()
        {

            Report[] report = new Report[]{
                
                new Report{ 
                    Id = "12288",
                    Cuid = "AfgVIsAn2NhIoUXnUMiQe3g",
                    Instance = new Instance{ Cuid="AUWxdEjeBP5NvLrNvWmuxaQ" },
                }
            };

            SchDownload frm = new SchDownload();
            frm.Url = @"http://watchmen:8080/dswsbobje/services/session";
            frm.Domain = "watchmen";
            frm.Login = "Administrator";
            frm.AuthType = "secEnterprise";
            frm.Directory = @"C:\dl";
            frm.SetReports(ref report);
            frm.Show();
            frm.Close();

        }

        static void GetList()
        {

            SchGetList frm = new SchGetList();
            frm.Url = @"http://watchmen:8080/dswsbobje/services";
            frm.Domain = "watchmen";
            frm.Login = "Administrator";
            frm.AuthType = "secEnterprise";
            frm.AssociatedInstance = "LAST_CREATED";
            frm.ReportsPath = "338";
         //   frm.ReportsPath = "1793584";
            frm.Show();
            Report[] rep =  frm.Reports;
            frm.Close();

        }
        static void GetStatus()
        {

            Report[] report = new Report[]{
                new Report{ 
                    Instance = new Instance{ Cuid="AUeoX2Se.OdPtmjP9j2sMKY" },
                }
            };

            SchGetStatus frm = new SchGetStatus();
            frm.Url = @"http://watchmen:8080/dswsbobje/services/session";
            frm.Domain = "watchmen";
            frm.Login = "Administrator";
            frm.AuthType = "secEnterprise";
            frm.SetReports(ref report);
            frm.Show();
            frm.Close();

        }

        static void ScheduleReport()
        {

            Report[] report = new Report[]{
                new Report{ 
                  //  Id="12288",
                    Id="18641",
                //    Cuid="AfgVIsAn2NhIoUXnUMiQe3g",
                    Prompts = new Prompt[]{ 
                        new Prompt{ Name="Début de période de règlement :", Value="01/01/2010"},
                        new Prompt{ Name="Fin de période de règlement :", Value="01/06/2010"},
                        new Prompt{ Name="Saisir une ou plusieurs valeurs pour N° Organisme :", Value="000001;000007;000002;000003"}
                    }
                }
            };

            SchSchedule frm = new SchSchedule();
            frm.Url = @"http://watchmen:8080/dswsbobje/services";
            frm.Domain = "watchmen";
            frm.Login = "Administrator";
            frm.AuthType = "secEnterprise";
      //      frm.OutFolder = @"F:\Partage\exportWebI\%SI_NAME%";
            frm.Format = "PDF"  ;
            frm.NotifEmail = "fbreheret@micropole.com";
            frm.SetReports(ref report);
            frm.Show();
         //   frm.Close();

        }
    }
}
