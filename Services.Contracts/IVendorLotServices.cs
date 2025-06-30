
using shared.DTO;

namespace Services.Contracts;

public interface IVendorLotServices
{
    public Task<IEnumerable<VendorLotDTO>> GetAllVendorLots();

    public Task<IEnumerable<VendorLotDTO>> GetVendorLotsByMaterialNumber(int materialNumber);
    public Task<Boolean> VerifyVendorLot(string lotNumber, int batchNumber);
}