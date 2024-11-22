using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("DimEmpleado", Schema = "DWH")]
public class DimEmpleado
{
    [Key]
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Posición { get; set; }
}