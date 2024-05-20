using AutoMapper;
using Entities;
using Repo.Contracts;
using Services.Contracts;
using shared.DTO;

namespace Services;

internal sealed class VendorServices : IVendorServices
{
    private readonly IRepoManager _repo;
    private readonly IMapper _mapper;
    public VendorServices(IRepoManager repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MaterialVendorDTO>> GetAllVendors()
    {
        var vendor = await _repo.VendorRepo.GetAllVendors();
        var vendorDTO = _mapper.Map<IEnumerable<MaterialVendorDTO>>(vendor);
        return vendorDTO;
    }
    public async Task<MaterialVendorDTO> GetVendorByMaterialNumber(int materialNumber)
    {
        var vendor = await _repo.VendorRepo.GetVendorByMaterialNumber(materialNumber);
        var vendorDTO = _mapper.Map<MaterialVendorDTO>(vendor);
        return vendorDTO;
    }
    public async Task<MaterialVendorDTO> GetVendorByVendorName(string vendorName)
    {
        var vendor = await _repo.VendorRepo.GetVendorByVendorName(vendorName);
        var vendorDTO = _mapper.Map<MaterialVendorDTO>(vendor);
        return vendorDTO;
    }
    public async Task<MaterialVendorDTO> AddMaterialVendor(MaterialVendorDTO material)
    {
        //needs to be changed
        var rmMaterial = _mapper.Map<Rawmaterialvendor>(material);
        _repo.VendorRepo.CreateMaterial(rmMaterial);
        await _repo.Save();
        return material;
    }
    public async Task UpdateMaterialVendor(int materialNumber, MaterialVendorDTO material)
    {
        var rmMaterial = _mapper.Map<Rawmaterialvendor>(material);
        _repo.VendorRepo.UpdateMaterial(rmMaterial);
        await _repo.Save();
    }
    public async Task DeleteMaterialVendor(int materialNumber)
    {
        var material = _repo.VendorRepo.GetVendorByMaterialNumber(materialNumber);
        var rmMaterial = _mapper.Map<Rawmaterialvendor>(material);
        _repo.VendorRepo.DeleteMaterial(rmMaterial);
        await _repo.Save();
    }

}
