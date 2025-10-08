using shared.DTO;

namespace Services.Contracts;

public interface IRawMaterialInputServices
{
    public Task<RawMaterialSampleDTO> CreateRawMaterial(CreateRawMaterialDTO rawMaterial);
}