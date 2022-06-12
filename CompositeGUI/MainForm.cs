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

namespace CompositeGUI
{
    public partial class MainForm : Based
    {
        bool showStructure = true;
        List<Composite> composites;

        NoProjectDataForm noDataForm;
        NoSelectedProjectForm noProjectForm;
        SimulationStatusForm statusForm;

        static string[] ColourValues = new string[] {
            "d11141", "00b159", "00aedb", "f37735", "ffc425", "d9534f", "000000",
            "5bc0de", "5cb85c", "428bca", "808000", "800080", "008080", "808080",
            "C00000", "00C000", "0000C0", "C0C000", "C000C0", "00C0C0", "C0C0C0",
            "400000", "004000", "000040", "404000", "400040", "004040", "404040",
            "200000", "002000", "000020", "202000", "200020", "002020", "202020",
            "600000", "006000", "000060", "606000", "600060", "006060", "606060",
            "A00000", "00A000", "0000A0", "A0A000", "A000A0", "00A0A0", "A0A0A0",
            "E00000", "00E000", "0000E0", "E0E000", "E000E0", "00E0E0", "E0E0E0",
        };

        string GetColor(int i)
        {
            if(i >= ColourValues.Length) {
                i -= i / ColourValues.Length * i;
            }
            return "#"+ColourValues[i];
        }

        public MainForm()
        {
            InitializeComponent();

            //db = new DB();
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            //resultComboBox.SelectedIndex = 0;
            UpdateMenuState();
            ShowSelectProjectForm();
            Main.ProjectList = DB.GetProjects();
            Main.ProjectChanged += ProjectChangedHandler;
            Main.SimulationStatusChanged += ProjectChangedHandler;
            //Main.SimulationStatusChanged += StatusChangedHandler;
            //заглушка
            //Main.CurrentProject = Main.ProjectList[0];
        }

        void ProjectChangedHandler()
        {
            if (Main.CurrentProject != null)
            {
                if (Main.InProcess())
                {
                    ShowStatusForm();
                }
                else if (Main.CurrentProject.Composites.Count == 0)
                {
                    ShowNoDataForm();
                }
                else
                {
                    composites = Main.CurrentProject.Composites.ToList();
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

        /*void StatusChangedHandler()
        {

        }*/

        void UpdateMenuState()
        {
            if(Main.CurrentProject == null)
            {
                toolStrip1.Visible = false;
                menuStrip1.Items[0].Enabled = false;
                menuStrip1.Items[1].Enabled = false;
                menuStrip1.Items[2].Enabled = false;
            }
            else if(Main.InProcess())
            {
                toolStrip1.Visible = true;
                menuStrip1.Items[0].Enabled = false;
                menuStrip1.Items[1].Enabled = true;
                menuStrip1.Items[2].Enabled = false;
            }
            else
            {
                toolStrip1.Visible = true;
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
                Thread gaThread = new Thread(InitializeGeneticAlgorithm);
                gaThread.Name = "GA Thread";
                gaThread.IsBackground = true;
                gaThread.Start();
            }
            else ProjectConfigError();
        }

        void InitializeGeneticAlgorithm()
        {
            UpdateStatusForThreadDelegate UpdateStatusDelegate = new UpdateStatusForThreadDelegate(UpdateStatusForThread);

            GeneticAlgorithm ga = new GeneticAlgorithm(
                DB.GetProject(Main.CurrentProject.ProjectId),
                UpdateStatusDelegate
            );
            ga.Start();
        }

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
                resultComboBox.Items.Add($"Композит {c.CompositeId}");
            }
            resultComboBox.SelectedIndex = 0;
        }

        void FillComposite(int row, Composite c)
        {
            resultsDataGridView.Rows.Add();
            resultsDataGridView.Rows[row].Cells[0].Value = c.CompositeId;
            resultsDataGridView.Rows[row].Cells[1].Value = c.FiberWidth;
            resultsDataGridView.Rows[row].Cells[2].Value = c.FiberThickness;
            resultsDataGridView.Rows[row].Cells[3].Value = c.FiberSpaceBetween;
            resultsDataGridView.Rows[row].Cells[4].Value = c.LayerCount;
            resultsDataGridView.Rows[row].Cells[5].Value = c.ShieldingEfficiency;
            resultsDataGridView.Rows[row].Cells[6].Value = c.Generation;
        }

        void FillCstResults(int col, Composite c)
        {
            resultsDataGridView.Columns.Add($"Column{col + 1}", $"SE{c.CompositeId}");
            List<CstResult> cstResults = c.CstResults.ToList();

            // костыль на создание строк
            if(cstResults.Count > resultsDataGridView.Rows.Count)
            {
                resultsDataGridView.Rows.Add(c.CstResults.Count - resultsDataGridView.Rows.Count);
            }

            for (int rIndex = 0; rIndex < cstResults.Count; rIndex++)
            {
                resultsDataGridView.Rows[rIndex].Cells[0].Value = cstResults[rIndex].Frequency;
                resultsDataGridView.Rows[rIndex].Cells[col + 1].Value = cstResults[rIndex].SE;
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
            chart1.Series.Clear();
            Composite c;
            if (showStructure)
            {
                chart1.Series.Add("SE");
                chart1.Legends.Clear();
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                for (int i = 0; i < composites.Count; i++)
                {
                    c = composites[i];
                    chart1.Series[0].Points.AddXY($"SE{c.CompositeId}", c.ShieldingEfficiency);
                    chart1.Series[0].Points[i].Color = ColorTranslator.FromHtml(GetColor(i));
                }
            }
            else
            {
                double Xmin = 999999, Xmax = -999999, Ymin = 999999, Ymax = -999999;
                if(resultComboBox.SelectedIndex == 0)
                {
                    for (int i = 0; i < composites.Count; i++)
                    {
                        c = composites[i];
                        chart1.Series.Add("SE" + c.CompositeId);
                        chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
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
                    chart1.Series.Add("SE" + c.CompositeId);
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    foreach (var r in c.CstResults)
                    {
                        Xmin = Math.Min((double)r.Frequency, Xmin);
                        Xmax = Math.Max((double)r.Frequency, Xmax);
                        Ymin = Math.Min((double)r.SE, Ymin);
                        Ymax = Math.Max((double)r.SE, Ymax);
                        chart1.Series[0].Points.AddXY(r.Frequency, r.SE);
                    }
                }
                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;

                chart1.ChartAreas[0].AxisY.Minimum = Ymin;
                chart1.ChartAreas[0].AxisY.Maximum = Ymax + 1;
            }
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
            MessageBox.Show(
                "Вы действительно хотите этот удалить проект?",
                "Предупреждение",  
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning
            );
        }

        private void startToolstrip_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
