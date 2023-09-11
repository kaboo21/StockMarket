namespace StockMarket.DTOs
{
    public class SaleTransactionResultDto
    {
        public int RemainShareNumber { get; set; }
        public decimal SoldSharesPrice { get; set; }
        public decimal RamainSharesPrice { get; set; }
        public decimal TotalSaleResult { get; set; }
    }
}
