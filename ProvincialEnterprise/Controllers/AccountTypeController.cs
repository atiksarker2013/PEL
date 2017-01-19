using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;

namespace ProvincialEnterprise.Controllers
{
    public class AccountTypeController : Controller
    {
        PELEntities _dbContext = new PELEntities();
        // GET: AccountType
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAccountType()
        {
            var accountTypes = _dbContext.AccountTypes.Select(x=> new
            {
                Id = x.Id,
                Name = x.Name
            });
            return Json(accountTypes, JsonRequestBehavior.AllowGet);
        }
    }
}