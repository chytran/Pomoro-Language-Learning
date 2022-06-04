using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomoro_Language_Learning.Areas.Identity.Data;
using System.Data.SqlClient;

namespace Pomoro_Language_Learning.Controllers
{
    public class KnowController : Controller
    {
        private readonly ApplicationDbContext _db;

        public KnowController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            using (var con = new SqlConnection("Server=tcp:pomoro-server.database.windows.net,1433;Initial Catalog=pomoro-db;Persist Security Info=False;User ID=pomoro-sql;Password=2021graduate!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM ReviewCards";
                using (var cmd = new SqlCommand(query, con))
                {
                    int rowsAmount = (int)cmd.ExecuteScalar();
                    //if(rowsAmount == 0)
                    //{

                    //}
                    IEnumerable<FlashCards> objFlashCardsList = _db.FlashCards.FromSqlRaw("Select * FROM ReviewCards WHERE Id = floor(rand()*" + rowsAmount + ")");
                    // add flash card list to the view page
                    return View(objFlashCardsList);
                }
            }
        }
    }
}
