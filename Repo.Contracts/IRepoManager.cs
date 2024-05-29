namespace Repo.Contracts;

public interface IRepoManager
{
    IMaterialRepo MaterialRepo { get; }
    IVendorRepo VendorRepo { get; }
    IRawMaterialRepo RawMaterial { get; }
    Task Save();

}