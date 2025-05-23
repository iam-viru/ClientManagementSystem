using ClientManagementSystem.Models; // Adjust namespace to where your Client model is
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Your custom entity sets
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // This is important! It configures Identity tables

            // Additional Fluent API configurations go here if needed
            // Example:
            // builder.Entity<Client>().Property(c => c.Name).IsRequired();
        }
    }
}
