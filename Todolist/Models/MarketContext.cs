using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
        }
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Market> Markets { get; set; } = null!;
}
