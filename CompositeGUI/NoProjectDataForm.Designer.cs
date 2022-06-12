
namespace CompositeGUI
{
    partial class NoProjectDataForm
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
            this.algorithmButton = new System.Windows.Forms.Button();
            this.projectParamsButton = new System.Windows.Forms.Button();
            this.limitsButton = new System.Windows.Forms.Button();
            this.noDataLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // algorithmButton
            // 
            this.algorithmButton.Location = new System.Drawing.Point(457, 120);
            this.algorithmButton.Name = "algorithmButton";
            this.algorithmButton.Size = new System.Drawing.Size(143, 49);
            this.algorithmButton.TabIndex = 2;
            this.algorithmButton.Text = "Параметры ГА";
            this.algorithmButton.UseVisualStyleBackColor = true;
            this.algorithmButton.Click += new System.EventHandler(this.algorithmButton_Click);
            // 
            // projectParamsButton
            // 
            this.projectParamsButton.Location = new System.Drawing.Point(65, 120);
            this.projectParamsButton.Name = "projectParamsButton";
            this.projectParamsButton.Size = new System.Drawing.Size(143, 49);
            this.projectParamsButton.TabIndex = 3;
            this.projectParamsButton.Text = "Проектные параметры";
            this.projectParamsButton.UseVisualStyleBackColor = true;
            this.projectParamsButton.Click += new System.EventHandler(this.projectParamsButton_Click);
            // 
            // limitsButton
            // 
            this.limitsButton.Location = new System.Drawing.Point(264, 120);
            this.limitsButton.Name = "limitsButton";
            this.limitsButton.Size = new System.Drawing.Size(143, 49);
            this.limitsButton.TabIndex = 1;
            this.limitsButton.Text = "Ограничения";
            this.limitsButton.UseVisualStyleBackColor = true;
            this.limitsButton.Click += new System.EventHandler(this.limitsButton_Click);
            // 
            // noDataLabel
            // 
            this.noDataLabel.Font = new System.Drawing.Font("Gilroy-Regular", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noDataLabel.Location = new System.Drawing.Point(44, 0);
            this.noDataLabel.Name = "noDataLabel";
            this.noDataLabel.Size = new System.Drawing.Size(582, 94);
            this.noDataLabel.TabIndex = 0;
            this.noDataLabel.Text = "Нет проектных данных.\r\nНастройте проектные параметры \r\nи запустите синтез компози" +
    "тного материала.";
            this.noDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.startButton);
            this.panel1.Controls.Add(this.noDataLabel);
            this.panel1.Controls.Add(this.algorithmButton);
            this.panel1.Controls.Add(this.limitsButton);
            this.panel1.Controls.Add(this.projectParamsButton);
            this.panel1.Location = new System.Drawing.Point(55, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 366);
            this.panel1.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startButton.Location = new System.Drawing.Point(264, 210);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(143, 58);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Запуск синтеза";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // NoProjectDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoProjectDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoProjectDataForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button projectParamsButton;
        private System.Windows.Forms.Button algorithmButton;
        private System.Windows.Forms.Button limitsButton;
        private System.Windows.Forms.Label noDataLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button startButton;
    }
}