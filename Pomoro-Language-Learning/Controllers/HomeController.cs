using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Pomoro_Language_Learning.Models;
using System.Diagnostics;

namespace Pomoro_Language_Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(IStringLocalizer<HomeController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
          //  _logger = logger;
        //}

        public IActionResult Index()
        {
            // Call values from the resource files
            // ViewData["PageTitle"] = _stringLocalizer["page.title"].Value;
            ViewData["PageTitle"] = _stringLocalizer["page.title"].Value;
            ViewData["PageDesc"] = _stringLocalizer["page.description"].Value;

            return View();
        }

        public IActionResult Privacy()
        {
            // Call values from the resource files
            ViewData["PageTitle"] = _stringLocalizer["page.title"].Value;
            ViewData["PageDesc"] = _stringLocalizer["page.description"].Value;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}