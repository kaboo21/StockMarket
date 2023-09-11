namespace StockMarket.DTOs
{
    public class LotItemRequest
    {
        public int ShareNumber { get; set; }
        public decimal SharePrice { get; set; }
        public DateTime Date { get; set; }
    }
}
