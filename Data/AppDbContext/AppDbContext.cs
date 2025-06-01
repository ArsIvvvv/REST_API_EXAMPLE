using CarAPI.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Data.AppDContext
{
    public class AppDbContext: DbContext
    {
        public DbSet<CarEntity> Cars { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>()
                .HasDiscriminator<string>("Manufacturer")
                .HasValue<BMWEntity>("BMW")
                .HasValue<MercedesEntity>("Mercedes")
                .HasValue<PorscheEntity>("Porsche");
        }

    }
}
