using Entities;
using Repo.Contracts;

namespace Repo;

public sealed class RepoManager : IRepoManager
{
    private readonly ravenContext _ctx;
    private readonly Lazy<IMaterialRepo> _materialRepo;
    private readonly Lazy<IVendorRepo> _vendorRepo;
    private readonly Lazy<IRawMaterialRepo> _rawMaterial;
    private readonly Lazy<IProductLotNumber> _lotNumber;
    private readonly Lazy<IDateCode> _dateCode;
    private readonly Lazy<IVendorLotRepo> _vendorLot;
    private readonly Lazy<ISampleStatusRepo> _sampleStatus;

    public RepoManager(ravenContext ctx)
    {
        _ctx = ctx;
        _materialRepo = new Lazy<IMaterialRepo>(() => new MaterialRepo(_ctx));
        _vendorRepo = new Lazy<IVendorRepo>(() => new VendorRepo(_ctx));
        _rawMaterial = new Lazy<IRawMaterialRepo>(() => new RawMaterialRepo(_ctx));
        _dateCode = new Lazy<IDateCode>(() => new DateCodeRepo(_ctx));
        _lotNumber = new Lazy<IProductLotNumber>(() => new RawMaterialLotNumber(_ctx));
        _vendorLot = new Lazy<IVendorLotRepo>(() => new VendorLotRepo(_ctx));
        _sampleStatus = new Lazy<ISampleStatusRepo>(() => new SampleStatusRepo(_ctx));
    }
    public IMaterialRepo MaterialRepo => _materialRepo.Value;
    public IVendorRepo VendorRepo => _vendorRepo.Value;
    public IRawMaterialRepo RawMaterial => _rawMaterial.Value;
    public IDateCode DateCode => _dateCode.Value;
    public IProductLotNumber LotNumber => _lotNumber.Value;
    public IVendorLotRepo VendorLotRepo => _vendorLot.Value;
    public ISampleStatusRepo SampleStatusRepo => _sampleStatus.Value;

    public async Task Save() => await _ctx.SaveChangesAsync();
}