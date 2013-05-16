using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectsEtl
{
    [Guid("99394203-631C-4374-921E-80689B76C690"), ComVisible(true)]
    public enum ExitCode:int{
        FAILED = 0,
        HASERROR = 1,
        SUCCEED = 2,
        CANCELED = 3
    }

    public class SessionBase{
        internal delegate void ProgressHandler(int progress);
        internal delegate void LogHandler(string info);
        internal event ProgressHandler ProgressEvent;
        internal event LogHandler LogEvent;
        private int pbStart;
        private int pbTotal;
        private float progressTotal;
        private float progressCpt;
        private int pbCurrent;
        protected bool cancel = false;
        private StringBuilder log;
        private float progressTotal2;
        private float progressCpt2;
        private int pbCurrent2;
        private int pbStart2;
        private float pbTotal2;

        internal string SessionURL { get; set; }

        protected SessionBase(string serviceURL){
            this.SessionURL = serviceURL;
            this.log = new StringBuilder();
        }

        internal void Cancel(){
            this.cancel = true;
        }

        protected void InitProgress(int lower, int upper, int total){
            this.pbStart = lower;
            this.pbTotal = upper - lower;
            this.progressTotal = total;
            this.progressCpt = 0;
            this.pbCurrent = lower;
            SetProgress(lower);
        }

        protected void InitSubProgress(int total){
            this.pbStart2 = this.pbCurrent;
            this.pbTotal2 = this.pbTotal / this.progressTotal;
            this.progressTotal2 = total;
            this.progressCpt2 = 0;
            this.pbCurrent2 = 0;
        }

        protected void IncSubProgress(){
            if (this.ProgressEvent != null){
                int lSubProgress = this.pbStart2 + (int)(++this.progressCpt2 / this.progressTotal2 * pbTotal2);
                if(this.pbCurrent2 != lSubProgress){
                    this.ProgressEvent(lSubProgress);
                    this.pbCurrent2 = lSubProgress;
                }
            }
        }

        protected void IncProgress(){
            if (this.ProgressEvent != null){
                int lProgress = this.pbStart + (int)(++this.progressCpt / this.progressTotal * pbTotal);
                if(this.pbCurrent != lProgress){
                    this.ProgressEvent(lProgress);
                    this.pbCurrent = lProgress;
                }
            }
        }

        protected void SetProgress(int progress){
            if (this.ProgressEvent != null) this.ProgressEvent(progress);
        }

        public void Log(string info){
            if (this.LogEvent != null) this.LogEvent(info);
            log.AppendLine(info);
        }

        protected string GetLogText(){
            return "Execution LOG : \r\n" + log.ToString();
        }

    }
}
