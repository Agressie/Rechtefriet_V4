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
    public decimal? Price { get; set; }

    [Column("date", TypeName = "smalldatetime")]
    public DateTime? Date { get; set; }

    [Column("discount", TypeName = "decimal(5, 2)")]
    public decimal? Discount { get; set; }

    [Column("klantid")]
    public int Klantid { get; set; }

    [ForeignKey("Klantid")]
    [InverseProperty("Orders")]
    public virtual Klant Klant { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
