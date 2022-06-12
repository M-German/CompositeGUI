using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompositeGUI.Data
{
    public class CstResult
    {
        public int CstResultId { get; set; }
        public decimal? Frequency { get; set; }
        public decimal? S21 { get; set; }
        public decimal? SE { get; set; }
        public int CompositeId { get; set; }
        public Composite Composite { get; set; }
    }
}
