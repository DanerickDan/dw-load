using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("FactVentasPorCategoría", Schema = "DWH")]
public class FactVentasPorCategoría
{
    [Key]
    public int CategoríaId { get; set; }

    public decimal? TotalVenta { get; set; }
}