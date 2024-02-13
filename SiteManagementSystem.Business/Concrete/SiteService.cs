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

        public void DeleteSite(int id)
        {
            _siteDal.Delete(new Site { Id = id });
        }

        public List<City> GetCities()
        {
            return _cityDal.GetAll();
        }

        public List<District> GetDistrictsByCityId(int cityId)
        {
            return _districtDal.GetAll(d => d.CityId == cityId);
        }

        public List<Site> GetSites()
        {
            return _siteDal.GetAll();
        }

        public List<Site> GetSitesWithAddress()
        {
            return _siteDal.GetSitesWithAddress();
        }

        public JqGridData<Site> GetSitesWithAddressFromJqGrid(int page, int rows)
        {
            return _siteDal.GetSitesWithAddressFromJqGrid(page, rows);
        }

        public void UpdateSite(Site site)
        {
            _siteDal.Update(site);
        }
    }
}
