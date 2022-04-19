using Microsoft.EntityFrameworkCore;

namespace Pomoro_Language_Learning.Models
{
    public class ApplicationDbContext1 :DbContext
    {
        public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> options) : base(options)
        {

        }

        public DbSet<LoginAndRegister> login { get; set; }
    }
}
