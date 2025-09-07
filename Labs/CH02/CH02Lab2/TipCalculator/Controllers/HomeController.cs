using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Fifteen = 0;
            ViewBag.Twenty = 0;
            ViewBag.TwentyFive = 0;
            return View();
        }
        public IActionResult Index(CalculateTip tip) 
        { 
            ViewBag.Fifteen = tip.CalculateTipFifteenPercent();
            ViewBag.Twenty = tip.CalculateTipTwentyPercent();
            ViewBag.TwentyFive = tip.CalculateTipTwentyFivePercent();
            return View();
        }

    }
}
