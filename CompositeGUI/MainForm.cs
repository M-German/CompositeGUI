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
    public partial class MainForm : Based
    {
        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 720);
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

        private void MainProcedureError()
        {
            MessageBox.Show(
                "Ошибка синтеза. Перезапустить проектную процедуру?",
                "Ошибка",
                MessageBoxButtons.YesNo,
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            //DBConnectionError();
            //FileAccessError();
            //InvalidDataError();
            MainProcedureError();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fiberMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMaterialForm form = new SelectMaterialForm();
            form.ShowDialog();
        }

        private void fiberStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiberStructureForm fs = new FiberStructureForm();
            fs.ShowDialog();
        }

        private void dischargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectStaticDischargeForm sdf = new SelectStaticDischargeForm();
            sdf.ShowDialog();
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedOptionsForm aof = new AdvancedOptionsForm();
            aof.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm abf = new AboutForm();
            abf.ShowDialog();
        }

        private void fiberEdit_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateProjectForm form = new CreateProjectForm();
            form.ShowDialog();
        }

        private void выбратьШаблонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectReportTemplateForm form = new SelectReportTemplateForm();
            form.ShowDialog();
        }

        private void создатьШаблонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateReportTemplateForm form = new CreateReportTemplateForm();
            form.ShowDialog();
        }

        private void createTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateReportTemplateForm form = new CreateReportTemplateForm();
            form.ShowDialog();
        }

    }
}
