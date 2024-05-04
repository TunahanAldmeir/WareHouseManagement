using BusinesLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WareHouseManagement.Controllers
{
    public class OrderController : Controller
    {
        OrderManager myOrder = new OrderManager(new EfOrderRepository());

        public IActionResult Order(int id)
        {
            ViewData["CostumerId"] = id;
            //////____İn order to optain variable from the url use it anywhere you wish_______-/////////
            HttpContext.Session.SetInt32("CustomerId", id);
            return View();

        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions, int id)
        {
            ViewData["CostumerId"] = id;
            var values = myOrder.GetAllOrdersByCostumerId(id);
            return DataSourceLoader.Load(values, loadOptions);
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var order = myOrder.GetOrderById(key);
            JsonConvert.PopulateObject(values, order);
            myOrder.UpdateOrder(order);
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            int costumerId =Convert.ToInt32( HttpContext.Session.GetInt32("CustomerId"));
            var order = new Order();
            JsonConvert.PopulateObject(values, order);
            myOrder.AddOrderwithCostumerId(order,costumerId);
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var order = myOrder.GetOrderById(key);
            myOrder.DeleteOrder(order);
        }
    }
}
