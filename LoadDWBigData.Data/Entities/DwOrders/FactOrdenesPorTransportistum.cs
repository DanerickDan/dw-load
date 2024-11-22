using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("FactOrdenesPorTransportista", Schema = "DWH")]
public class FactOrdenesPorTransportistum
{
    [Key]
    public int TransportistaId { get; set; }

    public int? CantidadOrdenes { get; set; }

}