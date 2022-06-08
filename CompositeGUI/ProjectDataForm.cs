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
        List<Material> materials;
        public ProjectDataForm()
        {
            InitializeComponent();
        }

        private void AdvancedOptionsForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = Main.CurrentProject.Name;
            FillMaterials();
            metalGridComboBox.SelectedIndex = Main.CurrentProject.HasMetalGrid ? 0 : 1;
            matrixComboBox.SelectedIndex = Main.CurrentProject.MatrixMaterialId != null ? materials.FindIndex(m => m.MaterialId == Main.CurrentProject.MatrixMaterialId) + 1 : 0;
            fiberComboBox.SelectedIndex = Main.CurrentProject.FiberMaterialId != null ? materials.FindIndex(m => m.MaterialId == Main.CurrentProject.FiberMaterialId) + 1 : 0;

            numericUpDown1.Value = Convert.ToDecimal(Main.CurrentProject.MinFrequency);
            numericUpDown2.Value = Convert.ToDecimal(Main.CurrentProject.MaxFrequency);
        }

        void FillMaterials()
        {
            string noMaterial = "Нет материала";
            matrixComboBox.Items.Clear();
            fiberComboBox.Items.Clear();
            matrixComboBox.Items.Add(noMaterial);
            fiberComboBox.Items.Add(noMaterial);

            materials = DB.GetMaterials();

            if (materials.Count > 0)
            {
                foreach (var item in materials)
                {
                    matrixComboBox.Items.Add(item.Name);
                    fiberComboBox.Items.Add(item.Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Project projectEdit = Main.CurrentProject;
            projectEdit.Name = nameTextBox.Text;
            projectEdit.HasMetalGrid = metalGridComboBox.SelectedIndex == 0;

            if (fiberComboBox.SelectedIndex == 0) projectEdit.FiberMaterialId = null;
            else projectEdit.FiberMaterialId = materials[fiberComboBox.SelectedIndex - 1].MaterialId;

            if (matrixComboBox.SelectedIndex == 0) projectEdit.MatrixMaterialId = null;
            else projectEdit.MatrixMaterialId = materials[matrixComboBox.SelectedIndex - 1].MaterialId;

            projectEdit.MinFrequency = Convert.ToDouble(numericUpDown1.Value);
            projectEdit.MaxFrequency = Convert.ToDouble(numericUpDown2.Value);

            Main.CurrentProject = DB.EditProject(projectEdit);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void matrixButton_Click(object sender, EventArgs e)
        {
            SelectMaterialForm f = new SelectMaterialForm(materials, true, matrixComboBox.SelectedIndex);
            f.ShowDialog();
            FillMaterials();
            matrixComboBox.SelectedIndex = materials.FindIndex(m => m.MaterialId == f.SelectedMaterialId) + 1;
        }

        private void fiberButton_Click(object sender, EventArgs e)
        {
            SelectMaterialForm f = new SelectMaterialForm(materials, false, fiberComboBox.SelectedIndex);
            f.ShowDialog();
            FillMaterials();
            fiberComboBox.SelectedIndex = materials.FindIndex(m => m.MaterialId == f.SelectedMaterialId) + 1;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = nameTextBox.Text.Length != 0;
        }
    }
}
