using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IOrderItemServices
    {
        void AddOrderItem(OrderItem  orderItem);
        void DeleteOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);

        List<OrderItem> GetAllOrderItems();
        List<OrderItem> GetAllOrderItemByOrderId(int id);


        OrderItem GetOrderItemById(int id);
    }
}
