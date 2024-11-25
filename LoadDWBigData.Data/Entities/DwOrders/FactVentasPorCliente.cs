using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("FactVentasPorCliente", Schema = "DWH")]
public class FactVentasPorCliente
{
    [Key]
    public string ClienteId { get; set; }

    public decimal? TotalVenta { get; set; }
}