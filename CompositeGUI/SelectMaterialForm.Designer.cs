
namespace CompositeGUI
{
    partial class SelectMaterialForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.densityLabel = new System.Windows.Forms.Label();
            this.densityUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.magUpDown = new System.Windows.Forms.NumericUpDown();
            this.elecLabel = new System.Windows.Forms.Label();
            this.thermalUpDown = new System.Windows.Forms.NumericUpDown();
            this.thermalLabel = new System.Windows.Forms.Label();
            this.elecUpDown = new System.Windows.Forms.NumericUpDown();
            this.magLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.densityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermalUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elecUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.densityLabel);
            this.panel1.Controls.Add(this.densityUpDown);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.magUpDown);
            this.panel1.Controls.Add(this.elecLabel);
            this.panel1.Controls.Add(this.thermalUpDown);
            this.panel1.Controls.Add(this.thermalLabel);
            this.panel1.Controls.Add(this.elecUpDown);
            this.panel1.Controls.Add(this.magLabel);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Location = new System.Drawing.Point(12, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 319);
            this.panel1.TabIndex = 32;
            // 
            // densityLabel
            // 
            this.densityLabel.AutoSize = true;
            this.densityLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.densityLabel.Location = new System.Drawing.Point(3, 215);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(112, 23);
            this.densityLabel.TabIndex = 30;
            this.densityLabel.Text = "Плотность:";
            // 
            // densityUpDown
            // 
            this.densityUpDown.DecimalPlaces = 2;
            this.densityUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.densityUpDown.Location = new System.Drawing.Point(305, 215);
            this.densityUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.densityUpDown.Name = "densityUpDown";
            this.densityUpDown.Size = new System.Drawing.Size(254, 27);
            this.densityUpDown.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // magUpDown
            // 
            this.magUpDown.DecimalPlaces = 2;
            this.magUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.magUpDown.Location = new System.Drawing.Point(304, 164);
            this.magUpDown.Name = "magUpDown";
            this.magUpDown.Size = new System.Drawing.Size(254, 27);
            this.magUpDown.TabIndex = 29;
            // 
            // elecLabel
            // 
            this.elecLabel.AutoSize = true;
            this.elecLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elecLabel.Location = new System.Drawing.Point(3, 74);
            this.elecLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.elecLabel.Name = "elecLabel";
            this.elecLabel.Size = new System.Drawing.Size(219, 23);
            this.elecLabel.TabIndex = 21;
            this.elecLabel.Text = "Электропроводность:";
            // 
            // thermalUpDown
            // 
            this.thermalUpDown.DecimalPlaces = 2;
            this.thermalUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.thermalUpDown.Location = new System.Drawing.Point(304, 120);
            this.thermalUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.thermalUpDown.Name = "thermalUpDown";
            this.thermalUpDown.Size = new System.Drawing.Size(254, 27);
            this.thermalUpDown.TabIndex = 28;
            // 
            // thermalLabel
            // 
            this.thermalLabel.AutoSize = true;
            this.thermalLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thermalLabel.Location = new System.Drawing.Point(3, 120);
            this.thermalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thermalLabel.Name = "thermalLabel";
            this.thermalLabel.Size = new System.Drawing.Size(192, 23);
            this.thermalLabel.TabIndex = 22;
            this.thermalLabel.Text = "Теплопроводность:";
            // 
            // elecUpDown
            // 
            this.elecUpDown.DecimalPlaces = 2;
            this.elecUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.elecUpDown.Location = new System.Drawing.Point(304, 74);
            this.elecUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.elecUpDown.Name = "elecUpDown";
            this.elecUpDown.Size = new System.Drawing.Size(254, 27);
            this.elecUpDown.TabIndex = 27;
            // 
            // magLabel
            // 
            this.magLabel.AutoSize = true;
            this.magLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magLabel.Location = new System.Drawing.Point(2, 164);
            this.magLabel.Name = "magLabel";
            this.magLabel.Size = new System.Drawing.Size(271, 23);
            this.magLabel.TabIndex = 23;
            this.magLabel.Text = "Магнитная проницаемость:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(304, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(253, 27);
            this.nameTextBox.TabIndex = 26;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(3, 27);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(108, 23);
            this.nameLabel.TabIndex = 25;
            this.nameLabel.Text = "Название:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите метариал";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Новый материал",
            "Графит",
            "Эпоксидная смола"});
            this.comboBox1.Location = new System.Drawing.Point(12, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(520, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(538, 47);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(31, 29);
            this.deleteButton.TabIndex = 48;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // SelectMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 405);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "SelectMaterialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор материала волокна";
            this.Load += new System.EventHandler(this.SelectMaterialForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.densityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermalUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elecUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label magLabel;
        private System.Windows.Forms.Label thermalLabel;
        private System.Windows.Forms.Label elecLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.NumericUpDown elecUpDown;
        private System.Windows.Forms.NumericUpDown thermalUpDown;
        private System.Windows.Forms.NumericUpDown magUpDown;
        private System.Windows.Forms.NumericUpDown densityUpDown;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button deleteButton;
    }
}