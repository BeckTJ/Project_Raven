using Automation.Contracts;
using Repo.Contracts;

namespace Automation;

public sealed class AutoManager : IAutoManager
{
    private readonly IRepoManager _repo;
    private readonly Lazy<IProductLotNumber> _lotNumber;
    private readonly Lazy<IProductLotNumber> _rmLotNumber;

    public AutoManager(IRepoManager repo)
    {
        _repo = repo;
        _lotNumber = new Lazy<IProductLotNumber>(() => new ProductLotNumber(_repo));
        _rmLotNumber = new Lazy<IProductLotNumber>(() => new RawMaterialLotNumber(_repo));
    }
    public IProductLotNumber ProductLotNumber => _lotNumber.Value;
    public IProductLotNumber RawMaterialLotNumber => _rmLotNumber.Value;
}
