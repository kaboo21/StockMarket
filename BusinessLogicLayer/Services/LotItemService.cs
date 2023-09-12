using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    public class LotItemService : ILotItemService
    {
        private readonly ILotItemRepository _lotItemRepo;
        private readonly IMapper _mapper;

        public LotItemService(ILotItemRepository lotItemRepository, IMapper mapper)
        {
            _lotItemRepo = lotItemRepository;
            _mapper = mapper;
        }

        public List<LotItemModel> GetAll()
        {
            var lotItemEntities = _lotItemRepo.GetAll();

            return _mapper.Map<List<LotItemModel>>(lotItemEntities);
        }

        public void AddLotItem(LotItemModel lotItem)
        {
            var lotItemEntity = _mapper.Map<LotItemEntity>(lotItem);
            _lotItemRepo.Add(lotItemEntity);
        }

        public SaleShareResultModel SaleShareTransaction(SaleTransactionModel saleTransaction)
        {
            var lotItemEntities = _lotItemRepo.GetAll();
            var totalShareNumber = lotItemEntities.Sum(l => l.ShareNumber);

            var result = new SaleShareResultModel();

            if (saleTransaction.ShareNumber > totalShareNumber)
            {
                result.IsFailed = true;
                return result;
            }


            var totalNumberToSale = saleTransaction.ShareNumber;
            var totalSaleAmount = 0m;
            var totalSaleDifference = 0m;
            var totalRamainAmount = 0m;

            foreach (var lot in lotItemEntities)
            {
                if (totalNumberToSale > 0)
                {
                    var nextNumberToSale = totalNumberToSale > lot.ShareNumber ? lot.ShareNumber : totalNumberToSale;

                    var lotUpdated = _lotItemRepo.SaleLotItemNumber(lot.Id, nextNumberToSale);

                    totalNumberToSale -= nextNumberToSale;
                    totalSaleAmount += nextNumberToSale * lot.SharePrice;
                    totalSaleDifference += nextNumberToSale * (saleTransaction.SharePrice - lot.SharePrice);

                    if (totalNumberToSale == 0 && lotUpdated.RemainShareNumber > 0)
                    {
                        totalRamainAmount += lotUpdated.RemainShareNumber * lot.SharePrice;
                    }
                }
                else
                {
                    totalRamainAmount += lot.ShareNumber * lot.SharePrice;
                }
            }

            result.RemainShareNumber = totalShareNumber - saleTransaction.ShareNumber;
            result.SoldSharesPrice = totalSaleAmount / saleTransaction.ShareNumber;
            result.RamainSharesPrice = totalRamainAmount / result.RemainShareNumber;
            result.TotalSaleResult = totalSaleDifference;


            return result;
        }
    }
}
