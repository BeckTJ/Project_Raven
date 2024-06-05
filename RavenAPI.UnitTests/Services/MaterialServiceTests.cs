using Services.Contracts;
using NSubstitute;
using Repo.Contracts;
using shared.Exceptions;
using Services;

namespace RavenAPI.UnitTests;

public class MaterialServiceTests
{
    private IServiceManager? _sut;
    private readonly IRepoManager _repo = Substitute.For<IRepoManager>();

    [Fact]
    public async void GetMaterial_ByMaterialNumber_NotFound()
    {
        var materialNumber = 11111;
        _sut = new ServiceManager(null, null);

        var e = await Record.ExceptionAsync(() => _sut.MaterialService.GetMaterialByMaterialNumber(materialNumber));
        var ex = Assert.IsType<MaterialNotFoundException>(e);
        Assert.StartsWith("The material number", ex.Message);
    }
    [Fact]
    public void TestName()
    {
        // Arrange
        var materialNumber = 31777;
        _sut = new ServiceManager(_repo, null);
        // Act
        var actual = _sut.MaterialService.GetMaterialByMaterialNumber(materialNumber);
        // Assert
    }
}