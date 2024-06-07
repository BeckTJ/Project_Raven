using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class RawMaterialRepo : RepoBase<RawMaterialLog>, IRawMaterialRepo
{
    public RawMaterialRepo(ravenContext ctx) : base(ctx) { }

    public async Task<IEnumerable<RawMaterialLog>> GetAllRawMaterial() =>
        await FindAll().ToListAsync();
    public async Task<IEnumerable<RawMaterialLog>> GetRawMaterialByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.MaterialNumber == materialNumber).ToListAsync();
    public async Task<RawMaterialLog> GetRawMaterialByProductLotNumber(string lotNumber) =>
        await FindByCondition(m => m.ProductLotNumber == lotNumber).FirstAsync();
    public void CreateRawMaterial(RawMaterialLog rawMaterial) =>
        Create(rawMaterial);
    public void UpdateRawMaterial(RawMaterialLog rawMaterial) =>
        Update(rawMaterial);
    public void DeleteRawMaterial(RawMaterialLog rawMaterial) =>
        Delete(rawMaterial);
}