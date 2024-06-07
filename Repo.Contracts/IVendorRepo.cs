using Entities;

namespace Repo.Contracts;

public interface IVendorRepo
{
    public Task<IEnumerable<RawMaterialVendor>> GetAllVendors();
    public Task<IEnumerable<RawMaterialVendor>> GetAllVendorsWithRawMaterialLogs();
    public Task<RawMaterialVendor> GetVendorByMaterialNumber(int materialNumber);
    public Task<RawMaterialVendor> GetVendorByVendorName(string vendorName);
    public void CreateMaterial(RawMaterialVendor material);
    public void UpdateMaterial(RawMaterialVendor material);
    public void DeleteMaterial(RawMaterialVendor material);
}