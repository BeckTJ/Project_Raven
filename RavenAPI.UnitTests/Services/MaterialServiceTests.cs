using Services.Contracts;
using NSubstitute;
using Repo.Contracts;
using shared.Exceptions;
using Services;
using AutoMapper;
using Entities;
using shared.DTO;

namespace RavenAPI.UnitTests;

public class MaterialServiceTests
{
    private IServiceManager? _sut;
    private readonly IRepoManager _repo = Substitute.For<IRepoManager>();
    private readonly MapperConfiguration _config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<HighPurityMaterial, MaterialDTO>();
    });

    [Fact]
    public async void GetMaterial_ByMaterialNumber_NotFound()
    {
        var materialNumber = 11111;
        var _map = _config.CreateMapper();
        _sut = new ServiceManager(_repo, _map);

        var e = await Record.ExceptionAsync(() => _sut.MaterialService.GetMaterialByMaterialNumber(materialNumber));
        var ex = Assert.IsType<MaterialNotFoundException>(e);
        Assert.StartsWith("The material number", ex.Message);
    }
    [Fact]
    public void TestName()
    {
        // Arrange
        var materialNumber = 31777;
        var _map = _config.CreateMapper();
        _repo.MaterialRepo.GetMaterialByMaterialNumber(materialNumber);
        _sut = new ServiceManager(_repo, _map);
        // Act
        var actual = _sut.MaterialService.GetMaterialByMaterialNumber(materialNumber);
        // Assert
    }
}