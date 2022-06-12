
namespace CompositeGUI
{
    partial class GeneticAlgorithmForm
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tourneyUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.generationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.populationUpDown = new System.Windows.Forms.NumericUpDown();
            this.layersLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tourneyUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(388, 32);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(31, 28);
            this.deleteButton.TabIndex = 50;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 20);
            this.label10.TabIndex = 49;
            this.label10.Text = "Выберите шаблон:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Новый шаблон",
            "Шаблон 1",
            "Шаблон 2"});
            this.comboBox1.Location = new System.Drawing.Point(12, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(370, 28);
            this.comboBox1.TabIndex = 48;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(301, 289);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(114, 34);
            this.saveButton.TabIndex = 43;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(202, 289);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(92, 34);
            this.cancelButton.TabIndex = 42;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tourneyUpDown
            // 
            this.tourneyUpDown.Location = new System.Drawing.Point(346, 181);
            this.tourneyUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tourneyUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.tourneyUpDown.Name = "tourneyUpDown";
            this.tourneyUpDown.Size = new System.Drawing.Size(73, 27);
            this.tourneyUpDown.TabIndex = 41;
            this.tourneyUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(74, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(266, 23);
            this.label6.TabIndex = 40;
            this.label6.Text = "Размер турнира селекции:";
            // 
            // generationsUpDown
            // 
            this.generationsUpDown.Location = new System.Drawing.Point(346, 136);
            this.generationsUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.generationsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.generationsUpDown.Name = "generationsUpDown";
            this.generationsUpDown.Size = new System.Drawing.Size(73, 27);
            this.generationsUpDown.TabIndex = 36;
            this.generationsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "Максимальное число поколений:";
            // 
            // populationUpDown
            // 
            this.populationUpDown.Location = new System.Drawing.Point(346, 89);
            this.populationUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.populationUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.populationUpDown.Name = "populationUpDown";
            this.populationUpDown.Size = new System.Drawing.Size(73, 27);
            this.populationUpDown.TabIndex = 31;
            this.populationUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // layersLabel
            // 
            this.layersLabel.AutoSize = true;
            this.layersLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layersLabel.Location = new System.Drawing.Point(151, 89);
            this.layersLabel.Name = "layersLabel";
            this.layersLabel.Size = new System.Drawing.Size(189, 23);
            this.layersLabel.TabIndex = 30;
            this.layersLabel.Text = "Размер популяции:";
            // 
            // GeneticAlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 336);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.tourneyUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.generationsUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.populationUpDown);
            this.Controls.Add(this.layersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GeneticAlgorithmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры генетического алгоритма";
            this.Load += new System.EventHandler(this.GeneticAlgorithmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tourneyUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown populationUpDown;
        private System.Windows.Forms.Label layersLabel;
        private System.Windows.Forms.NumericUpDown generationsUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tourneyUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}