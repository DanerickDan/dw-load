using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("DimRegión", Schema = "DWH")]
public class DimRegión
{
    [Key]
    public int RegiónId { get; set; }

    public string País { get; set; }

}