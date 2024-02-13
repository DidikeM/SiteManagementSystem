using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.DataAccess.Abstract
{
    public interface IFlatDal : IEntityRepository<Flat>
    {
        JqGridData<Flat> GetFlatsFromJqGrid(int page, int rows, Expression<Func<Flat, bool>> filter = null!);
    }
}
