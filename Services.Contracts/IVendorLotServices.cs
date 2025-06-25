
using shared.DTO;

namespace Services.Contracts;

public interface IVendorLotServices
{
    public Task<IEnumerable<VendorLotDTO>> GetAllVendorLots();

    public Task<IEnumerable<VendorLotDTO>> GetVendorLotsByMaterialNumber(int materialNumber);
}