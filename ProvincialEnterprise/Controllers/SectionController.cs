using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class SectionController : Controller
    {
        SectionRepository repository = new SectionRepository();
        BranchRepository branchRepository = new BranchRepository();
        CommonPel common = new CommonPel();
        // GET: Section
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllBranches()
        {
            var branches = branchRepository.GetBranches();
            return Json(branches, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllSections(string id, string branchId)
        {
            var sections = common.GetSections(id, branchId);
            return Json(sections, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllSectionsByBranch(string id)
        {
            if (id != "null")
            {
                int branchId = Convert.ToInt32(id);
                var sections = repository.GetSectionsByBranch(branchId);
                return Json(sections, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        //public JsonResult GetAllSections()
        //{
        //    var sections = repository.GetSections();
        //    return Json(sections, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetSectionById(string id)
        {
            if (id != "null")
            {
                int sectionId = Convert.ToInt32(id);
                var section = repository.GetSectionById(sectionId);
                return Json(section, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public string UpdateSection(Section section)
        {
            if (section != null)
            {
                int sectionId = Convert.ToInt32(section.SectionId);
                Section sectionObj = repository.Get(sectionId);
                sectionObj.Name = section.Name;
                sectionObj.BranchId = section.BranchId;
                repository.SaveChanges();
                return "Record updated successfully";
                
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddSection(Section section)
        {
            if (section != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(section.BranchId), section.Name.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(section);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteSection(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int sectionId = Int32.Parse(id);

                    var section = repository.Get(sectionId);
                    repository.Delete(section);
                    repository.SaveChanges();
                    return "Selected record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Section details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}