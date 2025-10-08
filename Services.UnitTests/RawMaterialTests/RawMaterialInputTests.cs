using AutoMapper;
using Entities;
using NSubstitute;
using Repo.Contracts;
using Services.Contracts;
using Services.UnitTests.Fakes;
using shared.DTO;

namespace Services.UnitTests.RawMaterialTests;

public class RawMaterialInputTests
{
    readonly IRepoManager _repo = Substitute.For<IRepoManager>();
    readonly MapperConfiguration _config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<RawMaterialLog, RawMaterialDTO>();
        cfg.CreateMap<MaterialVendorLot, VendorLotDTO>();
    });
    IServiceManager? _sut;
    [Fact]
    public async void CreateRawMaterialDrum_NewVendorLot()
    {
        //Arrange
        var rawMaterial = new CreateRawMaterialDTO
        {
            VendorLotNumber = "BRI-9999",
            BatchNumber = 9879876,
            Quantity = 6,
            MaterialNumber = 451771
        };
        var map = _config.CreateMapper();
        await _repo.VendorLotRepo.GetVendorLot(rawMaterial.VendorLotNumber, rawMaterial.BatchNumber);
        _sut = new ServiceManager(_repo, map);

        //Act

        var rawMaterialSample = await _sut.RawMaterialInputServices.CreateRawMaterial(rawMaterial);

        //Assert

    }

    [Fact]
    public async void CreateRawMaterialDrum_OldVendorLot()
    {
        //Arrange
        var rawMaterial = new CreateRawMaterialDTO
        {
            VendorLotNumber = "BRI-2345",
            BatchNumber = 1231234,
            Quantity = 2,
            MaterialNumber = 451771
        };
        var map = _config.CreateMapper();
        var vendorLotFake = VendorLotFakeBuilder.VendorLotFake();
        _repo.VendorLotRepo.GetVendorLot(rawMaterial.VendorLotNumber, rawMaterial.BatchNumber).Returns(vendorLotFake.First(v => v.VendorLotNumber == rawMaterial.VendorLotNumber && rawMaterial.BatchNumber == rawMaterial.BatchNumber));
        _sut = new ServiceManager(_repo, map);
        //Act
        var rawMaterialSample = await _sut.RawMaterialInputServices.CreateRawMaterial(rawMaterial);
        //Assert
    }

    [Fact]
    public async void CreateRawMaterialDrum_Reclaim()
    {
        //Arrange
        var rawMaterial = new CreateRawMaterialDTO
        {
            VendorLotNumber = "Reclaim",
            BatchNumber = 0,
            Quantity = 1,
            MaterialNumber = 3209876
        };
        var map = _config.CreateMapper();
        _sut = new ServiceManager(_repo, map);

        //Act
        var rawMaterialSample = await _sut.RawMaterialInputServices.CreateRawMaterial(rawMaterial);
        //Assert

    }
}