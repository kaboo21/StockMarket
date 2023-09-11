using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services
{
    public interface ILotItemService
    {
        void AddLotItem(LotItemModel lotItem);
        List<LotItemModel> GetAll();
        SaleShareResultModel SaleShareTransaction(SaleTransactionModel saleTransaction);
    }
}