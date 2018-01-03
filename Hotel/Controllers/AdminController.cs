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
    public class AdminController : Controller
    {
        //call service from 5th layer
        ICustomerService customerservice;
        IContactService contactservice;
        public AdminController()
        {
            this.customerservice = Injector.Container.Resolve<ICustomerService>();
            this.contactservice = Injector.Container.Resolve<IContactService>();
        }

        //GET : Front end user mail get and see
        public ActionResult MailInformation()
        {
            return View(this.contactservice.GetAllContactsInfo());
        }

        public ActionResult DetailsMails(int id) {

            return View(this.contactservice.Get(id));
        }
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin
        [HttpGet]
        public ActionResult AdminPage() {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else {

                return RedirectToAction("Login", "User");
            }         
        }

        //Get: User Bill Information
        public ActionResult BillGenerate()
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



    }
}