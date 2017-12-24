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
    public class UserController : Controller
    {

        IUserService service;
      //  ICustomerService sp;
        public UserController()
        {
            this.service = Injector.Container.Resolve<IUserService>();
           // this.sp = Injector.Container.Resolve<ICustomerService>();
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



        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {

            if (ModelState.IsValid)
            {

                ViewBag.message = "Registration Successfull";
                this.service.Insert(user);
                return RedirectToAction("Registration");
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
            var usr = service.check_pass(user);
            if (usr != null)
            {
                if (usr.UserType == "Admin")
                {
                    Session["UserType"] = usr.UserType.ToString();
                    Session["UserID"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["Firstname"] = usr.FirstName.ToString();
                    return RedirectToAction("index", "Admin");
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

        public ActionResult UserHomepage() {

            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

       


        
        





    }
}