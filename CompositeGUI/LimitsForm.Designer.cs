
namespace CompositeGUI
{
    partial class LimitsForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.freqToLabel = new System.Windows.Forms.Label();
            this.freqFromLabel = new System.Windows.Forms.Label();
            this.maxLayersUpDown = new System.Windows.Forms.NumericUpDown();
            this.minLayersUpDown = new System.Windows.Forms.NumericUpDown();
            this.layersLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.minWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxThickUpDown = new System.Windows.Forms.NumericUpDown();
            this.minThickUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maxSpaceUpDown = new System.Windows.Forms.NumericUpDown();
            this.minSpaceUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maxLayersUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minLayersUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxThickUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minThickUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpaceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSpaceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(343, 358);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(114, 34);
            this.saveButton.TabIndex = 24;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(244, 358);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 34);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // freqToLabel
            // 
            this.freqToLabel.AutoSize = true;
            this.freqToLabel.Location = new System.Drawing.Point(353, 107);
            this.freqToLabel.Name = "freqToLabel";
            this.freqToLabel.Size = new System.Drawing.Size(29, 20);
            this.freqToLabel.TabIndex = 29;
            this.freqToLabel.Text = "до";
            // 
            // freqFromLabel
            // 
            this.freqFromLabel.AutoSize = true;
            this.freqFromLabel.Location = new System.Drawing.Point(242, 107);
            this.freqFromLabel.Name = "freqFromLabel";
            this.freqFromLabel.Size = new System.Drawing.Size(26, 20);
            this.freqFromLabel.TabIndex = 28;
            this.freqFromLabel.Text = "от";
            // 
            // maxLayersUpDown
            // 
            this.maxLayersUpDown.Location = new System.Drawing.Point(388, 105);
            this.maxLayersUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxLayersUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxLayersUpDown.Name = "maxLayersUpDown";
            this.maxLayersUpDown.Size = new System.Drawing.Size(73, 27);
            this.maxLayersUpDown.TabIndex = 27;
            this.maxLayersUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // minLayersUpDown
            // 
            this.minLayersUpDown.Location = new System.Drawing.Point(274, 105);
            this.minLayersUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.minLayersUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minLayersUpDown.Name = "minLayersUpDown";
            this.minLayersUpDown.Size = new System.Drawing.Size(73, 27);
            this.minLayersUpDown.TabIndex = 26;
            this.minLayersUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // layersLabel
            // 
            this.layersLabel.AutoSize = true;
            this.layersLabel.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layersLabel.Location = new System.Drawing.Point(49, 105);
            this.layersLabel.Name = "layersLabel";
            this.layersLabel.Size = new System.Drawing.Size(186, 23);
            this.layersLabel.TabIndex = 25;
            this.layersLabel.Text = "Количество слоев:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "до";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "от";
            // 
            // maxWidthUpDown
            // 
            this.maxWidthUpDown.DecimalPlaces = 2;
            this.maxWidthUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxWidthUpDown.Location = new System.Drawing.Point(388, 160);
            this.maxWidthUpDown.Name = "maxWidthUpDown";
            this.maxWidthUpDown.Size = new System.Drawing.Size(73, 27);
            this.maxWidthUpDown.TabIndex = 32;
            // 
            // minWidthUpDown
            // 
            this.minWidthUpDown.DecimalPlaces = 2;
            this.minWidthUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.minWidthUpDown.Location = new System.Drawing.Point(274, 160);
            this.minWidthUpDown.Name = "minWidthUpDown";
            this.minWidthUpDown.Size = new System.Drawing.Size(73, 27);
            this.minWidthUpDown.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Ширина волокна (мм):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "до";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "от";
            // 
            // maxThickUpDown
            // 
            this.maxThickUpDown.DecimalPlaces = 2;
            this.maxThickUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxThickUpDown.Location = new System.Drawing.Point(388, 215);
            this.maxThickUpDown.Name = "maxThickUpDown";
            this.maxThickUpDown.Size = new System.Drawing.Size(73, 27);
            this.maxThickUpDown.TabIndex = 37;
            // 
            // minThickUpDown
            // 
            this.minThickUpDown.DecimalPlaces = 2;
            this.minThickUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.minThickUpDown.Location = new System.Drawing.Point(274, 215);
            this.minThickUpDown.Name = "minThickUpDown";
            this.minThickUpDown.Size = new System.Drawing.Size(73, 27);
            this.minThickUpDown.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 23);
            this.label6.TabIndex = 35;
            this.label6.Text = "Толщина волокна (мм):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "до";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(242, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "от";
            // 
            // maxSpaceUpDown
            // 
            this.maxSpaceUpDown.DecimalPlaces = 2;
            this.maxSpaceUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxSpaceUpDown.Location = new System.Drawing.Point(388, 275);
            this.maxSpaceUpDown.Name = "maxSpaceUpDown";
            this.maxSpaceUpDown.Size = new System.Drawing.Size(73, 27);
            this.maxSpaceUpDown.TabIndex = 42;
            // 
            // minSpaceUpDown
            // 
            this.minSpaceUpDown.DecimalPlaces = 2;
            this.minSpaceUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.minSpaceUpDown.Location = new System.Drawing.Point(274, 275);
            this.minSpaceUpDown.Name = "minSpaceUpDown";
            this.minSpaceUpDown.Size = new System.Drawing.Size(73, 27);
            this.minSpaceUpDown.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(51, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 46);
            this.label9.TabIndex = 40;
            this.label9.Text = "Расстояние между\r\n волокнами (мм):";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 20);
            this.label10.TabIndex = 46;
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
            this.comboBox1.Location = new System.Drawing.Point(12, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(407, 28);
            this.comboBox1.TabIndex = 45;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(430, 40);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(31, 28);
            this.deleteButton.TabIndex = 47;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // LimitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 404);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.maxSpaceUpDown);
            this.Controls.Add(this.minSpaceUpDown);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxThickUpDown);
            this.Controls.Add(this.minThickUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxWidthUpDown);
            this.Controls.Add(this.minWidthUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.freqToLabel);
            this.Controls.Add(this.freqFromLabel);
            this.Controls.Add(this.maxLayersUpDown);
            this.Controls.Add(this.minLayersUpDown);
            this.Controls.Add(this.layersLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LimitsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ограничения";
            this.Load += new System.EventHandler(this.FiberStructure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxLayersUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minLayersUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxThickUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minThickUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpaceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSpaceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label freqToLabel;
        private System.Windows.Forms.Label freqFromLabel;
        private System.Windows.Forms.NumericUpDown maxLayersUpDown;
        private System.Windows.Forms.NumericUpDown minLayersUpDown;
        private System.Windows.Forms.Label layersLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxWidthUpDown;
        private System.Windows.Forms.NumericUpDown minWidthUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown maxThickUpDown;
        private System.Windows.Forms.NumericUpDown minThickUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown maxSpaceUpDown;
        private System.Windows.Forms.NumericUpDown minSpaceUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button deleteButton;
    }
}