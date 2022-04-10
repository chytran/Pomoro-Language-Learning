using Microsoft.EntityFrameworkCore;

namespace Pomoro_Language_Learning.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<LoginAndRegister> login { get; set; }
    }
}
