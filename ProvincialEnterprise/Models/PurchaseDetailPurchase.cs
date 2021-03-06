//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProvincialEnterprise.Models
{
    using System;
    
    public partial class PurchaseDetailPurchase
    {
        public int PurchaseId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<int> AccountId { get; set; }
        public string AccountName { get; set; }
        public Nullable<int> BankId { get; set; }
        public string BankName { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string BranchName { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<System.DateTime> CheckDate { get; set; }
        public Nullable<System.DateTime> CheckMDate { get; set; }
        public string CheckNo { get; set; }
        public Nullable<int> CustomerBankId { get; set; }
        public string CustomerBankName { get; set; }
        public Nullable<decimal> DisountAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> GrantTotal { get; set; }
        public Nullable<decimal> PayAmount { get; set; }
        public Nullable<int> PaymentModeId { get; set; }
        public string PaymentType { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public int PurchaseDetailId { get; set; }
        public Nullable<int> ModelId { get; set; }
        public string ModelName { get; set; }
        public Nullable<int> ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> UnitId { get; set; }
        public string UnitName { get; set; }
        public string SerialNo { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> UnitPice { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> SerialId { get; set; }
    }
}
