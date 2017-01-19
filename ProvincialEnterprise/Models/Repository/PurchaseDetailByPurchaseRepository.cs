using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class PurchaseDetailByPurchaseRepository : Repository<PurchaseDetailPurchase>
    {
        PELEntities pel = new PELEntities();
        public dynamic GetPurchaseDetailByPurchase(string invoiceNo)
        {     
          //  var purchaseDetailByPurchase = DbSet.Where(d => d.InvoiceNo==invoiceNo).ToList();
            var purchaseDetailByPurchase = pel.GetPurchaseDetailByPurchase(invoiceNo).Select(d => new
            {
                d.PurchaseId,
                d.InvoiceNo,
                d.AccountId,
                d.AccountName,
                d.BankId,
                d.BankName,
                d.BranchId,
                d.BranchName,
                d.CompanyId,
                d.CompanyName,
                CheckDate = d.CheckDate.ToString(),
                CheckMDate = d.CheckMDate.ToString(),
                d.CheckNo,
                d.CustomerBankId,
                d.CustomerBankName,
                d.DisountAmount,
                d.DueAmount,
                d.GrantTotal,
                d.PayAmount,
                d.PaymentModeId,
                d.PaymentType,
                PurchaseDate= d.PurchaseDate.ToString(),
                d.SupplierId,
                d.SupplierName,
                d.TotalAmount,
                d.PurchaseDetailId,
                d.ModelId,
                d.ModelName,
                d.ItemId,
                d.ItemName,
                d.UnitId,
                d.UnitName,
                d.SerialNo,
                d.Qty,
                d.UnitPice,
                d.SerialId

            }).ToList();

            return purchaseDetailByPurchase;
           
        }     
    }
}