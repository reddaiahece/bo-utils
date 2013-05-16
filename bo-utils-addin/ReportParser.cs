using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsUtils;
using BusinessObjectsUtils.bo_scheduler;
using Excel = Microsoft.Office.Interop.Excel;

namespace BOUtilsAddin
{
    public class ReportParser
    {
        const int ColLog = 1;       const string ColLogName = "LOG";
        const int ColInsCuid = 2;   const string ColInsCuidName = "InsCuid";
        const int ColInsId = 3;     const string ColInsIdName = "InsId";
        const int ColInsStatus = 4; const string ColInsStatusName = "InsStatus";
        const int ColInsDate = 5;   const string ColInsDateName = "InsDate";
        const int ColInsTime = 6;   const string ColInsTimeName = "InsTime";
        const int ColDocPath = 7;   const string ColDocPathName = "DocFolder";
        const int ColDocCuid = 8;   const string ColDocCuidName = "DocCuid";
        const int ColDocId = 9;     const string ColDocIdName = "DocId";
        const int ColDocType = 10;  const string ColDocTypeName = "DocType";
        const int ColDocName = 11;  const string ColDocNameName = "DocName";
        const int ColNbInst = 12;   const string ColNbInstName = "NbInst";
        const int ColNbPrompt = 13; const string ColNbPromptName = "NbPrompt";
        const int ColPrompt = 14;   const string ColPromptName = "Prompt";

        public void FormatListObject(Excel.ListObject listobject) {
            foreach (string col in new string[] { ColInsIdName, ColDocIdName, ColNbInstName, ColNbPromptName })
                listobject.ListColumns[col].Range.NumberFormat = "";
            foreach (string col in new string[] { ColDocCuidName, ColInsCuidName, ColNbPromptName })
                listobject.ListColumns[col].Range.EntireColumn.Hidden = true;
        }

        public object[,] ParseReportsToTitleArray(Report[] pReports)
        {
            if (pReports == null) throw new ArgumentNullException("pReports");

            const int nbColumn = ColPrompt - 1;
            var nbPrompt = GetMaxPromptsLength(pReports);

            var titles = ExcelArray<object>.Create(1, nbColumn + nbPrompt);
            //set titles
            titles[1, ColLog] = ColLogName;
            titles[1, ColInsCuid] = ColInsCuidName;
            titles[1, ColInsId] = ColInsIdName;
            titles[1, ColInsStatus] = ColInsStatusName;
            titles[1, ColInsDate] = ColInsDateName;
            titles[1, ColInsTime] = ColInsTimeName;
            titles[1, ColDocPath] = ColDocPathName;
            titles[1, ColDocCuid] = ColDocCuidName;
            titles[1, ColDocId] = ColDocIdName;
            titles[1, ColDocType] = ColDocTypeName;
            titles[1, ColDocName] = ColDocNameName;
            titles[1, ColNbInst] = ColNbInstName;
            titles[1, ColNbPrompt] = ColNbPromptName;

            for (int p=1, c=ColPrompt; p <= nbPrompt; p++, c++){
                titles[1, c] = ColPromptName + p.ToString();
            }
            return titles;
        }

        public object[,] ParseReportsToDataArray(Report[] pReports)
        {
            if(pReports==null) return null;

            var nbReport = pReports.Length;
            var nbColumn = ColPrompt - 1;
            var nbPrompt = GetMaxPromptsLength(pReports);

            var data = ExcelArray<object>.Create( nbReport, nbColumn + nbPrompt);
            
            //set data
            for(int ir=0, r=1; ir<nbReport; ir++,r++){
                var report = pReports[ir];
                data[r, ColLog] = report.LOG;
                if(report.Instance!=null){
                    data[r, ColInsCuid] = report.Instance.Cuid;
                    data[r, ColInsId] = report.Instance.Id;
                    data[r, ColInsStatus] = report.Instance.Status;
                    data[r, ColInsDate] = report.Instance.Date;
                    data[r, ColInsTime] = report.Instance.Time;
                }
                data[r, ColDocPath] = report.Folder;
                data[r, ColDocCuid] = report.Cuid;
                data[r, ColDocId] = report.Id;
                data[r, ColDocType] = report.Type;
                data[r, ColDocName] = report.Name;
                data[r, ColNbInst] = report.NbChild;
                if(report.Prompts != null){
                    if (report.Prompts.Length != 0) data[r, ColNbPrompt] = report.Prompts.Length;
                    for(int p=0, col=ColPrompt; p<report.Prompts.Length; p++, col++){
                        data[r, col] = Truncate(report.Prompts[p].Value, 910);
                    }
                }
            }
            return data;
        }

