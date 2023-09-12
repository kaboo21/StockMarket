using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockMarket.DTOs
{
    public class LotItemRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        [DefaultValue(1)]
        public int ShareNumber { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal SharePrice { get; set; }
        public DateTime Date { get; set; }
    }
}
