using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BusinessObjectsEtl.Runner
{
    public class Structures
    {
    }

    public class Database{
        public string Type { get; set; }
        public string Path { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Multiload { get; set; }
    }

    public class WebService{
        public string WebServiceURL { get; set; }
        public string Domain { get; set; }
        public string AuthType { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Config
    {
        public WebService WebService { get; set; }
        public Database[] Databases { get; set; }

        public void ParseToXml(string xmlPath)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Config));
            using (StreamWriter file = new StreamWriter(xmlPath, false, Encoding.UTF8)){
                writer.Serialize(file, this);
            }
        }

        public static Config ParseFromXml(string xmlPath)
        {
            Config scheduleplan;
            XmlSerializer writer = new XmlSerializer(typeof(Config));
            using(FileStream ReadFileStream = new FileStream(xmlPath, FileMode.Open, FileAccess.Read, FileShare.Read)){
                scheduleplan = (Config)writer.Deserialize(ReadFileStream);
                ReadFileStream.Close();
            }
            return scheduleplan;
        }

    }



}
