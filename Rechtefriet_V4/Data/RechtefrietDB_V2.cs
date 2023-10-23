using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Rechtefriet;

namespace Rechtefriet_V4.Data;

public partial class RechtefrietDB_V2 : DbContext
{
    public RechtefrietDB_V2()
    {
    }

    public RechtefrietDB_V2(DbContextOptions<RechtefrietDB_V2> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Klant> Klants { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RechtefrietDB_V2;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Orderid).ValueGeneratedNever();
            entity.Property(e => e.Date).HasDefaultValueSql("(((2000)-(1))-(1))");
            entity.HasOne(d => d.Klant).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Klantorder");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(d => d.Item).WithMany().HasConstraintName("Itemkoppel");

            entity.HasOne(d => d.Order).WithMany().HasConstraintName("OrderkoppelItem");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
