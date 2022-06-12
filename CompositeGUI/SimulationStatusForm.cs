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
    public partial class SimulationStatusForm : Based
    {
        
        public SimulationStatusForm()
        {
            InitializeComponent();
            HandleStatusChanged();
        }

        private void SimulationStatusForm_Load(object sender, EventArgs e)
        {
            Main.SimulationStatusChanged += HandleStatusChanged;
        }

        void HandleStatusChanged()
        {
            statusLabel.Text = $"Идет проектирование структуры композитных материалов и вычисление эффективности экранирования...\n\n" +
                $"Текущее поколение: {Main.CurrentGeneration()}\n" +
                $"Текущая особь в поколении: {Main.CurrentIndividual()}";
        }
    }
}
