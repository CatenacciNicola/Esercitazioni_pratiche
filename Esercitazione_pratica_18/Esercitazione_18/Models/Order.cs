using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Esercitazione_18.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        public bool Processed { get; set; }
        [Required]
        [StringLength(70)]
        public string Address { get; set; }
        [Required]
        public string Notes { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        
        public List<OrderItem> Products { get; set; } = new List<OrderItem>();
    }
}
