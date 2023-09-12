using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using FakeItEasy;
using FluentAssertions;

namespace StockMarket.Tests.BusinessLogicLayer
{
    public class LotItemServiceTests
    {
        private readonly ILotItemRepository _lotItemRepo;
        private readonly IMapper _mapper;
        private readonly LotItemService _lotItemService;

        public LotItemServiceTests()
        {
            //Dependencies:
            _lotItemRepo = A.Fake<ILotItemRepository>();
            _mapper = A.Fake<IMapper>();

            //SUT:
            _lotItemService = new LotItemService(_lotItemRepo, _mapper);
        }

        [Theory]
        [InlineData(270, 40)]
        public void LotItemService_SaleShareTransaction_ReturnExectedResult(int ShareNumber, decimal SharePrice)
        {
            //Arrange
            A.CallTo(() => _lotItemRepo.GetAll()).Returns(GetAllLotItems());

            var saleTransactionModel = new SaleTransactionModel() { ShareNumber = ShareNumber, SharePrice = SharePrice };
            var expected = new SaleShareResultModel()
            {
                RemainShareNumber = 100,
                SoldSharesPrice = 24.814814814814814814814814815m,
                RamainSharesPrice = 0m,
                TotalSaleResult = 4100,
                IsFailed = false
            };

            //Act
            var result = _lotItemService.SaleShareTransaction(saleTransactionModel);

            //Assert
            result.Should().BeOfType<SaleShareResultModel>();
            result.Should().BeEquivalentTo(expected);
        }
        [Theory]
        [InlineData(371, 40)]
        [InlineData(999, 40)]
        public void LotItemService_SaleShareTransaction_ReturnFiledResult(int ShareNumber, decimal SharePrice)
        {
            //Arrange
            A.CallTo(() => _lotItemRepo.GetAll()).Returns(GetAllLotItems());
            var saleTransactionModel = new SaleTransactionModel() { ShareNumber = ShareNumber, SharePrice = SharePrice };

            //Act
            var result = _lotItemService.SaleShareTransaction(saleTransactionModel);

            //Assert
            result.IsFailed.Should().BeTrue();
        }

        private List<LotItemEntity> GetAllLotItems()
        {
            return new List<LotItemEntity>()
                {
                    new LotItemEntity() { Id = 1, ShareNumber = 100, RemainShareNumber = 100, SharePrice = 20.00m, Date = new DateTime(2023, 1, 1) },
                    new LotItemEntity() { Id = 2, ShareNumber = 150, RemainShareNumber = 150, SharePrice = 30.00m, Date = new DateTime(2023, 2, 1) },
                    new LotItemEntity() { Id = 3, ShareNumber = 120, RemainShareNumber = 120, SharePrice = 10.00m, Date = new DateTime(2023, 3, 1) }
                };
        }
    }
}
