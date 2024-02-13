using SiteManagementSystem.Business.Abstract;
using SiteManagementSystem.Entities.Concrete;
using SiteManagementSystem.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Business.Concrete
{
    public class FlatService : IFlatService
    {
        private readonly IBlockDal _blockDal;
        private readonly IFlatDal _flatDal;
        public FlatService(IBlockDal blockDal, IFlatDal flatDal)
        {
            _blockDal = blockDal;
            _flatDal = flatDal;
        }

        public void AddBlock(Block block)
        {
            _blockDal.Add(block);
        }

        public void AddFlat(Flat flat)
        {
            _flatDal.Add(flat);
        }

        public void DeleteBlock(int id)
        {
            _blockDal.Delete(new Block { Id = id });
        }

        public void DeleteFlat(int id)
        {
            _flatDal.Delete(new Flat { Id = id });
        }

        public JqGridData<Block> GetBlocksFromJqGrid(int page, int rows, int siteId)
        {
            return _blockDal.GetBlocksFromJqGrid(page, rows, p => p.SiteId == siteId);
        }

        public JqGridData<Flat> GetFlatsFromJqGrid(int page, int rows, int blockId)
        {
            return _flatDal.GetFlatsFromJqGrid(page, rows, p => p.BlockId == blockId);
        }

        public void UpdateBlock(Block block)
        {
            _blockDal.Update(block);
        }

        public void UpdateFlat(Flat flat)
        {
            _flatDal.Update(flat);
        }
    }
}
