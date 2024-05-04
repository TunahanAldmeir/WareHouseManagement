using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfCostumerRepository : GenericRepository<Costumer>, ICostumerDal
    {
        public void AddCostumerwithUserId(Costumer costumer, int userıd)
        {
            
            using (var context = new Context())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userıd);
                //************** Create a new Customer associated with the User*************//
                var newCustomer = new  Costumer 
                { 
                   CostumerName=costumer.CostumerName,
                   CostumerAge=costumer.CostumerAge,
                   CostumerPhoneNumber=costumer.CostumerPhoneNumber,
                   Address=costumer.Address,    
                   Status=costumer.Status,  
                   Email=costumer.Email,
                   user = user
                };
                context.Costumers.Add(newCustomer);
                context.SaveChanges();
            }
        }
    }
}
