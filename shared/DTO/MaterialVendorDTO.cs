using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace shared.DTO;

public record MaterialVendorDTO
{
    int MaterialNumber { get; set; }
    string VendorName { get; set; } = null!;
    string MaterialCode { get; set; } = null!;
    bool BatchManaged { get; set; }
    bool ContainerNumberRequired { get; set; }
    int SequenceId { get; set; }
    int TotalRecords { get; set; }
    string UnitOfIssue { get; set; }
    int ParentMaterialNumber { get; set; }
}