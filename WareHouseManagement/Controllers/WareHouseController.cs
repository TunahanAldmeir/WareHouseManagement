using BusinesLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using WareHouseManagement.Models;

namespace WareHouseManagement.Controllers
{
    [Authorize(Roles = "Admin,WareHouse")]
    public class WareHouseController : Controller
    {
        WareHouseManager warema = new WareHouseManager(new EfWareHouseRepository());

        public IActionResult WareHouse()
        {
            return View();
        }
        public IActionResult ProdcutSpecications()
        {
            return View();
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var values = warema.GetAllWareHouse();
            return DataSourceLoader.Load(values, loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var warehouse = new WareHouse();
            JsonConvert.PopulateObject(values, warehouse);

            if (!TryValidateModel(warehouse))
                return Error();
            warema.AddWareHouse(warehouse);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var warehouse = warema.GetWareHouseById(key);
            JsonConvert.PopulateObject(values, warehouse);

            if (!TryValidateModel(warehouse))
                return Error();
            warema.UpdateWareHouse(warehouse);
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var warehouse = warema.GetWareHouseById(key);
            warema.DeleteWareHouse(warehouse);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
