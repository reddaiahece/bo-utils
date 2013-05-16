using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using BusinessObjectsUtils.bo_session;

namespace BusinessObjectsUtils
{
    public partial class FrmRunner : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public delegate ExitCode ActionDelegate();

        private readonly Logger _logger;
        private readonly MethodInvoker _delegateCancel;
        private Thread _thread;

        public FrmRunner(Logger logger, MethodInvoker delegateCancel)
        {
            InitializeComponent();
            //if ((0x0FFF0|ldl)!=0xFFF0 || (0xFFF0&ldl)<1 ) MsgBox.ShowWarn(UTF8Encoding.UTF8.GetString(new byte[] { 0x54, 0x72, 0x69, 0x61, 0x6C, 0x20, 0x70, 0x65, 0x72, 0x69, 0x6F, 0x64, 0x20, 0x69, 0x73, 0x20, 0x6F, 0x76, 0x65, 0x72 }));
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            _logger = logger;
            _delegateCancel = delegateCancel;
        }

        private void AppDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            string msg = Func.ParseException(exception);
            _logger.Log(msg);
            MsgBox.ShowError(msg);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            _delegateCancel();
        }

        private void ScrollToBottom(TextBox tb)
        {
            SendMessage(tb.Handle, 0x115, (IntPtr)7, IntPtr.Zero);
        }

        internal void SetProgress(int pProgress)
        {
            if (progressBar1.InvokeRequired){
                Invoke((MethodInvoker)(() => SetProgress(pProgress)));
            }else{
                progressBar1.Value = pProgress;
            }
        }

        internal void AddInfo(string pInfo)
        {
            if (txtInfo.InvokeRequired){
                Invoke((MethodInvoker)delegate { AddInfo(pInfo); });
            }else{
                string txt = txtInfo.Text;
                if(txt != String.Empty) txt += "\r\n";
                txtInfo.Text = txt + pInfo;
                ScrollToBottom(txtInfo);
            }
        }

        internal void FormProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( (sender as Button) != null && _delegateCancel != null
                  && string.Equals((sender as Button).Name, @"CloseButton")
               ){
                _delegateCancel();
            }
        }

        private void FrmProgress_Load(object sender, EventArgs e)
        {
            _thread.Start();
        }

        public ExitCode Execute(ActionDelegate action_delegate)
        {
            var exitCode = ExitCode.FAILED;
            _logger.ProgressEvent += SetProgress;
            _logger.LogEvent += AddInfo;
            _thread = new Thread(delegate(){
                try{
                    exitCode = action_delegate();
                }catch (Exception ex){
                    exitCode = ExitCode.FAILED;
                    var ermsg = Func.ParseException(ex);
                    _logger.Log(ermsg);
                    //new FrmException(ex).ShowDialog();
                    MsgBox.ShowError(ermsg);
                }
                if (exitCode == ExitCode.CANCELED || exitCode == ExitCode.SUCCEED){
                    Invoke((MethodInvoker)Close);
                }else{
                    Invoke((MethodInvoker)(() =>{
                        btCancel.Enabled = false;
                        btClose.Enabled = true;
                    }));
                }
                /*if (exitCode == ExitCode.HASERROR){
                    MsgBox.ShowError("Some error occured! Check the log for further details.");
                }*/
            });
            ShowDialog();
            _logger.ProgressEvent -= SetProgress;
            _logger.LogEvent -= AddInfo;
            return exitCode;
        }


    }
}
