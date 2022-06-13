using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CompositeGUI.Data;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Globalization;

namespace CompositeGUI
{
    public partial class MainForm : Based
    {
        bool in_process = false;
        bool showStructure = true;
        int pageSize = 10;
        List<Composite> composites;

        NoProjectDataForm noDataForm;
        NoSelectedProjectForm noProjectForm;
        SimulationStatusForm statusForm;

        static string[] ColourValues = new string[] {
            "d11141", "00b159", "00aedb", "f37735", "ffc425", "d9534f", "ff0066",
            "5bc0de", "5cb85c", "428bca", "ff6600", "ffff66", "00ff66", "66ffff"
        };

        string GetColor(int i)
        {
            if(i >= ColourValues.Length) {
                i -= i / ColourValues.Length * ColourValues.Length;
            }
            return "#"+ColourValues[i];
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            topComboBox.SelectedIndex = 1;
            tableLayoutPanel1.SetRowSpan(chart1, 2);
            UpdateMenuState();
            ShowSelectProjectForm();
            Main.ProjectList = DB.GetProjects();
            Main.ProjectChanged += ProjectChangedHandler;
            //Main.SimulationStatusChanged += ProjectChangedHandler;
            Main.SimulationStatusChanged += StatusChangedHandler;
        }


        void ProjectChangedHandler()
        {
            if (Main.CurrentProject != null)
            {
                if (in_process)
                {
                    ShowStatusForm();
                }
                else if (Main.CurrentProject.Composites.Count == 0)
                {
                    ShowNoDataForm();
                }
                else
                {
                    if(topComboBox.SelectedIndex != 0)
                    {
                        composites = Main.CurrentProject.Composites
                            .OrderByDescending(c => c.ShieldingEfficiency)
                            .Take(pageSize)
                            .ToList();
                    }
                    else composites = Main.CurrentProject.Composites.ToList();
                    foreach(var c in composites)
                    {
                        c.CstResults = DB.GetCompositeResults(c.CompositeId);
                    }
                    FillResultsCombobox();
                    ShowResultsForm();
                }
            }
            else
            {
                ShowSelectProjectForm();
            }
            UpdateMenuState();
        }

        void StatusChangedHandler()
        {
            if(Main.InProcess() != in_process)
            {
                if(in_process)
                {
                    in_process = Main.InProcess();
                    Main.CurrentProject = DB.GetProject(Main.CurrentProject.ProjectId);
                }
                else
                {
                    in_process = Main.InProcess();
                    ProjectChangedHandler();
                }
            }
        }

        void UpdateMenuState()
        {
            if(Main.CurrentProject == null)
            {
                menuStrip1.Items[0].Enabled = false;
                menuStrip1.Items[1].Enabled = false;
                menuStrip1.Items[2].Enabled = false;
            }
            else if(in_process)
            {
                menuStrip1.Items[0].Enabled = false;
                menuStrip1.Items[1].Enabled = true;
                menuStrip1.Items[2].Enabled = false;
            }
            else
            {
                menuStrip1.Items[0].Enabled = true;
                menuStrip1.Items[1].Enabled = true;
                menuStrip1.Items[2].Enabled = true;
            }
        }

        private bool ProjectConfigured()
        {
            if (Main.CurrentProject.LimitsId == null)
            {
                return false;
            }
            if (Main.CurrentProject.GaSettingsId == null)
            {
                return false;
            }
            if (Main.CurrentProject.MatrixMaterialId == null)
            {
                return false;
            }
            if (Main.CurrentProject.FiberMaterialId == null)
            {
                return false;
            }
            return true;
        }

        public delegate void StartDelegate();
        public delegate SimulationStatus SetStatusDelegate(SimulationStatus status);
        public delegate void UpdateStatusForThreadDelegate(SimulationStatus status);

