using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class PurchaseDetailsRepository: Repository<PurchaseDetail>
    {

        public dynamic GetPurchaseDetailByPurchaseId(int purchaseId)
        {
            var purchaseDetails = DbSet.Where(p => p.PurchaseId == purchaseId).Select(d => new
            {
                PurchaseDetailId = d.PurchaseDetailId,
                SerialNo = d.SerialNo,
                PurchaseId = d.PurchaseId,
                InvoiceNo = d.InvoiceNo,
                ModelId = d.ModelId,
                ModelName = d.Model.ModelName,
                ItemId = d.ItemId,
                ItemName = d.Item.ItemName,
                UnitId = d.UnitId,
                UnitName = d.Unit.UnitName,
                Qty = d.Qty,
                UnitPice = d.UnitPice

            }).ToList();

            return purchaseDetails;
        }

        //public dynamic GetPurchaseDetailByPurchaseId(string invoiceNo)
        //{
        //    var purchaseDetails = DbSet.Where(p => p.InvoiceNo == invoiceNo).Select(d => new
        //    {
        //        PurchaseDetailId = d.PurchaseDetailId,
        //        SerialNo = d.SerialNo,
        //        PurchaseId = d.PurchaseId,
        //        InvoiceNo = d.InvoiceNo,
        //        ModelId = d.ModelId,
        //        ModelName = d.Model.ModelName,
        //        ItemId = d.ItemId,
        //        ItemName = d.Item.ItemName,
        //        UnitId = d.UnitId,
        //        UnitName = d.Unit.UnitName,
        //        Qty = d.Qty,
        //        UnitPice = d.UnitPice

        //    }).ToList();

        //    return purchaseDetails;
        //}

        public dynamic GetPurchaseDetailById(int pdId)
        {
            var PurchaseDetail = DbSet.Where(d => d.PurchaseDetailId == pdId).Select(d => new
                {
                    PurchaseDetailId = d.PurchaseDetailId,
                    SerialNo = d.SerialNo,
                    PurchaseId = d.PurchaseId,
                    InvoiceNo = d.InvoiceNo,
                    ModelId=d.ModelId,
                    ModelName = d.Model.ModelName,
                    ItemId = d.ItemId,
                    ItemName = d.Item.ItemName,
                    UnitId = d.UnitId,
                    UnitName = d.Unit.UnitName,
                    Qty = d.Qty,
                    UnitPrice = d.UnitPice
                });
            return PurchaseDetail;
        }

        public bool GetDuplicate(int purchaseId, string InvoiceNo)
        {
            var purchaseDetail = DbSet.Where(c => c.InvoiceNo.ToLower() == InvoiceNo.ToLower() && c.PurchaseId == purchaseId).FirstOrDefault();
            return (purchaseDetail != null) ? true : false;
        }
        //public dynamic GetPurchaseDetailById(int purchaseId)
        //{
        //    var purchaseDetail = DbSet.Where(p => p.PurchaseId == purchaseId).Select(p => new
        //    {
        //        p.SerialNo,
        //        p.PurchaseId,
        //        p.InvoiceNo,
        //        p.ModelId,
        //        p.ItemId,
        //        p.UnitId,
        //        p.Qty,
        //        p.UnitPice,
        //    }).ToList();
        //    return purchaseDetail;
        //}

        //public dynamic GetBranchesByCompany(int companyId)
        //{
        //    var branches = DbSet.Where(x => x.CompanyId == companyId).Select(b => new
        //    {
        //        BranchId = b.BranchId,
        //        Name = b.Name,
        //        Address = b.Address,
        //        Contact = b.Contact,
        //        Web = b.Web,
        //        Email = b.Email,
        //        CompanyId = b.CompanyId,
        //        CompanyName = b.Company.Name
        //    }).ToList();

        //    return branches;
        //}
    }
   
}