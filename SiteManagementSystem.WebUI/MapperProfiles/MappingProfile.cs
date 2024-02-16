using AutoMapper;
using SiteManagementSystem.Entities.Concrete;
using SiteManagementSystem.WebUI.DTOs;

namespace SiteManagementSystem.WebUI.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddSiteDto, Site>();

            CreateMap<Site, SiteDto>()
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.District.Id))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.District.City.Name))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.District.City.Id));

            CreateMap<UpdateSiteDto, Site>();

            CreateMap<Block, BlockDto>();
            CreateMap<AddBlockDto, Block>();
            CreateMap<UpdateBlockDto, Block>();

            CreateMap<Flat, FlatDto>();
            CreateMap<AddFlatDto, Flat>();
            CreateMap<UpdateFlatDto, Flat>();

            CreateMap<UserRegisterDto, User>();
        }
    }
}
