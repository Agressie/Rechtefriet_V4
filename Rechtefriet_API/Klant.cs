using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Rechtefriet;

namespace Rechtefriet_API
{
    public class Klant
    {
        [Key]
        [Column("klantid")]
        public int Klantid { get; set; }

        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Column("adress")]
        [StringLength(50)]
        public string? Adress { get; set; }

        [InverseProperty("Klant")]
        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
    }
}
