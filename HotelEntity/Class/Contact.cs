using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntity.Class
{
   public class Contact: Entity
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Your name is required ")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required ")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Your Phone No is required ")]
        public int  Phone { get; set; }

        public string Message { get; set; }

        public int status { get; set; }


    }
}
