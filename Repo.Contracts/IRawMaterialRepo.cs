using Entities;

namespace Repo.Contracts;

public interface IRawMaterialRepo
{
    public Task<IEnumerable<Rawmateriallog>> GetAllRawMaterial();
    public Task<IEnumerable<Rawmateriallog>> GetRawMaterialByMaterialNumber(int materialNumber);
    public Task<Rawmateriallog> GetRawMaterialByProductLotNumber(string lotNumber);
    public void CreateRawMaterial(Rawmateriallog rawMaterial);
    public void UpdateRawMaterial(Rawmateriallog rawMaterial);
    public void DeleteRawMaterial(Rawmateriallog rawMaterial);
}