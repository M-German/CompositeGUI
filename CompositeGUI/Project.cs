using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeGUI
{
    class Project
    {
        public GA_Settings settings = new GA_Settings();
        public bool hasMetalGrid = false;
        public Material matrixMaterial = new Material();
        public Material fiberMaterial = new Material();
        public Limits limits = new Limits();
        public (double, double) frequency;

        public Composite[] composites;

        public void Start()
        {
            GeneticAlgorithm ga = new GeneticAlgorithm(
                settings, hasMetalGrid, matrixMaterial,
                fiberMaterial, limits, frequency
            );

            ga.Start();
        }

        public Project()
        {
            // Заглушка
            Material Graphite = new Material("Графит", 12, 1, 24, 2230);
            Material Epoxyresin = new Material("Эпоксидная смола", 4, 1, 0.2, 1500);
            this.settings = new GA_Settings(4, 3, 2);
            this.hasMetalGrid = true;
            this.matrixMaterial = Epoxyresin;
            this.fiberMaterial = Graphite;
            this.limits.FiberWidth = (5, 10);
            this.limits.FiberThickness = (5, 10);
            this.limits.FiberSpaceBetween = (0.1, 3);
            this.limits.LayerCount = (2, 3);
            this.frequency = (0.1, 3);
        }
    }
}
