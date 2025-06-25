using AutoMapper;
using Repo.Contracts;
using Services.Contracts;
using shared.DTO;

namespace Services;

internal sealed class VendorLotServices : IVendorLotServices
{
    private readonly IRepoManager _repo;
    private readonly IMapper _mapper;
    public VendorLotServices(IRepoManager repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<IEnumerable<VendorLotDTO>> GetAllVendorLots()
    {
        var vendorLots = await _repo.VendorLotRepo.GetAllVendorLots();
        var vendorLotDTO = _mapper.Map<IEnumerable<VendorLotDTO>>(vendorLots);
        return vendorLotDTO;
    }

    public async Task<IEnumerable<VendorLotDTO>> GetVendorLotsByMaterialNumber(int materialNumber)
    {
        var vendorLots = await _repo.VendorLotRepo.GetVendorLotsByMaterialNumber(materialNumber);
        var vendorLotDTO = _mapper.Map<IEnumerable<VendorLotDTO>>(vendorLots);
        //Verify if sample previously submitted
        //if sample previously submitted Verify if sample is approved/rejected

        return vendorLotDTO;
    }
    public async Task<VendorLotDTO> GetVendorLotByLotNumber(string vendorLot)
    {
        var lot = await _repo.VendorLotRepo.GetVendorLotByLotNumber(vendorLot);
        var lotDTO = _mapper.Map<VendorLotDTO>(lot);
        return lotDTO;
    }
}