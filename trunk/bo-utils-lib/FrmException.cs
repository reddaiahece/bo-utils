using System;
using System.Text;
using System.Windows.Forms;

namespace BusinessObjectsUtils
{
    public partial class FrmException : BaseForm
    {
        bool _expended = true;
        const string Padleft = "   ";

        public FrmException(int hwnd, Exception exception) : base(hwnd)
        {
            InitializeComponent();
            var text = new StringBuilder();
            text.AppendLine("Exception :");
            text.AppendLine( Padleft + exception.Message);
            var exmsg = exception;
            while (exmsg.InnerException != null) {
                exmsg = exmsg.InnerException;
                text.AppendLine(Padleft + exmsg.Message);
            }
            text.AppendLine("Data :");
            foreach (object value in exception.Data.Values) {
                if(value!=null)
                    text.AppendLine(Padleft + value.ToString());
            }
            text.AppendLine("StackTrace : \r\n" + exception.StackTrace);
            textBox1.Text = text.ToString();
            textBox1.KeyDown += textBox1_KeyDown;
        }

        private void FrmException_Load(object sender, EventArgs e) {
            ToggleDetails();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.A && e.Control) {
                textBox1.SelectAll();
                e.Handled = true;
            }
        }

        private void btDetails_Click(object sender, EventArgs e) {
            ToggleDetails();
        }

        private void ToggleDetails()
        {
            if (_expended) {
                _expended = false;
                textBox1.Visible = false;
                Height = (Height - ClientSize.Height) + textBox1.Location.Y;
            } else {
                _expended = true;
                textBox1.Visible = true;
                Height = (Height - ClientSize.Height) + textBox1.Location.Y + textBox1.Size.Height + textBox1.Location.X;
            }
        }

        private void btClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);   
        }
    }
}
