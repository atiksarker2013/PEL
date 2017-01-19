using CIT.Models;
using CIT.Models.Repository;
using ProvincialEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIT.Controllers
{
    public class UnitController : Controller
    {
        UnitRepository repository = new UnitRepository();
        CommonPel common = new CommonPel();
        //
        // GET: /Unit/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllUnits()
        {
            var units = repository.GetUnits();
            return Json(units, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUnits(string companyId, string branchId)
        {
            var units = common.GetUnits(companyId, branchId);
            return Json(units, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnitById(string unitId)
        {
            var uUd = Convert.ToInt32(unitId);
            var unit = repository.GetUnitById(uUd);
            return Json(unit, JsonRequestBehavior.AllowGet);
        }
        public string UpdateUnit(Unit unit)
        {
            if (unit != null)
            {
                int unitId = Convert.ToInt32(unit.UnitId);
                Unit unitObj = repository.Get(unitId);
                unitObj.UnitName = unit.UnitName;
                unitObj.BranchId = unit.BranchId;
                repository.SaveChanges();
                return "Unit record updated successfully";
            }
            else
            {
                return "Invalid unit record";
            }
        }

        public string AddUnit(Unit unit)
        {
            if (unit != null)
            {
                if (repository.GetDuplicateUnit(unit.UnitName.Trim(), Convert.ToInt32(unit.BranchId)))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(unit);
                    repository.SaveChanges();
                    return "Unit record added successfully";
                }
            }
            else
            {
                return "Invalid unit record";
            }

        }

        public string DeleteUnit(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int unitId = Int32.Parse(id);

                    var unit = repository.Get(unitId);
                    repository.Delete(unit);
                    repository.SaveChanges();
                    return "Selected Unit record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Unit details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        
        }
	}
}