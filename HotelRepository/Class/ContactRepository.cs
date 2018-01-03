using HotelEntity.Class;
using HotelRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Class
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public DataContext context = new DataContext();
        public List<Contact> GetAllContactsInfo()
        {
            return this.context.Contacts.ToList();
        }
    }

}
