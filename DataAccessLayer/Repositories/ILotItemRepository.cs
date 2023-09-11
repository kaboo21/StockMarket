using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface ILotItemRepository
    {
        void Add(LotItemEntity lot);
        bool Delete(int id);
        List<LotItemEntity> GetAll();
        LotItemEntity GetById(int id);
        bool Update(LotItemEntity lot);
    }
}