        public void Start()
        {
            if (ProjectConfigured())
            {
                //List<Composite> initialGeneration = new List<Composite>();
                Project currentProject = DB.GetProject(Main.CurrentProject.ProjectId);
                if (currentProject.Composites.Count > 0)
                {
                    DialogResult cont = DialogResult.No;
                    if (currentProject.Composites.Count >= currentProject.GA_Settings.PopulationSize)
                    {
                        cont = MessageBox.Show(
                            "Хотите продолжить с последнего поколения? (При нажатии \"нет\" предыдущие результаты будут удалены)",
                            "Внимание",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly
                         );
                    }
                    if (cont == DialogResult.No)
                    {
                        DB.DeleteProjectResults(currentProject.ProjectId);
                        currentProject.Composites = new List<Composite>();
                    }
                }
                

                Thread gaThread = new Thread(() =>
                {
                    UpdateStatusForThreadDelegate UpdateStatusDelegate = new UpdateStatusForThreadDelegate(UpdateStatusForThread);

                    GeneticAlgorithm ga = new GeneticAlgorithm(
                        currentProject,
                        UpdateStatusDelegate
                    );
                    ga.Start();
                });
                gaThread.Name = "GA Thread";
                gaThread.IsBackground = true;
                gaThread.Start();
            }
            else ProjectConfigError();
        }

        /*void InitializeGeneticAlgorithm()
        {
            
        }*/

        public void UpdateStatusForThread(SimulationStatus status)
        {
            SetStatusDelegate del = new SetStatusDelegate(Main.SetStatus);
            if(this.IsHandleCreated)
                this.BeginInvoke(del, status);
        }

        void ShowNoDataForm()
        {
            if(noDataForm == null)
            {
                CloseAllForms();
                noDataForm = new NoProjectDataForm(new StartDelegate(Start));
                noDataForm.TopLevel = false;
                noDataForm.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(noDataForm);
                noDataForm.Show();
                resultsPanel.Visible = false;
            }
        }

        void CloseNoDataForm()
        {
            if (noDataForm != null)
            {
                mainPanel.Controls.Remove(noDataForm);
                noDataForm = null;
            }
        }

