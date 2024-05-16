using AutoMapper;
using Repo.Contracts;
using Services.Contracts;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly IRepoManager _repo;
    private readonly IMapper _mapper;
    private readonly Lazy<IMaterialServices> _material;
    private readonly Lazy<IVendorServices> _vendor;

    public ServiceManager(IRepoManager repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
        _material = new Lazy<IMaterialServices>(() => new MaterialServices(_repo, _mapper));
        _vendor = new Lazy<IVendorServices>(() => new VendorServices(_repo, _mapper));
    }

    public IMaterialServices MaterialService => _material.Value;
    public IVendorServices MaterialVendor => _vendor.Value;
}