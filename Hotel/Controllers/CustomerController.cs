
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
        ICustomerService s;
        public CustomerController()
        {
            this.s = Injector.Container.Resolve<ICustomerService>();
        }


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

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


        [HttpPost]
        public ActionResult addCustomer(Customers Cust)
        {

            if (ModelState.IsValid)
            {
                ViewBag.message = "Successfull added";
                this.s.Insert(Cust);

                return View();
            }
            else
            {
                return View(Cust);
            }

        }

        public ActionResult RegisterCustomer(Customers cus)
        {
            if (Session["UserId"] != null)
            {
                return View(this.s.GetAll());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

           
        }



    }
}