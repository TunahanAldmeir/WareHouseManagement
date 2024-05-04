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
    public class OrderItemManager : IOrderItemServices
    {
        IOrderItemDal _orderıtemdal;
        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderıtemdal = orderItemDal;   
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            _orderıtemdal.Insert(orderItem);
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
           _orderıtemdal.Delete(orderItem); 
        }

        public List<OrderItem> GetAllOrderItemByOrderId(int id)
        {
           return _orderıtemdal.GetAll(x=>x.OrderId==id);
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return _orderıtemdal.GetAll();
        }

        public OrderItem GetOrderItemById(int id)
        {
            return _orderıtemdal.GetByID(id);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _orderıtemdal.Update(orderItem); 
        }
    }
}
