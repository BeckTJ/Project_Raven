using Entities;

namespace Repo.Contracts;
public interface IMaterialRepo
{
    public Task<IEnumerable<Highpuritymaterial>> GetAllMaterial();
    public Task<Highpuritymaterial> GetMaterialByMaterialNumber(int materialNumber);
    public Task<Highpuritymaterial> GetMaterialByMaterialBinomial(string binomial);
}
