using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.DataAccess.Abstract
{
    public interface ISiteDal : IEntityRepository<Site>
    {
        List<Site> GetSitesWithAddress();
        JqGridData<Site> GetSitesWithAddressFromJqGrid(int page, int rows, Expression<Func<Site, bool>> filter = null!);
    }
}
