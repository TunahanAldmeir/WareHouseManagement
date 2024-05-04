using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductPicture { get; set; }
        public int ProductQuantity { get; set; }
        public Double ProductPrice { get; set; }
        public DateTime ProductAddedDate { get; set; }
        public bool IsProductActive { get; set; }

        [ForeignKey("ProductBrand")]
        public int BrandId { get; set; }
        public ProductBrand  ProductBrand { get; set; }
        

        [ForeignKey("ProductCategory")] 
        public int CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }


        [ForeignKey("WareHouse")]
        public int Id { get; set; }
        public WareHouse  WareHouse { get; set; }

    }
}
