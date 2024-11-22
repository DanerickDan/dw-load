using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.Northwind;

public class CustomerDemographic
{
    [Key]
    public string CustomerTypeId { get; set; }

    public string CustomerDesc { get; set; }
}