using System.Text.Json;

namespace FinalProjectV2.Models.Cart
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new();

        public void Add(CartItem item, int qty)
        {
            var existing = Items.FirstOrDefault(i => i.TicketTypeId == item.TicketTypeId);
            if (existing == null)
            {
                item.Quantity = qty;
                Items.Add(item);
            }
            else
            {
                existing.Quantity += qty;
            }
        }

        public void Update(int ticketTypeId, int qty)
        {
            var item = Items.FirstOrDefault(i => i.TicketTypeId == ticketTypeId);
            if (item == null) return;
            if (qty <= 0) Items.Remove(item);
            else item.Quantity = qty;
        }

        public decimal Total() => Items.Sum(i => i.Price * i.Quantity);

        public static Cart GetCart(ISession session)
        {
            var json = session.GetString("cart");
            return string.IsNullOrEmpty(json) ? new Cart() : JsonSerializer.Deserialize<Cart>(json)!;
        }

        public static void SaveCart(ISession session, Cart cart)
            => session.SetString("cart", JsonSerializer.Serialize(cart));

        public static void Clear(ISession session) => session.Remove("cart");
    }
}

