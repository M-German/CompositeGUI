
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.magLabel = new System.Windows.Forms.Label();
            this.thermalLabel = new System.Windows.Forms.Label();
            this.elecLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.elecUpDown = new System.Windows.Forms.NumericUpDown();
            this.thermalUpDown = new System.Windows.Forms.NumericUpDown();
            this.magUpDown = new System.Windows.Forms.NumericUpDown();
            this.densityUpDown = new System.Windows.Forms.NumericUpDown();
            this.densityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.elecUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermalUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityUpDown)).BeginInit();
            this.SuspendLayout();
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
            this.comboBox1.Size = new System.Drawing.Size(555, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(454, 334);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(12, 91);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(108, 23);
            this.nameLabel.TabIndex = 25;
            this.nameLabel.Text = "Название:";
            // 
            // magLabel
            // 
            this.magLabel.AutoSize = true;
            this.magLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magLabel.Location = new System.Drawing.Point(11, 228);
            this.magLabel.Name = "magLabel";
            this.magLabel.Size = new System.Drawing.Size(257, 23);
            this.magLabel.TabIndex = 23;
            this.magLabel.Text = "Магнитная проводимость:";
            // 
            // thermalLabel
            // 
            this.thermalLabel.AutoSize = true;
            this.thermalLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thermalLabel.Location = new System.Drawing.Point(12, 184);
            this.thermalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thermalLabel.Name = "thermalLabel";
            this.thermalLabel.Size = new System.Drawing.Size(192, 23);
            this.thermalLabel.TabIndex = 22;
            this.thermalLabel.Text = "Теплопроводность:";
            // 
            // elecLabel
            // 
            this.elecLabel.AutoSize = true;
            this.elecLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elecLabel.Location = new System.Drawing.Point(12, 138);
            this.elecLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.elecLabel.Name = "elecLabel";
            this.elecLabel.Size = new System.Drawing.Size(219, 23);
            this.elecLabel.TabIndex = 21;
            this.elecLabel.Text = "Электропроводность:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(313, 90);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(253, 27);
            this.nameTextBox.TabIndex = 26;
            // 
            // elecUpDown
            // 
            this.elecUpDown.Location = new System.Drawing.Point(313, 138);
            this.elecUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.elecUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.elecUpDown.Name = "elecUpDown";
            this.elecUpDown.Size = new System.Drawing.Size(254, 27);
            this.elecUpDown.TabIndex = 27;
            // 
            // thermalUpDown
            // 
            this.thermalUpDown.Location = new System.Drawing.Point(313, 184);
            this.thermalUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.thermalUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.thermalUpDown.Name = "thermalUpDown";
            this.thermalUpDown.Size = new System.Drawing.Size(254, 27);
            this.thermalUpDown.TabIndex = 28;
            // 
            // magUpDown
            // 
            this.magUpDown.Location = new System.Drawing.Point(313, 228);
            this.magUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.magUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.magUpDown.Name = "magUpDown";
            this.magUpDown.Size = new System.Drawing.Size(254, 27);
            this.magUpDown.TabIndex = 29;
            // 
            // densityUpDown
            // 
            this.densityUpDown.Location = new System.Drawing.Point(314, 279);
            this.densityUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.densityUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.densityUpDown.Name = "densityUpDown";
            this.densityUpDown.Size = new System.Drawing.Size(254, 27);
            this.densityUpDown.TabIndex = 31;
            // 
            // densityLabel
            // 
            this.densityLabel.AutoSize = true;
            this.densityLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.densityLabel.Location = new System.Drawing.Point(12, 279);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(112, 23);
            this.densityLabel.TabIndex = 30;
            this.densityLabel.Text = "Плотность:";
            // 
            // SelectMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 381);
            this.Controls.Add(this.densityUpDown);
            this.Controls.Add(this.densityLabel);
            this.Controls.Add(this.magUpDown);
            this.Controls.Add(this.thermalUpDown);
            this.Controls.Add(this.elecUpDown);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.magLabel);
            this.Controls.Add(this.thermalLabel);
            this.Controls.Add(this.elecLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "SelectMaterialForm";
            this.Text = "Выбор материала волокна";
            ((System.ComponentModel.ISupportInitialize)(this.elecUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermalUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityUpDown)).EndInit();
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
    }
}