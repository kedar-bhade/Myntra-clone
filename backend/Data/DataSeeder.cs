using System.Linq;
using MyntraCloneBackend.Models;

namespace MyntraCloneBackend.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "T-Shirt", Description = "Cotton T-Shirt", Price = 19.99M, ImageUrl = "/images/tshirt.png" },
                    new Product { Name = "Jeans", Description = "Blue Denim", Price = 49.99M, ImageUrl = "/images/jeans.png" }
                );
                context.SaveChanges();
            }
        }
    }
}
