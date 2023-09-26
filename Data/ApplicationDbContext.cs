using Microsoft.EntityFrameworkCore;
using parcial.Models;

namespace parcial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Parcial> Parcial { get; set; }
    }
}
