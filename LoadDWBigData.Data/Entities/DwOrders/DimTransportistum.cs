using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("DimTransportista", Schema = "DWH")]
public class DimTransportistum
{
    [Key]
    public int TransportistaId { get; set; }

    public string NombreTransportista { get; set; }

}