using Entities;

namespace Repo.Contracts;

public interface IVendorRepo
{
    Task<IEnumerable<Rawmaterialvendor>> GetAllVendors();
    Task<IEnumerable<Rawmaterialvendor>> GetAllVendorsWithRawMaterialLogs();
    Task<Rawmaterialvendor> GetVendorByMaterialNumber(int materialNumber);
    Task<Rawmaterialvendor> GetVendorByVendorName(string vendorName);
}