using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class RawMaterialVendor
    {
        public RawMaterialVendor()
        {
            RawMaterialLogs = new HashSet<RawMaterialLog>();
        }

        public int MaterialNumber { get; set; }
        public string VendorName { get; set; } = null!;
        public string MaterialCode { get; set; } = null!;
        public bool? BatchManaged { get; set; }
        public bool? ContainerNumberRequired { get; set; }
        public int SequenceId { get; set; }
        public int TotalRecords { get; set; }
        public string? UnitOfIssue { get; set; }
        public int ParentMaterialNumber { get; set; }

        public virtual HighPurityMaterial ParentMaterialNumberNavigation { get; set; } = null!;
        public virtual ICollection<RawMaterialLog> RawMaterialLogs { get; set; }
    }
}
