using Microsoft.EntityFrameworkCore;

namespace LocalApi.Models
{
    public class LocalApiContext : DbContext
    {
        public LocalApiContext(DbContextOptions<LocalApiContext> options)
            : base(options)
        {
        }

        public DbSet<Business> Businesses { get; set; }
    }
}