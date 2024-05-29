using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class RawMaterialRepo : RepoBase<Rawmateriallog>, IRawMaterialRepo
{
    public RawMaterialRepo(ravenContext ctx) : base(ctx) { }

    public async Task<IEnumerable<Rawmateriallog>> GetAllRawMaterial() =>
        await FindAll().ToListAsync();
    public async Task<IEnumerable<Rawmateriallog>> GetRawMaterialByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.MaterialNumber == materialNumber).ToListAsync();
    public async Task<Rawmateriallog> GetRawMaterialByProductLotNumber(string lotNumber) =>
        await FindByCondition(m => m.ProductLotNumber == lotNumber).FirstAsync();
    public void CreateRawMaterial(Rawmateriallog rawMaterial) =>
        Create(rawMaterial);
    public void UpdateRawMaterial(Rawmateriallog rawMaterial) =>
        Update(rawMaterial);
    public void DeleteRawMaterial(Rawmateriallog rawMaterial) =>
        Delete(rawMaterial);
}