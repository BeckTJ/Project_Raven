using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class MaterialVendorLot
    {
        public string VendorLotNumber { get; set; } = null!;
        public int? BatchNumber { get; set; }
        public int? Quantity { get; set; }
        public int? MaterialNumber { get; set; }

        public virtual RawMaterialVendor? MaterialNumberNavigation { get; set; }
    }
}
