using shared.DTO;
namespace Services.Contracts;

public interface IRawMaterialServices
{
    public Task<IEnumerable<RawMaterialDTO>> GetAllRawMaterial();
    public Task<IEnumerable<RawMaterialDTO>> GetRawMaterialByMaterialNumber(int materialNumber);
    public Task<RawMaterialDTO> GetRawMateriaByProductLotNumber(string lotNumber);
    public Task<RawMaterialDTO> CreateRawMaterial(CreateRawMaterialDTO rawMaterial);
    public Task UpdateRawMaterial(RawMaterialDTO rawMaterial);
    public Task DeleteRawMaterial(string productId);
}