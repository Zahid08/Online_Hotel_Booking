using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class UserImage :User
    {
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}