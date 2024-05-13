using System;
using System.Collections.Generic;
using System.Collections;

namespace Entities
{
    public partial class Highpuritymaterial
    {
        public Highpuritymaterial()
        {
            Rawmaterialvendors = new HashSet<Rawmaterialvendor>();
        }

        public int Materialnumber { get; set; }
        public string Materialname { get; set; } = null!;
        public string Binomial { get; set; } = null!;
        public string? Permitnumber { get; set; }
        public string Materialcode { get; set; } = null!;
        public bool Batchmanaged { get; set; }
        public int Sequenceid { get; set; }
        public int Totalrecords { get; set; }
        public string? Unitofissue { get; set; }

        public virtual ICollection<Rawmaterialvendor> Rawmaterialvendors { get; set; }
    }
}
