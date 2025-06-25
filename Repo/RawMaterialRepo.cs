using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class RawMaterialRepo : RepoBase<RawMaterialLog>, IRawMaterialRepo
{
    public RawMaterialRepo(ravenContext ctx) : base(ctx) { }

    public async Task<IEnumerable<RawMaterialLog>> GetAllRawMaterial() =>
        await FindAll().Include(s => s.Sample).ToListAsync();
    public async Task<IEnumerable<RawMaterialLog>> GetRawMaterialByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.MaterialNumber == materialNumber).Include(s => s.Sample).ToListAsync();
    public async Task<RawMaterialLog> GetRawMaterialByProductLotNumber(string productLot) =>
        await FindByCondition(m => m.ProductLotNumber == productLot)
            .Include(s => s.Sample).FirstAsync();
    public async Task<RawMaterialLog> GetRawMaterialByVendorLot(string vendorLot) =>
        await FindAll().Where(r => r.VendorLotNumber == vendorLot)
            .Include(s => s.Sample)
            .OrderByDescending(p => p.ProductLotNumber)
            .FirstAsync(v => v.VendorLotNumber == vendorLot);
    public void CreateRawMaterial(RawMaterialLog rawMaterial) =>
        Create(rawMaterial);
    public void UpdateRawMaterial(RawMaterialLog rawMaterial) =>
        Update(rawMaterial);
    public void DeleteRawMaterial(RawMaterialLog rawMaterial) =>
        Delete(rawMaterial);
}