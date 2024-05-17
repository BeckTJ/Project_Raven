using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;


namespace Repo;

internal sealed class MaterialRepo : RepoBase<Highpuritymaterial>, IMaterialRepo
{
    public MaterialRepo(ravenContext ctx) : base(ctx) { }

    public async Task<IEnumerable<Highpuritymaterial>> GetAllMaterial() =>
        await FindAll()
            .Include(m => m.Rawmaterialvendors)
            .ToListAsync();

    public async Task<Highpuritymaterial> GetMaterialByMaterialBinomial(string binomial) =>
        await FindByCondition(m => m.Binomial == binomial).FirstAsync();

    public async Task<Highpuritymaterial> GetMaterialByMaterialNumber(int materialNumber) =>
        await FindByCondition(m => m.Materialnumber == materialNumber).FirstAsync();
    
    public void CreateMaterial(Highpuritymaterial material) =>
        Create(material);

    public void UpdateMaterial(Highpuritymaterial material) =>
        Update(material);
    public void DeleteMaterial(Highpuritymaterial material) =>
        Delete(material);
}