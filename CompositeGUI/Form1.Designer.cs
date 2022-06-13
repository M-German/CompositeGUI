
namespace CompositeGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.проектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectDataToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.limitsToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.выполнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.topComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.resultComboBox = new System.Windows.Forms.ComboBox();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.mainPanel.SuspendLayout();
            this.resultsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.resultsPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1731, 694);
            this.mainPanel.TabIndex = 9;
            this.mainPanel.Tag = "";
            // 
            // resultsPanel
            // 
            this.resultsPanel.Controls.Add(this.tableLayoutPanel1);
            this.resultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsPanel.Location = new System.Drawing.Point(0, 0);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(1731, 694);
            this.resultsPanel.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Gilroy-Regular", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проектToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.выполнитьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1731, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // проектToolStripMenuItem
            // 
            this.проектToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.создатьToolStripMenuItem,
            this.openProjectToolstrip,
            this.удалитьПроектToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.проектToolStripMenuItem.Name = "проектToolStripMenuItem";
            this.проектToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.проектToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.создатьToolStripMenuItem.Text = "Создать проект";
            // 
            // openProjectToolstrip
            // 
            this.openProjectToolstrip.Name = "openProjectToolstrip";
            this.openProjectToolstrip.Size = new System.Drawing.Size(219, 26);
            this.openProjectToolstrip.Text = "Открыть проект";
            // 
            // удалитьПроектToolStripMenuItem
            // 
            this.удалитьПроектToolStripMenuItem.Name = "удалитьПроектToolStripMenuItem";
            this.удалитьПроектToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.удалитьПроектToolStripMenuItem.Text = "Удалить проект";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectDataToolstrip,
            this.limitsToolstrip,
            this.algorithmToolstrip});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.dataToolStripMenuItem.Text = "Проектные данные";
            // 
            // projectDataToolstrip
            // 
            this.projectDataToolstrip.Name = "projectDataToolstrip";
            this.projectDataToolstrip.Size = new System.Drawing.Size(397, 26);
            this.projectDataToolstrip.Text = "Основные проектные параметры";
            // 
            // limitsToolstrip
            // 
            this.limitsToolstrip.Name = "limitsToolstrip";
            this.limitsToolstrip.Size = new System.Drawing.Size(397, 26);
            this.limitsToolstrip.Text = "Структурные ограничения";
            // 
            // algorithmToolstrip
            // 
            this.algorithmToolstrip.Name = "algorithmToolstrip";
            this.algorithmToolstrip.Size = new System.Drawing.Size(397, 26);
            this.algorithmToolstrip.Text = "Параметры генетического алгоритма";
            // 
            // выполнитьToolStripMenuItem
            // 
            this.выполнитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolstrip});
            this.выполнитьToolStripMenuItem.Name = "выполнитьToolStripMenuItem";
            this.выполнитьToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.выполнитьToolStripMenuItem.Text = "Выполнить";
            // 
            // startToolstrip
            // 
            this.startToolstrip.Name = "startToolstrip";
            this.startToolstrip.Size = new System.Drawing.Size(317, 26);
            this.startToolstrip.Text = "Запуск проектирования КМ";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem1});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.оПрограммеToolStripMenuItem.Text = "Справка";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem1
            // 
            this.оПрограммеToolStripMenuItem1.Name = "оПрограммеToolStripMenuItem1";
            this.оПрограммеToolStripMenuItem1.Size = new System.Drawing.Size(202, 26);
            this.оПрограммеToolStripMenuItem1.Text = "О программе";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.resultsDataGridView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1731, 694);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 53);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(946, 638);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.topComboBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.resultComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(955, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 44);
            this.panel1.TabIndex = 6;
            // 
            // topComboBox
            // 
            this.topComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topComboBox.Items.AddRange(new object[] {
            "Все",
            "Топ 5",
            "Топ 10",
            "Топ 20"});
            this.topComboBox.Location = new System.Drawing.Point(3, 14);
            this.topComboBox.Name = "topComboBox";
            this.topComboBox.Size = new System.Drawing.Size(108, 28);
            this.topComboBox.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Показать структуру";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Отображается:";
            // 
            // resultComboBox
            // 
            this.resultComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resultComboBox.Location = new System.Drawing.Point(317, 13);
            this.resultComboBox.Name = "resultComboBox";
            this.resultComboBox.Size = new System.Drawing.Size(170, 28);
            this.resultComboBox.TabIndex = 7;
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.AllowUserToAddRows = false;
            this.resultsDataGridView.AllowUserToDeleteRows = false;
            this.resultsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsDataGridView.Location = new System.Drawing.Point(955, 53);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.RowHeadersWidth = 51;
            this.resultsDataGridView.RowTemplate.Height = 24;
            this.resultsDataGridView.Size = new System.Drawing.Size(773, 638);
            this.resultsDataGridView.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1731, 722);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.resultsPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel resultsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem проектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolstrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьПроектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectDataToolstrip;
        private System.Windows.Forms.ToolStripMenuItem limitsToolstrip;
        private System.Windows.Forms.ToolStripMenuItem algorithmToolstrip;
        private System.Windows.Forms.ToolStripMenuItem выполнитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolstrip;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox topComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox resultComboBox;
        private System.Windows.Forms.DataGridView resultsDataGridView;
    }
}