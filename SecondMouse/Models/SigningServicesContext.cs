using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace SecondMouse.Models
{
    public class SigningServicesContext : DbContext
    {
        public SigningServicesContext(DbContextOptions<SigningServicesContext> options) : base(options)
        {

        }

        public DbSet<SigningServices> SigningServices { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SigningServices>().HasData(
                new Models.SigningServices
                {
                    name = "Joe Signing Service",
                    email = "jsign@gmail.com",
                    address = "23 Main Street",
                    city = "Concord",
                    state = "NH"
                },
                new Models.SigningServices
                {
                    name = "Other Signing Service",
                    email = "other@gmail.com",
                    address = "23 Main Street",
                    city = "Concord",
                    state = "NH"
                },
                new Models.SigningServices
                {
                    name = "The Best Signing Service",
                    email = "bestsign@gmail.com",
                    address = "321 Alligator Drive",
                    city = "Orlando",
                    state = "FL"
                },
                new Models.SigningServices
                {
                    name = "A Different Signing Service",
                    email = "different@gmail.com",
                    address = "456 Willow Way",
                    city = "Tampa",
                    state = "FL"
                });
        }
    }
}
