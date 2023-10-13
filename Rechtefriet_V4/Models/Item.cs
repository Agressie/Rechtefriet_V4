using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rechtefriet;

[Table("Item")]
public partial class Item
{
    [Key]
    [Column("itemid")]
    public int Itemid { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("price", TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    [Column("picture")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Picture { get; set; }

    [Column("discount", TypeName = "decimal(5, 2)")]
    public decimal? Discount { get; set; }
}
