using E_CommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        

    }
}
