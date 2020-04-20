using CurrencyTrading.Money.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CurrencyTrading
{
    public class TradingEngineDbContext : DbContext
    {
        public TradingEngineDbContext(DbContextOptions<TradingEngineDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User.Domain.Model.User>()
                .HasOne(b => b.Balance)
                .WithOne(i => i.User)
                .HasForeignKey<Balance>(b => b.UserId);
        }

        public DbSet<User.Domain.Model.User> Users { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyBalance> CurrencyBalances { get; set; }
    }
}
