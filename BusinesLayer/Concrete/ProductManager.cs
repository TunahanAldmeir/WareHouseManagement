using BusinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
    public class ProductManager : IProductServices
    {
        IProductDal _productdal;
        public ProductManager(IProductDal productDal)
        {
            _productdal = productDal;
        }
        public void AddProduct(Product product)
        {
            _productdal.Insert(product);
        }

        public void DeleteProduct(Product product)
        {
            _productdal.Delete(product);
        }

        public List<Product> GetAllProduct()
        {
           return _productdal.GetAll();
        }
        public List<Product> GetAllProductByWareHouseId(int id)
        {
            return _productdal.GetAll(x => x.Id == id);
        }

        public Product GetProductById(int id)
        {
            return _productdal.GetByID(id);
        }

        public void UpdateProduct(Product product)
        {
            _productdal.Update(product);
        }
    }
}
