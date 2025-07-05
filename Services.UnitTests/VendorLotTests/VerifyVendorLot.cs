using AutoMapper;
using Entities;
using NSubstitute;
using Repo.Contracts;
using Services.Contracts;
using Services.UnitTests.Fakes;
using shared.DTO;

namespace Services.UnitTests.VendorLotTests;

public class VerifyVendorLot
{
    readonly IRepoManager _repo = Substitute.For<IRepoManager>();
    readonly MapperConfiguration _config = new(cfg =>
    {
        cfg.CreateMap<MaterialVendorLot, VendorLotDTO>();
    });

    IServiceManager? _sut;
    [Fact]
    public async void VerifyVendorLot_ByLotNumberAndBatchNumber_ReturnTrue()
    {
        int batchNumber = 3214321;
        string lotNumber = "123-123-123";
        var map = _config.CreateMapper();
        var vendorLots = VendorLotFakeBuilder.VendorLotFake();

        _repo.VendorLotRepo.GetVendorLot(lotNumber, batchNumber).Returns(vendorLots.First());
        _sut = new ServiceManager(_repo, map);

        var actual = await _sut.VendorLotServices.VerifyVendorLot(lotNumber, batchNumber);

        Assert.True(actual);

    }
    [Fact]
    //Figure out why this returns false
    public async void VerifyVendorLot_ByLotNumberAndBatchNumber_ReturnFalse()
    {
        int batchNumber = 3214321;
        string lotNumber = "123-123-128";
        var map = _config.CreateMapper();
        var vendorLots = VendorLotFakeBuilder.VendorLotFake();

        await _repo.VendorLotRepo.GetVendorLot(lotNumber, batchNumber);
        _sut = new ServiceManager(_repo, map);

        var actual = await _sut.VendorLotServices.VerifyVendorLot(lotNumber, batchNumber);

        Assert.False(actual);
    }
    [Fact]
    public async void VerifyVendorLot_ByLotNumberOnly_ReturnTrue()
    {
        string lotNumber = "123-123-123";
        var map = _config.CreateMapper();
        var vendorLots = VendorLotFakeBuilder.VendorLotFake();

        _repo.VendorLotRepo.GetVendorLotByLotNumber(lotNumber).Returns(vendorLots.First());
        _sut = new ServiceManager(_repo, map);

        var actual = await _sut.VendorLotServices.VerifyVendorLot(lotNumber);

        Assert.True(actual);
    }
}