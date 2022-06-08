using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompositeGUI
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public double ElecCond { get; set; }
        public double MagCond { get; set; }
        public double ThermalCond { get; set; }
        public double Density { get; set; }
    }
}
