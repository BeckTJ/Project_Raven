using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class HighPurityMaterial
    {
        public HighPurityMaterial()
        {
            HazardLabels = new HashSet<HazardLabel>();
            RawMaterialVendors = new HashSet<RawMaterialVendor>();
            SampleRequireds = new HashSet<SampleRequired>();
        }

        public int MaterialNumber { get; set; }
        public string MaterialName { get; set; } = null!;
        public string Binomial { get; set; } = null!;
        public string? PermitNumber { get; set; }
        public string MaterialCode { get; set; } = null!;
        public bool? BatchManaged { get; set; }
        public int SequenceId { get; set; }
        public int TotalRecords { get; set; }
        public string? UnitOfIssue { get; set; }

        public virtual ICollection<HazardLabel> HazardLabels { get; set; }
        public virtual ICollection<RawMaterialVendor> RawMaterialVendors { get; set; }
        public virtual ICollection<SampleRequired> SampleRequireds { get; set; }
    }
}
