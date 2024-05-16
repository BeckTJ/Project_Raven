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
        CreateMap<Highpuritymaterial, MaterialDTO>();
        CreateMap<Rawmaterialvendor, MaterialVendorDTO>();
    }
}