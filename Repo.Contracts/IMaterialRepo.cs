using Entities;

namespace Repo.Contracts;
public interface IMaterialRepo
{
    public Task<IEnumerable<HighPurityMaterial>> GetAllMaterial();
    public Task<HighPurityMaterial> GetMaterialByMaterialNumber(int materialNumber);
    public Task<HighPurityMaterial> GetMaterialByMaterialBinomial(string binomial);
    public void CreateMaterial(HighPurityMaterial material);
    public void UpdateMaterial(HighPurityMaterial material);
    public void DeleteMaterial(HighPurityMaterial material);

}
