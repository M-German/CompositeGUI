
namespace CompositeGUI
{
    partial class ProjectDataForm
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
            this.metalGridComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.matrixLabel = new System.Windows.Forms.Label();
            this.fiberLabel = new System.Windows.Forms.Label();
            this.matrixComboBox = new System.Windows.Forms.ComboBox();
            this.fiberComboBox = new System.Windows.Forms.ComboBox();
            this.freqLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.freqFromLabel = new System.Windows.Forms.Label();
            this.freqToLabel = new System.Windows.Forms.Label();
            this.fiberButton = new System.Windows.Forms.Button();
            this.matrixButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // metalGridComboBox
            // 
            this.metalGridComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.metalGridComboBox.Items.AddRange(new object[] {
            "Да",
            "Нет"});
            this.metalGridComboBox.Location = new System.Drawing.Point(272, 92);
            this.metalGridComboBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.metalGridComboBox.Name = "metalGridComboBox";
            this.metalGridComboBox.Size = new System.Drawing.Size(215, 28);
            this.metalGridComboBox.TabIndex = 12;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(405, 327);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(114, 34);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(306, 327);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(92, 34);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Металлическая сетка:";
            // 
            // matrixLabel
            // 
            this.matrixLabel.AutoSize = true;
            this.matrixLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matrixLabel.Location = new System.Drawing.Point(33, 149);
            this.matrixLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.matrixLabel.Name = "matrixLabel";
            this.matrixLabel.Size = new System.Drawing.Size(202, 23);
            this.matrixLabel.TabIndex = 13;
            this.matrixLabel.Text = "Материал матрицы:";
            // 
            // fiberLabel
            // 
            this.fiberLabel.AutoSize = true;
            this.fiberLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiberLabel.Location = new System.Drawing.Point(39, 206);
            this.fiberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fiberLabel.Name = "fiberLabel";
            this.fiberLabel.Size = new System.Drawing.Size(197, 23);
            this.fiberLabel.TabIndex = 14;
            this.fiberLabel.Text = "Материал волокна:";
            // 
            // matrixComboBox
            // 
            this.matrixComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matrixComboBox.Items.AddRange(new object[] {
            "Нет материала"});
            this.matrixComboBox.Location = new System.Drawing.Point(272, 147);
            this.matrixComboBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.matrixComboBox.Name = "matrixComboBox";
            this.matrixComboBox.Size = new System.Drawing.Size(215, 28);
            this.matrixComboBox.TabIndex = 15;
            // 
            // fiberComboBox
            // 
            this.fiberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fiberComboBox.Items.AddRange(new object[] {
            "Нет материала"});
            this.fiberComboBox.Location = new System.Drawing.Point(272, 206);
            this.fiberComboBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.fiberComboBox.Name = "fiberComboBox";
            this.fiberComboBox.Size = new System.Drawing.Size(215, 28);
            this.fiberComboBox.TabIndex = 16;
            // 
            // freqLabel
            // 
            this.freqLabel.AutoSize = true;
            this.freqLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freqLabel.Location = new System.Drawing.Point(96, 257);
            this.freqLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.freqLabel.Name = "freqLabel";
            this.freqLabel.Size = new System.Drawing.Size(140, 23);
            this.freqLabel.TabIndex = 19;
            this.freqLabel.Text = "Частота (ГГц):";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(300, 257);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(72, 27);
            this.numericUpDown1.TabIndex = 21;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown2.Location = new System.Drawing.Point(413, 257);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(72, 27);
            this.numericUpDown2.TabIndex = 22;
            // 
            // freqFromLabel
            // 
            this.freqFromLabel.AutoSize = true;
            this.freqFromLabel.Location = new System.Drawing.Point(269, 258);
            this.freqFromLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.freqFromLabel.Name = "freqFromLabel";
            this.freqFromLabel.Size = new System.Drawing.Size(26, 20);
            this.freqFromLabel.TabIndex = 23;
            this.freqFromLabel.Text = "от";
            // 
            // freqToLabel
            // 
            this.freqToLabel.AutoSize = true;
            this.freqToLabel.Location = new System.Drawing.Point(379, 258);
            this.freqToLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.freqToLabel.Name = "freqToLabel";
            this.freqToLabel.Size = new System.Drawing.Size(29, 20);
            this.freqToLabel.TabIndex = 24;
            this.freqToLabel.Text = "до";
            // 
            // fiberButton
            // 
            this.fiberButton.BackgroundImage = global::CompositeGUI.Properties.Resources.gear;
            this.fiberButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fiberButton.Location = new System.Drawing.Point(493, 206);
            this.fiberButton.Margin = new System.Windows.Forms.Padding(0);
            this.fiberButton.Name = "fiberButton";
            this.fiberButton.Size = new System.Drawing.Size(28, 28);
            this.fiberButton.TabIndex = 18;
            this.fiberButton.UseVisualStyleBackColor = true;
            this.fiberButton.Click += new System.EventHandler(this.fiberButton_Click);
            // 
            // matrixButton
            // 
            this.matrixButton.BackgroundImage = global::CompositeGUI.Properties.Resources.gear;
            this.matrixButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.matrixButton.Location = new System.Drawing.Point(493, 147);
            this.matrixButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.matrixButton.Name = "matrixButton";
            this.matrixButton.Size = new System.Drawing.Size(28, 28);
            this.matrixButton.TabIndex = 17;
            this.matrixButton.UseVisualStyleBackColor = true;
            this.matrixButton.Click += new System.EventHandler(this.matrixButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(272, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(213, 27);
            this.nameTextBox.TabIndex = 25;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(33, 44);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(193, 23);
            this.nameLabel.TabIndex = 26;
            this.nameLabel.Text = "Название проекта:";
            // 
            // ProjectDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 374);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.freqToLabel);
            this.Controls.Add(this.freqFromLabel);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.freqLabel);
            this.Controls.Add(this.fiberButton);
            this.Controls.Add(this.matrixButton);
            this.Controls.Add(this.fiberComboBox);
            this.Controls.Add(this.matrixComboBox);
            this.Controls.Add(this.fiberLabel);
            this.Controls.Add(this.matrixLabel);
            this.Controls.Add(this.metalGridComboBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.Name = "ProjectDataForm";
            this.Text = "Основные проектные параметры";
            this.Load += new System.EventHandler(this.AdvancedOptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox metalGridComboBox;
        private System.Windows.Forms.Label matrixLabel;
        private System.Windows.Forms.Label fiberLabel;
        private System.Windows.Forms.ComboBox matrixComboBox;
        private System.Windows.Forms.ComboBox fiberComboBox;
        private System.Windows.Forms.Button matrixButton;
        private System.Windows.Forms.Button fiberButton;
        private System.Windows.Forms.Label freqLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label freqFromLabel;
        private System.Windows.Forms.Label freqToLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
    }
}