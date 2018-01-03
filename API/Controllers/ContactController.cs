using HotelEntity.Class;
using HotelRepository.Class;
using HotelService.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class ContactController : ApiController
    {
        // GET api/values
        ContactService contactservice = new ContactService();

        DataContext context = new DataContext();

        public IHttpActionResult Post([FromBody]Contact mail)
        {
            context.Set<Contact>().Add(mail);
            context.SaveChanges();
            return Ok("Success");
        }

    }
}