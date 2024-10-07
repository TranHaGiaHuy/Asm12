using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Customer_Service.Models
{
    public class CustomerDbContext : DbContext
    {

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
            var passwordHasher = new PasswordHasher<Customer>();

        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            var passwordHasher = new PasswordHasher<Customer>();

            optionsBuilder.Entity<Customer>().HasData(
            new Customer { Username = "user1", Password = passwordHasher.HashPassword(null, "1") , Fullname = "Tran Ha Gia Huy", Birthday = DateOnly.Parse("2003-01-12"), Gender = "Nam", Email = "huy@gmail.com", Phone = "0399176334", Address = "120 Can tho" },
            new Customer { Username = "user2", Password = passwordHasher.HashPassword(null, "1"), Fullname = "Tran Ha Gia Huy2", Birthday = DateOnly.Parse("2003-01-12"), Gender = "Nam", Email = "huy2@gmail.com", Phone = "0399176334", Address = "120 Can tho" },
            new Customer { Username = "user3", Password = passwordHasher.HashPassword(null, "1"), Fullname = "Tran Ha Gia Huy3", Birthday = DateOnly.Parse("2003-01-12"), Gender = "Nam", Email = "huy3@gmail.com", Phone = "0399176334", Address = "120 Can tho" }
            );
        }
    }
}
