using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WareHouseManagement.Models
{
    public class AddUserıImage
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public IFormFile Picture { get; set; }
        public bool Status { get; set; }
    }
}
