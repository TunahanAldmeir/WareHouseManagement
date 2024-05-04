using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Picture { get; set; }
        public bool Status { get; set; }

        public ICollection<UserType>?  UserTypes { get; set; }
        public ICollection<Costumer>  Costumers { get; set; } = new List<Costumer>();


    }
}
