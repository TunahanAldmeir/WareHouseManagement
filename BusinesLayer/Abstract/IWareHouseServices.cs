using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IWareHouseServices
    {
        void AddWareHouse(WareHouse  wareHouse);
        void DeleteWareHouse(WareHouse wareHouse);
        void UpdateWareHouse(WareHouse wareHouse);

        List<WareHouse> GetAllWareHouse();

        WareHouse GetWareHouseById(int id);
    }
}
