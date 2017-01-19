using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository repository = new CustomerRepository();
        LedgerRepository ledgerRepository = new LedgerRepository();
        CommonPel common = new CommonPel();
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult GetAllCustomers()
        //{
        //    var customerList = repository.GetCustomers();
        //    return Json(customerList, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetCustomers(string companyId,string branchId)
        {
            var customers = common.GetCustomers(companyId,branchId);
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerById(string id)
        {
            int customerId = Convert.ToInt32(id);
            var customer = repository.GetCustomerById(customerId);
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public string UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                int customerId = Convert.ToInt32(customer.CustomerId);
                Customer _customer = repository.GetById(customerId);

                _customer.CustomerName = customer.CustomerName;
                _customer.MarketId = customer.MarketId;
                _customer.Address = customer.Address;
                _customer.OwnerName = customer.OwnerName;
                _customer.Telephone = customer.Telephone;
                _customer.EmailId = customer.EmailId;
                _customer.NID = customer.NID;
                _customer.TradeLicense = customer.TradeLicense;
                _customer.ChequeNo = customer.ChequeNo;
                _customer.ChequeAmount = customer.ChequeAmount;
                _customer.CompanyCode = customer.CompanyCode;
                _customer.BankId = customer.BankId;
                _customer.BranchId = customer.BranchId;
                repository.SaveChanges();

                int accountId = Convert.ToInt32(_customer.AcountId);

                Account accountObj = ledgerRepository.GetById(accountId);
                accountObj.AccountName = customer.CustomerName;
                accountObj.BranchId = customer.BranchId;
                ledgerRepository.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(customer.BranchId),customer.CustomerName.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    Account accountObj = new Account();
                    accountObj.AccountName = customer.CustomerName;
                    accountObj.BranchId = customer.BranchId;
                    accountObj.MainHeadId = 2;
                    ledgerRepository.Add(accountObj);
                    ledgerRepository.SaveChanges();

                    int accountId = accountObj.AccountId;
                    customer.AcountId = accountId;
                    repository.Add(customer);
                    repository.SaveChanges();
                    return "Record added successfully";
                }
            }
            else
            {
                return "Invalid record";
            }
        }

        public string DeleteCustomer(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {

                    int customerId = Convert.ToInt32(id);
                    var customer = repository.Get(customerId);

                    int accountId = Convert.ToInt32(customer.AcountId);
                    repository.Delete(customer);
                    repository.SaveChanges();

                    var ledger = ledgerRepository.Get(accountId);
                    ledgerRepository.Delete(ledger);
                    ledgerRepository.SaveChanges();

                    return "Selected record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Record not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}