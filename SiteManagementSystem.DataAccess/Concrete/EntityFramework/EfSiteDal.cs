using Microsoft.EntityFrameworkCore;
using SiteManagementSystem.DataAccess.Abstract;
using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfSiteDal : EfEntityRepositoryBase<Site, SiteManagementSystemContext>, ISiteDal
    {
        public EfSiteDal(IDbContextFactory<SiteManagementSystemContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
