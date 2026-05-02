using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { 
        
        
        }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // =========================
            // PurchaseOrder Config
            // =========================
            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.PONumber)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.SupplierName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.OrderDate)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.TotalAmount)
                      .HasPrecision(18, 2)
                      .IsRequired();
            });

            // =========================
            // PurchaseOrderItem Config
            // =========================
            modelBuilder.Entity<PurchaseOrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ItemName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Quantity)
                      .IsRequired();

                entity.Property(e => e.UnitPrice)
                      .HasPrecision(18, 2)
                      .IsRequired();

                entity.Property(e => e.LineTotal)
                      .HasPrecision(18, 2)
                      .IsRequired();

                entity.HasOne(d => d.PurchaseOrder)
                      .WithMany(p => p.Items)
                      .HasForeignKey(d => d.PurchaseOrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
