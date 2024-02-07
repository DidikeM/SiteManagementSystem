using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManagementSystem.Business.Abstract;
using SiteManagementSystem.Entities.Concrete;
using SiteManagementSystem.WebUI.Models;

namespace SiteManagementSystem.WebUI.Controllers
{
    public class SiteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISiteService _siteService;
        public SiteController(IMapper mapper, ISiteService siteService)
        {
            _mapper = mapper;
            _siteService = siteService;
        }

        public IActionResult Add()
        {
            var model = new SiteAddModel
            {
                Cities = _siteService.GetCities()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(SiteAddModel model)
        {
            var site = _mapper.Map<Site>(model.AddSiteDto);
            _siteService.AddSite(site!);

            return RedirectToAction("Add", "Site");
        }

        public List<District> GetDistricts(int cityId)
        {
            return _siteService.GetDistrictsByCityId(cityId);
        }
    }
}
