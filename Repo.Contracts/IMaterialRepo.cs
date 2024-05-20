using Entities;

namespace Repo.Contracts;
public interface IMaterialRepo
{
    public Task<IEnumerable<Highpuritymaterial>> GetAllMaterial();
    public Task<Highpuritymaterial> GetMaterialByMaterialNumber(int materialNumber);
    public Task<Highpuritymaterial> GetMaterialByMaterialBinomial(string binomial);
    public void CreateMaterial(Highpuritymaterial material);
    public void UpdateMaterial(Highpuritymaterial material);
    public void DeleteMaterial(Highpuritymaterial material);

}
