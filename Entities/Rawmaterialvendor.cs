using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Rawmaterialvendor
    {
        public Rawmaterialvendor()
        {
            Rawmateriallogs = new HashSet<Rawmateriallog>();
        }

        public int Materialnumber { get; set; }
        public string Vendorname { get; set; } = null!;
        public string Materialcode { get; set; } = null!;
        public bool? Batchmanaged { get; set; }
        public bool? Containernumberrequired { get; set; }
        public int Sequenceid { get; set; }
        public int Totalrecords { get; set; }
        public string? Unitofissue { get; set; }
        public int Parentmaterialnumber { get; set; }

        public virtual Highpuritymaterial ParentmaterialnumberNavigation { get; set; } = null!;
        public virtual ICollection<Rawmateriallog> Rawmateriallogs { get; set; }
    }
}
