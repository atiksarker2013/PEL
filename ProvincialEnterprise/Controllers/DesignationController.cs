using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class DesignationController : Controller
    {
        DesignationRepository repository = new DesignationRepository();
        SectionRepository sectionRepository = new SectionRepository();
        CommonPel common = new CommonPel();
        // GET: Designation
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllSections()
        {
            var sections = sectionRepository.GetSections();
            return Json(sections, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllDesignations(string id, string branchId, string sectionId)
        {
            var designations = common.GetAllDesignations(id,branchId,sectionId); //.GetDesignations();
            return Json(designations, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDesignationsBySection(string id)
        {
            if (id != null)
            {
                int sectionId = Convert.ToInt32(id);
                var designations = repository.GetDesignationsBySection(sectionId);
                return Json(designations, JsonRequestBehavior.AllowGet);
            }
            else
                return null;

        }
        public JsonResult GetDesignationById(string id)
        {
            if (id != null)
            {
                int designationId = Convert.ToInt32(id);
                var designation = repository.GetDesignationById(designationId);
                return Json(designation, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public string UpdateDesignation(Designation designation)
        {
            if (designation != null)
            {
                int designationId = Convert.ToInt32(designation.DesignationId);
                Designation designationObj = repository.Get(designationId);
                designationObj.Name = designation.Name;
                designationObj.SectionId = designation.SectionId;
                repository.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddDesignation(Designation designation)
        {
            if (designation != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(designation.SectionId), designation.Name.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(designation);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteDesignation(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int designationId = Int32.Parse(id);

                    var designation = repository.Get(designationId);
                    repository.Delete(designation);
                    repository.SaveChanges();
                    return "Selected record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Designation details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}