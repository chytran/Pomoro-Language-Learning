using Microsoft.AspNetCore.Mvc;

namespace Pomoro_Language_Learning.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
