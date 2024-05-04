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
    public class CostumerManager : ICostumerServices
    {
        ICostumerDal _costumerdal;
        public CostumerManager(ICostumerDal  costumerDal)
        {
           _costumerdal=costumerDal;
        }
        public void AddCostumerCategory(Costumer costumer)
        {
           _costumerdal.Insert(costumer);   
        }

        public void AddCostumerwithUserId(Costumer costumer, int userıd)
        {
            _costumerdal.AddCostumerwithUserId(costumer, userıd);
        }

        public void DeleteCostumerCategory(Costumer costumer)
        {
            _costumerdal.Delete(costumer);
        }

        public List<Costumer> GetAllCostumerByuserId(int id)
        {
            return _costumerdal.GetAll(x => x.user.Id == id);
        }
 
        public List<Costumer> GetAllCostumers()
        {
            return _costumerdal.GetAll();
        }


        public Costumer GetCostumerById(int id)
        {
            return _costumerdal.GetByID(id);
        }

        public void UpdateCostumerCategory(Costumer costumer)
        {
            _costumerdal.Update(costumer);
        }
    }
}
