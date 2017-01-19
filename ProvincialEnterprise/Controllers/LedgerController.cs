using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class LedgerController : Controller
    {
        // GET: Ledger
        LedgerRepository repository = new LedgerRepository();
        BranchRepository branchRepository = new BranchRepository();

        BankRepository bankRepository = new BankRepository();
        CustomerRepository customerRepository = new CustomerRepository();
        SupplierRepository supplierRepository = new SupplierRepository();
        CommonPel common = new CommonPel();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllAccounts()
        {
            var accounts = repository.GetAccounts();
            return Json(accounts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLedgers(string companyId, string branchId, string mainHeadId)
        {
            var accounts = common.GetLedgers(companyId, branchId, mainHeadId);
            return Json(accounts, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllPurchaseAccounts()
        {
            var accounts = repository.GetPurchaseAccounts();
            return Json(accounts, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetAllBranches()
        //{
        //    var branches = branchRepository.GetBranches();
        //    return Json(branches, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetAccountById(string id)
        {
            var accountId = Convert.ToInt32(id);
            var account = repository.GetAccountById(accountId);
            return Json(account, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAccount()
        {
            var account = repository.GetAcount();
            return Json(account, JsonRequestBehavior.AllowGet);
        }

        public string UpdateAccount(Account account)
        {
            if (account != null)
            {
                int accountId = Convert.ToInt32(account.AccountId);
                Account accountObj = repository.Get(accountId);
                accountObj.AccountName = account.AccountName;
                accountObj.MainHeadId = account.MainHeadId;
                accountObj.BranchId = account.BranchId;
                repository.SaveChanges();
                
                if (account.MainHeadId == 1) // For Supplier (ACCOUNTS PAYABLE (CREDITORS))
                {
                    Supplier supplier = supplierRepository.GetSupplierByAccoutId(accountId);
                    supplier.Name = account.AccountName;
                    supplier.BranchId = account.BranchId;
                    supplierRepository.SaveChanges();
                }
                else if (account.MainHeadId == 2) // For Customer (ACCOUNTS RECEIVABLE (DEBITORS))
                {
                    Customer customer = customerRepository.GetCustomerByAccoutId(accountId);
                    customer.CustomerName = account.AccountName;
                    customer.BranchId = account.BranchId;
                    customerRepository.SaveChanges();
                }
                else if (account.MainHeadId == 3) // For Bank (CASH AT BANK)
                {
                    Bank bank = bankRepository.GetBankByAccoutId(accountId);
                    bank.BankName = account.AccountName;
                    bank.BranchId = account.BranchId;
                    bankRepository.SaveChanges();
                }

                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddAccount(Account account)
        {
            if (account != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(account.MainHeadId), account.AccountName.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    repository.Add(account);
                    repository.SaveChanges();
                    int accountId = account.AccountId;

                    if (account.MainHeadId == 1) // For Supplier (ACCOUNTS PAYABLE (CREDITORS))
                    {
                        Supplier supplier = new Supplier();
                        supplier.Name = account.AccountName;
                        supplier.BranchId = account.BranchId;
                        supplier.AccountId = accountId;
                        supplierRepository.Add(supplier);
                        supplierRepository.SaveChanges();
                    }
                    else if (account.MainHeadId == 2) // For Customer (ACCOUNTS RECEIVABLE (DEBITORS))
                    {
                        Customer customer = new Customer();
                        customer.CustomerName = account.AccountName;
                        customer.BranchId = account.BranchId;
                        customer.AcountId = accountId;
                        customerRepository.Add(customer);
                        customerRepository.SaveChanges();
                    }
                    else if (account.MainHeadId == 3) // For Bank (CASH AT BANK)
                    {
                        Bank bank = new Bank();
                        bank.BankName = account.AccountName;
                        bank.BranchId = account.BranchId;
                        bank.AccountId = accountId;
                        bankRepository.Add(bank);
                        bankRepository.SaveChanges();
                    }
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteAccount(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int accountId = Int32.Parse(id);

                    var account = repository.Get(accountId);

                    int mainHeadId = Convert.ToInt32(account.MainHeadId);

                    repository.Delete(account);
                    repository.SaveChanges();

                    if (mainHeadId == 3)
                    {
                        var bank = bankRepository.GetBankByAccoutId(accountId);
                        bankRepository.Delete(bank);
                        bankRepository.SaveChanges();
                    }
                    else if (mainHeadId == 2)
                    {
                        var customer = customerRepository.GetCustomerByAccoutId(accountId);
                        customerRepository.Delete(customer);
                        customerRepository.SaveChanges();
                    }
                    else if (mainHeadId == 1)
                    {
                        var supplier = supplierRepository.GetSupplierByAccoutId(accountId);
                        supplierRepository.Delete(supplier);
                        supplierRepository.SaveChanges();
                    }

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