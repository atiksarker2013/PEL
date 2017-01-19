using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        ModelRepository repository = new ModelRepository();
        CommonPel common = new CommonPel();
        // GET: Bank
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllModels()
        {
            var models = repository.GetModels();
            return Json(models, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetModels(string companyId, string branchId, string itemId, string modelId)
        {
             string MId = null;

            if (modelId != null)
            {
                foreach (char str in modelId)
                {
                    if (char.IsLetterOrDigit(str))
                        MId += str.ToString();
                }

            }
            else
            {

                MId = null;
            }
            var models = common.GetModels(companyId, branchId, itemId, MId);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetModelById(string id)
        //{
        //    string MId = null;

        //    if (id != null)
        //    {
        //        foreach (char str in id)
        //        {
        //            if (char.IsLetterOrDigit(str))
        //                MId += str.ToString();
        //        }

        //    }
        //    else
        //    {

        //        MId = null;
        //    }
        //    var modelId = Convert.ToInt32(MId);
        //    var model = repository.GetModelById(modelId);
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}
        public string UpdateModel(Model model)
        {
            if (model != null)
            {
                int modelId = Convert.ToInt32(model.ModelId);
                Model modelObj = repository.Get(modelId);
                modelObj.ModelName = model.ModelName;
                modelObj.ItemId = model.ItemId;
                modelObj.Price = model.Price;
                modelObj.Qty = model.Qty;
                modelObj.SalePrice = model.SalePrice;
                modelObj.ReorderQty = model.ReorderQty;
                modelObj.IsWarranty = model.IsWarranty;
                modelObj.AvgCost = model.AvgCost;
                modelObj.BranchId = model.BranchId;

                repository.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddModel(Model model)
        {
            if (model != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(model.ItemId), model.ModelName.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(model);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteModel(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int modelId = Int32.Parse(id);

                    var model = repository.Get(modelId);
                    repository.Delete(model);
                    repository.SaveChanges();
                    return "Selected record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Record details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}