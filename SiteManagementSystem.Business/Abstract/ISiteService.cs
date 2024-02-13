using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Business.Abstract
{
    public interface ISiteService
    {
        void AddSite(Site site);
        void DeleteSite(int id);
        List<City> GetCities();
        List<District> GetDistrictsByCityId(int cityId);
        List<Site> GetSites();
        List<Site> GetSitesWithAddress();
        JqGridData<Site> GetSitesWithAddressFromJqGrid(int page, int rows);
        void UpdateSite(Site site);
    }
}
