using System;
using System.Collections.Generic;
using System.Collections;

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
        public BitArray Batchmanaged { get; set; } = null!;
        public BitArray Containernumberrequired { get; set; } = null!;
        public int Sequenceid { get; set; }
        public int Totalrecords { get; set; }
        public string? Unitofissue { get; set; }
        public int Parentmaterialnumber { get; set; }

        public virtual Highpuritymaterial ParentmaterialnumberNavigation { get; set; } = null!;
        public virtual ICollection<Rawmateriallog> Rawmateriallogs { get; set; }
    }
}
