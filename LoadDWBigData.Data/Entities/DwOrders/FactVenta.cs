using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("FactVentas", Schema = "DWH")]
public class FactVenta
{
    [Key]
    public int VentaId { get; set; }

    public int? EmpleadoId { get; set; }

    public string ClienteId { get; set; }

    public int? ProductoId { get; set; }

    public int? FechaId { get; set; }

    public int? CantidadVendida { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? TotalVenta { get; set; }
}