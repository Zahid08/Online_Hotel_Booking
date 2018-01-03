
using Hotel.App_Start;
using HotelEntity.Class;

using HotelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService customerservice;
        IRoomsService roomservice;
        public CustomerController()
        {
            this.roomservice = Injector.Container.Resolve<IRoomsService>();
            this.customerservice = Injector.Container.Resolve<ICustomerService>();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        //Get : User Can create Customer
        [HttpGet]
        public ActionResult addCustomer()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        
        //Post :User->Customer
        [HttpPost]
        public ActionResult addCustomer(Customers Cust)
        {

            if (ModelState.IsValid)
            {
                ViewBag.message = "Successfull added";
                this.customerservice.Insert(Cust);
                return RedirectToAction("RegisterCustomer", "Customer");
            }
            else
            {
                return View(Cust);
            }
        }

        //get :Register Customer List Show
        public ActionResult RegisterCustomer(Customers cus)
        {
            if (Session["UserId"] != null)
            {
                return View(this.customerservice.GetAll());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }         
        }

        //get :Register Customer Who wants to book romm details
        [HttpGet]
        public ActionResult RoomDetails(int id) {
            Customers c = customerservice.Get(id);
            ViewBag.customerid = c.CustomerId;
            return View(customerservice.GetAll());

        }

        [HttpGet]
        public ActionResult CustomerBookingRoomsDetails(int id)
        {
            Customers cust = this.customerservice.Get(id);
            ViewBag.customerid = cust.CustomerId;
            return View(this.roomservice.GetAllinformation());
        }

        //Search : date within checkin and checkout
        [HttpPost,ActionName("CustomerBookingRoomsDetails")]
        public ActionResult CustomerBookingRoomsDetailss(int id)
        {
            Customers cust = this.customerservice.Get(id);
            ViewBag.customerid = cust.CustomerId;

            ViewBag.searchdate =Convert.ToDateTime(Request.Form["Check"]);
            return View(this.roomservice.SearchGetAll(Convert.ToDateTime(Request.Form["Check"])));
        }


        //Get :Room List
        [HttpGet]
        public ActionResult ShowRoomDetails(int id, int cid)
        {
            Customers cust = this.customerservice.Get(cid);
            ViewBag.c_id = cust.CustomerId;
            return View(this.roomservice.Get(id));
        }

        //Post :Booked Room

        [HttpPost]
        public ActionResult ShowRoomDetails(Rooms rome, int id, int cid)
        {
            DateTime Chekin = Convert.ToDateTime(Request.Form["CheckIn"]);
            DateTime Chekout = Convert.ToDateTime(Request.Form["Chekout"]);
            TimeSpan ts = Chekout - Chekin;
            int days = ts.Days;           
            Customers cust = this.customerservice.Get(cid);
            cust.Status = 1;
            // cust.RoomId = Convert.ToInt32(Request.Form["RoomId"]);
            //  cust.TotalAmount = Convert.ToInt32(Request.Form["Amount"]);

            this.customerservice.UpdateStatus(cust);
            if (ModelState.IsValid)
            {
                ViewBag.days = days;
                this.roomservice.UpdateAll(rome);

                return RedirectToAction("RegisterCustomer");
            }
            else
            {
                return View(rome);
            }

        }

        //Get:All Rooms where Customer Books Now
        public ActionResult CustomerBookingRoom(Customers cust, int id)
        {
            cust = this.customerservice.Get(id);
            ViewBag.CustomerName = cust.Customer_Name;
            return View(this.roomservice.GetAllBookingRoom(cust, id));
        }
        //Bill Details Who paid
        public ActionResult BillGenerate() {

            if (Session["UserId"] != null)
            {
                return View(this.customerservice.GetAll());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }
    }
}