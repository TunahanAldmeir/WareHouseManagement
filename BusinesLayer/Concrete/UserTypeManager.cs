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
    public class UserTypeManager : IUserTypeServices
    {
        IUserTyoeDal _usertypedal;
        public UserTypeManager(IUserTyoeDal userTyoedal)
        {
            _usertypedal = userTyoedal;
        }
        public void AddUserType(UserType userType)
        {
            _usertypedal.Insert(userType);
        }

        public void DeleteUserType(UserType userType)
        {
            _usertypedal?.Delete(userType); 
        }

        public List<UserType> GetAllUserTypeById(int id)
        {
            return _usertypedal.GetAll(x=>x.Id==id);   
        }

        public UserType GetUserTypeById(int id)
        {
            return _usertypedal.GetByID(id);
        }

        public void UpdateUserType(UserType userType)
        {
            _usertypedal.Update(userType);
        }
    }
}
