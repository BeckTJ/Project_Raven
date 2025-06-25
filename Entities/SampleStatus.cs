using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class SampleStatus
    {
        public SampleStatus()
        {
            RawMaterialLogs = new HashSet<RawMaterialLog>();
        }

        public int SampleId { get; set; }
        public string? SampleType { get; set; }
        public long? InspectionLotNumber { get; set; }
        public DateTime? SubmitDate { get; set; }
        public bool? Approved { get; set; }
        public bool? Rejected { get; set; }
        public DateTime? StatusDate { get; set; }

        public virtual ICollection<RawMaterialLog> RawMaterialLogs { get; set; }
    }
}
