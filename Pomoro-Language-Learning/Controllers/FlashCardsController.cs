using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var i = 4;
            IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw($"Select * FROM FlashCards WHERE Id = 4{i}")
                .ToList();
            return View(objFlashCardsList);
        }




        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FlashCards obj)
        {
            _db.FlashCards.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
