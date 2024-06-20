using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class SampleRequired
    {
        public int RequiredId { get; set; }
        public string? MaterialType { get; set; }
        public string? ProductType { get; set; }
        public bool? Assay { get; set; }
        public bool? Water { get; set; }
        public bool? Metals { get; set; }
        public bool? Chloride { get; set; }
        public bool? Boron { get; set; }
        public bool? Phosphorus { get; set; }
        public int? MaterialNumber { get; set; }

        public virtual HighPurityMaterial? MaterialNumberNavigation { get; set; }
    }
}
