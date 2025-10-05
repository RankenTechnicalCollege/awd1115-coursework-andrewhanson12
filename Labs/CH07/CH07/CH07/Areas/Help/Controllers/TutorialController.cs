using Microsoft.AspNetCore.Mvc;

namespace CH07.Areas.Help.Controllers
{
    [Area("Help")]
    public class TutorialController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            if (id < 1) id = 1;
            if (id > 3) id = 3;

            var tutorial = id switch
            {
                2 => "Page2",
                3 => "Page3",
                _ => "Page1"
            };

            ViewBag.Page = id;
            return View(tutorial);
        }
    }
}
