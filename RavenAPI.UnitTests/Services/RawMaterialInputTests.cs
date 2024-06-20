using AutoMapper;
using Entities;
using NSubstitute;
using Repo.Contracts;
using Services.Contracts;
using shared.DTO;

namespace RavenAPI.UnitTests;

public class RawMaterialInputTests
{
    private IServiceManager? _sut;
    private readonly IRepoManager _repo = Substitute.For<IRepoManager>();
    private readonly MapperConfiguration _config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<CreateRawMaterialDTO, RawMaterialDTO>();
        cfg.CreateMap<RawMaterialDTO, RawMaterialLog>();
        cfg.CreateMap<RawMaterialLog, RawMaterialDTO>();
    });

    [Fact]
    public void Create_RawMaterial_MaterialNotFound()
    {
        // Arrange

        // Act

        // Assert
    }
    [Fact]
    public void Create_RawMaterial_InitLotNumber()
    {
        // Arrange

        // Act

        // Assert
    }
    [Fact]
    public void Create_RawMaterial_NextLotNumber()
    {
        // Arrange

        // Act

        // Assert
    }
}