namespace Repo.Contracts;

public interface IRepoManager
{
    IMaterialRepo MaterialRepo { get; }
    IVendorRepo VendorRepo { get; }
    IRawMaterialRepo RawMaterial { get; }
    IDateCode DateCode { get; }
    IProductLotNumber LotNumber { get; }
    IVendorLotRepo VendorLotRepo { get; }
    ISampleStatusRepo SampleStatusRepo { get; }
    Task Save();

}