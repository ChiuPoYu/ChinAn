using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Resources;

namespace WebApi.Models.DBModels;

public partial class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString(AppSettingsKey.DBConnection);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<MaintenanceItem> MaintenanceItems { get; set; }
    public virtual DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    // public virtual DbSet<ServiceItem> ServiceItems { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    // public virtual DbSet<Notification> Notifications { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
        });

        modelBuilder.Entity<MaintenanceItem>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.Property(e => e.ItemName).HasMaxLength(50);
        });

        modelBuilder.Entity<MaintenanceRecord>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Vehicle).WithMany(p => p.MaintenanceRecords)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK_MaintenanceRecord_Vehicle");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Vehicle)
                .WithMany()
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK_Booking_Vehicle");
        });

        // modelBuilder.Entity<ServiceItem>(entity =>
        // {
        //     entity.HasKey(e => e.Id);
        //     entity.Property(e => e.Name).HasMaxLength(50);
        //     entity.Property(e => e.Brand).HasMaxLength(30);
        //     entity.Property(e => e.Specification).HasMaxLength(50);
        // });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        // modelBuilder.Entity<Notification>(entity =>
        // {
        //     entity.HasKey(e => e.Id);
        //     entity.HasOne(d => d.Booking).WithMany()
        //         .HasForeignKey(d => d.BookingId);
        // });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.PlateNumber);

            entity.Property(e => e.PlateNumber).HasMaxLength(10);
            entity.Property(e => e.Model).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
