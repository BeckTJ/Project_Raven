using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Highpuritymaterial
    {
        public Highpuritymaterial()
        {
            RawMaterialVendors = new HashSet<Rawmaterialvendor>();
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

        public virtual ICollection<Rawmaterialvendor> RawMaterialVendors { get; set; }
    }
}
