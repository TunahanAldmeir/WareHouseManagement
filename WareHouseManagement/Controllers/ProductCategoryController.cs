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
    public class ProductCategoryController : Controller
    {
        ProductCategoryManager pcateg = new ProductCategoryManager(new EfProductCategoryRepository());
        public IActionResult ProductCategory()
        {
            return View();
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var values = pcateg.GetAllProductCategory();
            return DataSourceLoader.Load(values, loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var category = new ProductCategory();
            JsonConvert.PopulateObject(values, category);

            if (!TryValidateModel(category))
                return Error();
            pcateg.AddProductCategory(category);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var category = pcateg.GetProductCategoryById(key);
            JsonConvert.PopulateObject(values, category);

            if (!TryValidateModel(category))
                return Error();
            pcateg.UpdateProductCategory(category);
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var catetgory = pcateg.GetProductCategoryById(key);
            pcateg.DeleteProductCategory(catetgory);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
