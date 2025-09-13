using BootCamp2_6_weekEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BootCamp2_6_weekEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

    }
                
         
        
}
