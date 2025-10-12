namespace HOT3.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int? Quantity { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Total { get; set; }
    }
}
