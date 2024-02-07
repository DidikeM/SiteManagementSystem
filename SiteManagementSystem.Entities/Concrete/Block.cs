using SiteManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Entities.Concrete
{
    public class Block : IEntity
    {
        public int Id { get; set; }
        public string BlockName { get; set; } = null!;
        public int SiteId { get; set; }
        public Site Site { get; set; } = null!;
        public List<Flat> Flats { get; set; } = null!;
    }
}
