using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<MaintenanceItem> MaintenanceItems { get; set; }

    public virtual DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ChinAn;User Id=sa;Password=MyPassword00;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC27FD8F224D");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateBy).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UpdateBy).HasColumnType("datetime");
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<MaintenanceItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Maintena__727E838BA3E262DC");

            entity.ToTable("MaintenanceItem");

            entity.Property(e => e.CreateBy).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.ItemName).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnType("datetime");
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<MaintenanceRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Maintena__3214EC07BB3F2586");

            entity.ToTable("MaintenanceRecord");

            entity.Property(e => e.CreateBy).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.MaintenanceItems).HasMaxLength(3000);
            entity.Property(e => e.PlateNumber).HasMaxLength(20);
            entity.Property(e => e.Technician).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasColumnType("datetime");
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.PlateNumberNavigation).WithMany(p => p.MaintenanceRecords)
                .HasForeignKey(d => d.PlateNumber)
                .HasConstraintName("FK__Maintenan__Plate__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.MaintenanceRecords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Maintenan__UserI__440B1D61");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.PlateNumber).HasName("PK__Vehicles__03692625706F3830");

            entity.Property(e => e.PlateNumber).HasMaxLength(20);
            entity.Property(e => e.CreateBy).HasColumnType("datetime");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.UpdateBy).HasColumnType("datetime");
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Vehicles__UserID__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