        void ShowSelectProjectForm()
        {
            if (noProjectForm == null)
            {
                CloseAllForms();
                noProjectForm = new NoSelectedProjectForm();
                noProjectForm.TopLevel = false;
                noProjectForm.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(noProjectForm);
                noProjectForm.Show();
                resultsPanel.Visible = false;
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

        void ShowStatusForm()
        {
            if (statusForm == null)
            {
                CloseAllForms();
                statusForm = new SimulationStatusForm();
                statusForm.TopLevel = false;
                statusForm.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(statusForm);
                statusForm.Show();
                resultsPanel.Visible = false;
            }
        }

        void CloseStatusForm()
        {
            if (statusForm != null)
            {
                mainPanel.Controls.Remove(statusForm);
                statusForm = null;
            }
        }

        void CloseAllForms()
        {
            CloseStatusForm();
            CloseSelectProjectForm();
            CloseNoDataForm();
        }

        void ShowResultsForm()
        {
            CloseAllForms();
            resultsPanel.Visible = true;
        }

        void FillResultsCombobox()
        {
            resultComboBox.Items.Clear();
            resultComboBox.Items.Add("Все композиты");
            foreach(var c in composites)
            {
                resultComboBox.Items.Add($"Композит {c.NumberInProject}");
            }
            resultComboBox.SelectedIndex = 0;
        }

        void FillComposite(int row, Composite c)
        {
            resultsDataGridView.Rows.Add();
            resultsDataGridView.Rows[row].Cells[0].Value = c.NumberInProject;
            resultsDataGridView.Rows[row].Cells[1].Value = c.FiberWidth;
            resultsDataGridView.Rows[row].Cells[2].Value = c.FiberThickness;
            resultsDataGridView.Rows[row].Cells[3].Value = c.FiberSpaceBetween;
            resultsDataGridView.Rows[row].Cells[4].Value = c.LayerCount;
            resultsDataGridView.Rows[row].Cells[5].Value = c.ShieldingEfficiency;
            resultsDataGridView.Rows[row].Cells[6].Value = c.Generation;
        }

        void FillCstResults(int col, Composite c)
        {
            resultsDataGridView.Columns.Add($"Column{col + 1}", $"SE{c.NumberInProject}");
            List<CstResult> cstResults = c.CstResults.ToList();

            // костыль на создание строк
            if(cstResults.Count > resultsDataGridView.Rows.Count)
            {
                resultsDataGridView.Rows.Add(c.CstResults.Count - resultsDataGridView.Rows.Count);
            }

            for (int rIndex = 0; rIndex < cstResults.Count; rIndex++)
            {
                resultsDataGridView.Rows[rIndex].Cells[0].Value = cstResults[rIndex].Frequency;
                resultsDataGridView.Rows[rIndex].Cells[col + 1].Value = Math.Round((double)cstResults[rIndex].SE, 3);
            }
        }

        void FillDataGridView()
        {
            resultsDataGridView.Rows.Clear();
            resultsDataGridView.Columns.Clear();

            if (showStructure)
            {
                resultsDataGridView.Columns.Add("Column0", "Композит");
                resultsDataGridView.Columns.Add("Column1", "Ширина волокна");
                resultsDataGridView.Columns.Add("Column2", "Толщина волокна");
                resultsDataGridView.Columns.Add("Column3", "Расстояние между");
                resultsDataGridView.Columns.Add("Column4", "Количество слоев");
                resultsDataGridView.Columns.Add("Column5", "SE");
                resultsDataGridView.Columns.Add("Column6", "Поколение");

                if (resultComboBox.SelectedIndex == 0)
                {
                    for (int i = 0; i < composites.Count; i++) FillComposite(i, composites[i]);
                }
                else FillComposite(0, composites[resultComboBox.SelectedIndex - 1]);
            }
            else
            {
                resultsDataGridView.Columns.Add("Column0", "f (ГГц)");
                if (resultComboBox.SelectedIndex == 0)
                {
                    for (int cIndex = 0; cIndex < composites.Count; cIndex++)
                    {
                        FillCstResults(cIndex, composites[cIndex]);
                    }
                }
                else FillCstResults(0, composites[resultComboBox.SelectedIndex - 1]);
            }

            resultsDataGridView.ClearSelection();
        }

        void FillChart()
        {
            double Xmin = 999999, Xmax = -999999, Ymin = 999999, Ymax = -999999;
            chart1.Series.Clear();
            chart1.Legends.Clear();
            Composite c;
            if (showStructure)
            {
                chart1.Series.Add("SE");
                chart1.Series[0].ChartType = SeriesChartType.Column;
                for (int i = 0; i < composites.Count; i++)
                {
                    c = composites[i];
                    Xmin = Math.Min((double)c.NumberInProject, Xmin);
                    Xmax = Math.Max((double)c.NumberInProject, Xmax);
                    Ymin = Math.Min((double)c.ShieldingEfficiency, Ymin);
                    Ymax = Math.Max((double)c.ShieldingEfficiency, Ymax);
                    chart1.Series[0].Points.AddXY(c.NumberInProject, c.ShieldingEfficiency);
                    chart1.Series[0].Points[i].Color = ColorTranslator.FromHtml(GetColor(c.NumberInProject));
                }

                // мин/макс по осям
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax+1;
                chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(Ymin);
                chart1.ChartAreas[0].AxisY.Maximum = Ymax + 1;

                // цена деления
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisY.Interval = GetInterval(Ymin, Ymax);

                chart1.ChartAreas[0].AxisX.Title = "Номер композита";
                chart1.ChartAreas[0].AxisY.Title = "SE (дБ)";
            }
            else
            {
                string name;
                if(resultComboBox.SelectedIndex == 0)
                {
                    for (int i = 0; i < composites.Count; i++)
                    {
                        c = composites[i];
                        name = "SE" + c.NumberInProject;
                        chart1.Series.Add(name);
                        chart1.Legends.Add(new Legend(name));
                        chart1.Legends[name].DockedToChartArea = chart1.ChartAreas[0].Name;
                        chart1.Series[i].Legend = name;
                        chart1.Series[i].IsVisibleInLegend = true;
                        chart1.Series[i].ChartType = SeriesChartType.Spline;
                        foreach (var r in c.CstResults)
                        {
                            Xmin = Math.Min((double)r.Frequency, Xmin);
                            Xmax = Math.Max((double)r.Frequency, Xmax);
                            Ymin = Math.Min((double)r.SE, Ymin);
                            Ymax = Math.Max((double)r.SE, Ymax);
                            chart1.Series[i].Points.AddXY(r.Frequency, r.SE);
                        }
                    }
                }
                else
                {
                    c = composites[resultComboBox.SelectedIndex - 1];
                    name = "SE" + c.NumberInProject;
                    chart1.Series.Add(name);
                    chart1.Legends.Add(new Legend(name));
                    chart1.Legends[name].DockedToChartArea = chart1.ChartAreas[0].Name;
                    chart1.Series[0].Legend = name;
                    chart1.Series[0].IsVisibleInLegend = true;
                    chart1.Series[0].ChartType = SeriesChartType.Spline;
                    foreach (var r in c.CstResults)
                    {
                        Xmin = Math.Min((double)r.Frequency, Xmin);
                        Xmax = Math.Max((double)r.Frequency, Xmax);
                        Ymin = Math.Min((double)r.SE, Ymin);
                        Ymax = Math.Max((double)r.SE, Ymax);
                        chart1.Series[0].Points.AddXY(r.Frequency, Math.Round((double)r.SE, 3));
                    }
                }
                // мин/макс по осям
                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;
                chart1.ChartAreas[0].AxisY.Minimum = Ymin - 1;
                chart1.ChartAreas[0].AxisY.Maximum = Ymax + 1;

                // цена деления
                chart1.ChartAreas[0].AxisX.Interval = GetInterval(Xmin, Xmax); ;
                chart1.ChartAreas[0].AxisY.Interval = GetInterval(Ymin, Ymax);

                chart1.ChartAreas[0].AxisX.Title = "Частота (ГГц)";
                chart1.ChartAreas[0].AxisY.Title = "SE (дБ)";
            }
        }

        double GetInterval(double min, double max)
        {
            /*if (min == max)
            {
                if (min == 0) return 1;
                return Math.Round((max) / 5, 1);
            }
            return Math.Round((max - min) / 5, 1);*/
            double i = (max != min ? max - min : max);// * 0.50;
            if (i >= 25) return 25;
            if (i >= 10) return 10;
            if (i >= 5) return 5;
            if (i >= 1) return 1;
            if (i >= 0.5) return 0.5;
            if (i >= 0.1) return 0.1;
            if (i >= 0.05) return 0.05;
            return 0.01;
        }

        private void ProjectConfigError()
        {
            MessageBox.Show(
                "Вы настроили не все проектные параметры",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
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
            FillChart();
        }

        private void удалитьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Main.CurrentProject == null) return;
            DialogResult res = MessageBox.Show(
                "Вы действительно хотите этот удалить проект?",
                "Предупреждение",  
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning
            );

            if(res == DialogResult.Yes)
            {
                int id = Main.CurrentProject.ProjectId;
                DB.DeleteProject(id);
                Main.CurrentProject = null;
            }
        }

        private void startToolstrip_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void topComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newPageSize;
            switch(topComboBox.SelectedIndex)
            {
                case 1: newPageSize = 5; break;
                case 2: newPageSize = 10; break;
                case 3: newPageSize = 20; break;
                default: newPageSize = 1000; break;
            };
            if(pageSize != newPageSize)
            {
                pageSize = newPageSize;
                ProjectChangedHandler();
            }
        }
    }
}
