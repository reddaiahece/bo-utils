using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BusinessObjectsUtils.helper;

namespace BusinessObjectsUtils
{
    public partial class ComboBoxCust : ComboBox
    {
        int count;

        public ComboBoxCust() : base()
        {
            base.ValueMember = "key";
            base.DisplayMember = "value";
        }

        public void AddItem(object key, string value)
        {
            base.Items.Add(new ValuePair(key, value));
        }

        public void AddItem(string text)
        {
            AddItem(count++, text);
        }

    }



}
