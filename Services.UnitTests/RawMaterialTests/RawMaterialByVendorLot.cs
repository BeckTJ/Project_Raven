using AutoMapper;
using Entities;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Services.Contracts;
using Repo.Contracts;
using shared.DTO;
using Repo.UnitTests.Fakes;

namespace Services.UnitTests.RawMaterialTests;

public class RawMaterialByVendorLot
{
    readonly IRepoManager _repo = Substitute.For<IRepoManager>();
    readonly MapperConfiguration _config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<RawMaterialLog, RawMaterialDTO>();
        cfg.CreateMap<MaterialVendorLot, VendorLotDTO>();
        cfg.CreateMap<SampleStatus, SampleStatusDTO>();
    });
    IServiceManager? _sut;
    [Fact]
    public async Task GetRawMaterial_ByVendorLot_ReturnSingleResult()
    {
        var vendorLot = "12-123-1234";
        var productLot = "4001AA5J27";
        var map = _config.CreateMapper();
        var rawMaterial = RawMaterialLogFakeBuilder.RawMaterialLogFake();
        _repo.RawMaterial.GetRawMaterialByVendorLot(vendorLot).Returns(rawMaterial.First(x => x.Lot.VendorLotNumber.Equals(vendorLot) && x.ProductLotNumber.Equals(productLot)));

        _sut = new ServiceManager(_repo, map);

        var actual = await _sut.RawMaterialService.GetRawMaterialByVendorLot(vendorLot);

        Assert.Contains(vendorLot, actual.Lot.VendorLotNumber);
        Assert.Contains(productLot, actual.ProductLotNumber);
    }
}