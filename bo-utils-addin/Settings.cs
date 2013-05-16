using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BusinessObjectsUtils.bo_session;
using System.Globalization;

namespace BOUtilsAddin
{
    class Settings
    {
        private readonly Excel.Workbook _workbook;

        public static string ApplicationDataDir {
            get {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).TrimEnd('\\') + @"\BusinessObjectsUtils";
            }
        }

        public Settings(Excel.Workbook workbook)
        {
            _workbook = workbook;
        }

        public string GetWorkbookParam(string pParam, string pDefault)
        {
            try{
                return GetWorkbookNameValue(pParam);
            }catch(Exception){
                return pDefault;
            }
        }

        public int GetWorkbookParam(string pParam, int pDefault)
        {
            int value;
            if(int.TryParse(GetWorkbookNameValue(pParam),NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                return value;
            return pDefault;
        }

        public bool GetWorkbookParam(string pParam, bool pDefault)
        {
            bool value;
            if(bool.TryParse(GetWorkbookNameValue(pParam), out value))
                return value;
            return pDefault;
        }

        public string GetWorksheetParam(string pParam, string pDefault)
        {
            string value = GetWorksheetNameValue(pParam);
            if (string.IsNullOrEmpty(value))
                return pDefault;
            return value;
        }

        public int GetWorksheetParam(string pParam, int pDefault) {
            string value = GetWorksheetNameValue(pParam);
            int result;
            if (string.IsNullOrEmpty(value) || int.TryParse(value, out result) == false)
                return pDefault;
            return result;
        }

        public bool GetWorksheetParam(string pParam, bool pDefault)
        {
            string value = GetWorksheetNameValue(pParam);
            bool result;
            if( string.IsNullOrEmpty(value) || bool.TryParse(value, out result) == false)
                return pDefault;
            return result;
        }

        private string GetWorksheetNameValue(string pParam)
        {
            return GetNameValue(((Excel.Worksheet)_workbook.ActiveSheet).CodeName + pParam);
        }

        private string GetWorkbookNameValue(string pParam)
        {
            return GetNameValue("Wb" + pParam);
        }
        
        private string GetNameValue(string pName)
        {
            foreach(Excel.Name name in _workbook.Names)
                if (name.Name == pName)
                    return name.Value.Trim(new[] { '=', '"' });
            return null;
        }

        // Function to Set the user parameters saved in the registry
        public void SetWorksheetParam(string pParam, object pValue)
        {
            _workbook.Names.Add(((Excel.Worksheet)_workbook.ActiveSheet).CodeName + pParam, "=\"" + (pValue == null ? "" : pValue.ToString()) + "\"", false);
        }

        // Function to Set the user parameters saved in the registry
        public void SetWorkbookParam(string pParam, object pValue)
        {
            _workbook.Names.Add("Wb" + pParam, "=\"" + (pValue == null ? "" : pValue.ToString()) + "\"", false);
        }

        public void SaveToFile(string name, object data){
            try{
                string appDataDir = ApplicationDataDir;
                if(!Directory.Exists(appDataDir))
                    Directory.CreateDirectory(appDataDir);
                using(Stream stream = File.Open(appDataDir + "\\" + name, FileMode.Create)){
                    var bformatter = new BinaryFormatter();
                    bformatter.Serialize(stream, data);
                    stream.Close();
                }
            }catch(Exception ex){
                throw new Exception("Failed to load settings!", ex);
            }
        }

        public object LoadFromFile(string name){
            try{
                string appDataDir = ApplicationDataDir;
                if(!File.Exists(appDataDir + "\\" + name))
                    return null;
                object data;
                using(Stream stream = File.Open(appDataDir + "\\" + name, FileMode.Open)){
                    var bformatter = new BinaryFormatter();
                    data = bformatter.Deserialize(stream);
                    stream.Close();
                }
                return data;
            }catch(Exception ex){
                throw new Exception("Failed to save settings!", ex);
            }
        }

    }
}
