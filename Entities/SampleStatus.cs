using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class SampleStatus
    {
        public int SampleId { get; set; }
        public string? SampleType { get; set; }
        public string? ProductLotNumber { get; set; }
        public string? VendorLotNumber { get; set; }
        public DateTime? SubmitDate { get; set; }
        public bool? Approved { get; set; }
        public bool? Rejected { get; set; }
        public DateTime? StatusDate { get; set; }
    }
}
