using SiteManagementSystem.Entities.Concrete;
using SiteManagementSystem.WebUI.DTOs;

namespace SiteManagementSystem.WebUI.Models
{
    public class SiteAddModel
    {
        public List<City> Cities { get; set; } = new List<City>();
        public AddSiteDto AddSiteDto { get; set; } = null!;
    }
}
