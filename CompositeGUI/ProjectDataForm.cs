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
    public partial class ProjectDataForm : Based
    {
        public ProjectDataForm()
        {
            InitializeComponent();
            metalGridComboBox.SelectedIndex = 0;
            matrixComboBox.SelectedIndex = 1;
            fiberComboBox.SelectedIndex = 0;
            numericUpDown2.Value = 3.0m;
        }

        private void AdvancedOptionsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void matrixButton_Click(object sender, EventArgs e)
        {
            SelectMaterialForm f = new SelectMaterialForm();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectMaterialForm f = new SelectMaterialForm();
            f.ShowDialog();
        }
    }
}
