namespace shared.DTO;
public record MaterialDTO
{
    public int MaterialNumber { get; set; }
    public string Name { get; set; } = null!;
    public string Binomial { get; set; } = null!;
    public string PermitNumber { get; set; } = null!;
    public bool BatchManaged { get; set; }
    public int SequenceId { get; set; }
    public int totalRecords { get; set; }
    public string UnitOfIssue { get; set; } = null!;
    public IEnumerable<MaterialVendorDTO>? MaterialVendors { get; set; }
}
