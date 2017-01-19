using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class PaymentModeController : Controller
    {
        PaymentModeRepository _repository = new PaymentModeRepository();
        // GET: PaymentMode
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllPaymentModes()
        {
            var paymentModes = _repository.GetAllPaymentMode();
            return Json(paymentModes, JsonRequestBehavior.AllowGet);
        }
    }
}