using shared.DTO;

namespace Services.Contracts;
public interface IMaterialServices
{
    public Task<IEnumerable<MaterialDTO>> GetAllMaterial();
    public Task<MaterialDTO> GetMaterialByMaterialNumber(int materialNumber);
    public void AddMaterial(MaterialDTO material);
    public void UpdateMaterial(MaterialDTO material);
    public void DeleteMaterial(MaterialDTO material);

}
