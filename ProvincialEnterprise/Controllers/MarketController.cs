using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class MarketController : Controller
    {
        MarketRepository repository = new MarketRepository();
        CommonPel common = new CommonPel();
        // GET: Market
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllPeoples()
        {
            var peoples = repository.GetMarketingPeoples();
            return Json(peoples, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPeoplesByBranch(string id)
        {
            if (id != "null")
            {
                int branchId = Convert.ToInt32(id);
                var peoples = repository.GetMarketingPeoplesByBranch(branchId);
                return Json(peoples, JsonRequestBehavior.AllowGet);
            }
            else
                return null;
            
        }

        public JsonResult GetMarketing(string id, string branchId)
        {
            var marketing = common.GetMarketing(id, branchId);
            return Json(marketing, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMarketingById(string id)
        {
            int marketingid = Convert.ToInt32(id);
            var market = repository.GetMarketingPeopleById(marketingid); // repository.Get(marketingid); //db.Markets.Where(m => m.MarketId == marketingid).FirstOrDefault();

            return Json(market, JsonRequestBehavior.AllowGet);
        }

        public string UpdateMarketing(Market market)
        {
            if (market != null)
            {
                int marketingid = Convert.ToInt32(market.MarketId);
                Market _market = repository.Get(marketingid); // db.Markets.Where(m => m.MarketId == marketingid).FirstOrDefault();

                _market.MarketName = market.MarketName;
                _market.Contact = market.Contact;
                _market.BranchId = market.BranchId;
                repository.SaveChanges();
                return "Marketing record updated successfully";
                
            }
            else
            {
                return "Invalid marketing record";
            }
        }

        public string AddMarket(Market market)
        {
            if (market != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(market.BranchId), market.MarketName.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(market);
                    repository.SaveChanges();
                    return "Market record added successfully";
                }
            }
            else
            {
                return "Invalid market record";
            }
        }

        public string DeleteMarket(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int marketId = Int32.Parse(id);

                    var market = repository.Get(marketId);
                    repository.Delete(market);
                    repository.SaveChanges();
                    return "Selected market record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Market details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}