using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManagementSystem.Business.Abstract;
using SiteManagementSystem.Entities.Concrete;
using SiteManagementSystem.WebUI.DTOs;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSites(int page, int rows)
        {
            var data = _siteService.GetSitesWithAddressFromJqGrid(page, rows);
            var jqGridData = new JqGridData<SiteDto>
            {
                Page = data.Page,
                Records = data.Records,
                Total = data.Total,
                Rows = _mapper.Map<List<SiteDto>>(data.Rows)!
            };
            return Json(jqGridData);
            var sites = _mapper.Map<List<SiteDto>>(_siteService.GetSitesWithAddress());
            var total = Math.Ceiling(sites!.Count / (decimal)rows);
            return Json(new { rows = sites!.Skip((page - 1) * rows).Take(rows), total, page, records = sites!.Count });
        }

        //public IActionResult Add()
        //{
        //    var model = new SiteAddModel
        //    {
        //        Cities = _siteService.GetCities()
        //    };
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult Add(AddSiteDto addSiteDto)
        {
            var site = _mapper.Map<Site>(addSiteDto);
            _siteService.AddSite(site!);

            return Ok();
        }

        public IActionResult Update(UpdateSiteDto updateSiteDto)
        {
            var site = _mapper.Map<Site>(updateSiteDto);
            _siteService.UpdateSite(site!);
            return Ok();
        }

        public IActionResult Delete(int id)
        {
            _siteService.DeleteSite(id);
            return Ok();
        }

        public List<District> GetDistricts(int cityId)
        {
            return _siteService.GetDistrictsByCityId(cityId);
        }

        public List<City> GetCities()
        {
            return _siteService.GetCities();
        }
    }
}
