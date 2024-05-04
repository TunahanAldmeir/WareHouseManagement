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
    public class UserManager : IUserServices
    {
        IUserDal _userDal;
        public UserManager(IUserDal  userDal)
        {
             _userDal= userDal;
        }
        public void Adduser(User user)
        {
            _userDal.Insert(user);
        }

        public void Deleteuser(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAlluser()
        {
            return _userDal.GetAll();   
        }


        public User GetuserById(int id)
        {
            return _userDal.GetByID(id);
        }

        public User logUser(User user)
        {
            return _userDal.logUser(user);
        }

        public void Updateuser(User user)
        {
            _userDal.Update(user);
        }
    }
}
