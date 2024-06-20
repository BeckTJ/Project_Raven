namespace shared.DTO;

public record CreateRawMaterialDTO
{
    public int MaterialNumber { get; set; }
    public int ProductBatchNumber { get; set; }
    public string? VendorLotNumber { get; set; }
    public string? SampleId { get; set; }
    public long InspectionLotNumber { get; set; }
    public string? ContainerNumber { get; set; }
    public int NetWeight { get; set; }
}