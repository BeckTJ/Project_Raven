using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repo;

internal sealed class MaterialRepo : RepoBase<HighPurityMaterial>, IMaterialRepo
{
    public MaterialRepo(ravenContext ctx) : base(ctx) { }

    public async Task<IEnumerable<HighPurityMaterial>> GetAllMaterial() =>
        await FindAll()
            .Include(m => m.RawMaterialVendors)
            .ToListAsync();

    public async Task<HighPurityMaterial> GetMaterialByMaterialBinomial(string binomial) =>
        await FindByCondition(m => m.Binomial == binomial).FirstAsync();

    public async Task<HighPurityMaterial> GetMaterialByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.MaterialNumber == materialNumber).FirstAsync();

    public void CreateMaterial(HighPurityMaterial material) =>
         Create(material);

    public void UpdateMaterial(HighPurityMaterial material) =>
        Update(material);
    public void DeleteMaterial(HighPurityMaterial material) =>
        Delete(material);
}