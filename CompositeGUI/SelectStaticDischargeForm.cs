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
    public partial class SelectStaticDischargeForm : Based
    {
        public SelectStaticDischargeForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateStaticDischargeForm form = new CreateStaticDischargeForm();
            form.ShowDialog();
        }
    }
}
