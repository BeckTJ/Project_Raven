using Repo.Contracts;
using Repo.UnitTests.Fakes;
using Entities;

namespace Repo.UnitTests.RawMaterialTests;

public class GetVendorLotByRawMaterial
{
    private readonly ravenContext? _ctx;
    private IRepoManager? _sut;

    public GetVendorLotByRawMaterial()
    {
        _ctx = dbContextFake.CreateRawMaterialDBContext();
    }

    [Fact]
    public async void GetRawMaterial_ByVendorLot_ReturnLast()
    {
        //Arrange
        string vendorLotNumber = "12-123-1234";
        _sut = new RepoManager(_ctx);

        //Act
        var rawMaterial = await _sut.RawMaterial.GetRawMaterialByVendorLot(vendorLotNumber);

        //Assert
        Assert.Contains(vendorLotNumber, rawMaterial.Lot.VendorLotNumber);
    }
    [Fact]
    public async void GetRawMaterial_ByVendorLot_ReturnNull()
    {

    }
}