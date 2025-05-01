using Gym_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym_Store.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Optimum Nutrition Gold Standard 100% Whey",
                    Type = "Protein Powder",
                    Price = 98.95m,
                    Quantity = "2.27 kg",
                    ImageUrl = null
                },
                new Product
                {
                    Id = 2,
                    Name = "Myprotein Impact Whey Isolate",
                    Type = "Protein Powder",
                    Price = 70.50m,
                    Quantity = "1 kg",
                    ImageUrl = null
                },
                new Product
                {
                    Id = 3,
                    Name = "INC Creatine Monohydrate",
                    Type = "Creatine Supplement",
                    Price = 39.95m,
                    Quantity = "500 g",
                    ImageUrl = null
                },
                new Product
                {
                    Id = 4,
                    Name = "EHP Labs Pride Pre-Workout",
                    Type = "Pre-Workout",
                    Price = 79.95m,
                    Quantity = "40 Serves",
                    ImageUrl = null
                },
                new Product
                {
                    Id = 5,
                    Name = "Optimum Nutrition Gold Standard Pre-Workout",
                    Type = "Pre-Workout",
                    Price = 39.90m,
                    Quantity = "30 Serves",
                    ImageUrl = null
                },
                new Product
                {
                    Id = 6,
                    Name = "Musashi Pre-Workout Purple Grape",
                    Type = "Pre-Workout",
                    Price = 29.99m,
                    Quantity = "225 g",
                    ImageUrl = null
                }
            );
        }
    }
}
