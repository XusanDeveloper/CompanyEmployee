using AutoMapper;
using CompanyEmployee.Entities.DataTransferObjects;
using CompanyEmployee.Entities.Models;

namespace CompanyEmployee.Entities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}
