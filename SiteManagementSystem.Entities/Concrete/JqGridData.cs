using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Entities.Concrete
{
    public class JqGridData<T> where T : class
    {
        public int Page { get; set; }
        public int Total { get; set; }
        public int Records { get; set; }
        public List<T> Rows { get; set; } = new List<T>();
    }
}
