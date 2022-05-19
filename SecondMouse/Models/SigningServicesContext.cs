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
    }
}
