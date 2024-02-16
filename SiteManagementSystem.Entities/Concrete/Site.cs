using SiteManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Entities.Concrete
{
    public class Site : IEntity
    {
        public int Id { get; set; }
        public string SiteName { get; set; } = null!;
        public string AddressDetail { get; set; } = null!;
        public int DistrictId { get; set; }
        public string TypeOfHeating { get; set; } = null!;
        public int? SiteManagerId { get; set; }
        public District District { get; set; } = null!;
        public List<Block> Blocks { get; set; } = null!;
        public User? SiteManager { get; set; }
    }
}
