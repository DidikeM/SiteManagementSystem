using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class EfBlockDal : EfEntityRepositoryBase<Block, SiteManagementSystemContext>, IBlockDal
    {
        private readonly IDbContextFactory<SiteManagementSystemContext> _contextFactory;
        public EfBlockDal(IDbContextFactory<SiteManagementSystemContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public JqGridData<Block> GetBlocksFromJqGrid(int page, int rows, Expression<Func<Block, bool>> filter = null!)
        {
            using var context = _contextFactory.CreateDbContext();
            var blocks = context.Blocks.AsQueryable();
            if (filter != null)
            {
                blocks = blocks.Where(filter);
            }

            int skip = (page - 1) * rows;
            skip = skip < 0 ? 0 : skip;

            var count = blocks.Count();

            return new JqGridData<Block>
            {
                Page = page,
                Records = count,
                Total = (int)Math.Ceiling(count / (decimal)rows),
                Rows = blocks.Skip(skip).Take(rows).ToList()
            };
        }
    }
}
