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

        public List<LotItem> GetAll()
        {
            var lotItemEntities = _lotItemRepo.GetAll();

            return _mapper.Map<List<LotItem>>(lotItemEntities);
        }

        public void AddLotItem(LotItem lotItem)
        {
            var lotItemEntity = _mapper.Map<LotItemEntity>(lotItem);
            _lotItemRepo.Add(lotItemEntity);
        }




    }
}
