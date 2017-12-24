using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Class
{
   public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
