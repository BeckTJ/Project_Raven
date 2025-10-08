using Entities;
using Repo.Contracts;
using Repo.UnitTests.Fakes;

namespace Repo.UnitTests;

public class AddVendorLot
{
    private readonly ravenContext? _ctx;
    private IRepoManager? _sut;

    public AddVendorLot()
    {
        _ctx = new ravenContext();
    }
    [Fact]
    public async void AddVendorLot_oldVendor()
    {
        MaterialVendorLot lot = new()
        {
            LotId = 1,
            MaterialNumber = 31777,
            VendorLotNumber = "123-1234-12",
            Quantity = 4,
            BatchNumber = 1231234
        };


        _sut = new RepoManager(_ctx);
        var oldLot = await _sut.VendorLotRepo.GetVendorLot(lot.VendorLotNumber, lot.BatchNumber);
        var total = oldLot.Quantity + lot.Quantity;
        lot.Quantity += oldLot.Quantity;
        _sut.VendorLotRepo.UpdateVendorLot(lot);
        _sut.VendorLotRepo.SaveChanges();

        var lotId = await _sut.VendorLotRepo.GetVendorLot(lot.VendorLotNumber, lot.BatchNumber);

        Assert.Equal(total, lotId.Quantity);
    }
    [Fact]
    public async void AddVendorLot_NewLot()
    {
        MaterialVendorLot lot = new()
        {
            LotId = 0,
            MaterialNumber = 31777,
            VendorLotNumber = "123-1234-1233",
            Quantity = 4,
            BatchNumber = 1231239
        };

        _sut = new RepoManager(_ctx);
        _sut.VendorLotRepo.AddVendorLot(lot);
        _sut.VendorLotRepo.SaveChanges();
        var newLot = await _sut.VendorLotRepo.GetVendorLot(lot.VendorLotNumber, lot.BatchNumber);

        Assert.Equal(lot.Quantity, newLot.Quantity);
    }
}