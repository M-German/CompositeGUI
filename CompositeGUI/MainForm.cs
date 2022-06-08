using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompositeGUI.Data;

namespace CompositeGUI
{
    public partial class MainForm : Based
    {
        bool noProjectData = false, showStructure = false;

        List<List<double>> propData;
        List<Composite> propDataStructre;

        NoProjectDataForm noDataForm;
        NoSelectedProjectForm noProjectForm;

        public MainForm()
        {
            InitializeComponent();

            //db = new DB();

            propData = new List<List<double>>()
            {
                new List<double>() { 0.1, 35.65341942, 35.20124463, 35.43246019 },
                new List<double>() { 0.11, 35.52501895, 35.06567688, 35.29958923 },
                new List<double>() { 0.12, 35.40444732, 34.9382407, 35.17458749 },
                new List<double>() { 0.13, 35.29030919, 34.81747912, 35.05602615 },
                new List<double>() { 0.14, 35.1814952, 34.7022314, 34.94276714 },
                new List<double>() { 0.15, 35.07710187, 34.59155173, 34.83388319 },
                new List<double>() { 0.16, 34.97637879, 34.48465335, 34.7286013 },
                new List<double>() { 0.17, 34.87869171, 34.3808696, 34.62626841 },
                new List<double>() { 0.18, 34.7834978, 34.27962994, 34.52632373 },
                new List<double>() { 0.19, 34.690327, 34.18043921, 34.42828145 },
                new List<double>() { 0.2, 34.59876817, 34.08286305, 34.33171452 },
                new List<double>() { 0.21, 34.50845977, 33.98651994, 34.2362478 },
                new List<double>() { 0.22, 34.41908092, 33.89106933, 34.14154796 },
                new List<double>() { 0.23, 34.33034772, 33.79621007, 34.0473193 },
                new List<double>() { 0.24, 34.24200701, 33.70167365, 33.9532989 },
                new List<double>() { 0.25, 34.15383421, 33.60722035, 33.85925349 },
                new List<double>() { 0.26, 34.06563062, 33.51263879, 33.76497694 },
                new List<double>() { 0.27, 33.9772207, 33.41774025, 33.67028766 },
                new List<double>() { 0.28, 33.88845057, 33.32236042, 33.57502739 },
                new List<double>() { 0.29, 33.79918508, 33.22635297, 33.47905859 },
                new List<double>() { 0.3, 33.70930879, 33.12959258, 33.3822634 }
            };

            propDataStructre = new List<Composite>()
            {
                new Composite(3, 7.64, 7.75, 1.61),
                new Composite(3, 7.68, 7.64, 1.66),
                new Composite(3, 7.91, 7.67, 1.84),
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            resultComboBox.SelectedIndex = 0;
            ShowSelectProjectForm();
            Main.ProjectList = DB.GetProjects();
            Main.ProjectChanged += ProjectChangedHandler;

            //заглушка
            Main.CurrentProject = Main.ProjectList[0];
        }

        void ProjectChangedHandler()
        {
            MessageBox.Show("lol");
            if (Main.CurrentProject != null)
            {
                if (Main.CurrentProject.Composites.Count == 0)
                {
                    ShowNoDataForm();
                }
                else
                {
                    ShowResultsForm();
                }
            }
            else ShowSelectProjectForm();
        }

        void FillComposite(int i)
        {
            int index = this.resultsDataGridView.Columns.Count;
            resultsDataGridView.Columns.Add("Column" + (i + 2), "Композит " + (i + 1));
            this.resultsDataGridView.Rows[0].Cells[index].Value = propDataStructre[i].FiberWidth;
            this.resultsDataGridView.Rows[1].Cells[index].Value = propDataStructre[i].FiberThickness;
            this.resultsDataGridView.Rows[2].Cells[index].Value = propDataStructre[i].FiberSpaceBetween;
            this.resultsDataGridView.Rows[3].Cells[index].Value = Convert.ToDouble(propDataStructre[i].LayerCount);
        }

        void FillDataGridView()
        {
            resultsDataGridView.Rows.Clear();
            resultsDataGridView.Columns.Clear();

            if(!showStructure)
            {
                resultsDataGridView.Columns.Add("Column1", "f (ГГц)");
                if (resultComboBox.SelectedIndex == 1)
                {
                    resultsDataGridView.Columns.Add("Column2", "SE1");
                    foreach (var row in propData) this.resultsDataGridView.Rows.Add(row[0], row[1]);
                }
                else if (resultComboBox.SelectedIndex == 2)
                {
                    resultsDataGridView.Columns.Add("Column2", "SE2");
                    foreach (var row in propData) this.resultsDataGridView.Rows.Add(row[0], row[2]);
                }
                else if (resultComboBox.SelectedIndex == 3)
                {
                    resultsDataGridView.Columns.Add("Column2", "SE3");
                    foreach (var row in propData) this.resultsDataGridView.Rows.Add(row[0], row[3]);
                }
                else
                {
                    resultsDataGridView.Columns.Add("Column2", "SE1");
                    resultsDataGridView.Columns.Add("Column3", "SE2");
                    resultsDataGridView.Columns.Add("Column4", "SE3");
                    foreach (var row in propData) this.resultsDataGridView.Rows.Add(row[0], row[1], row[2], row[3]);
                }
            }
            else
            {
                resultsDataGridView.Columns.Add("Column1", "");
                resultsDataGridView.Rows.Add(4);
                this.resultsDataGridView.Rows[0].Cells[0].Value = "Ширина волокна";
                this.resultsDataGridView.Rows[1].Cells[0].Value = "Толщина волокна";
                this.resultsDataGridView.Rows[2].Cells[0].Value = "Расстояние между";
                this.resultsDataGridView.Rows[3].Cells[0].Value = "Количество слоев";

                if (resultComboBox.SelectedIndex == 0)
                {
                    for (int i = 0; i < propDataStructre.Count; i++) FillComposite(i);
                }
                else FillComposite(resultComboBox.SelectedIndex - 1);
            }
            
            this.resultsDataGridView.ClearSelection();
        }

        void DrawSpline(int i)
        {
            this.chart1.Series.Add("SE" + (i + 1));
            int index = this.chart1.Series.Count - 1;
            this.chart1.Series[index].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            foreach (var row in propData) this.chart1.Series[index].Points.AddXY(row[0], row[i + 1]);
        }

        void FillChart()
        {
            this.chart1.Series.Clear();
            chart1.ChartAreas[0].AxisY.Minimum = 33;
            if(resultComboBox.SelectedIndex == 0)
                for (int i = 0; i < 3; i++) DrawSpline(i);
            else DrawSpline(resultComboBox.SelectedIndex - 1);
        }

        void ShowNoDataForm()
        {
            if(noDataForm == null)
            {
                noDataForm = new NoProjectDataForm();
                noDataForm.TopLevel = false;
                noDataForm.Dock = DockStyle.Fill;
                this.mainPanel.Controls.Add(noDataForm);
                noDataForm.Show();
                CloseSelectProjectForm();
                this.resultsPanel.Visible = false;
            }
        }

        void CloseNoDataForm()
        {
            if (noProjectForm != null)
            {
                this.mainPanel.Controls.Remove(noDataForm);
                noDataForm = null;
            }
        }

        void ShowSelectProjectForm()
        {
            if (noProjectForm == null)
            {
                noProjectForm = new NoSelectedProjectForm();
                noProjectForm.TopLevel = false;
                noProjectForm.Dock = DockStyle.Fill;
                this.mainPanel.Controls.Add(noProjectForm);
                noProjectForm.Show();
                CloseNoDataForm();
                this.resultsPanel.Visible = false;
            }
        }

        void CloseSelectProjectForm()
        {
            if (noProjectForm != null)
            {
                this.mainPanel.Controls.Remove(noProjectForm);
                noProjectForm = null;
            }
        }

        void ShowResultsForm()
        {
            this.resultsPanel.Visible = true;
            CloseSelectProjectForm();
            CloseNoDataForm();
        }

        private void DBConnectionError()
        {
            MessageBox.Show(
                "Ошибка подключения к БД",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
             );
        }

        private void FileAccessError()
        {
            MessageBox.Show(
                "Ошибка открытия файла",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
             );
        }

        private void InvalidDataError()
        {
            MessageBox.Show(
                "Введены некорректные данные",
                "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
             );
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main.CurrentProject = null;
            //Close();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm abf = new AboutForm();
            abf.ShowDialog();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateProjectForm form = new CreateProjectForm();
            form.ShowDialog();
        }

        private void openProjectToolstrip_Click(object sender, EventArgs e)
        {
            OpenProjectForm form = new OpenProjectForm();
            form.ShowDialog();
        }

        private void NewProjectButton_Click(object sender, EventArgs e)
        {
            CreateProjectForm form = new CreateProjectForm();
            form.ShowDialog();
        }

        private void projectDataToolstrip_Click(object sender, EventArgs e)
        {
            ProjectDataForm f = new ProjectDataForm();
            f.ShowDialog();
        }

        private void limitsToolstrip_Click(object sender, EventArgs e)
        {
            LimitsForm f = new LimitsForm();
            f.ShowDialog();
        }

        private void algorithmToolstrip_Click(object sender, EventArgs e)
        {
            GeneticAlgorithmForm f = new GeneticAlgorithmForm();
            f.ShowDialog();
        }

        private void resultComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGridView();
            FillChart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showStructure = !showStructure;
            if (showStructure) button1.Text = "Покзать экранирование";
            else button1.Text = "Показать структуру";
            FillDataGridView();
        }

        private void удалитьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Вы действительно хотите этот удалить проект?",
                "Предупреждение",  
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning
            );
        }
    }
}
