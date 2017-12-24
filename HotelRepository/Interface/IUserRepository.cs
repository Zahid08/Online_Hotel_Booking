using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Interface
{
   public interface IUserRepository:IRepository<User>
    {
        User check_pass(User us);
    }
}
