using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;


[Table("FactVentasPorTransportista", Schema = "DWH")]
public class FactVentasPorTransportistum
{
    [Key]
    public int TransportistaId { get; set; }

    public decimal? TotalVenta { get; set; }

}