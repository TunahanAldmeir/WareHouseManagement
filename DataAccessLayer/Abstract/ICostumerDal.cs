using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICostumerDal:IGenericDal<Costumer>
    {
        public void AddCostumerwithUserId(Costumer costumer, int userıd);
    }
}
