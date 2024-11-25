using LoadDWBigData.Data.Entities.DwSales;
using LoadDWBigData.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadDWBigData.Data.Context;

public partial class DbOrdersContext : DbContext
{
    public DbOrdersContext(DbContextOptions<DbOrdersContext> options)
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
}