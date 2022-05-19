using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace SecondMouse.Models
{
    public class ServicesContext : DbContext {
        public ServicesContext(DbContextOptions<ServicesContext> options) : base(options)
        {

        }

        public DbSet<Services> Services { get; set; } = null!;
        public DbSet<SigningServices> SigningServices { get; set; } = null!;
    }
}
