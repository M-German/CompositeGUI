using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompositeGUI
{
    public partial class AdvancedOptionsForm : Based
    {
        public AdvancedOptionsForm()
        {
            InitializeComponent();
        }

        private void AdvancedOptionsForm_Load(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
        }
    }
}
