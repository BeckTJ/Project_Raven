using AutoMapper;
using Entities;
using Repo.Contracts;
using Services.Contracts;
using shared.DTO;
using shared.Exceptions;

namespace Services;
internal sealed class MaterialServices : IMaterialServices
{
    private readonly IRepoManager _repo;
    private readonly IMapper _mapper;
    public MaterialServices(IRepoManager repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MaterialDTO>> GetAllMaterial()
    {
        var material = await _repo.MaterialRepo.GetAllMaterial();
        var materialDTO = _mapper.Map<IEnumerable<MaterialDTO>>(material);
        return materialDTO;
    }
    public async Task<MaterialDTO> GetMaterialByMaterialNumber(int materialNumber)
    {
        var material = await _repo.MaterialRepo.GetMaterialByMaterialNumber(materialNumber) ?? throw new MaterialNotFoundException(materialNumber);
        var materialDTO = _mapper.Map<MaterialDTO>(material);
        return materialDTO;
    }
    public async Task<MaterialDTO> AddMaterial(MaterialDTO material)
    {
        var hpMaterial = _mapper.Map<HighPurityMaterial>(material);
        _repo.MaterialRepo.CreateMaterial(hpMaterial);
        await _repo.Save();
        var materialReturn = _mapper.Map<MaterialDTO>(hpMaterial);
        return materialReturn;
    }
    public async Task UpdateMaterial(int materialNumber, MaterialDTO material)
    {
        var hpMaterial = _mapper.Map<HighPurityMaterial>(material);
        _repo.MaterialRepo.UpdateMaterial(hpMaterial);

        await _repo.Save();
    }
    public async Task DeleteMaterial(int materialNumber)
    {
        var material = await _repo.MaterialRepo.GetMaterialByMaterialNumber(materialNumber);
        _repo.MaterialRepo.DeleteMaterial(material);
        await _repo.Save();
    }
}
