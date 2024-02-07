using AutoMapper;
using SiteManagementSystem.Entities.Concrete;
using SiteManagementSystem.WebUI.DTOs;

namespace SiteManagementSystem.WebUI.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddSiteDto, Site>().ReverseMap();
        }
    }
}
