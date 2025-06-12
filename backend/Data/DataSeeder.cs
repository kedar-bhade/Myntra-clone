using System.Linq;
using MyntraCloneBackend.Models;

namespace MyntraCloneBackend.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Men" },
                    new Category { Name = "Women" },
                    new Category { Name = "Kids" }
                );
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var men = context.Categories.First(c => c.Name == "Men");
                var women = context.Categories.First(c => c.Name == "Women");

                context.Products.AddRange(
                    new Product { Name = "T-Shirt", Description = "Cotton T-Shirt", Price = 19.99M, ImageUrl = "/images/tshirt.png", CategoryId = men.Id },
                    new Product { Name = "Jeans", Description = "Blue Denim", Price = 49.99M, ImageUrl = "/images/jeans.png", CategoryId = men.Id },
                    new Product { Name = "Dress", Description = "Red Dress", Price = 39.99M, ImageUrl = "/images/dress.png", CategoryId = women.Id }
                );
                context.SaveChanges();
            }

            if (!context.Reviews.Any())
            {
                var tshirt = context.Products.First(p => p.Name == "T-Shirt");
                context.Reviews.AddRange(
                    new Review { ProductId = tshirt.Id, Author = "Alice", Content = "Great quality!", Rating = 5 },
                    new Review { ProductId = tshirt.Id, Author = "Bob", Content = "Good value", Rating = 4 }
                );
                context.SaveChanges();
            }
        }
    }
}
