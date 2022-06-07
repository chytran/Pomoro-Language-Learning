using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomoro_Language_Learning.Areas.Identity.Data;
using System.Data.SqlClient;

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
            using (var con = new SqlConnection("Server=tcp:pomoro-server.database.windows.net,1433;Initial Catalog=pomoro-db;Persist Security Info=False;User ID=pomoro-sql;Password=2021graduate!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM FlashCards";
                using (var cmd = new SqlCommand(query, con))
                {
                    int rowsAmount = (int)cmd.ExecuteScalar();
                    IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw("Select * FROM FlashCards WHERE Id = floor(rand()*" + rowsAmount + ")");
                    return View(objFlashCardsList);
                }
            }
            // var i = 4;
            //var count = _db.FlashCards.FromSqlRaw("SELECT COUNT(*) FROM FlashCards");
            // IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw($"Select * FROM FlashCards WHERE Id = 4{i}")

            
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

        // GET
        public IActionResult Know()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Know(ReviewCards obj1)
        {
            //_db.FlashCards.Add(obj1);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Review()
        {
            using (var con = new SqlConnection("Server=tcp:pomoro-server.database.windows.net,1433;Initial Catalog=pomoro-db;Persist Security Info=False;User ID=pomoro-sql;Password=2021graduate!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM FlashCards";
                using (var cmd = new SqlCommand(query, con))
                {
                    int rowsAmount = (int)cmd.ExecuteScalar();
                    IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw("Select * FROM FlashCards WHERE Id = floor(rand()*" + rowsAmount + ")");
                    return View(objFlashCardsList);
                }
            }
            // var i = 4;
            //var count = _db.FlashCards.FromSqlRaw("SELECT COUNT(*) FROM FlashCards");
            // IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw($"Select * FROM FlashCards WHERE Id = 4{i}")


        }


        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Review(FlashCards obj)
        {
            return RedirectToAction("Review");
        }

        // GET
        public IActionResult Previous()
        {
            using (var con = new SqlConnection("Server=tcp:pomoro-server.database.windows.net,1433;Initial Catalog=pomoro-db;Persist Security Info=False;User ID=pomoro-sql;Password=2021graduate!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                // get query for previous card, if no previous, randomize
                string query = "SELECT COUNT(*) FROM FlashCards";
                using (var cmd = new SqlCommand(query, con))
                {
                    int rowsAmount = (int)cmd.ExecuteScalar();
                    IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw("Select * FROM FlashCards WHERE Id = floor(rand()*" + rowsAmount + ")");
                    return View(objFlashCardsList);
                }
            }
            // var i = 4;
            //var count = _db.FlashCards.FromSqlRaw("SELECT COUNT(*) FROM FlashCards");
            // IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw($"Select * FROM FlashCards WHERE Id = 4{i}")


        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Previous(FlashCards obj)
        {
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Check()
        {
            using (var con = new SqlConnection("Server=tcp:pomoro-server.database.windows.net,1433;Initial Catalog=pomoro-db;Persist Security Info=False;User ID=pomoro-sql;Password=2021graduate!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM FlashCards";
                using (var cmd = new SqlCommand(query, con))
                {
                    int rowsAmount = (int)cmd.ExecuteScalar();
                    IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw("Select * FROM FlashCards WHERE Id = floor(rand()*" + rowsAmount + ")");
                    return View(objFlashCardsList);
                }
            }
            // var i = 4;
            //var count = _db.FlashCards.FromSqlRaw("SELECT COUNT(*) FROM FlashCards");
            // IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw($"Select * FROM FlashCards WHERE Id = 4{i}")


        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Check(FlashCards obj)
        {
            return RedirectToAction("Review");
        }

        // GET
        public IActionResult Next()
        {
            using (var con = new SqlConnection("Server=tcp:pomoro-server.database.windows.net,1433;Initial Catalog=pomoro-db;Persist Security Info=False;User ID=pomoro-sql;Password=2021graduate!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                // get query for previous card, if no previous, randomize
                string query = "SELECT COUNT(*) FROM FlashCards";
                using (var cmd = new SqlCommand(query, con))
                {
                    int rowsAmount = (int)cmd.ExecuteScalar();
                    // get random card from deck
                    IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw("Select * FROM FlashCards WHERE Id = floor(rand()*" + rowsAmount + ")");
                    return View(objFlashCardsList);
                }
            }
            // var i = 4;
            //var count = _db.FlashCards.FromSqlRaw("SELECT COUNT(*) FROM FlashCards");
            // IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw($"Select * FROM FlashCards WHERE Id = 4{i}")


        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Next(FlashCards obj)
        {
            return RedirectToAction("Index");
        }
    }
}
