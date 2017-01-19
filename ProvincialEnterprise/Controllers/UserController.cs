using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;

namespace ProvincialEnterprise.Controllers
{
    public class UserController : Controller
    {
        PELEntities _dbContext = new PELEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidUser(User user)
        {
            var data = _dbContext.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password);

            if (data.Any())
            {
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }

            //if (data.Any())
            //{
            //    //  Error
            //    return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    //  Success
            //    return Json(new { success = true, responseText = "Your message successfuly sent!" }, JsonRequestBehavior.AllowGet);
            //} 
        }
    }
}