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
    public class OrderManager : IOrderServices
    {
        IOrderDal _orderdal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderdal = orderDal;   
        }
        public void AddOrder(Order order)
        {
            _orderdal.Insert(order);
        }

        public void AddOrderwithCostumerId(Order order, int costumerId)
        {
           _orderdal.AddOrderwithCostumerId(order, costumerId);
        }

        public void DeleteOrder(Order order)
        {
            _orderdal.Delete(order);
        }

        public List<Order> GetAllOrders()
        {
            return _orderdal.GetAll();
        }

        public List<Order> GetAllOrdersByCostumerId(int id)
        {
            return _orderdal.GetAll(x => x.CostumerId == id);
        }

        public Order GetOrderById(int id)
        {
           return _orderdal.GetByID(id);    
        }

        public void UpdateOrder(Order order)
        {
            _orderdal.Update(order);
        }
    }
}
