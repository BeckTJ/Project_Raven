using Services.Contracts;
using NSubstitute;
using Repo.Contracts;
using Services;

namespace RavenAPI.UnitTests;

public class MaterialServiceTests
{
    private IServiceManager _sut;
    private readonly IRepoManager _repo = Substitute.For<IRepoManager>();

    [Fact]
    public async void GetMaterial_ByMaterialNumber_NotFound()
    {
        var materialNumber = 0;
        _sut = new ServiceManager(null, null);

        var e = await Record.ExceptionAsync(() => _sut.MaterialService.GetMaterialByMaterialNumber(materialNumber));
        var ex = Assert.IsType<MaterialNotFoundException>(e);
        Assert.StartsWith("Material Number", ex.Message);
    }
}