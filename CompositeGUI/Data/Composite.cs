using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompositeGUI
{
    public class Composite
    {
        [Key]
        public int CompositeId { get; set; }
        public int LayerCount { get; set; }
        public double FiberWidth { get; set; }
        public double FiberThickness { get; set; }
        public double FiberSpaceBetween { get; set; }
        public double ShieldingEfficiency { get; set; }
        public string Diagrams { get; set; }
       
        [Required]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

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
