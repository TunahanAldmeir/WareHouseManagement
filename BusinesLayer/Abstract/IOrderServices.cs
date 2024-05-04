using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IOrderServices
    {
        void AddOrder(Order  order);
        void DeleteOrder(Order  order);
        void UpdateOrder(Order  order);

        List<Order> GetAllOrders();
        List<Order> GetAllOrdersByCostumerId(int id);
        void AddOrderwithCostumerId(Order order, int costumerId);



        Order GetOrderById(int id);
    }
}
