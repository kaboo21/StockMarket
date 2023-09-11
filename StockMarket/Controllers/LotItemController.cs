using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using StockMarket.DTOs;

namespace StockMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotItemController : ControllerBase
    {
        private readonly ILotItemService _lotItemService;
        private readonly IMapper _mapper;

        public LotItemController(ILotItemService lotItemService, IMapper mapper)
        {
            _lotItemService = lotItemService;
            _mapper = mapper;
        }

        
        [HttpGet]
        [Route("lots")]
        public ActionResult<List<LotItemDto>> GetAllLotItems()
        {
            var lots = _lotItemService.GetAll();

            return Ok(_mapper.Map<List<LotItemDto>>(lots));
        }

        [HttpPost]
        public ActionResult AddLotItem(LotItemRequest lotItemRequest)
        {
            var lotToAdd = _mapper.Map<LotItemModel>(lotItemRequest);

            _lotItemService.AddLotItem(lotToAdd);

            return Ok();
        }
    }
}
