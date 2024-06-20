namespace shared.DTO;

public record RawMaterialDTO
{
    public string ProductLotNumber { get; set; } = null!;
    public int? ProductBatchNumber { get; set; }
    public string? VendorLotNumber { get; set; }
    public int? SampleId { get; set; }
    public long? InspectionLotNumber { get; set; }
    public string? ContainerNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public int? NetWeight { get; set; }
    public int MaterialNumber { get; set; }
}