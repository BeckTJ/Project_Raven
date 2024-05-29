using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Rawmaterialvendor
    {
        public Rawmaterialvendor()
        {
            RawMaterialLogs = new HashSet<Rawmateriallog>();
        }

        public int MaterialNumber { get; set; }
        public string VendorName { get; set; } = null!;
        public string MaterialCode { get; set; } = null!;
        public bool? BatchManaged { get; set; }
        public bool? ContainerNumberRequired { get; set; }
        public int Sequenceid { get; set; }
        public int TotalRecords { get; set; }
        public string? UnitOfIssue { get; set; }
        public int ParentMaterialNumber { get; set; }

        public virtual Highpuritymaterial ParentmaterialnumberNavigation { get; set; } = null!;
        public virtual ICollection<Rawmateriallog> RawMaterialLogs { get; set; }
    }
}
