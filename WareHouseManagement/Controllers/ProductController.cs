using BusinesLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using WareHouseManagement.Models;
using System;
using Microsoft.Extensions.Hosting;

namespace WareHouseManagement.Controllers
{
    [Authorize(Roles = "Admin,WareHouse")]
    public class ProductController : Controller
    {
        private IWebHostEnvironment _hostEnvironment;

        ProductManager pmangr = new ProductManager(new EfProductRepository());  
        ProductBrandManager pbrandma = new ProductBrandManager(new EfProductBrandRepository());  
        ProductCategoryManager pcategoryma = new ProductCategoryManager(new EfProductCategoryRepository());  
        WareHouseManager pwarema = new WareHouseManager(new EfWareHouseRepository());
        public ProductController( IWebHostEnvironment environment)
        {
            _hostEnvironment = environment;
        }
        public IActionResult Products(int id)
        {
            ViewData["WareHouseId"] = id;
            return View();
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions,int id)
        {
            var a = 0;
            a = id;
            if (a ==0)
            {
                var values = pmangr.GetAllProduct();
                return DataSourceLoader.Load(values, loadOptions);
                
            }
            else if(a !=0)
            {
                var values = pmangr.GetAllProductByWareHouseId(a);
                a = 0;
                return DataSourceLoader.Load(values, loadOptions);
            }
            else
            {
                return Ok();
            }


        }
        [HttpGet]
        public object GetBrand(DataSourceLoadOptions loadOptions)
        {
            var values = pbrandma.GetAllProductBrand();
            return DataSourceLoader.Load(values, loadOptions);
        }        
        [HttpGet]
        public object GetCategory(DataSourceLoadOptions loadOptions)
        {
            var values = pcategoryma.GetAllProductCategory();
            return DataSourceLoader.Load(values, loadOptions);
        }        
        [HttpGet]
        public object GetWareHouse(DataSourceLoadOptions loadOptions)
        {
            var values = pwarema.GetAllWareHouse();
            return DataSourceLoader.Load(values, loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var product = new Product();
            JsonConvert.PopulateObject(values, product);
            var warehousee= pwarema.GetWareHouseById(product.Id);
            warehousee.CurrentCapacity = warehousee.CurrentCapacity - product.ProductQuantity;
            warehousee.UsedCapacity = product.ProductQuantity;
            pwarema.UpdateWareHouse(warehousee);
            //if (!TryValidateModel(product))
            //    return Error();
            pmangr.AddProduct(product);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var product = pmangr.GetProductById(key);
            int oldQuantity = product.ProductQuantity;
            var warehousee = pwarema.GetWareHouseById(product.Id);
            JsonConvert.PopulateObject(values, product);
            pmangr.UpdateProduct(product);
            int newQuantity= product.ProductQuantity;   
            if (oldQuantity != newQuantity)
            {
                var increse = newQuantity - oldQuantity;
                warehousee.CurrentCapacity -= increse;
                warehousee.UsedCapacity += increse;
                pwarema.UpdateWareHouse(warehousee);
            }
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var product = pmangr.GetProductById(key);
            var warehousee = pwarema.GetWareHouseById(product.Id);
            if (warehousee.UsedCapacity!=0)
            {
                warehousee.CurrentCapacity = warehousee.CurrentCapacity + product.ProductQuantity;
                warehousee.UsedCapacity = warehousee.UsedCapacity - product.ProductQuantity;
                pwarema.UpdateWareHouse(warehousee);
            }

            pmangr.DeleteProduct(product);
        }
        [HttpPost]
        public IActionResult PostPhoto3()
        {
            IFormFileCollection files = Request.Form.Files;
            string uniqueFileName = "";

            if (files.Count > 0)
            {
                var file = files[0];
                uniqueFileName = string.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(file.FileName));

                try
                {
                    var path = Path.Combine(_hostEnvironment.WebRootPath, "ProductImages/" + uniqueFileName);

                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                catch
                {
                    return BadRequest("Failed to save a file on the server");
                }
            }

            return Ok(uniqueFileName);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
