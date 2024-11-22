using LoadDWBigData.Data.Entities.DwSales;
using LoadDWBigData.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadDWBigData.Data.Context;

public partial class DbSalesContext : DbContext
{
    public DbSalesContext(DbContextOptions<DbSalesContext> options)
        : base(options)
    {
    }
    #region DbSets
    public DbSet<DimCategoría> DimCategorías { get; set; }

    public DbSet<DimCliente> DimClientes { get; set; }

    public DbSet<DimEmpleado> DimEmpleados { get; set; }

    public DbSet<DimFecha> DimFechas { get; set; }

    public DbSet<DimProducto> DimProductos { get; set; }

    public DbSet<DimRegión> DimRegións { get; set; }

    public DbSet<DimTransportistum> DimTransportista { get; set; }

    public DbSet<FactOrdenesPorCliente> FactOrdenesPorClientes { get; set; }

    public DbSet<FactOrdenesPorTransportistum> FactOrdenesPorTransportista { get; set; }

    public DbSet<FactPedido> FactPedidos { get; set; }

    public DbSet<FactProductosVendido> FactProductosVendidos { get; set; }

    public DbSet<FactVenta> FactVentas { get; set; }

    public DbSet<FactVentasPorCategoría> FactVentasPorCategorías { get; set; }

    public DbSet<FactVentasPorCliente> FactVentasPorClientes { get; set; }

    public DbSet<FactVentasPorRegión> FactVentasPorRegións { get; set; }

