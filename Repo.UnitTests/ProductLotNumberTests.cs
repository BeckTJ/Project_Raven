using Entities;
using Repo.Contracts;
using Repo.UnitTests.Fakes;
using shared.DTO;

namespace Repo.UnitTests;

public class ProductLotNumberTests
{
    private readonly ravenContext? MockDb;
    private IRepoManager? _sut;

    public ProductLotNumberTests()
    {
        MockDb = dbContextFake.CreateMaterialVendorDbContext();
    }

    [Fact]
    public async void GetProductLotNumber_NewMaterial_ReturnFirstLotNumber()
    {
        var materialNumber = 12345;
        var expected = "500BR";
        _sut = new RepoManager(MockDb);
        var actual = await _sut.RawMaterialLotNumber.GetProductLotNumber(materialNumber);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public async void GetProductLotNumber_PreviousLot_ReturnNextLotNumber()
    {
        var materialNumber = 451771;
        var expected = "4003AR";
        _sut = new RepoManager(MockDb);
        var actual = await _sut.RawMaterialLotNumber.GetProductLotNumber(materialNumber);

        Assert.Equal(expected, actual);
    }
}