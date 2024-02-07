using SiteManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Entities.Concrete
{
    public class Flat : IEntity
    {
        public int Id { get; set; }
        public int FlatNumber { get; set; }
        public int BlockId { get; set; }
        public Block Block { get; set; } = null!;
    }
}
