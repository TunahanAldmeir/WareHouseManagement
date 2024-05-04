using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IProductCategoryServices
    {
        void AddProductCategory(ProductCategory  productCategory);
        void DeleteProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);

        List<ProductCategory> GetAllProductCategory();

        ProductCategory GetProductCategoryById(int id);
    }
}
