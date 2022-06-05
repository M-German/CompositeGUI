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
    public partial class SelectMaterialForm : Based
    {
        public SelectMaterialForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                nameTextBox.Text = "Новый материал";
                elecUpDown.Value = 0;
                thermalUpDown.Value = 0;
                magUpDown.Value = 0;
                densityUpDown.Value = 0;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                nameTextBox.Text = "Графит";
                elecUpDown.Value = 12;
                thermalUpDown.Value = 24;
                magUpDown.Value = 1;
                densityUpDown.Value = 2230;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                nameTextBox.Text = "Эпоксидная смола";
                elecUpDown.Value = 4;
                thermalUpDown.Value = 0.2m;
                magUpDown.Value = 1;
                densityUpDown.Value = 1500;
            }
        }
    }
}
