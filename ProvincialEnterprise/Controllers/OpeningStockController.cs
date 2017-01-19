using ProvincialEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvincialEnterprise.Controllers
{
    public class OpeningStockController : Controller
    {
        //
        // GET: /OpeningStock/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveOpeningStock(OpeningStock openingStock)
        {
            bool status = true;
            return new JsonResult { Data = new { status = status } };
        }
	}
}