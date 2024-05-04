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
    public class ProductBrandManager : IProductBrandServices
    {
        IProductBradDal   _productbranddal ;
        public ProductBrandManager(IProductBradDal  productBradDal)
        {
            _productbranddal = productBradDal;
        }
        public void AddProductBrandt(ProductBrand productBrand)
        {
            _productbranddal.Insert(productBrand);
        }

        public void DeleteProductBrand(ProductBrand productBrand)
        {
            _productbranddal.Delete(productBrand);  
        }

        public List<ProductBrand> GetAllProductBrand()
        {
            return _productbranddal.GetAll();   
        }

        public ProductBrand GetProductBrandById(int id)
        {
            return _productbranddal.GetByID(id);
        }

        public void UpdateProductBrand(ProductBrand productBrand)
        {
            _productbranddal.Update(productBrand);  
        }
    }
}
