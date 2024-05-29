namespace Services.Contracts;

public interface IServiceManager
{
    public IMaterialServices MaterialService { get; }
    public IVendorServices MaterialVendorService { get; }
    public IRawMaterialServices RawMaterialService { get; }
}