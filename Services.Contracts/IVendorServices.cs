
using shared.DTO;

namespace Services.Contracts;

public interface IVendorServices
{
    Task<IEnumerable<MaterialVendorDTO>> GetAllVendors();
    Task<MaterialVendorDTO> GetVendorByMaterialNumber(int materialNumber);
    Task<MaterialVendorDTO> GetVendorByVendorName(string vendorName);
}