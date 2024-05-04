using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IProductBrandServices
    {
        void AddProductBrandt(ProductBrand  productBrand);
        void DeleteProductBrand(ProductBrand productBrand);
        void UpdateProductBrand(ProductBrand productBrand);

        List<ProductBrand> GetAllProductBrand();

        ProductBrand  GetProductBrandById(int id);
    }
}
