using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Rawmateriallog
    {
        public string Productlotnumber { get; set; } = null!;
        public int? Productbatchnumber { get; set; }
        public string Vendorname { get; set; } = null!;
        public string? Vendorlotnumber { get; set; }
        public int? Sampleid { get; set; }
        public long? Inspectionlotnumber { get; set; }
        public string? Containernumber { get; set; }
        public DateOnly? Issuedate { get; set; }
        public int? Netweight { get; set; }
        public int Materialnumber { get; set; }

        public virtual Rawmaterialvendor MaterialnumberNavigation { get; set; } = null!;
    }
}
