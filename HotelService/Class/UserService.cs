using HotelEntity.Class;
using HotelRepository.Class;
using HotelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Class
{
    public class UserService : Service<User>, IUserService
    {
        UserRepository repo = new UserRepository();

        public User check_pass(User us)
        {
            return repo.check_pass(us);
        }
    }
}
