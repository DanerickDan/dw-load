namespace LoadDWBigData.Data.Entities.Northwind;

public class ViewFactDatum
{
    public string ClienteKey { get; set; }

    public string CustomerName { get; set; }

    public int EmpleadoKey { get; set; }

    public string EmployeeName { get; set; }

    public int TransportistaKey { get; set; }

    public string ShipperName { get; set; }

    public int ProductoKey { get; set; }

    public string ProductoName { get; set; }

    public int? CategoríaKey { get; set; }

    public string CategoryName { get; set; }

    public int ProveedorKey { get; set; }

    public string SupplierName { get; set; }

    public int? FechaKey { get; set; }

    public int? Año { get; set; }

    public int? Mes { get; set; }

    public int VentaKey { get; set; }

    public decimal PrecioUnitario { get; set; }

    public short CantidadVendida { get; set; }

    public float Descuento { get; set; }

    public float? TotalVenta { get; set; }

    public int PedidoId { get; set; }

    public int? CantidadTotalPorOrden { get; set; }

    public double? TotalVentaPorCategoría { get; set; }

    public int RegiónId { get; set; }

    public string RegiónNombre { get; set; }

    public double? TotalVentaPorRegión { get; set; }

    public double? TotalVentaPorTransportista { get; set; }

    public int? CantidadOrdenesPorTransportista { get; set; }

    public int? CantidadVendidaPorProducto { get; set; }

    public double? TotalVentaPorCliente { get; set; }

    public int? CantidadOrdenesPorCliente { get; set; }
}