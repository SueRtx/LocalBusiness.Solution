using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace LocalApi.Models
{
    public class LocalApiContext : IdentityDbContext
    {
        public LocalApiContext(DbContextOptions<LocalApiContext> options)
            : base(options)
        {
        }
        
        public DbSet<Business> Businesses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Business>()
            .HasData(
                new Business { BusinessId = 1, Name = "Matilda", Description = "Restaurant", Location = "Baytown" },
                new Business { BusinessId = 2, Name = "Rexie", Description = "Shop", Location = "" },
                new Business { BusinessId = 3, Name = "Blue Room", Description = "Shop", Location = "Beachcity" },
                new Business { BusinessId = 4, Name = "Pipeline", Description = "Restaurant", Location = "Baytown" },
                new Business { BusinessId = 5, Name = "Sweet Dream", Description = "Shop", Location = "Houston" }
            );
        } 
    }
}