using AutoMapper;
using Entities;
using Repo.Contracts;
using Services.Contracts;
using shared.DTO;

namespace Services;

internal sealed class RawMaterialServices : IRawMaterialServices
{
    private readonly IRepoManager _repo;
    private readonly IMapper _mapper;

    public RawMaterialServices(IRepoManager repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RawMaterialDTO>> GetAllRawMaterial()
    {
        var material = await _repo.RawMaterial.GetAllRawMaterial();
        var rawMaterial = _mapper.Map<IEnumerable<RawMaterialDTO>>(material);

        return rawMaterial.OrderBy(m => m.MaterialNumber);
    }
    public async Task<IEnumerable<RawMaterialDTO>> GetRawMaterialByMaterialNumber(int materialNumber)
    {
        var material = await _repo.RawMaterial.GetRawMaterialByMaterialNumber(materialNumber);
        var rawMaterial = _mapper.Map<IEnumerable<RawMaterialDTO>>(material);

        return rawMaterial.OrderByDescending(m => m.ProductLotNumber);
    }
    public async Task<RawMaterialDTO> GetRawMateriaByProductLotNumber(string lotNumber)
    {
        var material = await _repo.RawMaterial.GetRawMaterialByProductLotNumber(lotNumber);
        var rawMaterial = _mapper.Map<RawMaterialDTO>(material);

        return rawMaterial;
    }
    public async Task<RawMaterialDTO> CreateRawMaterial(RawMaterialDTO rawMaterial)
    {
        var material = _mapper.Map<RawMaterialLog>(rawMaterial);
        _repo.RawMaterial.CreateRawMaterial(material);
        await _repo.Save();
        return rawMaterial;
    }
    public async Task UpdateRawMaterial(RawMaterialDTO rawMaterial)
    {
        var material = _mapper.Map<RawMaterialLog>(rawMaterial);
        _repo.RawMaterial.UpdateRawMaterial(material);
        await _repo.Save();
    }
    public async Task DeleteRawMaterial(string productId)
    {
        var rawMaterial = await _repo.RawMaterial.GetRawMaterialByProductLotNumber(productId);
        _repo.RawMaterial.DeleteRawMaterial(rawMaterial);
        await _repo.Save();
    }
}