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
    public partial class NoProjectDataForm : Based
    {
        public NoProjectDataForm()
        {
            InitializeComponent();
        }

        private void projectParamsButton_Click(object sender, EventArgs e)
        {
            ProjectDataForm f = new ProjectDataForm();
            f.ShowDialog();
        }

        private void limitsButton_Click(object sender, EventArgs e)
        {
            LimitsForm f = new LimitsForm();
            f.ShowDialog();
        }

        private void algorithmButton_Click(object sender, EventArgs e)
        {
            GeneticAlgorithmForm f = new GeneticAlgorithmForm();
            f.ShowDialog();
        }
    }
}
