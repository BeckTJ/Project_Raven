using shared.DTO;

namespace Services.Contracts;
public interface IMaterialServices
{
    Task<IEnumerable<MaterialDTO>> GetAllMaterial();
    Task<MaterialDTO> GetMaterialByMaterialNumber(int materialNumber);
}
