using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rechtefriet;

[Keyless]
[Table("OrderItem")]
public partial class OrderItem
{

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("itemid")]
    public int? Itemid { get; set; }

    [ForeignKey("Itemid")]
    public virtual Item? Item { get; set; }

    [ForeignKey("Orderid")]
    public virtual Order? Order { get; set; }
}
