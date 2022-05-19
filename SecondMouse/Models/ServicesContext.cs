using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace SecondMouse.Models
{
    public class ServicesContext : DbContext {
        public ServicesContext(DbContextOptions<ServicesContext> options) : base(options)
        {

        }

        public DbSet<Services> Services { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>().HasData(
                new Models.Services 
                { 
                    state = "NH", 
                    county = "Merrimack", 
                    eFile = true, 
                    RON = true, 
                    RIN = false, 
                    otherService = true, 
                    otherService2 = false 
                },
                new Models.Services
                {
                    state = "FL",
                    county = "Orange",
                    eFile = true,
                    RON = false,
                    RIN = false,
                    otherService = true,
                    otherService2 = true
                },
                new Models.Services
                {
                    state = "TX",
                    county = "Harris",
                    eFile = false,
                    RON = true,
                    RIN = false,
                    otherService = false,
                    otherService2 = true
                });
        }
    }
}
