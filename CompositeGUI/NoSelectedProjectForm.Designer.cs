
namespace CompositeGUI
{
    partial class NoSelectedProjectForm
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
            this.createButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(204, 142);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(322, 49);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Созать новый проект";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(204, 221);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(322, 49);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Открыть проект";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.openButton);
            this.panel1.Controls.Add(this.createButton);
            this.panel1.Location = new System.Drawing.Point(55, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 366);
            this.panel1.TabIndex = 4;
            // 
            // NoSelectedProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoSelectedProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoProjectDataForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Panel panel1;
    }
}