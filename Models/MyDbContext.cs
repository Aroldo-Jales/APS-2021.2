using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) {
        }
        public DbSet<Department> Departament {get;set;}
        public DbSet<Seller> Seller {get;set;}
        public DbSet<Projeto.Models.SaleRecord> SaleRecord { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Seller>()
            .HasOne(s => s.Department)
            .WithMany(d => d.Sellers)
            .HasForeignKey(s => s.DepartmentForeignKey)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SaleRecord>()
            .HasOne(s => s.Seller)
            .WithMany(s => s.SalesRecord)
            .HasForeignKey(s => s.SellerForeignKey)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}