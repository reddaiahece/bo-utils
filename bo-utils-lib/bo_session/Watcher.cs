using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectsUtils.bo_session
{

    public delegate void ProgressHandler(int progress);
    public delegate void LogHandler(string info);

    public class Logger{

        public event ProgressHandler ProgressEvent;
        public event LogHandler LogEvent;

        private int _pbStart;
        private int _pbTotal;
        private float _progressTotal;
        private float _progressCpt;
        private int _pbCurrent;
        protected bool _cancel = false;
        private readonly StringBuilder _log;
        private float _progressTotal2;
        private float _progressCpt2;
        private int _pbCurrent2;
        private int _pbStart2;
        private float _pbTotal2;

        internal string SessionURL { get; set; }

        public Logger()
        {
            //SessionURL = serviceURL;
            _log = new StringBuilder();
        }
            
        /*
        internal void Cancel(){
            cancel = true;
        }
        */

        internal void InitProgress(int lower, int upper, int total){
            _pbStart = lower;
            _pbTotal = upper - lower;
            _progressTotal = total;
            _progressCpt = 0;
            _pbCurrent = lower;
            SetProgress(lower);
        }

        internal void InitSubProgress(int total)
        {
            _pbStart2 = _pbCurrent;
            _pbTotal2 = _pbTotal / _progressTotal;
            _progressTotal2 = total;
            _progressCpt2 = 0;
            _pbCurrent2 = 0;
        }

        internal void IncSubProgress()
        {
            if (ProgressEvent != null){
                int lSubProgress = _pbStart2 + (int)(++_progressCpt2 / _progressTotal2 * _pbTotal2);
                if(_pbCurrent2 != lSubProgress){
                    ProgressEvent(lSubProgress);
                    _pbCurrent2 = lSubProgress;
                }
            }
        }

        internal void IncProgress()
        {
            if (ProgressEvent != null){
                int lProgress = _pbStart + (int)(++_progressCpt / _progressTotal * _pbTotal);
                if(_pbCurrent != lProgress){
                    ProgressEvent(lProgress);
                    _pbCurrent = lProgress;
                }
            }
        }

        internal void SetProgress(int progress)
        {
            if (ProgressEvent != null) ProgressEvent(progress);
        }

        internal void Log(string message)
        {
            if (LogEvent != null) LogEvent(message);
            _log.AppendLine(message);
            //for(int i=1; i<info.Length; i++)
            //    log.AppendLine( "  " + info[i] );
        }

        internal string GetLogText()
        {
            return _log.ToString();
        }


    }
}
