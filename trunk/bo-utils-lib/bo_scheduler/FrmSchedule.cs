using System;
using System.Text;
using System.Windows.Forms;


namespace BusinessObjectsUtils.bo_scheduler
{
    public partial class FrmSchedule : BaseForm
    {
        public bool Schedule { get; set; }

        public bool CreateXML { get; set; }

        public bool WithPrompts { 
            get { return ctrlPrompts.Checked; } 
            set { ctrlPrompts.Checked = value; }
        }

        public bool WaitEnd {
            get { return ctrlWait.Checked && !ctrlDateTimePicker.Checked; } 
            set { ctrlWait.Checked = value; } 
        }

        public bool CleanEnd {
            get { return ctrlClean.Checked && WaitEnd; } 
            set { ctrlClean.Checked = value; } 
        }

        public string Destination { 
            get { return ctrlDestination.Text; } 
            set { ctrlDestination.Text = value; } 
        }

        public string Format { 
            get { return ctrlFormat.Text; } 
            set { ctrlFormat.Text = value; } 
        }

        public string NotifEmail { 
            get { return ctrlEmail.Text; } 
            set { ctrlEmail.Text = value; } 
        }

        public bool RunNow { 
            get { return ctrlDateTimePicker.Checked; } 
            set { ctrlDateTimePicker.Checked = value; } 
        }

        public string StartTime { 
            get { return ctrlDateTimePicker.Value.ToString("yyyy/MM/dd HH:mm:ss"); }
            set { try { ctrlDateTimePicker.Value = DateTime.Parse(value); } catch (Exception) { throw new Exception("File format must be yyyy/MM/dd HH:mm:ss "); } }
        }

        public string Date { 
            get{
                return ctrlDateTimePicker.Checked ? ctrlDateTimePicker.Value.ToString() : DateTime.MinValue.ToString();
            }
        }

        public StringBuilder Reports {
            set {
                ctrlReports.Text = value.ToString();
            }
        }

        public FrmSchedule(int hwnd) : base(hwnd)
        {
            InitializeComponent();

            ctrlFormat.AddItem( "Default" );
            ctrlFormat.AddItem( "PDF" );
            ctrlFormat.AddItem( "Excel" );

            ctrlDateTimePicker.Checked = false;
            ctrlDateTimePicker.Format = DateTimePickerFormat.Custom;
            ctrlDateTimePicker.CustomFormat = "  yyyy/MM/dd  HH:mm:ss";
            var toolTip1 = new ToolTip {ShowAlways = true};
            toolTip1.SetToolTip(ctrlDateTimePicker, "Optional - Date and time at which to run the scheduling");
            toolTip1.SetToolTip(ctrlPrompts, "Schedule reports with specified prompts");
            toolTip1.SetToolTip(ctrlWait, "Wait the creation of the report");
            toolTip1.SetToolTip(ctrlClean, "Delete scheduled instances when finished");
            toolTip1.SetToolTip(ctrlDestination, "Optional - Location on the server to create reports\nEx : C:\\Export\\%SI_NAME%.%EXT%");
            toolTip1.SetToolTip(ctrlFormat, "Optional - Output format for reports creation");
        }

        private void btCancel_Click(object sender, EventArgs e){
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dtPicker_ValueChanged(object sender, EventArgs e)
        {
            if(ctrlDateTimePicker.Checked){
                ctrlWait.Checked = false;
                ctrlWait.Enabled = false;
            }else{
                ctrlWait.Enabled = true;
            }
        }

        private void btSchedule_Click(object sender, EventArgs e)
        {
            Schedule = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCreateXml_Click(object sender, EventArgs e){
            CreateXML = true;
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
