using Microsoft.EntityFrameworkCore;

namespace LocalApi.Models
{
    public class LocalApiContext : DbContext
    {
        public LocalApiContext(DbContextOptions<LocalApiContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Business>()
            .HasData(
                new Business { BusinessId = 1, Name = "Matilda", Description = "Woolly Mammoth", Location = "Baytown" },
                new Business { BusinessId = 2, Name = "Rexie", Description = "Dinosaur", Location = "Baytown" },
                new Business { BusinessId = 3, Name = "Matilda", Description = "Dinosaur", Location = "Baytown" },
                new Business { BusinessId = 4, Name = "Pip", Description = "Shark", Location = "Baytown" },
                new Business { BusinessId = 5, Name = "Bartholomew", Description = "Dinosaur", Location = "Baytown" }
            );
        }
        

        public DbSet<Business> Businesses { get; set; }
    }
}