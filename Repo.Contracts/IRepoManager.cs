namespace Repo.Contracts;

public interface IRepoManager
{
    IMaterialRepo MaterialRepo { get; }
    IVendorRepo VendorRepo { get; }
}