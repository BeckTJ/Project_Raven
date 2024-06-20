using AutoMapper;
using Entities;
using shared.DTO;

namespace RavenAPI;

public class MappingProfile : Profile
{
    /*
     * CreateMap<Company, CompanyDTO>()
     *      .ForCtorParam("FullAddress",
     *          opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
     */
    public MappingProfile()
    {
        CreateMap<HighPurityMaterial, MaterialDTO>();
        CreateMap<MaterialDTO, HighPurityMaterial>();

        CreateMap<RawMaterialVendor, MaterialVendorDTO>();
        CreateMap<MaterialVendorDTO, RawMaterialVendor>();

        CreateMap<RawMaterialLog, RawMaterialDTO>();
        CreateMap<RawMaterialDTO, RawMaterialLog>();
        CreateMap<CreateRawMaterialDTO, RawMaterialDTO>();
    }
}