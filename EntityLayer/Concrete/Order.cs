using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CostumerId { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public bool Status { get; set; }
        public string? Address { get; set; }

        public Costumer?  costumer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // Sipariş öğeleri

    }
}
