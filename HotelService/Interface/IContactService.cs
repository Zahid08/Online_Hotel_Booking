using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Interface
{
    public interface IContactService : IService<Contact>
    {
        List<Contact> GetAllContactsInfo();
    }
}
