namespace shared.DTO;
public record MaterialDTO
{
    int MaterialNumber { get; set; }
    string Name { get; set; } = null!;
    string Binomial { get; set; } = null!;
    string PermitNumber { get; set; } = null!;
    bool BatchManaged { get; set; }
    int SequenceId { get; set; }
    int totalRecords { get; set; }
    string UnitOfIssue { get; set; } = null!;
    ICollection<MaterialVendorDTO>? MaterialVendor { get; set; }
}
