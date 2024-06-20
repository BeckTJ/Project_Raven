using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class HazardLabel
    {
        public int HazardId { get; set; }
        public bool? Carcinogen { get; set; }
        public bool? Flammable { get; set; }
        public bool? Corrosive { get; set; }
        public bool? Pyrophoric { get; set; }
        public bool? Combustable { get; set; }
        public bool? Sensitizer { get; set; }
        public bool? Hygroscopic { get; set; }
        public bool? Irritant { get; set; }
        public bool? HighlyToxic { get; set; }
        public bool? Volitile { get; set; }
        public bool? Explosive { get; set; }
        public bool? Peroxidizable { get; set; }
        public bool? ShelfLife { get; set; }
        public bool? Dusty { get; set; }
        public int? MaterialNumber { get; set; }

        public virtual HighPurityMaterial? MaterialNumberNavigation { get; set; }
    }
}
