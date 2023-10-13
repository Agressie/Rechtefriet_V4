using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rechtefriet;

[Table("Transaction")]
public partial class Transaction
{
    [Key]
    [Column("transactionid")]
    public int Transactionid { get; set; }

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("price", TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Date { get; set; }

    [ForeignKey("Orderid")]
    [InverseProperty("Transactions")]
    public virtual Order? Order { get; set; }

    public void Pay(decimal payprice)
    {
        Console.WriteLine($"You have payed the order for {payprice}.");
    }
}
