using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Nike" },
                new Category { CategoryID = 2, Name = "Adidas" },
                new Category { CategoryID = 3, Name = "Puma" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1, 
                    CategoryID = 1,
                    Code = "nike_mercurial",
                    Name = "Nike Mercurial",
                    StartBid = "12/1/2022",
                    EndBid = "5/15/2023",
                    Condition = "Good",
                    Description = "Shoes",
                    Price = (decimal)125.00, 
                    UserAuhtor = "admin@gmail.com"
                },
                new Product
                {
                    ProductID = 2,
                    CategoryID = 1,
                    Code = "nike_vapor",
                    Name = "Nike Vapor",
                    StartBid = "12/1/2022",
                    EndBid = "5/15/2023",
                    Condition = "Good",
                    Description = "Shoes",
                    Price = (decimal)208.85,
                    UserAuhtor = "admin@gmail.com"
                },
                new Product
                {
                    ProductID = 3,
                    CategoryID = 3,
                    Code = "puma_future",
                    Name = "Puma Future",
                    StartBid = "12/1/2022",
                    EndBid = "5/15/2023",
                    Condition = "Good",
                    Description = "Shoes",
                    Price = (decimal)285.00,
                    UserAuhtor = "admin@gmail.com"
                },
                new Product
                {
                    ProductID = 4,
                    CategoryID = 3,
                    Code = "puma_court",
                    Name = "Court Rider",
                    StartBid = "12/1/2022",
                    EndBid = "5/15/2023",
                    Condition = "Good",
                    Description = "Shoes",
                    Price = (decimal)120.00,
                    UserAuhtor = "admin@gmail.com"
                },
                new Product
                {
                    ProductID = 5,
                    CategoryID = 2,
                    Code = "adidas_ozelia",
                    Name = "Adidas Ozelia",
                    StartBid = "12/1/2022",
                    EndBid = "5/15/2023",
                    Condition = "Good",
                    Description = "Shoes",
                    Price = (decimal)130.00,
                    UserAuhtor = "admin@gmail.com"
                },
                new Product
                {
                    ProductID = 6,
                    CategoryID = 2,
                    Code = "adidas_ozweego",
                    Name = "Adidas Ozweego",
                    StartBid = "12/1/2022",
                    EndBid = "5/15/2023",
                    Condition = "Good",
                    Description = "Shoes",
                    Price = (decimal)170.00,
                    UserAuhtor = "admin@gmail.com"
                }
            );
        }
    }
}