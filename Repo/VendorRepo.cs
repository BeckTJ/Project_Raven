using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class VendorRepo : RepoBase<RawMaterialVendor>, IVendorRepo
{
    public VendorRepo(ravenContext ctx) : base(ctx) { }
    public async Task<IEnumerable<RawMaterialVendor>> GetAllVendors() =>
        await FindAll().ToListAsync();

    public async Task<IEnumerable<RawMaterialVendor>> GetAllVendorsWithRawMaterialLogs() =>
        await FindAll()
            .Include(m => m.RawMaterialLogs)
            .ToListAsync();

    public async Task<RawMaterialVendor> GetVendorByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.MaterialNumber == materialNumber).FirstAsync();

    public async Task<RawMaterialVendor> GetVendorByVendorName(string vendorName) =>
        await FindByCondition(m => m.VendorName == vendorName).FirstAsync();

    public void CreateMaterial(RawMaterialVendor material) =>
        Create(material);

    public void UpdateMaterial(RawMaterialVendor material) =>
        Update(material);
    public void DeleteMaterial(RawMaterialVendor material) =>
        Delete(material);
}