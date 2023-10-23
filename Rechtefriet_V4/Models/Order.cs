using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rechtefriet;

[Table("Order")]
public partial class Order
{
    [Key]
    [Column("orderid")]
    public int Orderid { get; set; }

    [Column("price", TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; } = 0;

    [Column("date", TypeName = "smalldatetime")]
    public DateTime? Date { get; set; } = DateTime.Now;

    [Column("discount", TypeName = "decimal(5, 2)")]
    public decimal? Discount { get; set; } = 0;

    [Column("klantid")]
    public int Klantid { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Totalprice { get; set; } = 0;

    [Column(TypeName = "smalldatetime")]
    public DateTime? Paydate { get; set; }

    [ForeignKey("Klantid")]
    [InverseProperty("Orders")]
    public virtual Klant Klant { get; set; } = null!;
}
