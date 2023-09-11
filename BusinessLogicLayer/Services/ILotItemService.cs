using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services
{
    public interface ILotItemService
    {
        void AddLotItem(LotItem lotItem);
        List<LotItem> GetAll();
    }
}