using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompositeGUI
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public bool HasMetalGrid { get; set; }
        public double MinFrequency { get; set; }
        public double MaxFrequency { get; set; }
        public string Name { get; set; }

        public int? GaSettingsId { get; set; }
        [ForeignKey("GaSettingsId")]
        public GA_Settings GA_Settings { get; set; }

        public int? MatrixMaterialId { get; set; }
        [ForeignKey("MatrixMaterialId")]
        public Material MatrixMaterial { get; set; }

        public int? FiberMaterialId { get; set; }
        [ForeignKey("FiberMaterialId")]
        public Material FiberMaterial { get; set; }

        public int? LimitsId { get; set; }
        [ForeignKey("LimitsId")]
        public Limits Limits { get; set; }

        [ForeignKey("ProjectId")]
        public ICollection<Composite> Composites { get; set; }

        public void Start()
        {
            /*GeneticAlgorithm ga = new GeneticAlgorithm(
                ga_settings, hasMetalGrid, matrixMaterial,
                fiberMaterial, limits, frequency
            );

            ga.Start();*/
        }

        public Project()
        {
            Composites = new List<Composite>();
            HasMetalGrid = true;
            MinFrequency = 0.1;
            MaxFrequency = 1;
            // Заглушка
            /*Material Graphite = new Material("Графит", 12, 1, 24, 2230);
            Material Epoxyresin = new Material("Эпоксидная смола", 4, 1, 0.2, 1500);

            this.ga_settings = new GA_Settings(4, 3, 2);
            this.hasMetalGrid = true;
            this.matrixMaterial = Epoxyresin;
            this.fiberMaterial = Graphite;
            this.limits.FiberWidth = (5, 10);
            this.limits.FiberThickness = (5, 10);
            this.limits.FiberSpaceBetween = (0.1, 3);
            this.limits.LayerCount = (2, 3);
            this.frequency = (0.1, 3);*/
        }
    }
}
