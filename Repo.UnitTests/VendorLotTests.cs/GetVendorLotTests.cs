using Entities;
using Repo.Contracts;
using Repo.UnitTests.Fakes;

namespace Repo.UnitTests;

public class GetVendorLot
{
    private readonly ravenContext? _ctx;
    private IRepoManager? _sut;

    public GetVendorLot()
    {
        _ctx = dbContextFake.CreateVendorLotDbContext();
    }
    [Fact]
    public async void GetVendorLot_ByLotNumberAndBatchNumber_ReturnLotId()
    {
        string lotNumber = "123-12-1234";
        int batchNumber = 3211234;
        int lotId = 123;

        _sut = new RepoManager(_ctx);

        var lot = await _sut.VendorLotRepo.GetVendorLot(lotNumber, batchNumber);

        Assert.Equal(lotId, lot.LotId);

    }
}