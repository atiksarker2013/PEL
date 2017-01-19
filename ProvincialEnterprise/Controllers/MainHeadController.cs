using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class MainHeadController : Controller
    {
        MainHeadRepository repository = new MainHeadRepository();
        BranchRepository branchRepository = new BranchRepository();
        CommonPel common = new CommonPel();
        // GET: MainHead
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllMainHeads()
        {
            var mainHeads = repository.GetMainHeads();
            return Json(mainHeads, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMainHeads(string companyId, string branchId, string accountTypeId)
        {
            var mainHeads = common.GetMainHead(companyId, branchId, accountTypeId);
            return Json(mainHeads, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMainHeadsByBranch(string id)
        {
            if (id != "null")
            {
                var branchId = Convert.ToInt32(id);
                var account = repository.GetMainHeadsByBranch(branchId);
                return Json(account, JsonRequestBehavior.AllowGet);
            }
            else
                return null;
        }

        public JsonResult GetMainHeadById(string id)
        {
            if (id != "null")
            {
                int mainHeadId = Convert.ToInt32(id);
                var branch = repository.GetMainheadById(mainHeadId);
                return Json(branch, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public string UpdateMainHead(MainHead mainHead)
        {
            if (mainHead != null)
            {
                int mainHeadId = Convert.ToInt32(mainHead.MainHeadId);
                MainHead mainHeadObj = repository.GetById(mainHeadId);
                mainHeadObj.Name = mainHead.Name;
                mainHeadObj.AccountTypeId = mainHead.AccountTypeId;
                mainHeadObj.BranchId = mainHead.BranchId;
                repository.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddMainHead(MainHead mainHead)
        {
            if (mainHead != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(mainHead.AccountTypeId), mainHead.Name.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(mainHead);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteMainHead(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int mainHeadId = Int32.Parse(id);

                    var mainHead = repository.Get(mainHeadId);
                    repository.Delete(mainHead);
                    repository.SaveChanges();
                    return "Selected record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Branch details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}