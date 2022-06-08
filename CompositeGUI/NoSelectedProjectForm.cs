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
    public partial class NoSelectedProjectForm : Based
    {
        public NoSelectedProjectForm()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenProjectForm f = new OpenProjectForm();
            f.ShowDialog();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            CreateProjectForm f = new CreateProjectForm();
            f.ShowDialog();
        }
    }
}
