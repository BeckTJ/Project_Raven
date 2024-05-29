using Entities;
using Repo.Contracts;

namespace Repo;

public sealed class RepoManager : IRepoManager
{
    private readonly ravenContext _ctx;
    private readonly Lazy<IMaterialRepo> _materialRepo;
    private readonly Lazy<IVendorRepo> _vendorRepo;
    private readonly Lazy<IRawMaterialRepo> _rawMaterial;

    public RepoManager(ravenContext ctx)
    {
        _ctx = ctx;
        _materialRepo = new Lazy<IMaterialRepo>(() => new MaterialRepo(_ctx));
        _vendorRepo = new Lazy<IVendorRepo>(() => new VendorRepo(_ctx));
        _rawMaterial = new Lazy<IRawMaterialRepo>(() => new RawMaterialRepo(_ctx));
    }
    public IMaterialRepo MaterialRepo => _materialRepo.Value;
    public IVendorRepo VendorRepo => _vendorRepo.Value;
    public IRawMaterialRepo RawMaterial => _rawMaterial.Value;

    public async Task Save() => await _ctx.SaveChangesAsync();
}