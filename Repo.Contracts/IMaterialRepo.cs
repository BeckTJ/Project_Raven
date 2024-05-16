using Entities;

namespace Repo.Contracts;
public interface IMaterialRepo
{
    Task<IEnumerable<Highpuritymaterial>> GetAllMaterial();
    Task<Highpuritymaterial> GetMaterialByMaterialNumber(int materialNumber);
    Task<Highpuritymaterial> GetMaterialByMaterialBinomial(string binomial);
}
