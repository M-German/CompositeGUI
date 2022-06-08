using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompositeGUI
{
    public class GA_Settings
    {
        [Key]
        public int GaSettingsId { get; set; }
        public int PopulationSize { get; set; }
        public int MaxGenerations { get; set; }
        public int SelectionTourneySize { get; set; }

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
