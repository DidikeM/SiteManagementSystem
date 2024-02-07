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
        List<City> GetCities();
        List<District> GetDistrictsByCityId(int cityId);
    }
}
