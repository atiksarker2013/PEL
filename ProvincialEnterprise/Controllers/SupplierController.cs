using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        SupplierRepository repository = new SupplierRepository();
        LedgerRepository ledgerRepository = new LedgerRepository();
        CommonPel common = new CommonPel();
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllSuppliers()
        {
            var supplierList = repository.GetSuppliers();
            return Json(supplierList, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetSuppliersByCode(string supplierCode)
        //{
        //    var supplierByCodeList = string.Empty;
        //    if (!string.IsNullOrEmpty(supplierCode))
        //    {
        //        supplierByCodeList = repository.GetSuppliersByCode(supplierCode);
        //        //return Json(supplierByCodeList, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(supplierByCodeList, JsonRequestBehavior.AllowGet);
           
        //}
        public JsonResult GetSuppliers(string companyId, string branchId, string supplierId)
        {
            string SId = null;

            if (supplierId != null)
            {
                foreach (char str in supplierId)
                {
                    if (char.IsLetterOrDigit(str))
                        SId += str.ToString();                
                }
                
            }
            else {

                SId = null;
            }
            var supplierList = common.GetSuppliers(companyId, branchId, SId);
            return Json(supplierList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSupplierById(string id)
        {
            int supplierId = Convert.ToInt32(id);
            var supplier = repository.GetSupplierById(supplierId);
            return Json(supplier, JsonRequestBehavior.AllowGet);
        }

        public string UpdateSuppler(Supplier supplier)
        {
            if (supplier != null)
            {
                int supplierId = Convert.ToInt32(supplier.SupplierId);
                Supplier _supplier = repository.GetById(supplierId);

                _supplier.Name = supplier.Name;
                _supplier.Address = supplier.Address;
                _supplier.Contact = supplier.Contact;
                _supplier.OwnerName = supplier.OwnerName;
                _supplier.Fax = supplier.Fax;
                _supplier.Email = supplier.Email;
                _supplier.BranchId = supplier.BranchId;
                _supplier.SupplierCode = supplier.SupplierCode;
                repository.SaveChanges();

                int accountId = Convert.ToInt32(_supplier.AccountId);

                Account accountObj = ledgerRepository.GetById(accountId);
                accountObj.AccountName = supplier.Name;
                accountObj.BranchId = supplier.BranchId;
                ledgerRepository.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Invalid record";
            }
        }

        public string AddSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                if (repository.GetDuplicate(Convert.ToInt32(supplier.BranchId), supplier.Name.Trim()))
                {
                    return "Duplicate record is found.";
                }
                else
                {
                    Account accountObj = new Account();
                    accountObj.AccountName = supplier.Name;
                    accountObj.MainHeadId = 1;
                    ledgerRepository.Add(accountObj);
                    ledgerRepository.SaveChanges();

                    int accountId = accountObj.AccountId;
                    supplier.AccountId = accountId;
                    repository.Add(supplier);
                    repository.SaveChanges();
                    return "Supplier record added successfully";
                }
            }
            else
            {
                return "Invalid supplier record";
            }
        }

        public string DeleteSupplier(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    int supplierId = Convert.ToInt32(id);
                    var supplier = repository.Get(supplierId);
                    int accountId = Convert.ToInt32(supplier.AccountId);
                    repository.Delete(supplier);
                    repository.SaveChanges();

                    var ledger = ledgerRepository.Get(accountId);
                    ledgerRepository.Delete(ledger);
                    ledgerRepository.SaveChanges();

                    return "Selected supplier record deleted sucessfully";
                }
                catch (Exception)
                {
                    return "Supplier details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}