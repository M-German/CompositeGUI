using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompositeGUI.Main;

namespace CompositeGUI
{
    public class SimulationStatus
    {
        public bool InProcess { get; set; }
        public int CurrentGeneration { get; set; }
        public int CurrentIndividualInGeneration { get; set; }

        public SimulationStatus()
        {
            InProcess = false;
            CurrentGeneration = 1;
            CurrentIndividualInGeneration = 1;
        }
    }
}
