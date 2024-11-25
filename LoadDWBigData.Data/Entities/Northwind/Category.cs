﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWBigData.Data.Entities.Northwind;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }

    public byte[] Picture { get; set; }
}