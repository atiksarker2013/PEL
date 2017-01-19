using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvincialEnterprise.Controllers
{
    public class PurchaseReturnController : Controller
    {
        //
        // GET: /PurchaseReturn/
        public ActionResult Index()
        {
            return View();
        }

        PurchaseRepository purchaseRepository = new PurchaseRepository();
        PurchaseDetailsRepository pdRepository = new PurchaseDetailsRepository();
        SupplierRepository sRepository = new SupplierRepository();
        //ItemJournalRepository ijRepository = new ItemJournalRepository();

        JournalDetailRepository jdRepository = new JournalDetailRepository();
        StockSerialRepository serialRepository = new StockSerialRepository();
        ReceivePaymentRepository receivepaymentRepository = new ReceivePaymentRepository();
        ChequeInfoReository chequeInfoRepository = new ChequeInfoReository();
        CommonPel common = new CommonPel();

        public JsonResult GetPurchases(string companyId, string branchId)
        {
           // var purchaseDetail = pdRepository.GetPurchaseDetailById(1018);
            var purchases = common.GetPurchases(companyId, branchId);           
            return Json(purchases, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetPurchaseById(string purchaseId)
        //{
        //    var pId = Convert.ToInt32(purchaseId);
        //    var purchase = purchaseRepository.GetPurchaseById(pId);
        //    //var purchaseDetail = pdRepository.GetPurchaseDetailById(pId);
        //    return Json(purchase, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetPurchaseDetails(string invoiceNo)
        //{
        //   // var pId = Convert.ToInt32(purchaseId);
        //    var purchaseDetail = pdRepository.GetPurchaseDetailById(invoiceNo);
        //    return Json(purchaseDetail, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetPurchaseDetails(string companyId, string branchId, string purchaseId)
        {
            var purchaseDetail = common.GetPurchaseDetails(companyId, branchId, purchaseId);
            return Json(purchaseDetail, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPurchaseById(string companyId, string branchId, string purchaseId)
        {
            //dynamic companyId = purchase.Branch.CompanyId;
            //dynamic branchId = purchase.BranchId;
            //dynamic purchaseId = purchase.PurchaseId;
            
            var purchaseDetail = common.GetPurchaseDetails(companyId, branchId, purchaseId);
            return Json(purchaseDetail, JsonRequestBehavior.AllowGet);
        }

	}
}