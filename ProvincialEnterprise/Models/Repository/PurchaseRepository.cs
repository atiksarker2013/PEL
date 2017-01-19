using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class PurchaseRepository: Repository<PurchaseHead>
    {

        public dynamic GetPurchases()
        {
            var purchases = DbSet.Select(p => new
            {
                p.PurchaseId,
                p.InvoiceNo,
                p.SupplierId,
                p.AccountId,
                p.PaymentModeId,
                p.PurchaseDate,
                p.TotalAmount,
                p.DisountAmount,
                p.LoadingCharge,
                p.GrantTotal,
                p.DueAmount,
                p.BankId,
                p.CheckNo,
                p.CheckDate,
                p.CheckMDate,
                p.PayAmount,
                p.BranchId,
                p.CustomerBankId
            }).ToList();

            return purchases;
        }
        public bool GetDuplicate(string invoiceNo)
        {
            var bank = DbSet.Where(x=> x.InvoiceNo == invoiceNo).FirstOrDefault();
            return (bank != null) ? true : false;
        }

        public dynamic GetPurchaseByInvoiceNo(string invoiceno)
        {
            var purchase = DbSet.Where(p => p.InvoiceNo == invoiceno).Select(p => new
            {
                PurchaseId = p.PurchaseId,
                InvoiceNo = p.InvoiceNo,
                SupplierId = p.SupplierId,
                SupplierName = p.Supplier.Name,
                AccountId = p.AccountId,
                AccountName = p.Account.AccountName,
                PaymentModeId = p.PaymentModeId,
                PaymentType = p.PaymentMode.PaymentType,
                PurchaseDate = p.PurchaseDate,
                TotalAmount = p.TotalAmount,
                DisountAmount = p.DisountAmount,
                LoadingCharge = p.LoadingCharge,
                GrantTotal = p.GrantTotal,
                DueAmount = p.DueAmount,
                BankId = p.BankId,
                BankName = p.Bank.BankName,
                CheckNo = p.CheckNo,
                CheckDate = p.CheckDate,
                CheckMDate = p.CheckMDate,
                PayAmount = p.PayAmount,
                BranchId = p.BranchId,
                BranchName = p.Branch.Name,
                CustomerBankId = p.CustomerBankId,
                CustomerBankName = p.CustomerBank.Name,
                CompanyId = p.Branch.CompanyId,
                CompanyName = p.Branch.Company.Name

            });
            return purchase;
        }

        public dynamic GetPurchasesByBranch(int branchId)
        {
            var purchases = DbSet.Where(p => p.BranchId == branchId).Select(p => new
            {
                p.PurchaseId,
                p.InvoiceNo,
                p.SupplierId,
                p.AccountId,
                p.PaymentModeId,
                p.PurchaseDate,
                p.TotalAmount,
                p.DisountAmount,
                p.LoadingCharge,
                p.GrantTotal,
                p.DueAmount,
                p.BankId,
                p.CheckNo,
                p.CheckDate,
                p.CheckMDate,
                p.PayAmount,
                p.BranchId,
                p.CustomerBankId,

            }).ToList();

            return purchases;
        }
    }
}