using Microsoft.AspNetCore.Mvc;
using Pomoro_Language_Learning.Areas.Identity.Data;

namespace Pomoro_Language_Learning.Controllers
{
    public class FlashCardsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FlashCardsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.ToList();
            return View(objFlashCardsList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
