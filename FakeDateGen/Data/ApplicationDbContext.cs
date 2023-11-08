using FakeDateGen.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeDateGen.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Product> Product { get; set; }
    }
}