        public StringBuilder GetReportsList(Excel.ListObject pListObject)
        {
            var ids = ExcelArray<object>.Get(GetDataBodyRange(pListObject.ListColumns[ColDocIdName].Range).Value);
            var names = ExcelArray<object>.Get(GetDataBodyRange(pListObject.ListColumns[ColDocNameName].Range).Value);
            var worksheet = (Excel.Worksheet)pListObject.Parent;
            int rowOffest = pListObject.DataBodyRange.Row;
            int nbRow = ids.GetLength(0);
            var reports = new StringBuilder();
            for (int r = 1, rr = rowOffest; r <= nbRow; r++, rr++){
                if ((bool)((Excel.Range)worksheet.Rows[rr]).Hidden == false)
                    reports.AppendLine( ids[r, 1] + " - " + names[r, 1] );
            }
            return reports;
        }

        private Excel.Range GetDataBodyRange(Excel.Range range) {
            return range.Resize[range.Rows.Count - 1, Type.Missing].Offset[1, Type.Missing];
        }

        public Report[] ParseListObjectToReports(Excel.ListObject pListObject, bool pIncludePrompts)
        {
            var loDataRange = pIncludePrompts ? pListObject.DataBodyRange : pListObject.DataBodyRange.Resize[Type.Missing, ColPrompt - 1];
            var data = ExcelArray<object>.Get(loDataRange.Value);
            var nbRow = data.GetLength(0);

            //Get columns index
            var colInsIdIndex = pListObject.ListColumns[ColInsIdName].Index;
            var colInsCuidIndex = pListObject.ListColumns[ColInsCuidName].Index;
            var colInsStatusIndex = pListObject.ListColumns[ColInsStatusName].Index;
            var colInsDateIndex = pListObject.ListColumns[ColInsDateName].Index;
            var colInsTimeIndex = pListObject.ListColumns[ColInsTimeName].Index;
            var colCuidIndex = pListObject.ListColumns[ColDocCuidName].Index;
            var colIdIndex = pListObject.ListColumns[ColDocIdName].Index;
            var colNameIndex = pListObject.ListColumns[ColDocNameName].Index;
            var colTypeIndex = pListObject.ListColumns[ColDocTypeName].Index;
            var colNbChildIndex = pListObject.ListColumns[ColNbInstName].Index;
            var colNbPromptsIndex = pListObject.ListColumns[ColNbPromptName].Index;

            int[] colPromptName = null;
            const string pattern = "^" + ColPromptName + @"\d+$";
            if(pIncludePrompts){
                var colPrompt= new List<int>();
                foreach (Excel.ListColumn listcolumn in pListObject.ListColumns) {
                    if( System.Text.RegularExpressions.Regex.IsMatch( listcolumn.Name, pattern ) )
                        colPrompt.Add(listcolumn.Index);
                }
                colPromptName = colPrompt.ToArray();
            }

            var activesheet = (Excel.Worksheet)pListObject.Parent;

            //Set values
            var lReports = new List<Report>();
            for (int r=1, rr=loDataRange.Row; r <= nbRow; r++, rr++){
                if ((bool) ((Excel.Range) activesheet.Rows[rr]).Hidden) continue;
                var report = new Report{
                    Cuid = (string)data[r, colCuidIndex],
                    Id = GetInteger(data[r, colIdIndex]),
                    Name = (string)data[r, colNameIndex],
                    Type = (string)data[r, colTypeIndex],
                    NbChild = GetInteger(data[r, colNbChildIndex]),
                    Instance = data[r, colInsCuidIndex]==null ? null : new Instance{
                        Id = GetInteger(data[r, colInsIdIndex]),
                        Cuid = (string)data[r, colInsCuidIndex],
                        Date = (string)data[r, colInsDateIndex],
                        Time = (string)data[r, colInsTimeIndex],
                    }
                };

                if (pIncludePrompts){
                    var nbPrompts = GetInteger(data[r, colNbPromptsIndex]);
                    if ( nbPrompts != null && nbPrompts!=0) {
                        report.Prompts = new Prompt[(int)nbPrompts];
                        for (var ip = 0; ip < (int)nbPrompts; ip++){
                            report.Prompts[ip] = new Prompt{
                                Name = ((Excel.Range)loDataRange.Cells[r, colPromptName[ip]]).Comment.Text(),
                                Value = (string)data[r, colPromptName[ip]]
                            };
                        }
                    }
                }
                lReports.Add(report);
            }

            return lReports.ToArray();
        }

