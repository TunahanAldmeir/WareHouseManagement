using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IProductServices
    {
        void AddProduct(Product  product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);

        List<Product> GetAllProduct();

        Product GetProductById(int id);
    }
}
