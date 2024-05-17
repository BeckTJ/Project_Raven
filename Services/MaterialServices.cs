using AutoMapper;
using Entities;
using Repo.Contracts;
using Services.Contracts;
using shared.DTO;

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
        var material = await _repo.MaterialRepo.GetMaterialByMaterialNumber(materialNumber);
        var materialDTO = _mapper.Map<MaterialDTO>(material);
        return materialDTO;
    }
    public void AddMaterial(MaterialDTO material)
    {
        var hpMaterial = _mapper.Map<Highpuritymaterial>(material);
        _repo.MaterialRepo.CreateMaterial(hpMaterial);
    }
        public void UpdateMaterial(MaterialDTO material)
    {
        var hpMaterial = _mapper.Map<Highpuritymaterial>(material);
        _repo.MaterialRepo.UpdateMaterial(hpMaterial);
    }
    public void DeleteMaterial(MaterialDTO material)
    {
        var hpMaterial = _mapper.Map<Highpuritymaterial>(material);
        _repo.MaterialRepo.DeleteMaterial(hpMaterial);
    }

}
