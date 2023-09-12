namespace BusinessLogicLayer.Models
{
    public class SaleShareResultModel
    {
        public int RemainShareNumber { get; set; }
        public decimal SoldSharesPrice { get; set; }
        public decimal RamainSharesPrice { get; set; }
        public decimal TotalSaleResult { get; set; }

        public bool IsFailed { get; set; }
    }
}
