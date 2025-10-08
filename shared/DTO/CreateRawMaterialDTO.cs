namespace shared.DTO;

public record CreateRawMaterialDTO
{
    public int MaterialNumber { get; set; }
    public int BatchNumber { get; set; }
    public string? VendorLotNumber { get; set; }
    public long InspectionLotNumber { get; set; }
    public string? ContainerNumber { get; set; }
    public int NetWeight { get; set; }
    public int Quantity { get; set; }
}