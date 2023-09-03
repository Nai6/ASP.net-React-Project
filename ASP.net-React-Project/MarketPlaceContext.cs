using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP.net_React_Project;

public partial class MarketPlaceContext : DbContext
{
    public MarketPlaceContext()
    {
    }

    public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-ND0GN5F; Initial Catalog=MarketPlace; Integrated Security=True; User Id=myUsername; Password=myPassword; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC075EA3DAE7");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Goods__3214EC070BE68AEC");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC071256F565");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<CartGood>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
