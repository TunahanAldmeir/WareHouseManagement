using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface ICostumerServices
    {
        void AddCostumerCategory(Costumer  costumer);
        void AddCostumerwithUserId(Costumer costumer,int userıd);
        void DeleteCostumerCategory(Costumer costumer);
        void UpdateCostumerCategory(Costumer costumer);

        List<Costumer> GetAllCostumers();
        List<Costumer> GetAllCostumerByuserId(int id);


        Costumer GetCostumerById(int id);
    }
}
