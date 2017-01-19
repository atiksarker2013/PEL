using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class CustomerBankController : Controller
    {
        // GET: CustomerBank
        CustomerBankRepository repository = new CustomerBankRepository();
        // GET: CustomerBank
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBanks()
        {
            var customerBanks = repository.GetCustomerBanks();
            return Json(customerBanks, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBankById(string id)
        {
            var bankId = Convert.ToInt32(id);
            var bank = repository.GetBankById(bankId);
            return Json(bank, JsonRequestBehavior.AllowGet);
        }

        public string UpdateBank(CustomerBank bank)
        {
            if (bank != null)
            {
                int bankId = Convert.ToInt32(bank.BankId);
                CustomerBank bankObj = repository.Get(bankId);
                bankObj.Name = bank.Name;
                repository.SaveChanges();
                return "Bank record updated successfully";
            }
            else
            {
                return "Invalid bank record";
            }
        }

        public string AddBank(CustomerBank bank)
        {
            if (bank != null)
            {
                if (repository.GetDuplicate(bank.Name.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(bank);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid bank record";
            }
        }

        public string DeleteBank(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int bankId = Int32.Parse(id);

                    var bank = repository.Get(bankId);
                    repository.Delete(bank);
                    repository.SaveChanges();
                    return "Selected record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Bank details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}