using System.Collections;

namespace shared.DTO;
public record MaterialDTO
{
    public int MaterialNumber { get; set; }
    public string MaterialName { get; set; } = null!;
    public string Binomial { get; set; } = null!;
    public string? PermitNumber { get; set; }
    public string MaterialCode { get; set; } = null!;
    public bool BatchManaged { get; set; }
    public int SequenceId { get; set; }
    public int TotalRecords { get; set; }
    public string? UnitOfIssue { get; set; }
    public IEnumerable<MaterialVendorDTO>? RawMaterialVendors { get; set; }
}
