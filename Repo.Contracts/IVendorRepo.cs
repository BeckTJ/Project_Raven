using Entities;

namespace Repo.Contracts;

public interface IVendorRepo
{
    public Task<IEnumerable<Rawmaterialvendor>> GetAllVendors();
    public Task<IEnumerable<Rawmaterialvendor>> GetAllVendorsWithRawMaterialLogs();
    public Task<Rawmaterialvendor> GetVendorByMaterialNumber(int materialNumber);
    public Task<Rawmaterialvendor> GetVendorByVendorName(string vendorName);
    public void CreateMaterial(Rawmaterialvendor material);
    public void UpdateMaterial(Rawmaterialvendor material);
    public void DeleteMaterial(Rawmaterialvendor material);
}