using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.DwSales;

[Table("FactPedido", Schema = "DWH")]
public class FactPedido
{
    [Key]
    public int PedidoId { get; set; }

    public int? EmpleadoId { get; set; }

    public string ClienteId { get; set; }

    public int? FechaId { get; set; }

    public int? CantidadPedidos { get; set; }

}