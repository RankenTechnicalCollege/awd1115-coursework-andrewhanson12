using Microsoft.AspNetCore.Mvc;
using HOT3.Models;

namespace HOT3.Controllers
{
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

        [Route("games/{genre?}")]
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
        [Route("games/details/{id:int}/{slug?}")]
        public IActionResult Details(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null && game.ImageFileName != null)
            {
                game.ImageFileName = "/Images/" + game.ImageFileName;
            }
            return View(game);
        }
    }
}
