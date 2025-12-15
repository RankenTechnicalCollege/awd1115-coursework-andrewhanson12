namespace FinalProjectV2.Models.Cart
{
    public class CartItem
    {
        public int TicketTypeId { get; set; }
        public string TicketName { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal LineTotal => Price * Quantity;
    }
}




