using System.Collections.Generic;
using System.Linq;

namespace FinalProjectV2.Models.Cart
{
    public class CartVM
    {
        public List<CartItem> Items { get; set; } = new();
        public decimal Total => Items.Sum(i => i.LineTotal);
    }
}


