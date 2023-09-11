﻿using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using StockMarket.DTOs;

namespace StockMarket.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockCalculationsController : ControllerBase
    {
        private readonly ILotItemService _lotItemService;
        private readonly IMapper _mapper;

        public StockCalculationsController(ILotItemService lotItemService, IMapper mapper)
        {
            _lotItemService = lotItemService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<SaleTransactionResultDto> SaleShareTransaction(SaleTransactionRequest request)
        {
            var saleTransaction = _mapper.Map<SaleTransactionModel>(request);
            var result = _lotItemService.SaleShareTransaction(saleTransaction);

            return _mapper.Map<SaleTransactionResultDto>(result);
        }

    }
}
