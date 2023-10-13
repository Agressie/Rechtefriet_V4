using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rechtefriet;

[Table("Klant")]
public partial class Klant
{
    [Key]
    [Column("klantid")]
    public int Klantid { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("adress")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Adress { get; set; }

    [InverseProperty("Klant")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
