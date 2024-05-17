
using System.Collections;

namespace shared.DTO;

public record MaterialVendorDTO
{
    public int MaterialNumber { get; set; }
    public string VendorName { get; set; } = null!;
    public string MaterialCode { get; set; } = null!;
    public bool BatchManaged { get; set; }
    public bool ContainerNumberRequired { get; set; }
    public int SequenceId { get; set; }
    public int TotalRecords { get; set; }
    public string UnitOfIssue { get; set; } = null!;
    public int ParentMaterialNumber { get; set; }
}