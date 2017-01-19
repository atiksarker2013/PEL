using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        ItemRepository repository = new ItemRepository();
        CommonPel common = new CommonPel();
        // GET: Bank

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllItems()
        {
            var items = repository.GetItems();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemsByBranch(string branchId)
        {
            if (branchId != "null") {
                int id = Convert.ToInt32(branchId);
                var items = repository.GetItemsByBranch(id);
                return Json(items, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
        public JsonResult GetItems(string companyId,string branchId)
        {
            var items = common.GetItems(companyId,branchId);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItemById(string id)
        {
            var itemId = Convert.ToInt32(id);
            var item = repository.GetItemById(itemId);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public string UpdateItem(Item item)
        {
            if (item != null)
            {
                int itemId = Convert.ToInt32(item.ItemId);
                Item itemObj = repository.Get(itemId);
                itemObj.ItemName = item.ItemName;
                repository.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddItem(Item item)
        {
            if (item != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(item.BranchId), item.ItemName.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(item);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteItem(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int itemId = Int32.Parse(id);

                    var item = repository.Get(itemId);
                    repository.Delete(item);
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