using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class RawMaterialLog
    {
        public string ProductLotNumber { get; set; } = null!;
        public string? ContainerNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public int? NetWeight { get; set; }
        public int? LotId { get; set; }
        public int MaterialNumber { get; set; }
        public int? SampleId { get; set; }

        public virtual MaterialVendorLot? Lot { get; set; }
        public virtual RawMaterialVendor MaterialNumberNavigation { get; set; } = null!;
        public virtual SampleStatus? Sample { get; set; }
    }
}
