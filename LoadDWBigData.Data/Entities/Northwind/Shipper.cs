using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.Northwind;

public class Shipper
{
    [Key]
    public int ShipperId { get; set; }

    public string CompanyName { get; set; }

    public string Phone { get; set; }
}