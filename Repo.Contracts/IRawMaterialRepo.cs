using Entities;

namespace Repo.Contracts;

public interface IRawMaterialRepo
{
    public Task<IEnumerable<RawMaterialLog>> GetAllRawMaterial();
    public Task<IEnumerable<RawMaterialLog>> GetRawMaterialByMaterialNumber(int materialNumber);
    public Task<RawMaterialLog> GetRawMaterialByProductLotNumber(string lotNumber);
    public void CreateRawMaterial(RawMaterialLog rawMaterial);
    public void UpdateRawMaterial(RawMaterialLog rawMaterial);
    public void DeleteRawMaterial(RawMaterialLog rawMaterial);
}