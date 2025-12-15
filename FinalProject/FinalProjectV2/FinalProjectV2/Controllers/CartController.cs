using FinalProjectV2.Data;
using FinalProjectV2.Models;
using FinalProjectV2.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectV2.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetCart();
            var vm = new CartVM { Items = cart.Items };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int ticketTypeId, int quantity = 1)
        {
            if (quantity < 1) quantity = 1;

            var ticketType = _context.TicketTypes
                .Include(t => t.Event)
                .FirstOrDefault(t => t.TicketTypeId == ticketTypeId);

            if (ticketType == null)
            {
                TempData["message"] = "That ticket type was not found.";
                return RedirectToAction("Index", "Event");
            }

            var cart = HttpContext.Session.GetCart();

            var existing = cart.Items.FirstOrDefault(i => i.TicketTypeId == ticketTypeId);
            if (existing == null)
            {
                cart.Items.Add(new CartItem
                {
                    TicketTypeId = ticketType.TicketTypeId,
                    TicketName = $"{ticketType.Event?.Name} - {ticketType.Name}",
                    Price = ticketType.Price,
                    Quantity = quantity
                });
            }
            else
            {
                existing.Quantity += quantity;
            }

            HttpContext.Session.SaveCart(cart);

            TempData["message"] = "Added to cart.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int ticketTypeId, int quantity)
        {
            var cart = HttpContext.Session.GetCart();

            var item = cart.Items.FirstOrDefault(i => i.TicketTypeId == ticketTypeId);
            if (item != null)
            {
                if (quantity <= 0)
                    cart.Items.Remove(item);
                else
                    item.Quantity = quantity;

                HttpContext.Session.SaveCart(cart);
                TempData["message"] = "Cart updated.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int ticketTypeId)
        {
            var cart = HttpContext.Session.GetCart();

            var item = cart.Items.FirstOrDefault(i => i.TicketTypeId == ticketTypeId);
            if (item != null)
            {
                cart.Items.Remove(item);
                HttpContext.Session.SaveCart(cart);
                TempData["message"] = "Removed from cart.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            HttpContext.Session.ClearCart();
            TempData["message"] = "Cart cleared.";
            return RedirectToAction("Index");
        }
    }
}

