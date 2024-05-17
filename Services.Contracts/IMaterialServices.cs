using shared.DTO;

namespace Services.Contracts;
public interface IMaterialServices
{
    public Task<IEnumerable<MaterialDTO>> GetAllMaterial();
    public Task<MaterialDTO> GetMaterialByMaterialNumber(int materialNumber);
}
