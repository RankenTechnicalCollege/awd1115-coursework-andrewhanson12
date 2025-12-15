using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace FinalProjectV2.Models.Cart
{
    public static class SessionExtensions
    {
        private const string CartKey = "cart";

        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var json = session.GetString(key);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }

        public static Cart GetCart(this ISession session)
        {
            return session.GetObject<Cart>(CartKey) ?? new Cart();
        }

        public static void SaveCart(this ISession session, Cart cart)
        {
            session.SetObject(CartKey, cart);
        }

        public static void ClearCart(this ISession session)
        {
            session.Remove(CartKey);
        }
    }
}


