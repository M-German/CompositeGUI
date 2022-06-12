
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CompositeGUI
{
    public partial class LimitsForm : Based
    {
        List<Limits> limits;
        int? SelectedLimitsId;
        public LimitsForm()
        {
            InitializeComponent();
        }

        private void FiberStructure_Load(object sender, System.EventArgs e)
        {
            SelectedLimitsId = Main.CurrentProject.LimitsId;
            FillLimits();
        }

        void FillLimits()
        { 
            comboBox1.Items.Clear();
            limits = DB.GetLimits();

            comboBox1.Items.Add("Новый шаблон");
            foreach(var item in limits) 
                comboBox1.Items.Add($"Шаблон {item.LimitsId}");

            comboBox1.SelectedIndex = limits.FindIndex(l => l.LimitsId == SelectedLimitsId) + 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                minLayersUpDown.Value = 1;
                maxLayersUpDown.Value = 3;
                minWidthUpDown.Value = 0.5m;
                maxWidthUpDown.Value = 3;
                minThickUpDown.Value = 0.5m;
                maxThickUpDown.Value = 3;
                minSpaceUpDown.Value = 0.2m;
                maxSpaceUpDown.Value = 2;

                SelectedLimitsId = null;
            }
            else
            {
                minLayersUpDown.Value = Convert.ToDecimal(limits[comboBox1.SelectedIndex - 1].MinLayerCount);
                maxLayersUpDown.Value = Convert.ToDecimal(limits[comboBox1.SelectedIndex - 1].MaxLayerCount);
                minWidthUpDown.Value = Convert.ToDecimal(limits[comboBox1.SelectedIndex - 1].MinFiberWidth);
                maxWidthUpDown.Value = Convert.ToDecimal(limits[comboBox1.SelectedIndex - 1].MaxFiberWidth);
                minThickUpDown.Value = Convert.ToDecimal(limits[comboBox1.SelectedIndex - 1].MinFiberThickness);
                maxThickUpDown.Value = Convert.ToDecimal(limits[comboBox1.SelectedIndex - 1].MaxFiberThickness);
                minSpaceUpDown.Value = Convert.ToDecimal(limits[comboBox1.SelectedIndex - 1].MinFiberSpaceBetween);
                maxSpaceUpDown.Value = Convert.ToDecimal(limits[comboBox1.SelectedIndex - 1].MaxFiberSpaceBetween);

                SelectedLimitsId = limits[comboBox1.SelectedIndex - 1].LimitsId;
            }
            deleteButton.Enabled = SelectedLimitsId != null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Project projectEdit = Main.CurrentProject;
            Limits newL = new Limits()
            {
                MinLayerCount = Convert.ToInt32(minLayersUpDown.Value),
                MaxLayerCount = Convert.ToInt32(maxLayersUpDown.Value),
                MinFiberWidth = Convert.ToDouble(minWidthUpDown.Value),
                MaxFiberWidth = Convert.ToDouble(maxWidthUpDown.Value),
                MinFiberThickness = Convert.ToDouble(minThickUpDown.Value),
                MaxFiberThickness = Convert.ToDouble(maxThickUpDown.Value),
                MinFiberSpaceBetween = Convert.ToDouble(minSpaceUpDown.Value),
                MaxFiberSpaceBetween = Convert.ToDouble(maxSpaceUpDown.Value)
            };
            if (SelectedLimitsId == null)
            {
                SelectedLimitsId = DB.AddLimits(newL).LimitsId;
            }
            else
            {
                newL.LimitsId = (int) SelectedLimitsId;
                SelectedLimitsId = DB.EditLimits(newL).LimitsId;
            }
            projectEdit.LimitsId = SelectedLimitsId;
            Main.CurrentProject = DB.EditProject(projectEdit);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (SelectedLimitsId != null && comboBox1.SelectedIndex != 0)
            {
                DialogResult res = MessageBox.Show(
                    "Вы действительно хотите удалить этот шаблон?",
                    "Предупреждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (res != DialogResult.Yes) return;

                DB.DeleteLimits(limits[comboBox1.SelectedIndex - 1].LimitsId);
                if (Main.CurrentProject.LimitsId == SelectedLimitsId) Main.CurrentProject.LimitsId = null;
                comboBox1.SelectedIndex = 0;

                FillLimits();
            }
        }
    }
}
