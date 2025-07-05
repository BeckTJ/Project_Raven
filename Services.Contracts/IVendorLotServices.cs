
using shared.DTO;

namespace Services.Contracts;

public interface IVendorLotServices
{
    public Task<IEnumerable<VendorLotDTO>> GetAllVendorLots();

    public Task<IEnumerable<VendorLotDTO>> GetVendorLotsByMaterialNumber(int materialNumber);
    public Task<bool> VerifyVendorLot(string lotNumber, int batchNumber);
    Task<bool> VerifyVendorLot(string lotNumber);
}