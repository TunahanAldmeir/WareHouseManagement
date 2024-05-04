using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfOrderRepository : GenericRepository<Order>, IOrderDal
    {
        public void AddOrderwithCostumerId(Order order, int costumerıd)
        {
            using (var context = new Context())
            {
                var costumer = context.Costumers.FirstOrDefault(u => u.CostumerId ==costumerıd);

                //************** Create a new Customer associated with the User*************//
                var newOrder = new Order
                {
                    Status = order.Status,
                    CostumerId=costumerıd,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    Address = order.Address,
                    costumer=costumer
                };
                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
        }
    }
}
