using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("DimCliente", Schema = "DWH")]
public class DimCliente
{
    [Key]
    public string ClienteId { get; set; }

    public string NombreCliente { get; set; }

    public string País { get; set; }

    public string Ciudad { get; set; }
}