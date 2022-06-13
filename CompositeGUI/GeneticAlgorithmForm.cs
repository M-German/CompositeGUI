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
    public partial class GeneticAlgorithmForm : Based
    {
        List<GA_Settings> GA_Settings;
        int? SelectedGaSettingsId;

        public GeneticAlgorithmForm()
        {
            InitializeComponent();
        }
        private void GeneticAlgorithmForm_Load(object sender, EventArgs e)
        {
            saveButton.Enabled = !Main.InProcess();
            SelectedGaSettingsId = Main.CurrentProject.GaSettingsId;
            FillSettings();
        }

        void FillSettings()
        {
            comboBox1.Items.Clear();
            GA_Settings = DB.GetGaSetings();

            comboBox1.Items.Add("Новый шаблон");
            foreach (var item in GA_Settings)
                comboBox1.Items.Add($"Шаблон {item.GaSettingsId}");

            comboBox1.SelectedIndex = GA_Settings.FindIndex(l => l.GaSettingsId == SelectedGaSettingsId) + 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                populationUpDown.Value = 4;
                generationsUpDown.Value = 5;
                tourneyUpDown.Value = 2;

                SelectedGaSettingsId = null;
            }
            else
            {
                populationUpDown.Value = Convert.ToDecimal(GA_Settings[comboBox1.SelectedIndex - 1].PopulationSize);
                generationsUpDown.Value = Convert.ToDecimal(GA_Settings[comboBox1.SelectedIndex - 1].MaxGenerations);
                tourneyUpDown.Value = Convert.ToDecimal(GA_Settings[comboBox1.SelectedIndex - 1].SelectionTourneySize);

                SelectedGaSettingsId = GA_Settings[comboBox1.SelectedIndex - 1].GaSettingsId;
            }
            deleteButton.Enabled = SelectedGaSettingsId != null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Project projectEdit = Main.CurrentProject;
            GA_Settings newS = new GA_Settings()
            {
                PopulationSize = Convert.ToInt32(populationUpDown.Value),
                MaxGenerations = Convert.ToInt32(generationsUpDown.Value),
                SelectionTourneySize = Convert.ToInt32(tourneyUpDown.Value)
            };
            if (SelectedGaSettingsId == null)
            {
                SelectedGaSettingsId = DB.AddGaSetings(newS).GaSettingsId;
            }
            else
            {
                newS.GaSettingsId = (int) SelectedGaSettingsId;
                SelectedGaSettingsId = DB.EditGaSettings(newS).GaSettingsId;
            }
            projectEdit.GaSettingsId = SelectedGaSettingsId;
            Main.CurrentProject = DB.EditProject(projectEdit);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (SelectedGaSettingsId != null && comboBox1.SelectedIndex != 0)
            {
                DialogResult res = MessageBox.Show(
                    "Вы действительно хотите удалить этот шаблон?",
                    "Предупреждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (res != DialogResult.Yes) return;

                DB.DeleteGaSettings(GA_Settings[comboBox1.SelectedIndex - 1].GaSettingsId);
                if (Main.CurrentProject.GaSettingsId == SelectedGaSettingsId) Main.CurrentProject.GaSettingsId = null;
                comboBox1.SelectedIndex = 0;

                FillSettings();
            }
        }
    }
}
