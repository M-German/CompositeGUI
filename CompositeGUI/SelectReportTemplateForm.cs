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
    public partial class SelectReportTemplateForm : Based
    {
        public SelectReportTemplateForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateReportTemplateForm form = new CreateReportTemplateForm();
            form.ShowDialog();
        }
    }
}
