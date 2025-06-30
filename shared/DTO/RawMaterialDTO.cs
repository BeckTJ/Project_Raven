namespace shared.DTO;

public record RawMaterialDTO
{
    public string ProductLotNumber { get; set; } = null!;
    public string? ContainerNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public int? NetWeight { get; set; }
    public int MaterialNumber { get; set; }
    public VendorLotDTO? Lot { get; set; }
    public SampleStatusDTO? Sample { get; set; }
}