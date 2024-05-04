using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IUserTypeServices
    {
        void AddUserType(UserType   userType);
        void DeleteUserType(UserType userType);
        void UpdateUserType(UserType userType);

        List<UserType> GetAllUserTypeById(int id);

        UserType GetUserTypeById(int id);
    }
}
