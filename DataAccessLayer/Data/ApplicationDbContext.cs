using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "StockDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LotItemEntity>().HasData(
                new LotItemEntity[]
                {
                    new LotItemEntity() { Id = 1, ShareNumber = 100, RemainShareNumber = 100, SharePrice = 20.00m, Date = new DateTime(2023, 1, 1) },
                    new LotItemEntity() { Id = 2, ShareNumber = 150, RemainShareNumber = 150, SharePrice = 30.00m, Date = new DateTime(2023, 2, 1) },
                    new LotItemEntity() { Id = 3, ShareNumber = 120, RemainShareNumber = 120, SharePrice = 10.00m, Date = new DateTime(2023, 3, 1) }
                });
        }

        public DbSet<LotItemEntity> LotItems { get; set; }
    }
}
