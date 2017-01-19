using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;
using ProvincialEnterprise.Helper.Payment;
using ProvincialEnterprise.Helper;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Common;
using System.IO;
using ProvincialEnterprise.Report.Models;
using System.Threading.Tasks;

namespace ProvincialEnterprise.Controllers
{
    public class PurchaseController : Controller
    {
       
        PurchaseRepository purchaseRepository = new PurchaseRepository();
        PurchaseDetailsRepository pdRepository = new PurchaseDetailsRepository();
        SupplierRepository sRepository = new SupplierRepository();
        //ItemJournalRepository ijRepository = new ItemJournalRepository();

        JournalDetailRepository jdRepository = new JournalDetailRepository();
        StockSerialRepository serialRepository = new StockSerialRepository();
        ReceivePaymentRepository receivepaymentRepository = new ReceivePaymentRepository();
        ChequeInfoReository chequeInfoRepository = new ChequeInfoReository();
        VoucherInfoRepository vip = new VoucherInfoRepository();
        PurchaseDetailByPurchaseRepository pdpRep = new PurchaseDetailByPurchaseRepository();
        CommonPel common = new CommonPel();
        Business business = new Business();

        ReportDataSource rd;

        LocalReport lr;
        ReportController rc=new ReportController();
        PELEntities pel = new PELEntities();

        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public JsonResult GetPurchase(string companyId, string branchId)
        {
            var purchaseList = common.GetPurchases(companyId, branchId);
            return Json(purchaseList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveOrder(PurchaseHead purchase)      
        {
            bool status = true;
            bool duplicate = false;
            duplicate = purchaseRepository.GetDuplicate(purchase.InvoiceNo);
            if (duplicate == true)
            {
                return new JsonResult { Data = new { duplicate = duplicate } };
            }
            //if (ModelState.IsValid)
            //{

            //Save Purchase Head
            PurchaseHead ph = new PurchaseHead
            {
                AccountId = purchase.AccountId,
                InvoiceNo = purchase.InvoiceNo,
                PurchaseDate = purchase.PurchaseDate,
                SupplierId = purchase.SupplierId,
                BankId = purchase.BankId,
                CheckDate = purchase.CheckDate,
                CheckNo = purchase.CheckNo,
                CheckMDate = purchase.CheckMDate,
                PaymentModeId = purchase.PaymentModeId,
                PayAmount = purchase.PayAmount,
                TotalAmount = purchase.TotalAmount,
                DisountAmount = purchase.DisountAmount,
                LoadingCharge=purchase.LoadingCharge,
                DueAmount = purchase.DueAmount,
                GrantTotal = purchase.GrantTotal,
                CustomerBankId = purchase.CustomerBankId,
                BranchId = purchase.BranchId
            };
            purchaseRepository.Add(ph);
            purchaseRepository.SaveChanges();

            int purchaseId = ph.PurchaseId;

            //StockSerial sl = new StockSerial();

            foreach (var i in purchase.PurchaseDetails)
            {
                //PurchaseDetail pd = new PurchaseDetail();

                //pd.Qty = i.Qty;
                //pd.PurchaseId = purchaseId;
                //pd.InvoiceNo = purchase.InvoiceNo;
                //pd.ModelId = i.ModelId;
                //pd.ItemId = i.ItemId;
                //pd.UnitId = i.UnitId;
                //pd.SerialNo = i.SerialNo;
                //pd.UnitPice = i.UnitPice;
                //pd.SerialId = i.SerialId;


                //StockSerial stockSerial = new StockSerial();
                //if (i.SerialNo != null)
                //{
                    //Add stock serial 

                //Save Stock Serial
                StockSerial stockSerial = new StockSerial();
                    //string serial = i.SerialNo;
                    //string[] serials = serial.Split(',');
                    //foreach (string sno in serials)
                    //{
                        stockSerial.PurchaseId = purchaseId;
                        stockSerial.PDate = purchase.PurchaseDate;
                        stockSerial.ModelId = i.ModelId;
                        stockSerial.SerialNo = i.SerialNo;
                        stockSerial.OnHand = "Yes";
                        stockSerial.AccountId = sRepository.GetAccountIdBySupplierId(Convert.ToInt32(purchase.SupplierId));
                        stockSerial.BranchId = purchase.BranchId;

                        serialRepository.Add(stockSerial);
                        serialRepository.SaveChanges();
                //    }


                //}

                //Save Purchase Details
                PurchaseDetail pd = new PurchaseDetail();
                pd.Qty = i.Qty;
                pd.PurchaseId = purchaseId;
                pd.InvoiceNo = purchase.InvoiceNo;
                pd.ModelId = i.ModelId;
                pd.ItemId = i.ItemId;
                pd.UnitId = i.UnitId;
                pd.SerialNo = i.SerialNo;
                pd.UnitPice = i.UnitPice;
                pd.SerialId = stockSerial.SerialId;
                pdRepository.Add(pd);
                pdRepository.SaveChanges();
            }

            //Save Voucher Info
            VoucherInfo vi = new VoucherInfo();
            vi.VNo = purchase.InvoiceNo;
            vi.VDate = purchase.PurchaseDate;
            vi.Type = "Purchase";
            vi.BranchId = purchase.BranchId;

            vip.Add(vi);
            vip.SaveChanges();

            GenerateCode gen = new GenerateCode();
            // For Journal Details Entry
            JournalDetail jrDetail = new JournalDetail();
            string maxVoucherNo = jdRepository.GetMaxValue();
            string journalNo = gen.GetJournalNo(maxVoucherNo);

            LedgerEntry ledgerEntry = new LedgerEntry();
            CashEntry cashEntry = new CashEntry();

            if (purchase.PaymentModeId == 1) //Ledger
            {
                ledgerEntry.AddPayment(purchase, jrDetail, journalNo, purchaseId);              
            }
            if (purchase.PaymentModeId == 2) //Cash
            {
                AddReceivePayment(purchase, purchaseId);
                ledgerEntry.AddPayment(purchase, jrDetail, journalNo, purchaseId); 
            }

            if (purchase.PaymentModeId == 3)//Cheque
            {
                AddChequeInfo(purchase, purchaseId);
                ledgerEntry.AddPayment(purchase, jrDetail, journalNo, purchaseId);
            }
            if (purchase.PaymentModeId == 4) //Online Payment
            {
               // ledgerEntry.AddPayment(purchase, jrDetail, journalNo, purchaseId);
                cashEntry.AddPayment(purchase, jrDetail, journalNo, purchaseId);

                AddReceivePayment(purchase, purchaseId);
            }

             //rc.GetPDFReport(purchase.InvoiceNo);

            //else  //Others
            //{
            //    //Debit
            //  // ledgerEntry.AddPayment(purchase, jrDetail, journalNo, purchaseId);

            //   cashEntry.AddPayment(purchase, jrDetail, journalNo, purchaseId);

            //    AddReceivePayment(purchase, purchaseId);
            //}

            

            //}
            //else
            //{
            //    status = false;
            //}

            try
            {

                GetReportPath();

                GetPurchaseInvoiceList(purchase.InvoiceNo);

            }

            catch (Exception ex)
            {

                // return View("Index");

            }

            GetReportFile(purchase.InvoiceNo);

           // return new JsonResult { Data = new { status = status } };

           // var reportParameters = new List<object>
           //                            {
           //                                new ReportCommonParameter
           //                                    {
           //                                        ReportName = "",
           //                                        //Logo = company.Logo,
           //                                        //ReportTitle = company.CompanyName,
           //                                        ReportSubTitle = "Rangpur Cantonment, Rangpur",
           //                                        ReportFooter = "All rights reserved. Copyright @ Pro Dhaka Soft Ltd"
           //                                    }
           //                            };
           ////// //var business = new Business();

           // ReportViewModel reportViewModel = null;
           ////// List<object> extraFields = null;

           // List<PurchaseDetailPurchase> PurchaseInvoiceList = pel.GetPurchaseDetailByPurchase(purchase.InvoiceNo).ToList();
           // //var PurchaseInvoicelist = pdpRep.GetPurchaseDetailByPurchase(purchase.InvoiceNo);

           // //var itemBudget = ReportService.CallProcedureForItemBudgetReport(ReportMode, sDate, eDate);
           //  reportViewModel = business.GetMyPurchaseRepoertViewModel(new List<object>(PurchaseInvoiceList.ToList()), "Purchase Invoice".ToString());

           // ////var itemBudget = ReportService.CallProcedureForItemBudgetReport(ReportMode, sDate, eDate);
           // //reportViewModel = PurchaseInvoicelist(new List<object>(),
           // //                                                            "Report/PurchaseInvoice");


           // //reportViewModel.ReportDataSets.Add(new ReportViewModel.ReportDataSet { DataSetData = reportParameters, DatasetName = "PurchaseInvoicLDataSet" });
           // //reportViewModel.ReportDataSets.Add(new ReportViewModel.ReportDataSet { DataSetData = extraFields, DatasetName = "DataSet3" });

           // var renderedBytes = reportViewModel.RenderReport();
           // if (reportViewModel.ViewAsAttachment)
           //     Response.AddHeader("content-disposition", reportViewModel.ReporExportFileName);
           // return Json(File(renderedBytes, reportViewModel.LastmimeType));
            //rc.GetPDFReport(purchase.InvoiceNo);
            //return Json(rc.GetPDFReport(purchase.InvoiceNo), JsonRequestBehavior.AllowGet);
             return new JsonResult { Data = new { status = status } };
        }

            
        //Save Cheque Info
        private void AddChequeInfo(PurchaseHead purchase, int purchaseId)
        {
            ChequeInfo chequeInfo = new ChequeInfo
            {
                ChequeDate = purchase.CheckDate,
                ChequeMDate = purchase.CheckMDate,
                ChequeType = "Out",
                Amount = purchase.PayAmount,
                PurchaseId = purchaseId,
                AccountId = sRepository.GetAccountIdBySupplierId(Convert.ToInt32(purchase.SupplierId)),
                BranchId = purchase.BranchId,
                TransactionDate = purchase.PurchaseDate,
                BankId = purchase.BankId
            };

            chequeInfoRepository.Add(chequeInfo);
            chequeInfoRepository.SaveChanges();
        }

        //Save Receive Payment
        private void AddReceivePayment(PurchaseHead purchase, int purchaseId)
        {
            ReceivePayment receivePayment = new ReceivePayment();

            receivePayment.SType = "Payment";
            receivePayment.PurchaseId = purchaseId;
            receivePayment.PaymentModeId = purchase.PaymentModeId;
            receivePayment.AccountId = sRepository.GetAccountIdBySupplierId(Convert.ToInt32(purchase.SupplierId));
            receivePayment.Amount = purchase.PayAmount;
            receivePayment.ChequeNo = purchase.CheckNo;
            receivePayment.ChequeDate = purchase.CheckDate;
            receivePayment.MChequeDate = purchase.CheckMDate;
            receivePayment.BranchId = purchase.BranchId;
            receivePayment.TransactionDate = purchase.PurchaseDate;

            receivepaymentRepository.Add(receivePayment);
            receivepaymentRepository.SaveChanges();
        }


        private string GetReportPath()
        {
           // throw new NotImplementedException();
            lr = new LocalReport();

            string reportPath = null;

            reportPath = Path.Combine(Server.MapPath("~/Report/PurchaseInvoice.rdlc"));

            return lr.ReportPath = reportPath;
        }

        private dynamic GetPurchaseInvoiceList(string p)
        {
            //throw new NotImplementedException();

            var PurchaseInvoicelist = pdpRep.GetPurchaseDetailByPurchase(p);

            rd = new ReportDataSource("PurchaseInvoicDataSet", PurchaseInvoicelist);

            lr.DataSources.Add(rd);

            return PurchaseInvoicelist;
        }

        public JsonResult GetReportFile(string p)
        {

            string reportType = "pdf";

            string mimeType;

            string encoding;

            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +

            "  <OutputFormat>" + reportType + "</OutputFormat>" +

            "  <PageWidth>11.5in</PageWidth>" +

            "  <PageHeight>8.30in</PageHeight>" +

            "  <MarginTop>0in</MarginTop>" +

            "  <MarginLeft>0in</MarginLeft>" +

            "  <MarginRight>0in</MarginRight>" +

            "  <MarginBottom>0in</MarginBottom>" +

            "</DeviceInfo>";

            Warning[] warnings;

            string[] streams;

            byte[] renderedBytes;


            renderedBytes = lr.Render(

                reportType,

                deviceInfo,

                out mimeType,

                out encoding,

                out fileNameExtension,

                out streams,

                out warnings);

            return Json(renderedBytes, mimeType);

            ////return Json(File(renderedBytes, mimeType), JsonRequestBehavior.AllowGet);
          //  return new JsonResult { Data = new { status = status } };


            //LocalReport localReport = new LocalReport();
            //localReport.ReportPath = Server.MapPath("~/Report/StateAreaReport.rdlc");
            ////List<StateArea> sa = new List<StateArea>();
            ////using (Database1Entities ent = new Database1Entities())
            ////{
            ////    sa = ent.StateAreas.ToList();
            ////}
            //ReportDataSource reportDataSource = new ReportDataSource("Dataset1", sa);
            //localReport.DataSources.Add(reportDataSource);
            //string reportType = "PDF";
            //string mimeType;
            //string encoding;
            //string fileNameExtension;
            //Warning[] warnings;
            //string[] streams;
            //byte[] renderdBytes;
            //string deviceInfo = "<DeviceInfo>" + " <OutputFormat>" + StateName + "," + format + "</OutputFormat>" +
            //    " <PageWidth>8.5in</PageWidth>" + " <PageHeight>11in</PageHeight>" + " <MarginTop>0.5in</MarginTop>" + " <MarginLeft>1in</MarginLeft>" +
            //    " <MarginRight>1in</MarginRight>" + " <MarginBottom>0.5in</MarginBottom>" + "</DeviceInfo>";
            ////Renderd the Report
            //renderdBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            //// if (format == "PDF")
            //return File(renderdBytes, "pdf");


            //var PurchaseInvoicelist = pdpRep.GetPurchaseDetailByPurchase(p);
            ////var company = companyService.getAllCompanies(1).FirstOrDefault();
            //var reportParameters = new List<object>
            //                           {
            //                               new ReportCommonParameter
            //                                   {
            //                                       ReportName = "",
            //                                       //Logo = company.Logo,
            //                                        ReportTitle = "KRK",
            //                                       ReportSubTitle = "KRK",
            //                                       ReportFooter = "All rights reserved. Copyright @ KRK IT Solutions"
            //                                   }
            //                           };

            ////var business = new Business();
            //var reportViewModel = PurchaseInvoicelist;// business.GetMyStudentRepoertViewModel(new List<object>(attendenceReport.ToList()), "EmployeeAttendenceReport");
            //reportViewModel.ReportDataSets.Add(new ReportViewModel.ReportDataSet { DataSetData = reportParameters, DatasetName = "PurchaseInvoiceDataSet" });

            //var renderedBytes = reportViewModel.RenderReport();
            //if (reportViewModel.ViewAsAttachment)
            //    Response.AddHeader("content-disposition", reportViewModel.ReporExportFileName);
            //return File(renderedBytes, reportViewModel.LastmimeType);
        }

        //public JsonResult GetPDFReport(string p)
        //{ 
        //   var pur= rc.GetPDFReport(p);

        //   return Json(pur, JsonRequestBehavior.AllowGet);
        //}
   
    }
}

