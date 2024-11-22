using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Models;


[Table("DimFecha", Schema = "DWH")]
public class DimFecha
{
    [Key]
    public int FechaId { get; set; }

    public int? Año { get; set; }

    public int? Mes { get; set; }

    public int? Día { get; set; }
}