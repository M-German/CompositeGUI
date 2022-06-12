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
            
        }

        public Project()
        {
            Composites = new List<Composite>();
            HasMetalGrid = true;
            MinFrequency = 0.1;
            MaxFrequency = 1;
        }
    }
}
