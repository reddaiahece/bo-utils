using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BusinessObjectsUtils
{

    public class BaseForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        private Wrapper _wrapper;

        public bool RestoreSelectionOnExit { get;set;}

        public BaseForm() : this(0) {
        }

        public BaseForm(int hwnd)
        {
            _wrapper = new Wrapper(hwnd);
            Application.EnableVisualStyles();
            SuspendLayout();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += ExcelForm_FormClosed;
            Application.ThreadException += Application_ThreadException;
            ResumeLayout();

        }

        internal virtual void Application_ThreadException(object sender, ThreadExceptionEventArgs e){
            DialogResult = DialogResult.Abort;
            Hide();
            if (e.Exception is InputError)
                MsgBox.ShowError( e.Exception.Message);
            else
                new FrmException(_wrapper.Hwnd, e.Exception).ShowDialog();
            Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


        public new void Show()
        {
            base.Show(_wrapper);
        }

        public new DialogResult ShowDialog() {
            return base.ShowDialog(_wrapper);
        }

        private void ExcelForm_FormClosed(object sender, FormClosedEventArgs e) {
            SetForegroundWindow(_wrapper.Handle);
        }

        internal class Wrapper : IWin32Window
        {
            readonly IntPtr _handle;

            public Wrapper(int hwnd) {
                _handle = new IntPtr(hwnd);
            }

            public IntPtr Handle {
                get { return _handle; }
            }

            public int Hwnd {
                get { return (int)_handle; }
            }
        }

    }

}