        private int GetInteger(object value) {
            if (value is double) return (int)(double)value;
            return 0;
        }

        public void AddPromptsNameAsComment(Excel.ListObject pListObject, Report[] pReports)
        {
            var loDataRange = pListObject.DataBodyRange;
            var maxPrompts = GetMaxPromptsLength(pReports);
            var colPromptName = new int[maxPrompts];

            //Get columns index
            for( int ic = 0, c = 1; ic<maxPrompts; ic++, c++)
                colPromptName[ic] = pListObject.ListColumns[ColPromptName + c.ToString()].Index;
            //Add comments
            for( int ir = 0, r = 1; ir<pReports.Length; ir++, r++){
                if (pReports[ir].Prompts == null) continue;
                for( int ip = 0; ip<pReports[ir].Prompts.Length; ip++)
                    ((Excel.Range)loDataRange.Cells[r, colPromptName[ip]]).AddComment(pReports[ir].Prompts[ip].Name);
            }
        }

        public void UpdateListObjectStatus(Excel.ListObject pListObject, Report[] pReports)
        {
            var loDataRange = pListObject.DataBodyRange.Resize[Type.Missing, ColPrompt - 1];
            var data = ExcelArray<object>.Get(loDataRange.Value);
            var nbrow = data.GetLength(0);

            //Get columns index
            int colLogIndex = pListObject.ListColumns[ColLogName].Index;
            int colStatusIndex = pListObject.ListColumns[ColInsStatusName].Index;
            int colDateIndex = pListObject.ListColumns[ColInsDateName].Index;
            int colTimeIndex = pListObject.ListColumns[ColInsTimeName].Index;
            int colInsCuidIndex = pListObject.ListColumns[ColInsCuidName].Index;
            int colInsIdIndex = pListObject.ListColumns[ColInsIdName].Index;
            int colIdIndex = pListObject.ListColumns[ColDocIdName].Index;
            int colNbInsIndex = pListObject.ListColumns[ColNbInstName].Index;

            //Update values
            var refRow = new Dictionary<int?,int>();

            for( var r=1; r<=nbrow; r++ )
                refRow.Add((int)(double)(data[r, colIdIndex]), r);

            foreach(Report lReport in pReports){
                if (lReport.Id == null) continue;
                var lRow = refRow[ lReport.Id ];
                data[lRow, colLogIndex] = lReport.LOG;
                if (lReport.Instance != null) {
                    data[lRow, colInsCuidIndex] = lReport.Instance.Cuid;
                    data[lRow, colInsIdIndex] = lReport.Instance.Id;
                    data[lRow, colStatusIndex] = lReport.Instance.Status;
                    data[lRow, colDateIndex] = lReport.Instance.Date;
                    data[lRow, colTimeIndex] = lReport.Instance.Time;
                }
                    data[lRow, colNbInsIndex] = lReport.NbChild;
            }

            loDataRange.Value = data;
            loDataRange.WrapText = false;
        }

        private string Truncate(string source, int length)
        {
            if (source!=null)
                return source.Length > length ? source.Substring(0, length) : source;
            return null;
        }

        private int GetMaxPromptsLength(IEnumerable<Report> pReports)
        {
            var lenMax = 0;
            foreach (var rep in pReports){
                if (rep.Prompts == null) continue;
                var len = rep.Prompts.Length;
                if(len > lenMax) lenMax = len;
            }
            return lenMax;
        }

        public bool checkTablePresent(Excel.Worksheet activesheet)
        {
            if(activesheet.ListObjects.Count == 0){
                MsgBox.ShowWarn("Report table is missing !  ");
                return false;
            }
            return true;
        }

    }
}
