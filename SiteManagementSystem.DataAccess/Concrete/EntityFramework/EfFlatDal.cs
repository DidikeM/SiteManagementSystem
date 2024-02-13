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
    public class EfFlatDal : EfEntityRepositoryBase<Flat, SiteManagementSystemContext>, IFlatDal
    {
        private readonly IDbContextFactory<SiteManagementSystemContext> _contextFactory;

        public EfFlatDal(IDbContextFactory<SiteManagementSystemContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public JqGridData<Flat> GetFlatsFromJqGrid(int page, int rows, Expression<Func<Flat, bool>> filter = null!)
        {
            using var context = _contextFactory.CreateDbContext();
            var flats = context.Flats.AsQueryable();
            if (filter != null)
            {
                flats = flats.Where(filter);
            }

            int skip = (page - 1) * rows;
            skip = skip < 0 ? 0 : skip;

            var count = flats.Count();

            return new JqGridData<Flat>
            {
                Page = page,
                Records = count,
                Total = (int)Math.Ceiling(count / (decimal)rows),
                Rows = flats.Skip(skip).Take(rows).ToList()
            };
        }
    }
}
