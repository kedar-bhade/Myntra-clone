using Microsoft.EntityFrameworkCore;
using MyntraCloneBackend.Models;

namespace MyntraCloneBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Product> Products { get; set; }
    }
}
