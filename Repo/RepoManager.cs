using Entities;
using Repo.Contracts;

namespace Repo;

public sealed class RepoManager : IRepoManager
{
    private readonly ravenContext _ctx;
    private readonly Lazy<IMaterialRepo> _materialRepo;
    private readonly Lazy<IVendorRepo> _vendorRepo;

    public RepoManager(ravenContext ctx)
    {
        _ctx = ctx;
        _materialRepo = new Lazy<IMaterialRepo>(() => new MaterialRepo(_ctx));
        _vendorRepo = new Lazy<IVendorRepo>(() => new VendorRepo(_ctx));
    }
    public IMaterialRepo MaterialRepo => _materialRepo.Value;
    public IVendorRepo VendorRepo => _vendorRepo.Value;

    public async Task Save() => await _ctx.SaveChangesAsync();
}