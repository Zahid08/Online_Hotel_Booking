using Hotel.App_Start;
using Hotel.Models;
using HotelEntity.Class;
using HotelService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class UserController : Controller
    {

        IUserService userservice;
        IRoomsService roomservice;
        ICustomerService customerservice;

        IContactService contactservice;
        //  ICustomerService sp;
        public UserController()
        {
            this.userservice = Injector.Container.Resolve<IUserService>();
            this.roomservice = Injector.Container.Resolve<IRoomsService>();
            this.customerservice = Injector.Container.Resolve<ICustomerService>();
            this.contactservice = Injector.Container.Resolve<IContactService>();

        }

        // GET: User
        public ActionResult Index()
        {
            return View();
           // return View(this.service.GetAll());
        }
        public ActionResult RoomsDetails() {

            return View();
        }
        public ActionResult About()
        {

            return View();
        }

        public ActionResult Restaurent()
        {

            return View();
        }
        public ActionResult Gallery()
        {

            return View();
        }

        public ActionResult Contact() {

            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult UserProfile(int id) {
            return View(this.userservice.Get(id));
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                ViewBag.message = "Registration Successfull";
                this.userservice.Insert(user);
                return RedirectToAction("Login");
            }
            else
            {
                return View(user);
            }
            // ViewBag.Message = us.FirstName + " " + us.LastName + " Successfully Registered";
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = userservice.check_pass(user);
            if (usr != null)
            {
                if (usr.UserType == "Admin")
                {
                    List<Contact> clist = contactservice.GetAllContactsInfo().ToList();
                    List<Contact> cetlist = new List<Contact>();

                    foreach (Contact c in clist)
                    {

                        Session["status"] = c.status;
                    }

                    Session["UserType"] = usr.UserType.ToString();
                    Session["UserID"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["Firstname"] = usr.FirstName.ToString();
                    return RedirectToAction("AdminPage", "Admin");
                }
                else if (usr.UserType == "User")
                {
                    Session["UserType"] = usr.UserType.ToString();
                    Session["UserID"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();
                     Session["Firstname"] = usr.FirstName.ToString();
                    return RedirectToAction("UserHomepage", "User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is Wrong!");
            }

            return View();
        }

        [HttpGet]
        public ActionResult LoggedIn()
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


        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "User");
        }

        //reservation
        public ActionResult UserHomepage() {

            if (Session["UserId"] != null)
            {               
                ViewBag.customerid =Session["UserID"];

                return View(this.roomservice.GetAllinformation());

            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpPost, ActionName("UserHomepage")]
        public ActionResult UserHomepages()
        {
            // User users = this.service.Get(id);
            ViewBag.customerid = Session["UserID"];
            ViewBag.searchdate = Convert.ToDateTime(Request.Form["Check"]);
            return View(this.roomservice.SearchGetAll(Convert.ToDateTime(Request.Form["Check"])));
        }

        [HttpGet]
        public ActionResult ShowRoomDetails(int id, int cid)
        {
            ViewBag.customerid = Session["UserID"];
            return View(this.roomservice.Get(id));
        }

        [HttpPost]
        public ActionResult ShowRoomDetails(Rooms rome, int id, int cid)
        {
            User user = this.userservice.Get(cid);
            user.Status = 1;
            this.userservice.UpdateStatus(user);

            if (ModelState.IsValid)
            {
                this.userservice.UpdateAllUsersBookingRoom(rome);

                return RedirectToAction("UserHomepage");
            }
            else
            {
                return View(rome);
            }
        }


        [HttpGet]
        public ActionResult UserDetails()
        {
            return View(this.userservice.GetAllinformation());
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            return View(this.userservice.Get(id));
        }

        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteConfirmedUSer(int id)
        {       
            this.userservice.DeleteUser(id);
            return RedirectToAction("UserDetails", "User");
        }

        [HttpGet]
        public ActionResult EditUserDetails(int id)
        {         
           return View(this.userservice.GetUser(id));
        }

        [HttpPost]
        public ActionResult EditUserDetails(User Us)
        {         
                this.userservice.UpdateUserInformation(Us);
                return RedirectToAction("UserDetails", "User");
        }

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