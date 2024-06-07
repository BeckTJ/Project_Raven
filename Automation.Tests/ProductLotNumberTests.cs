using Automation.Contracts;
using Repo.Contracts;
using NSubstitute;
using Automation;
using Entities;

namespace Automation.Tests;

public class ProductLotNumberTests
{
    private IAutoManager _sut;
    private readonly IRepoManager _repo = Substitute.For<IRepoManager>();
    HighPurityMaterial material = new()
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
    public async void Get_InitLotNumber_Pass()
    {
        //Arrange
        var actual = "100AA";
        _repo.MaterialRepo.GetMaterialByMaterialNumber(12345).Returns(material);
        _sut = new AutoManager(_repo);

        //Act
        var lotNumber = await _sut.ProductLotNumber.GetInitialLotNumber(material.MaterialNumber);

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
}