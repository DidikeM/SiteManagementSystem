using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManagementSystem.Business.Abstract;
using SiteManagementSystem.Entities.Concrete;
using SiteManagementSystem.WebUI.DTOs;

namespace SiteManagementSystem.WebUI.Controllers
{
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;
        private readonly IMapper _mapper;
        public FlatController(IFlatService flatService, IMapper mapper)
        {
            _flatService = flatService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SiteDetail(int id)
        {
            ViewBag.SiteId = id;
            return View();
        }

        public IActionResult GetBlocks(int id, int page, int rows)
        {
            JqGridData<Block> data = _flatService.GetBlocksFromJqGrid(page, rows, id);
            var jqGridData = new JqGridData<BlockDto>
            {
                Page = data.Page,
                Records = data.Records,
                Total = data.Total,
                Rows = _mapper.Map<List<BlockDto>>(data.Rows)!
            };
            return Json(jqGridData);
        }

        public IActionResult AddBlock(AddBlockDto addBlockDto)
        {
            var block = _mapper.Map<Block>(addBlockDto);
            _flatService.AddBlock(block!);
            return Ok();
        }

        public IActionResult UpdateBlock(UpdateBlockDto updateBlockDto)
        {
            var block = _mapper.Map<Block>(updateBlockDto);
            _flatService.UpdateBlock(block!);
            return Ok();
        }

        public IActionResult DeleteBlock(int id)
        {
            _flatService.DeleteBlock(id);
            return Ok();
        }

        public IActionResult GetFlats(int id, int page, int rows)
        {
            JqGridData<Flat> data = _flatService.GetFlatsFromJqGrid(page, rows, id);
            var jqGridData = new JqGridData<FlatDto>
            {
                Page = data.Page,
                Records = data.Records,
                Total = data.Total,
                Rows = _mapper.Map<List<FlatDto>>(data.Rows)!
            };
            return Json(jqGridData);
        }

        public IActionResult AddFlat(AddFlatDto addFlatDto)
        {
            var flat = _mapper.Map<Flat>(addFlatDto);
            _flatService.AddFlat(flat!);
            return Ok();
        }

        public IActionResult UpdateFlat(UpdateFlatDto updateFlatDto)
        {
            var flat = _mapper.Map<Flat>(updateFlatDto);
            _flatService.UpdateFlat(flat!);
            return Ok();
        }

        public IActionResult DeleteFlat(int id)
        {
            _flatService.DeleteFlat(id);
            return Ok();
        }
    }
}
