using Automation.Contracts;
using Repo.Contracts;
using NSubstitute;
using Automation;
using Entities;
using shared.Exceptions;

namespace Automation.Tests;

public class RawMaterialLotNumberTests
{
    private IAutoManager _sut;
    private readonly List<RawMaterialLog> rawMaterial = new()
    {
        new RawMaterialLog()
        {
            MaterialNumber = 12345,
            ProductLotNumber = "100AA4A21"
        },
        new RawMaterialLog()
        {
            MaterialNumber = 12345,
            ProductLotNumber = "101AA4F08"
        }
    };
    private readonly IRepoManager _repo = Substitute.For<IRepoManager>();
    RawMaterialVendor material = new()
    {
        MaterialNumber = 12345,
        MaterialCode = "AA",
        SequenceId = 100
    };
    DateCode code = new()
    {
        DateId = DateTime.Now.Month,
        DateCode1 = 'F'
    };

    [Fact]
    public async void Get_InitLotNumber_MaterialNotFound()
    {
        _sut = new AutoManager(_repo);

        var e = await Record.ExceptionAsync(() => _sut.RawMaterialLotNumber.GetInitialLotNumber(0));
        var ex = Assert.IsType<MaterialNotFoundException>(e);

        Assert.StartsWith("The material", ex.Message);
    }

    [Fact]
    public async void Get_InitLotNumber_Pass()
    {
        //Arrange
        var actual = "100AA";
        _repo.VendorRepo.GetVendorByMaterialNumber(12345).Returns(material);
        _sut = new AutoManager(_repo);

        //Act
        var lotNumber = await _sut.RawMaterialLotNumber.GetInitialLotNumber(material.MaterialNumber);

        //Assert
        Assert.Equal(actual, lotNumber);
    }
    [Fact]
    public async void Update_LotNumber_Pass()
    {
        var lotNumber = "100AA";
        var currentDay = DateTime.Now.Day;
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year % 10;
        var expected = $"100AA{currentYear}F{currentDay}";

        _repo.DateCode.GetDateCode(currentMonth).Returns(code);
        _sut = new AutoManager(_repo);
        var actual = await _sut.ProductLotNumber.UpdateLotNumber(lotNumber);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public async void Get_LastLotNumber_Pass()
    {
        var materialNumber = 12345;
        _repo.RawMaterial.GetRawMaterialByMaterialNumber(materialNumber).Returns(rawMaterial);
        _sut = new AutoManager(_repo);
    }
    [Fact]
    public async void Get_LastLotNumber_NotFound()
    {
        int materialNumber = 12345;
        _sut = new AutoManager(_repo);

        var e = await Record.ExceptionAsync(() => _sut.RawMaterialLotNumber.GetLastLotNumber(materialNumber));
        var ex = Assert.IsType<RawMaterialNotFoundException>(e);

        Assert.StartsWith("Raw material", ex.Message);
    }
}