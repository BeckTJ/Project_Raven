
namespace shared.DTO;

public record VendorLotDTO
{
    public string VendorLotNumber { get; set; } = null!;
    public int BatchNumber { get; set; }
    public int MaterialNumber { get; set; }
    public int Quantity { get; set; }
}