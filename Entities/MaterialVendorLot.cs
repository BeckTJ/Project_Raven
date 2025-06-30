using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class MaterialVendorLot
    {
        public MaterialVendorLot()
        {
            RawMaterialLogs = new HashSet<RawMaterialLog>();
        }

        public int LotId { get; set; }
        public string? VendorLotNumber { get; set; }
        public int? BatchNumber { get; set; }
        public int? Quantity { get; set; }
        public int? MaterialNumber { get; set; }

        public virtual RawMaterialVendor? MaterialNumberNavigation { get; set; }
        public virtual ICollection<RawMaterialLog> RawMaterialLogs { get; set; }
    }
}
