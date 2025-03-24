using EsercizioS7L1.Models;
using Microsoft.EntityFrameworkCore;

namespace EsercizioS7L1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
