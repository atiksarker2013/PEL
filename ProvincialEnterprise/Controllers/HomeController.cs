using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvincialEnterprise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Home = "class=active";
            ViewBag.Product = "class=dropdown";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.About = "class=active";
            ViewBag.Product = "class=dropdown";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Contact = "class=active";
            ViewBag.Product = "class=dropdown";

            return View();
        }

        public ActionResult Land()
        {
            return View();
        }
    }
}