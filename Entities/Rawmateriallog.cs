using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class RawMaterialLog
    {
        public string ProductLotNumber { get; set; } = null!;
        public int? ProductBatchNumber { get; set; }
        public string VendorName { get; set; } = null!;
        public string? VendorLotNumber { get; set; }
        public int? SampleId { get; set; }
        public long? InspectionLotNumber { get; set; }
        public string? ContainerNumber { get; set; }
        public DateOnly? IssueDate { get; set; }
        public int? NetWeight { get; set; }
        public int MaterialNumber { get; set; }

        public virtual RawMaterialVendor MaterialNumberNavigation { get; set; } = null!;
    }
}
