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
        List<Material> materials;
        bool isMatrixMaterial;
        int selectedIndex;

        public int SelectedMaterialId;

        public SelectMaterialForm(List<Material> _materials, bool _isMatrixMaterial, int _selectedIndex)
        {
            InitializeComponent();
            materials = _materials;
            isMatrixMaterial = _isMatrixMaterial;
            selectedIndex = _selectedIndex;
        }

        void FillMaterialsComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Новый материал");
            foreach (var item in materials) comboBox1.Items.Add(item.Name);
        }

        private void SelectMaterialForm_Load(object sender, EventArgs e)
        {
            Text = isMatrixMaterial ? "Выбор материала матрицы" : "Выбор материала волокна";
            FillMaterialsComboBox();
            comboBox1.SelectedIndex = selectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                nameTextBox.Text = "Новый материал";
                elecUpDown.Value = 0;
                thermalUpDown.Value = 0;
                magUpDown.Value = 0;
                densityUpDown.Value = 0;
                SelectedMaterialId = 0;
            }
            else
            {
                nameTextBox.Text = materials[comboBox1.SelectedIndex - 1].Name; 
                elecUpDown.Value = Convert.ToDecimal(materials[comboBox1.SelectedIndex - 1].ElecCond);
                thermalUpDown.Value = Convert.ToDecimal(materials[comboBox1.SelectedIndex - 1].ThermalCond);
                magUpDown.Value = Convert.ToDecimal(materials[comboBox1.SelectedIndex - 1].MagCond);
                densityUpDown.Value = Convert.ToDecimal(materials[comboBox1.SelectedIndex - 1].Density);
                SelectedMaterialId = materials[comboBox1.SelectedIndex - 1].MaterialId;
            }
            deleteButton.Enabled = SelectedMaterialId != 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) // save
        {
            Material material = new Material()
            {
                Name = nameTextBox.Text,
                ElecCond = Convert.ToDouble(elecUpDown.Value),
                MagCond = Convert.ToDouble(magUpDown.Value),
                ThermalCond = Convert.ToDouble(thermalUpDown.Value),
                Density = Convert.ToDouble(densityUpDown.Value)
            };
            if (comboBox1.SelectedIndex == 0) // add new
            {
                SelectedMaterialId = DB.AddMaterial(material).MaterialId;
            }
            else // edit
            {
                material.MaterialId = materials[comboBox1.SelectedIndex - 1].MaterialId;
                DB.EditMaterial(material);
                SelectedMaterialId = material.MaterialId;
            }
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (SelectedMaterialId != 0 && comboBox1.SelectedIndex != 0)
            {
                DialogResult res = MessageBox.Show(
                    "Вы действительно хотите удалить этот материал?",
                    "Предупреждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (res != DialogResult.Yes) return;
                DB.DeleteMaterial(SelectedMaterialId);
                materials.Remove(materials[comboBox1.SelectedIndex-1]);
                if (Main.CurrentProject.MatrixMaterialId == SelectedMaterialId) Main.CurrentProject.MatrixMaterialId = null;
                if (Main.CurrentProject.FiberMaterialId == SelectedMaterialId) Main.CurrentProject.FiberMaterialId = null;
                FillMaterialsComboBox();
                comboBox1.SelectedIndex = 0;
            } 
        }
    }
}
