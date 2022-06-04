using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeGUI
{
    class Material
    {
        public string Name;
        public double ElecCond;
        public double MagCond;
        public double ThermalCond;
        public double Density;

        public Material() : this("Unknown", 0, 0, 0, 0) { }

        public Material(string Name, double ElecCond, double MagCond, double ThermalCond, double Density) {
            this.Name = Name;
            this.ElecCond = ElecCond;
            this.MagCond = MagCond;
            this.ThermalCond = ThermalCond;
            this.Density = Density;
        }
    }
}
