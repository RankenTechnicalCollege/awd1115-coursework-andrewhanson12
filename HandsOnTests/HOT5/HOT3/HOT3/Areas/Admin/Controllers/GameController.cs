using HOT3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace HOT3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        private readonly ShopContext _context;
        public GameController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("admin/games/{genre?}")]
        public IActionResult List(string genre = "all")
        {
            List<Game> games;

            if (genre.Equals("all"))
            {
                games = _context.Games.ToList();
            }
            else
            {
                games = _context.Games.Where(g => g.Genre == genre).ToList();
            }
            return View(games);
        }
        [HttpGet]
        public IActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                var game = _context.Games.Find(id.Value);
                if (game != null)
                {
                    return View("AddEdit", game);
                }
            }
            return View("AddEdit", new Game());
        }
        [HttpPost]
        public IActionResult Add(Game game)
        {
            if (ModelState.IsValid)
            {
                if(game.Id == 0)
                {
                    _context.Games.Add(game);
                }
                else
                {
                    _context.Games.Update(game);
                }
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("AddEdit", game);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                return View(game);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
