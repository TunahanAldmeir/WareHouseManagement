using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IUserServices
    {
        void Adduser (User  user);
        void Deleteuser (User user );
        void Updateuser (User user );

        List<User> GetAlluser ();
        
        User GetuserById(int id);
        User logUser(User user);
    }
}
