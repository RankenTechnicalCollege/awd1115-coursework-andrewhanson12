using HOT3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace HOT3.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShopContext _context;
        private List<ShoppingCartItem> _cartItems;
        public ShoppingCartController(ShopContext context)
        {
            _context = context;
            _cartItems = new List<ShoppingCartItem>();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCart(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var gameToAdd = _context.Games.Find(id);
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var existingCartItem = cartItems.FirstOrDefault(item => item.Game.Id == id);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                cartItems.Add(new ShoppingCartItem { Game = gameToAdd, Quantity = 1 });
            }
            HttpContext.Session.Set("Cart", cartItems);
            TempData["CartMessage"] = $"{gameToAdd.Name} has been added to your cart.";
            return RedirectToAction("ViewCart");
        }
        public IActionResult ViewCart()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var cartViewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(item => item.Game.Price * item.Quantity)
            };
            ViewBag.CartMessage = TempData["CartMessage"];
            return View(cartViewModel);
        }
        public IActionResult RemoveItem(int id)
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var itemToRemove = cartItems.FirstOrDefault(item => item.Game.Id == id);
            TempData["CartMessage"] = $"{itemToRemove.Game.Name} has been removed from your cart.";
            if (itemToRemove != null)
            {
                if (itemToRemove.Quantity > 1)
                {
                    itemToRemove.Quantity--;
                }
                else
                {
                    cartItems.Remove(itemToRemove);
                }
            }
            HttpContext.Session.Set("Cart", cartItems);
            return RedirectToAction("ViewCart");
        }
        public IActionResult PurchaseItems()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            foreach (var item in cartItems)
            {
                _context.Purchases.Add(new Purchase 
                {
                    GameId = item.Game.Id,
                    Quantity = item.Quantity,
                    PurchaseDate = DateTime.Now,
                    Total = item.Game.Price * item.Quantity
                });
            }
            _context.SaveChanges();

            HttpContext.Session.Set("Cart", new List<ShoppingCartItem>());

            return RedirectToAction("Index", "Home");
        }
    }
}
