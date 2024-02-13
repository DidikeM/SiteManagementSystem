using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Business.Abstract
{
    public interface IFlatService
    {
        void AddBlock(Block block);
        void AddFlat(Flat flat);
        void DeleteBlock(int id);
        void DeleteFlat(int id);
        JqGridData<Block> GetBlocksFromJqGrid(int page, int rows, int siteId);
        JqGridData<Flat> GetFlatsFromJqGrid(int page, int rows, int blockId);
        void UpdateBlock(Block block);
        void UpdateFlat(Flat flat);
    }
}
