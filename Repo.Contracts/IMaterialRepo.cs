using shared.DTO;

namespace Repo.Contracts;
public interface IMaterialRepo
{
    Task<IEnumerable<MaterialDTO>> GetAllMaterial();
    Task<MaterialDTO> GetMaterialByMaterialNumber(int materialNumber);
    Task<MaterialDTO> GetMaterialByMaterialBinomial(string binomial);
}