    public DbSet<FactVentasPorTransportistum> FactVentasPorTransportista { get; set; }
    #endregion

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<DimCategoría>(entity =>
    //    {
    //        entity.HasKey(e => e.CategoríaId).HasName("PK__DimCateg__59CC1EABA6AD0A5C");

    //        entity.ToTable("DimCategoría", "DWH");

    //        entity.HasIndex(e => e.CategoríaId, "IDX_CategoríaID");

    //        entity.Property(e => e.CategoríaId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("CategoríaID");
    //        entity.Property(e => e.NombreCategoría).HasMaxLength(100);
    //    });

    //    modelBuilder.Entity<DimCliente>(entity =>
    //    {
    //        entity.HasKey(e => e.ClienteId).HasName("PK__DimClien__71ABD0A76004C973");

    //        entity.ToTable("DimCliente", "DWH");

    //        entity.HasIndex(e => e.ClienteId, "IDX_ClienteID");

    //        entity.HasIndex(e => new { e.País, e.Ciudad }, "IDX_PaisCiudad");

    //        entity.Property(e => e.ClienteId)
    //            .HasMaxLength(5)
    //            .HasColumnName("ClienteID");
    //        entity.Property(e => e.Ciudad).HasMaxLength(50);
    //        entity.Property(e => e.NombreCliente).HasMaxLength(50);
    //        entity.Property(e => e.País).HasMaxLength(50);
    //    });

    //    modelBuilder.Entity<DimEmpleado>(entity =>
    //    {
    //        entity.HasKey(e => e.EmpleadoId).HasName("PK__DimEmple__958BE6F001078A7B");

    //        entity.ToTable("DimEmpleado", "DWH");

    //        entity.HasIndex(e => e.EmpleadoId, "IDX_EmpleadoID");

    //        entity.HasIndex(e => new { e.Nombre, e.Apellido }, "IDX_NombreApellido");

    //        entity.Property(e => e.EmpleadoId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("EmpleadoID");
    //        entity.Property(e => e.Apellido).HasMaxLength(50);
    //        entity.Property(e => e.Nombre).HasMaxLength(50);
    //        entity.Property(e => e.Posición).HasMaxLength(50);
    //    });

    //    modelBuilder.Entity<DimFecha>(entity =>
    //    {
    //        entity.HasKey(e => e.FechaId).HasName("PK__DimFecha__E52651BCE1CE2E94");

    //        entity.ToTable("DimFecha", "DWH");

    //        entity.HasIndex(e => new { e.Año, e.Mes }, "IDX_AnioMes");

    //        entity.HasIndex(e => e.FechaId, "IDX_FechaID");

    //        entity.Property(e => e.FechaId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("FechaID");
    //    });

    //    modelBuilder.Entity<DimProducto>(entity =>
    //    {
    //        entity.HasKey(e => e.ProductoId).HasName("PK__DimProdu__A430AE830FF29E7E");

    //        entity.ToTable("DimProducto", "DWH");

    //        entity.HasIndex(e => e.CategoríaId, "IDX_CategoriaID");

    //        entity.HasIndex(e => e.ProductoId, "IDX_ProductoID");

    //        entity.Property(e => e.ProductoId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("ProductoID");
    //        entity.Property(e => e.CategoríaId).HasColumnName("CategoríaID");
    //        entity.Property(e => e.NombreProducto).HasMaxLength(100);
    //        entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
    //    });

    //    modelBuilder.Entity<DimRegión>(entity =>
    //    {
    //        entity.HasKey(e => e.RegiónId).HasName("PK__DimRegió__763DC99EC6241795");

    //        entity.ToTable("DimRegión", "DWH");

    //        entity.HasIndex(e => e.RegiónId, "IDX_RegiónID");

    //        entity.Property(e => e.RegiónId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("RegiónID");
    //        entity.Property(e => e.País).HasMaxLength(50);
    //    });

    //    modelBuilder.Entity<DimTransportistum>(entity =>
    //    {
    //        entity.HasKey(e => e.TransportistaId).HasName("PK__DimTrans__A26C7F554EBF52BD");

    //        entity.ToTable("DimTransportista", "DWH");

    //        entity.HasIndex(e => e.TransportistaId, "IDX_TransportistaID");

    //        entity.Property(e => e.TransportistaId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("TransportistaID");
    //        entity.Property(e => e.NombreTransportista).HasMaxLength(50);
    //    });

    //    modelBuilder.Entity<FactOrdenesPorCliente>(entity =>
    //    {
    //        entity.HasKey(e => e.ClienteId).HasName("PK__FactOrde__71ABD0A78B0B7D5A");

    //        entity.ToTable("FactOrdenesPorCliente", "DWH");

    //        entity.HasIndex(e => e.CantidadOrdenes, "IDX_CantidadOrdenesCliente");

    //        entity.HasIndex(e => e.ClienteId, "IDX_ClienteID_Ordenes");

    //        entity.Property(e => e.ClienteId)
    //            .HasMaxLength(5)
    //            .HasColumnName("ClienteID");

    //        entity.HasOne(d => d.Cliente).WithOne(p => p.FactOrdenesPorCliente)
    //            .HasForeignKey<FactOrdenesPorCliente>(d => d.ClienteId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__FactOrden__Clien__5224328E");
    //    });

    //    modelBuilder.Entity<FactOrdenesPorTransportistum>(entity =>
    //    {
    //        entity.HasKey(e => e.TransportistaId).HasName("PK__FactOrde__A26C7F55C957CABD");

    //        entity.ToTable("FactOrdenesPorTransportista", "DWH");

    //        entity.HasIndex(e => e.CantidadOrdenes, "IDX_CantidadOrdenes");

    //        entity.HasIndex(e => e.TransportistaId, "IDX_TransportistaID_Ordenes");

    //        entity.Property(e => e.TransportistaId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("TransportistaID");

    //        entity.HasOne(d => d.Transportista).WithOne(p => p.FactOrdenesPorTransportistum)
    //            .HasForeignKey<FactOrdenesPorTransportistum>(d => d.TransportistaId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__FactOrden__Trans__498EEC8D");
    //    });

    //    modelBuilder.Entity<FactPedido>(entity =>
    //    {
    //        entity.HasKey(e => e.PedidoId).HasName("PK__FactPedi__09BA141088EE2458");

    //        entity.ToTable("FactPedidos", "DWH");

    //        entity.HasIndex(e => e.CantidadPedidos, "IDX_Pedidos_Cantidad");

    //        entity.HasIndex(e => e.ClienteId, "IDX_Pedidos_ClienteID");

    //        entity.HasIndex(e => e.EmpleadoId, "IDX_Pedidos_EmpleadoID");

    //        entity.HasIndex(e => e.FechaId, "IDX_Pedidos_FechaID");

    //        entity.Property(e => e.PedidoId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("PedidoID");
    //        entity.Property(e => e.ClienteId)
    //            .HasMaxLength(5)
    //            .HasColumnName("ClienteID");
    //        entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
    //        entity.Property(e => e.FechaId).HasColumnName("FechaID");

    //        entity.HasOne(d => d.Cliente).WithMany(p => p.FactPedidos)
    //            .HasForeignKey(d => d.ClienteId)
    //            .HasConstraintName("FK__FactPedid__Clien__42E1EEFE");

    //        entity.HasOne(d => d.Empleado).WithMany(p => p.FactPedidos)
    //            .HasForeignKey(d => d.EmpleadoId)
    //            .HasConstraintName("FK__FactPedid__Emple__41EDCAC5");

    //        entity.HasOne(d => d.Fecha).WithMany(p => p.FactPedidos)
    //            .HasForeignKey(d => d.FechaId)
    //            .HasConstraintName("FK__FactPedid__Fecha__43D61337");
    //    });

    //    modelBuilder.Entity<FactProductosVendido>(entity =>
    //    {
    //        entity.HasKey(e => e.ProductoId).HasName("PK__FactProd__A430AE83F406853D");

    //        entity.ToTable("FactProductosVendidos", "DWH");

    //        entity.HasIndex(e => e.CantidadVendida, "IDX_CantidadVendida");

    //        entity.HasIndex(e => e.ProductoId, "IDX_ProductoID_Vendido");

    //        entity.Property(e => e.ProductoId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("ProductoID");

    //        entity.HasOne(d => d.Producto).WithOne(p => p.FactProductosVendido)
    //            .HasForeignKey<FactProductosVendido>(d => d.ProductoId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__FactProdu__Produ__4C6B5938");
    //    });

    //    modelBuilder.Entity<FactVenta>(entity =>
    //    {
    //        entity.HasKey(e => e.VentaId).HasName("PK__FactVent__5B41514C8A125E9F");

    //        entity.ToTable("FactVentas", "DWH");

    //        entity.HasIndex(e => e.ClienteId, "IDX_Venta_ClienteID");

    //        entity.HasIndex(e => e.EmpleadoId, "IDX_Venta_EmpleadoID");

    //        entity.HasIndex(e => e.FechaId, "IDX_Venta_FechaID");

    //        entity.HasIndex(e => e.ProductoId, "IDX_Venta_ProductoID");

    //        entity.HasIndex(e => e.TotalVenta, "IDX_Venta_TotalVenta");

    //        entity.Property(e => e.VentaId).HasColumnName("VentaID");
    //        entity.Property(e => e.ClienteId)
    //            .HasMaxLength(5)
    //            .HasColumnName("ClienteID");
    //        entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
    //        entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
    //        entity.Property(e => e.FechaId).HasColumnName("FechaID");
    //        entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
    //        entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
    //        entity.Property(e => e.TotalVenta).HasColumnType("decimal(18, 2)");

    //        entity.HasOne(d => d.Cliente).WithMany(p => p.FactVenta)
    //            .HasForeignKey(d => d.ClienteId)
    //            .HasConstraintName("FK__FactVenta__Clien__37703C52");

    //        entity.HasOne(d => d.Empleado).WithMany(p => p.FactVenta)
    //            .HasForeignKey(d => d.EmpleadoId)
    //            .HasConstraintName("FK__FactVenta__Emple__367C1819");

    //        entity.HasOne(d => d.Fecha).WithMany(p => p.FactVenta)
    //            .HasForeignKey(d => d.FechaId)
    //            .HasConstraintName("FK__FactVenta__Fecha__395884C4");

    //        entity.HasOne(d => d.Producto).WithMany(p => p.FactVenta)
    //            .HasForeignKey(d => d.ProductoId)
    //            .HasConstraintName("FK__FactVenta__Produ__3864608B");
    //    });

    //    modelBuilder.Entity<FactVentasPorCategoría>(entity =>
    //    {
    //        entity.HasKey(e => e.CategoríaId).HasName("PK__FactVent__59CC1EABF12680E7");

    //        entity.ToTable("FactVentasPorCategoría", "DWH");

    //        entity.HasIndex(e => e.CategoríaId, "IDX_Ventas_CategoriaID");

    //        entity.HasIndex(e => e.TotalVenta, "IDX_Ventas_TotalVenta");

    //        entity.Property(e => e.CategoríaId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("CategoríaID");
    //        entity.Property(e => e.TotalVenta).HasColumnType("decimal(18, 2)");

    //        entity.HasOne(d => d.Categoría).WithOne(p => p.FactVentasPorCategoría)
    //            .HasForeignKey<FactVentasPorCategoría>(d => d.CategoríaId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__FactVenta__Categ__3C34F16F");
    //    });

    //    modelBuilder.Entity<FactVentasPorCliente>(entity =>
    //    {
    //        entity.HasKey(e => e.ClienteId).HasName("PK__FactVent__71ABD0A7B2F1C1CE");

    //        entity.ToTable("FactVentasPorCliente", "DWH");

    //        entity.HasIndex(e => e.ClienteId, "IDX_ClienteID_Ventas");

    //        entity.HasIndex(e => e.TotalVenta, "IDX_TotalVenta_Cliente");

    //        entity.Property(e => e.ClienteId)
    //            .HasMaxLength(5)
    //            .HasColumnName("ClienteID");
    //        entity.Property(e => e.TotalVenta).HasColumnType("decimal(18, 2)");

    //        entity.HasOne(d => d.Cliente).WithOne(p => p.FactVentasPorCliente)
    //            .HasForeignKey<FactVentasPorCliente>(d => d.ClienteId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__FactVenta__Clien__4F47C5E3");
    //    });

    //    modelBuilder.Entity<FactVentasPorRegión>(entity =>
    //    {
    //        entity.HasKey(e => e.RegiónId).HasName("PK__FactVent__763DC99E283F679F");

    //        entity.ToTable("FactVentasPorRegión", "DWH");

    //        entity.HasIndex(e => e.RegiónId, "IDX_Ventas_RegiónID");

    //        entity.HasIndex(e => e.TotalVenta, "IDX_Ventas_TotalVentaRegión");

    //        entity.Property(e => e.RegiónId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("RegiónID");
    //        entity.Property(e => e.TotalVenta).HasColumnType("decimal(18, 2)");

    //        entity.HasOne(d => d.Región).WithOne(p => p.FactVentasPorRegión)
    //            .HasForeignKey<FactVentasPorRegión>(d => d.RegiónId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__FactVenta__Regió__3F115E1A");
    //    });

    //    modelBuilder.Entity<FactVentasPorTransportistum>(entity =>
    //    {
    //        entity.HasKey(e => e.TransportistaId).HasName("PK__FactVent__A26C7F556D30B5AA");

    //        entity.ToTable("FactVentasPorTransportista", "DWH");

    //        entity.HasIndex(e => e.TotalVenta, "IDX_TotalVenta_Transportista");

    //        entity.HasIndex(e => e.TransportistaId, "IDX_TransportistaID_Ventas");

    //        entity.Property(e => e.TransportistaId)
    //            .ValueGeneratedNever()
    //            .HasColumnName("TransportistaID");
    //        entity.Property(e => e.TotalVenta).HasColumnType("decimal(18, 2)");

    //        entity.HasOne(d => d.Transportista).WithOne(p => p.FactVentasPorTransportistum)
    //            .HasForeignKey<FactVentasPorTransportistum>(d => d.TransportistaId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__FactVenta__Trans__46B27FE2");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}