using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        BankRepository repository = new BankRepository();
        BranchRepository branchRepository = new BranchRepository();
        CommonPel common = new CommonPel();

        LedgerRepository ledgerRepository = new LedgerRepository();
        // GET: Bank
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBanks()
        {
            var companies = repository.GetBanks();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBanks(string companyId,string branchId)
        {
            var banks = common.GetBanks(companyId,branchId);
            return Json(banks, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllBranches()
        {
            var branches = branchRepository.GetBranches();
            return Json(branches, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBankById(string id)
        {
            var bankId = Convert.ToInt32(id);
            var bank = repository.GetBankById(bankId);
            return Json(bank, JsonRequestBehavior.AllowGet);
        }

        public string UpdateBank(Bank bank)
        {
            if (bank != null)
            {
                int bankId = Convert.ToInt32(bank.BankId);
                Bank bankObj = repository.Get(bankId);
                int accountId = Convert.ToInt32(bankObj.AccountId);

                bankObj.BankName = bank.BankName;
                bankObj.Branch = bank.Branch;
                bankObj.AccountNo = bank.AccountNo;
                bankObj.Opening = bank.Opening;
                bankObj.BranchId = bank.BranchId;
                //bankObj.AccountId = 3;
                repository.SaveChanges();

                
                Account accountObj = ledgerRepository.GetById(accountId);
                accountObj.AccountName = bank.BankName;
                accountObj.BranchId = bank.BranchId;
                ledgerRepository.SaveChanges();

                return "Record updated successfully";
                
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddBank(Bank bank)
        {
            if (bank != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(bank.BranchId),bank.BankName.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    Account accountObj = new Account();
                    accountObj.AccountName = bank.BankName;
                    accountObj.BranchId = bank.BranchId;
                    accountObj.MainHeadId = 3;
                    ledgerRepository.Add(accountObj);
                    ledgerRepository.SaveChanges();

                    int accountId = accountObj.AccountId;
                    bank.AccountId = accountId;
                    repository.Add(bank);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
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
                    int accountId = Convert.ToInt32(bank.AccountId);
                    repository.Delete(bank);
                    repository.SaveChanges();

                    var ledger = ledgerRepository.Get(accountId);
                    ledgerRepository.Delete(ledger);
                    ledgerRepository.SaveChanges();
 
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