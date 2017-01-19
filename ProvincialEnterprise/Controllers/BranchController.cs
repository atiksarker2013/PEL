using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class BranchController : Controller
    {
        BranchRepository repository = new BranchRepository();
        CompanyRepository compRepository = new CompanyRepository();
        // GET: Branch
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBranches()
        {
            var branches = repository.GetBranches();
            return Json(branches, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllBranchesByCompany(string id)
        {
            if (id != "null")
            {
                int companyId = Convert.ToInt32(id);
                var branches = repository.GetBranchesByCompany(companyId);
                return Json(branches, JsonRequestBehavior.AllowGet);
            }
            else
                return null;
        }

        public JsonResult GetAllCompanies()
        {
            var companies = compRepository.GetCompanies();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetBranchById(string id)
        {
            if (id != null)
            {
                int branchId = Convert.ToInt32(id);
                var branch = repository.GetBrancheById(branchId);
                return Json(branch, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        //public string GetDuplicate(string companyId, string name)
        //{
        //    if (repository.GetDuplicate(companyId,name))
        //    {
        //        return "Duplicate Data.";
        //    }
        //    else
        //        return null;
        //}

        public string UpdateBranch(Branch branch)
        {
            if (branch != null)
            {
                int branchId = Convert.ToInt32(branch.BranchId);
                Branch branchObj = repository.GetById(branchId);
                branchObj.Name = branch.Name;
                branchObj.Address = branch.Address;
                branchObj.Contact = branch.Contact;
                branchObj.Web = branch.Web;
                branchObj.Email = branch.Email;
                branchObj.CompanyId = branch.CompanyId;
                repository.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddBranch(Branch branch)
        {
            if (branch != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(branch.CompanyId), branch.Name))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(branch);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteBranch(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int branchId = Int32.Parse(id);

                    var branch = repository.Get(branchId);
                    repository.Delete(branch);
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