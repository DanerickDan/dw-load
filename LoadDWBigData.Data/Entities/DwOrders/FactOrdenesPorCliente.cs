using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("FactOrdenesPorCliente", Schema = "DWH")]
public class FactOrdenesPorCliente
{
    [Key]
    public string ClienteId { get; set; }

    public int? CantidadOrdenes { get; set; }

}