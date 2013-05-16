using System.Xml.Serialization;
using System.Text;
using System.IO;
using BusinessObjectsUtils.bo_session;
using System;

namespace BusinessObjectsUtils.bo_scheduler
{
    public class Report
    {
        [XmlIgnore()]
        public string LOG { get; set; }
        [XmlIgnore()]
        public string Folder { get; set; }
        [XmlAttribute]
        public string Cuid { get; set; }
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlIgnore()]
        public int NbChild { get; set; }
        public Prompt[] Prompts { get; set; }
        [XmlIgnore()]
        public Instance Instance { get; set; }

        public void SetPrompts(ref Prompt[] prompts) {
            Prompts = prompts;
        }

        public void SetInstance(ref Instance instance) {
            Instance = instance;
        }

        public string ToLongName(){
            return Id.ToString() + "-" + Name;
        }
    }

    public class Prompt
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlText()]
        public string Value { get; set; }
    }

    [Serializable]
    public class Instance
    {
        public string Cuid { get; set; }
        public int Id { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }

    [Serializable]
    public class PlanSchedule
    {
        public LoginData Credentials { get; set; }
        public bool WithPrompts { get; set; }
        public string Destination { get; set; }
        public string Format { get; set; }
        public bool WaitEnd { get; set; }
        public bool CleanEnd { get; set; }
        public string NotifEmail { get; set; }
        public Report[] Reports { get; set; }

        public void ParseToXml(string xmlPath)
        {
            var writer = new XmlSerializer(typeof(PlanSchedule));
            using (var file = new StreamWriter(xmlPath, false, Encoding.UTF8)){
                writer.Serialize(file, this);
            }
        }

        public static PlanSchedule ParseFromXml(string xmlPath)
        {
            PlanSchedule scheduleplan;
            var writer = new XmlSerializer(typeof(PlanSchedule));
            using(var ReadFileStream = new FileStream(xmlPath, FileMode.Open, FileAccess.Read, FileShare.Read)){
                scheduleplan = (PlanSchedule)writer.Deserialize(ReadFileStream);
                ReadFileStream.Close();
            }
            return scheduleplan;
        }

    }

}
