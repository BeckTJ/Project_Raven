using shared.DTO;

namespace Services.Contracts;
public interface IMaterialServices
{
    public Task<IEnumerable<MaterialDTO>> GetAllMaterial();
    public Task<MaterialDTO> GetMaterialByMaterialNumber(int materialNumber);
    public Task<MaterialDTO> AddMaterial(MaterialDTO material);
    public Task UpdateMaterial(int materialNumber, MaterialDTO material);
    public Task DeleteMaterial(int materialNumber);

}
