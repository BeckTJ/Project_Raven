using Entities;
using Repo.Contracts;
using shared.DTO;

namespace Repo;

internal sealed class MaterialRepo : RepoBase<MaterialDTO>, IMaterialRepo
{
    public MaterialRepo(ravenContext ctx) : base(ctx) { }

    public IEnumerable<MaterialDTO> GetAllMaterial()
    {
        throw new NotImplementedException();
    }

    public MaterialDTO GetMaterialByMaterialBinomial(string binomial)
    {
        throw new NotImplementedException();
    }

    public MaterialDTO GetMaterialByMaterialNumber(int materialNumber)
    {
        throw new NotImplementedException();
    }
}