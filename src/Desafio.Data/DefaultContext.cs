using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sale
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SaleNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Cancelled).IsRequired();

                entity.HasMany(e => e.Items)
                      .WithOne()
                      .HasForeignKey("SaleId")
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // SaleItem
            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.DiscountPercent).IsRequired().HasColumnType("decimal(5,2)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
