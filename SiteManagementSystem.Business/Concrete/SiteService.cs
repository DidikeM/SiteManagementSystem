using SiteManagementSystem.Business.Abstract;
using SiteManagementSystem.DataAccess.Abstract;
using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Business.Concrete
{
    public class SiteService : ISiteService
    {
        private readonly IDistrictDal _districtDal;
        private readonly ICityDal _cityDal;
        private readonly ISiteDal _siteDal;
        public SiteService(IDistrictDal districtDal, ICityDal cityDal, ISiteDal siteDal)
        {
            _districtDal = districtDal;
            _cityDal = cityDal;
            _siteDal = siteDal;
        }

        public void AddSite(Site site)
        {
            _siteDal.Add(site);
        }

        public List<City> GetCities()
        {
            return _cityDal.GetAll();
        }

        public List<District> GetDistrictsByCityId(int cityId)
        {
            return _districtDal.GetAll(d => d.CityId == cityId);
        }
    }
}
