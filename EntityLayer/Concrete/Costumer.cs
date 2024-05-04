using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Costumer
    {
        [Key]
        public int CostumerId { get; set; }
        public int Id { get; set; }
        public string? CostumerName { get; set; }
        public int  CostumerAge { get; set; }
        public string? CostumerPhoneNumber   { get; set; }
        public string? Address   { get; set; }
        public bool Status   { get; set; }
        public string? Email   { get; set; }
        public User? user { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
