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
    public class ProductCategoryManager : IProductCategoryServices
    {
        IProductCategoryDal _productcategorydal;
        public ProductCategoryManager(IProductCategoryDal productCategoryDal)
        {
            _productcategorydal = productCategoryDal;
        }
        public void AddProductCategory(ProductCategory productCategory)
        {
            _productcategorydal.Insert(productCategory);
        }

        public void DeleteProductCategory(ProductCategory productCategory)
        {
            _productcategorydal.Delete(productCategory);
        }

        public List<ProductCategory> GetAllProductCategory()
        {
            return _productcategorydal.GetAll();
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            return _productcategorydal.GetByID(id);
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            _productcategorydal.Update(productCategory);    
        }
    }
}
