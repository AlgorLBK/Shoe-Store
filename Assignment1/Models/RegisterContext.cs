using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(DbContextOptions<RegisterContext> options)
            : base(options)
        { }
        public DbSet<Registration> Registers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //seeding the (initial) table
            modelBuilder.Entity<Registration>().HasData(
                new Registration()
                {
                    Id = 1,
                    username= "algor@gmail.com",
                    type = "Seller",
                    password= "test",
                },
                new Registration()
                {
                    Id = 2,
                    username = "lombako@gmail.com",
                    type =  "Buyer",
                    password = "test",
                }
            );
        }

    }
}
