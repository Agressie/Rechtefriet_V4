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

    public virtual DbSet<Transaction> Transactions { get; set; }

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

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Date).HasDefaultValueSql("(((2000)-(1))-(1))");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions).HasConstraintName("Transactionorder");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
