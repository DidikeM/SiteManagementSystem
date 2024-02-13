using Microsoft.EntityFrameworkCore;
using SiteManagementSystem.DataAccess.Abstract;
using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfSiteDal : EfEntityRepositoryBase<Site, SiteManagementSystemContext>, ISiteDal
    {
        private readonly IDbContextFactory<SiteManagementSystemContext> _contextFactory;
        public EfSiteDal(IDbContextFactory<SiteManagementSystemContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Site> GetSitesWithAddress()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Sites.Include(s => s.District).ThenInclude(d => d.City).ToList();
        }

        public JqGridData<Site> GetSitesWithAddressFromJqGrid(int page, int rows, Expression<Func<Site, bool>> filter = null!)
        {
            using var context = _contextFactory.CreateDbContext();
            var sites = context.Sites.Include(s => s.District).ThenInclude(d => d.City).AsQueryable();
            if (filter != null)
            {
                sites = sites.Where(filter);
            }
            int skip = (page - 1) * rows;
            skip = skip < 0 ? 0 : skip;
            return new JqGridData<Site>
            {
                Page = page,
                Records = sites.Count(),
                Total = (int)Math.Ceiling(sites.Count() / (decimal)rows),
                Rows = sites.Skip(skip).Take(rows).ToList()
            };
        }
    }
}
