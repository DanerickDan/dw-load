using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("DimCategoría", Schema="DWH")]
public class DimCategoría
{
    [Key]
    public int CategoríaId { get; set; }

    public string NombreCategoría { get; set; }
}