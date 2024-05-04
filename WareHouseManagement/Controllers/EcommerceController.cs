using BusinesLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WareHouseManagement.Controllers
{
    public class EcommerceController : Controller
    {
        OrderItemManager orderItemn = new OrderItemManager(new EfOrderItemRepository());

        public IActionResult Commerce(int id)
        {
            ViewData["OrderIdd"] = id;
            HttpContext.Session.SetInt32("OrderIdd", id);
            return View();
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions, int id)
        {
            id= Convert.ToInt32(HttpContext.Session.GetInt32("OrderIdd"));
            var values = orderItemn.GetAllOrderItemByOrderId(id);
            return DataSourceLoader.Load(values, loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var orderItem = new OrderItem();
            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderIdd"));
            orderItem.OrderId = orderId;    
            JsonConvert.PopulateObject(values, orderItem);
            orderItemn.AddOrderItem(orderItem);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var orderItemnew = orderItemn.GetOrderItemById(key);
            JsonConvert.PopulateObject(values, orderItemnew);
            orderItemn.UpdateOrderItem(orderItemnew);
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var orderItemNew = orderItemn.GetOrderItemById(key);

            orderItemn.DeleteOrderItem(orderItemNew);
        }
    }
}
