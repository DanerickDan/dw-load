using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("FactProductosVendidos", Schema = "DWH")]
public class FactProductosVendido
{
    [Key]
    public int ProductoId { get; set; }

    public int? CantidadVendida { get; set; }

}