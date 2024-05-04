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
    public class WareHouseManager : IWareHouseServices
    {
        IWareHouseDal _warehousedal;
        public WareHouseManager(IWareHouseDal wareHouseDal)
        {
            _warehousedal = wareHouseDal;
        }
        public void AddWareHouse(WareHouse wareHouse)
        {
            _warehousedal.Insert(wareHouse);
        }

        public void DeleteWareHouse(WareHouse wareHouse)
        {
            _warehousedal.Delete(wareHouse);
        }

        public List<WareHouse> GetAllWareHouse()
        {
            return _warehousedal.GetAll();  
        }

        public WareHouse GetWareHouseById(int id)
        {
           return _warehousedal.GetByID(id);
        }

        public void UpdateWareHouse(WareHouse wareHouse)
        {
            _warehousedal.Update(wareHouse);    
        }
    }
}
