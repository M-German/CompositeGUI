﻿using System;
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
    public partial class OpenProjectForm : Based
    {
        List<Project> ProjectList;
        public OpenProjectForm()
        {
            InitializeComponent();
        }

        private void OpenProjectForm_Load(object sender, EventArgs e)
        {
            ProjectList = DB.GetProjects();
            projectComboBox.Items.Clear();
            if(ProjectList.Count > 0)
            {
                foreach (var item in ProjectList)
                {
                    projectComboBox.Items.Add(item.Name);
                }
                projectComboBox.SelectedIndex = 0;
            }
            selectButton.Enabled = projectComboBox.Items.Count > 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateProjectForm f = new CreateProjectForm();
            f.ShowDialog();
            Close();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            Main.CurrentProject = DB.GetProject(ProjectList[projectComboBox.SelectedIndex].ProjectId);
            Close();
        }

        private void projectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectButton.Enabled = projectComboBox.Items.Count > 0;
        }
    }
}
