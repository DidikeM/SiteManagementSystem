using SiteManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; } = null!;
        public List<District> Districts { get; set; } = null!;
    }
}
