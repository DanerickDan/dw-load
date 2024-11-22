using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.Northwind;
public class Region
{
    [Key]
    public int RegionId { get; set; }

    public string RegionDescription { get; set; }
}