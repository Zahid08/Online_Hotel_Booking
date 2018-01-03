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
    public class RoomController : ApiController
    {
        // GET api/values
        RoomService roomservice = new RoomService();

        DataContext context = new DataContext();
        public IHttpActionResult Get()
        {
              List<Rooms> roomlistdata = context.Rooms.Take(4).ToList();
             return Ok(roomlistdata); 

        }

       


    }
}