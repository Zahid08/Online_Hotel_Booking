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
    public class ContactService : Service<Contact>, IContactService
    {
        ContactRepository crepo = new ContactRepository();
        public List<Contact> GetAllContactsInfo()
        {
            return crepo.GetAllContactsInfo();
        }
    }
}
