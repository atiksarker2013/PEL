using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace ProvincialEnterprise.Controllers
{
    public class PurchaseDetailController : Controller
    {
        //
        // GET: /PurchaseDetail/
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
        PurchaseDetailByPurchaseRepository pdpRepository = new PurchaseDetailByPurchaseRepository();

        public JsonResult GetPurchases(string companyId, string branchId)
        {
            // var purchaseDetail = pdRepository.GetPurchaseDetailById(1018);
            var purchases = common.GetPurchases(companyId, branchId);
            return Json(purchases, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetPurchases(string companyId, string branchId)
        //{
        //    // var purchaseDetail = pdRepository.GetPurchaseDetailById(1018);
        //    var purchases = common.GetPurchases(companyId, branchId);
        //    return Json(purchases, JsonRequestBehavior.AllowGet);
        //}

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

        public JsonResult GetAllPurchase()
        {
            var purchases = purchaseRepository.GetPurchases();
            return Json(purchases, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetPurchaseDetailByPurchase(string purchaseId)
        //{
        //    if (purchaseId != null)
        //    {
        //        int pId = Convert.ToInt32(purchaseId);
        //        var purchasedetails = pdRepository.GetPurchaseDetailByPurchaseId(pId);
        //        return Json(purchasedetails, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //        return null;

        //}

        public JsonResult GetPurchaseDetailByPurchase(string invoiceno)
        {         
            string inv = string.Empty;
          
            if (invoiceno != null)
            {
                foreach (char str in invoiceno)
                {
                    if (char.IsLetterOrDigit(str))
                        inv += str.ToString();                 
                }
                //var purchasedetails = pdRepository.GetPurchaseDetailByPurchaseId(inv);
                var purchasedetails = pdpRepository.GetPurchaseDetailByPurchase(inv);
                // var purchasedetails = common.GetPurchaseDetailByPurchase(inv);
                return Json(purchasedetails, JsonRequestBehavior.AllowGet);
            }
            else
                return null;

        }

        public JsonResult GetPurchaseDetailById(string purchasedetailid)
        {
            if (purchasedetailid != null)
            {
                int purchaseDetailId = Convert.ToInt32(purchasedetailid);
                var pd = common.GetPurchaseDetailById(purchaseDetailId);
                return Json(pd, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public string UpdatePurchase(PurchaseDetailPurchase purchase)
        {
            if (purchase != null)
            {
                int pdId = Convert.ToInt32(purchase.PurchaseDetailId);
               //var purchaseDetails= pdRepository.GetPurchaseDetailByPurchaseId(pdId);
                PurchaseDetail pdObj = pdRepository.Get(pdId);
                pdObj.PurchaseId = purchase.PurchaseId;
                pdObj.InvoiceNo = purchase.InvoiceNo;
                pdObj.SerialNo = purchase.SerialNo;
                pdObj.ModelId = purchase.ModelId;
                pdObj.ItemId = purchase.ItemId;
                pdObj.UnitId = purchase.UnitId;
                pdObj.Qty = purchase.Qty;
                pdObj.UnitPice = purchase.UnitPice;
                pdObj.SerialId = purchase.SerialId;
                pdRepository.SaveChanges();

                int pId = Convert.ToInt32(purchase.PurchaseId);
                PurchaseHead phObj = purchaseRepository.Get(pId);
                phObj.InvoiceNo = purchase.InvoiceNo;
                phObj.SupplierId = purchase.SupplierId;
                phObj.AccountId = purchase.AccountId;
                phObj.PaymentModeId = purchase.PaymentModeId;
                phObj.PurchaseDate = purchase.PurchaseDate;
                phObj.TotalAmount = purchase.TotalAmount;
                phObj.DisountAmount = purchase.DisountAmount;
                phObj.GrantTotal = purchase.GrantTotal;
                phObj.DueAmount = purchase.DueAmount;
                phObj.BankId = purchase.BankId;
                phObj.CheckNo = purchase.CheckNo;
                phObj.CheckDate = purchase.CheckDate;
                phObj.CheckMDate = purchase.CheckMDate;
                phObj.PayAmount = purchase.PayAmount;
                phObj.BranchId = purchase.BranchId;
                phObj.CustomerBankId = purchase.CustomerBankId;
                purchaseRepository.SaveChanges();

                int slId= Convert.ToInt32(purchase.SerialId);
                StockSerial slObj = serialRepository.Get(slId);
                slObj.PurchaseId = purchase.PurchaseId;
                slObj.PDate = purchase.PurchaseDate;
                slObj.ModelId = purchase.ModelId;
                slObj.SerialNo = purchase.SerialNo;
                slObj.OnHand = "Yes";
                //slObj.AccountId = purchase.AccountId;
                slObj.BranchId = purchase.BranchId;
                serialRepository.SaveChanges();

                var jds = jdRepository.GetJournalDetailByPurchaseId(pId);

                foreach (var jd in jds)
                {
                    if (jd.Debit == 0)
                    {
                        JournalDetail jrObj = jdRepository.Get(jd.JournalDetailId);
                        //Debit
                        // jrDetail.JournalNo = journalNo;
                        // jrObj.AccountId = purchase.AccountId;
                        jrObj.PurchaseId = purchase.PurchaseId;
                        // jrObj.TransAccountId = accountId; // purchase.SupplierId;
                        jrObj.Debit = purchase.PayAmount;
                        jrObj.Credit = 0;
                        jrObj.PaymentModeId = purchase.PaymentModeId;
                        jrObj.ChecqueNo = purchase.CheckNo;
                        jrObj.ChequeDate = purchase.CheckDate;
                        jrObj.ChequeMDate = purchase.CheckMDate;
                        jrObj.TransDate = purchase.PurchaseDate;
                        jrObj.BranchId = purchase.BranchId;
                        jdRepository.SaveChanges();
                    
                    }
                    if (jd.Credit == 0)
                    {
                        JournalDetail jrObj = jdRepository.Get(jd.JournalDetailId);
                        //Credit
                        //jrDetail.JournalNo = journalNo;
                        //jrDetail.AccountId = accountId; // purchase.SupplierId;
                        jrObj.PurchaseId = purchase.PurchaseId;
                        //jrDetail.TransAccountId = purchase.AccountId;
                        jrObj.Debit = 0;
                        jrObj.Credit = purchase.PayAmount;
                        jrObj.PaymentModeId = purchase.PaymentModeId;
                        jrObj.ChecqueNo = purchase.CheckNo;
                        jrObj.ChequeDate = purchase.CheckDate;
                        jrObj.ChequeMDate = purchase.CheckMDate;
                        jrObj.BranchId = purchase.BranchId;
                        jdRepository.SaveChanges();
                    
                    }
                
                }

                //JournalDetail jrObj = jdRepository.Get(pId);
               
                //    //Debit
                //    // jrDetail.JournalNo = journalNo;
                //    // jrObj.AccountId = purchase.AccountId;
                //    jrObj.PurchaseId = purchase.PurchaseId;
                //    // jrObj.TransAccountId = accountId; // purchase.SupplierId;
                //    jrObj.Debit = purchase.PayAmount;
                //    jrObj.Credit = 0;
                //    jrObj.PaymentModeId = purchase.PaymentModeId;
                //    jrObj.ChecqueNo = purchase.CheckNo;
                //    jrObj.ChequeDate = purchase.CheckDate;
                //    jrObj.ChequeMDate = purchase.CheckMDate;
                //    jrObj.TransDate = purchase.PurchaseDate;
                //    jrObj.BranchId = purchase.BranchId;
                //    jdRepository.SaveChanges();

                //    //Credit
                //    //jrDetail.JournalNo = journalNo;
                //    //jrDetail.AccountId = accountId; // purchase.SupplierId;
                //    jrObj.PurchaseId = purchase.PurchaseId;
                //    //jrDetail.TransAccountId = purchase.AccountId;
                //    jrObj.Debit = 0;
                //    jrObj.Credit = purchase.PayAmount;
                //    jrObj.PaymentModeId = purchase.PaymentModeId;
                //    jrObj.ChecqueNo = purchase.CheckNo;
                //    jrObj.ChequeDate = purchase.CheckDate;
                //    jrObj.ChequeMDate = purchase.CheckMDate;
                //    jrObj.BranchId = purchase.BranchId;
                //    jdRepository.SaveChanges();

                    ChequeInfo ckObj = chequeInfoRepository.Get(3);
                        //chequeInfoRepository.GetChequeInfoById(pId);
               // ChequeInfo ckObj=ck;
                    ckObj.ChequeDate = purchase.CheckDate;
                    ckObj.ChequeMDate = purchase.CheckMDate;
                    ckObj.ChequeType = "Out";
                    ckObj.Amount = purchase.PayAmount;
                    ckObj.PurchaseId = purchase.PurchaseId;
                    //ckObj.AccountId = purchase.AccountId;
                    ckObj.BranchId = purchase.BranchId;
                    ckObj.TransactionDate = purchase.PurchaseDate;
                    ckObj.BankId = purchase.BankId;
                    chequeInfoRepository.SaveChanges();

                    ReceivePayment rpObj = receivepaymentRepository.Get(14);
                    rpObj.SType = "Payment";
                    rpObj.PurchaseId = purchase.PurchaseId;
                    rpObj.PaymentModeId = purchase.PaymentModeId;
                   // rpObj.AccountId = purchase.AccountId;
                    rpObj.Amount = purchase.PayAmount;
                    rpObj.ChequeNo = purchase.CheckNo;
                    rpObj.ChequeDate = purchase.CheckDate;
                    rpObj.MChequeDate = purchase.CheckMDate;
                    rpObj.BranchId = purchase.BranchId;
                    rpObj.TransactionDate = purchase.PurchaseDate;

                receivepaymentRepository.SaveChanges();


                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddPurchaseDetail(PurchaseDetail purchaseDetail)
        {
            if (purchaseDetail != null)
            {
                if (pdRepository.GetDuplicate(Convert.ToInt32(purchaseDetail.PurchaseId), purchaseDetail.InvoiceNo.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    pdRepository.Add(purchaseDetail);
                    pdRepository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeletePurchaseDetail(string pdId)
        {
            if (!String.IsNullOrEmpty(pdId))
            {
                try
                {
                    int purchaseDetailId = Int32.Parse(pdId);

                    var purchaseDetail = pdRepository.Get(purchaseDetailId);
                    pdRepository.Delete(purchaseDetail);
                    pdRepository.SaveChanges();
                    return "Selected record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "PurchaseDetail details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }

        public JsonResult GetAllPurchasesByBranch(string branchId)
        {
            if (branchId != "null")
            {
                int bId = Convert.ToInt32(branchId);
                var purchases = purchaseRepository.GetPurchasesByBranch(bId);
                return Json(purchases, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
	}
}