using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeGUI
{
    class GA_Settings
    {
        public int PopulationSize;
        public int MaxGenerations;
        public int SelectionTourneySize;
        public double CrossingoverAlphaParam = 0.1;

        public GA_Settings() : this(4, 3, 2)
        { }
        public GA_Settings(int PopulationSize, int MaxGenerations, int SelectionTourneySize)
        {
            this.PopulationSize = PopulationSize;
            this.MaxGenerations = MaxGenerations;
            this.SelectionTourneySize = SelectionTourneySize;
        }
    }
}
