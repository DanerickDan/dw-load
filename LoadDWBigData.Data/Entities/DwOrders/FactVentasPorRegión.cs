using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("FactVentasPorRegión", Schema = "DWH")]
public class FactVentasPorRegión
{
    [Key]
    public int RegiónId { get; set; }

    public decimal? TotalVenta { get; set; }
}