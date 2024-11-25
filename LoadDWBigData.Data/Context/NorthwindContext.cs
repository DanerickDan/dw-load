using LoadDWBigData.Data.Entities.Northwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDWBigData.Data.Context;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<CustomerDemographic> CustomerDemographics { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Region> Regions { get; set; }

    public DbSet<Shipper> Shippers { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Territory> Territories { get; set; }
    public DbSet<ViewFactDatum> ViewFactData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ViewFactDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewFactData", "DWH");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            entity.Property(e => e.ClienteKey)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.EmployeeName)
                .IsRequired()
                .HasMaxLength(31);
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("money");
            entity.Property(e => e.ProductoName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.RegiónId).HasColumnName("RegiónID");
            entity.Property(e => e.RegiónNombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.ShipperName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.SupplierName)
                .IsRequired()
                .HasMaxLength(40);
        });
        OnModelCreatingPartial(modelBuilder);

    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}