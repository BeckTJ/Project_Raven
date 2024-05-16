namespace Services.Contracts;

public interface IServiceManager
{
    public IMaterialServices MaterialService { get; }
    public IVendorServices MaterialVendor { get; }
}