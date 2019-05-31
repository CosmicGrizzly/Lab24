using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_21.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult SummaryPage(string FirstName, string LastName, string Email, string PhoneNumber, string Password)
        {
            Models.User myUser = new Models.User(FirstName, LastName, Email, PhoneNumber, Password);
            return View(myUser);
        }
    }
}