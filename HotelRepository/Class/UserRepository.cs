using HotelEntity.Class;
using HotelRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Class
{
    public class UserRepository : Repository<User>, IUserRepository
    {
       public DataContext context = new DataContext();

        public User check_pass(User us)
        {
            return context.Set<User>().SingleOrDefault(u => u.Username == us.Username && u.Password == us.Password);
        }
    }
}
