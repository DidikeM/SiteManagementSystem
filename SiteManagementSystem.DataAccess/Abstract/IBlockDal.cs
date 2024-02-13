using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.DataAccess.Abstract
{
    public interface IBlockDal : IEntityRepository<Block>
    {
        JqGridData<Block> GetBlocksFromJqGrid(int page, int rows, Expression<Func<Block, bool>> filter = null!);
    }
}
