using SiteManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Entities.Concrete
{
    public class PersonNote : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public Person Person { get; set; } = null!;
    }
}
