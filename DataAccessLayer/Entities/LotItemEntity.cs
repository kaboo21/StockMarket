namespace DataAccessLayer.Entities
{
    public class LotItemEntity
    {
        public int Id { get; set; }
        public int ShareNumber { get; set; }
        public int RemainShareNumber { get; set; }
        public decimal SharePrice { get; set; }
        public DateTime Date { get; set; }
    }
}
