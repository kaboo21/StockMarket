using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface ILotItemRepository
    {
        void Add(LotItemEntity lot);
        bool Delete(int id);
        List<LotItemEntity> GetAll();
        LotItemEntity GetById(int id);
        LotItemEntity? SaleLotItemNumber(int id, int numberToSale);
        bool Update(LotItemEntity lot);
    }
}