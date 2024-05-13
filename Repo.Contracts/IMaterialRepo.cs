using shared.DTO;

namespace Repo.Contracts;
public interface IMaterialRepo
{
    IEnumerable<MaterialDTO> GetAllMaterial();
    MaterialDTO GetMaterialByMaterialNumber(int materialNumber);
    MaterialDTO GetMaterialByMaterialBinomial(string binomial);
}
