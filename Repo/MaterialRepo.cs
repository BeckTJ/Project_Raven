using Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;
using shared.DTO;

namespace Repo;

internal sealed class MaterialRepo : RepoBase<MaterialDTO>, IMaterialRepo
{
    public MaterialRepo(ravenContext ctx) : base(ctx) { }

    public async Task<IEnumerable<MaterialDTO>> GetAllMaterial() =>
        await FindAll()
            .Include(m => m.MaterialVendors)
            .ToListAsync();

    public async Task<MaterialDTO> GetMaterialByMaterialBinomial(string binomial)
    {
        throw new NotImplementedException();
    }

    public async Task<MaterialDTO> GetMaterialByMaterialNumber(int materialNumber)
    {
        throw new NotImplementedException();
    }
}