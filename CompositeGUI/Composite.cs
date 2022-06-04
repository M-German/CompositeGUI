using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeGUI
{
    class Composite
    {
        public int LayerCount;
        public double FiberWidth;
        public double FiberThickness;
        public double FiberSpaceBetween;

        public double ShieldingEfficiency;
        public string[] Diagrams;

        public Composite() : this(1, 1, 1, 1) { }

        public Composite(
            int LayerCount,
            double FiberWidth,
            double FiberThickness,
            double FiberSpaceBetween
        )
        {
            this.LayerCount = LayerCount;
            this.FiberWidth = FiberWidth;
            this.FiberThickness = FiberThickness;
            this.FiberSpaceBetween = FiberSpaceBetween;
        }
    }
}
