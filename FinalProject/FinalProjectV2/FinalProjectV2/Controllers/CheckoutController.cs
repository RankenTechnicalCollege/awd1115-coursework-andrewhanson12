using FinalProjectV2.Data;
using FinalProjectV2.Models;
using FinalProjectV2.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProjectV2.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetCart();
            if (cart.Items.Count == 0)
            {
                TempData["message"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            var vm = new CartVM { Items = cart.Items };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder()
        {
            var cart = HttpContext.Session.GetCart();
            if (cart.Items.Count == 0)
            {
                TempData["message"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                Status = "Placed"
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cart.Items)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    TicketTypeId = item.TicketTypeId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                };

                _context.OrderItems.Add(orderItem);
            }

            _context.SaveChanges();

            HttpContext.Session.ClearCart();

            return RedirectToAction("Confirmation", new { id = order.OrderId });
        }

        public IActionResult Confirmation(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}


