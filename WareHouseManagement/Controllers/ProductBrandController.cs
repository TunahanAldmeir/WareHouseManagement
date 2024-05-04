using BusinesLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WareHouseManagement.Models;

namespace WareHouseManagement.Controllers
{
    public class ProductBrandController : Controller
    {
        ProductBrandManager pbrand = new ProductBrandManager(new EfProductBrandRepository());

        public IActionResult ProdcutBrand()
        {
            return View();
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var values = pbrand.GetAllProductBrand();
            return DataSourceLoader.Load(values, loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var brand = new ProductBrand();
            JsonConvert.PopulateObject(values, brand);

            if (!TryValidateModel(brand))
                return Error();
            pbrand.AddProductBrandt(brand);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var brand = pbrand.GetProductBrandById(key);
            JsonConvert.PopulateObject(values, brand);

            if (!TryValidateModel(brand))
                return Error();
            pbrand.UpdateProductBrand(brand);
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var brand = pbrand.GetProductBrandById(key);
            pbrand.DeleteProductBrand(brand);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
