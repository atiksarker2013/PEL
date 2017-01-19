using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvincialEnterprise.Controllers
{
    public class CCLimitController : Controller
    {

        CCLimitRepository repository = new CCLimitRepository();
        BankRepository bankRepository = new BankRepository();
        CommonPel common = new CommonPel();


        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCCLimitById(int id)
        {
            var cclimit = repository.GetCCLimitById(id);
            return Json(cclimit, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCCLimits(string companyId, string branchId, string bankId)
        {
            var cclimit = common.GetCCLimits(companyId, branchId, bankId);
            return Json(cclimit, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetAllBanks()
        //{
        //    var banks = bankRepository.GetBanks();
        //    //var banks = common.GetBanks(companyId, branchId);
        //    var bankcc = (dynamic)null;
        //    List<dynamic> bankcclist = new List<dynamic>();

        //    foreach (var bank in banks)
        //    {
        //        if (bank.BankName.Contains("(CC)"))
        //        {
        //            bankcc = bank;
        //            bankcclist.Add(bankcc);
        //        }
        //    }
        //    return Json(bankcclist, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetAllBanks(string companyId, string branchId)
        {
            // var banks = bankRepository.GetBanks();
            var banks = common.GetBanks(companyId, branchId);
            var bankcc = (dynamic)null;
            List<dynamic> bankcclist = new List<dynamic>();

            foreach (var bank in banks)
            {
                if (bank.BankName.Contains("(CC)"))
                {
                    bankcc = bank;
                    bankcclist.Add(bankcc);
                }
            }
            return Json(bankcclist, JsonRequestBehavior.AllowGet);
        }

        public string UpdateCCLimit(CCLimit cclimit)
        {
            if (cclimit != null)
            {
                int id = Convert.ToInt32(cclimit.Id);
                CCLimit cclimitObj = repository.Get(id);
                cclimitObj.BankId = cclimit.BankId;
                cclimitObj.LimitAmount = cclimit.LimitAmount;
                cclimitObj.EntryDate = DateTime.Now;//cclimit.EntryDate;
                cclimitObj.BranchId = cclimit.BranchId;

                //int accountId = Convert.ToInt32(cclimitObj.AccountId);
                ////bankObj.AccountId = 3;
                repository.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddCCLimit(CCLimit cclimit)
        {
            if (cclimit != null)
            {
                if (repository.GetDuplicateCCLimit(Convert.ToInt32(cclimit.BranchId), Convert.ToInt32(cclimit.BankId)))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    if (cclimit != null)
                    {
                        //int id = Convert.ToInt32(cclimit.Id);
                        CCLimit cclimitObj = new CCLimit();
                        cclimitObj.BankId = cclimit.BankId;
                        cclimitObj.LimitAmount = cclimit.LimitAmount;
                        cclimitObj.EntryDate = DateTime.Now;//cclimit.EntryDate;
                        cclimitObj.BranchId = cclimit.BranchId;
                        repository.Add(cclimitObj);
                        repository.SaveChanges();
                    }
                    
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteCCLimit(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int cclimitId = Int32.Parse(id);

                    var cclimit = repository.Get(cclimitId);
                    repository.Delete(cclimit);
                    repository.SaveChanges();
                    return "Selected record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "CCLimit details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
       

	}
}