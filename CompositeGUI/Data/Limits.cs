using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompositeGUI
{
    public class Limits
    {
        [Key]
        public int LimitsId { get; set; }
        public int MinLayerCount { get; set; }
        public int MaxLayerCount { get; set; }
        public double MinFiberWidth { get; set; }
        public double MaxFiberWidth { get; set; }
        public double MinFiberThickness { get; set; }
        public double MaxFiberThickness { get; set; }
        public double MinFiberSpaceBetween { get; set; }
        public double MaxFiberSpaceBetween { get; set; }
    }
}
