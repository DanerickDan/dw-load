using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Models;

[Table("DimProducto", Schema = "DWH")]
public class DimProducto
{
    [Key]
    public int ProductoId { get; set; }

    public string NombreProducto { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? UnidadesEnStock { get; set; }

    public int? CategoríaId { get; set; }
}