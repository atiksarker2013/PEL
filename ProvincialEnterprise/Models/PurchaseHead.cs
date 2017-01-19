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
    using System.Collections.Generic;
    
    public partial class PurchaseHead
    {
        public PurchaseHead()
        {
            this.ChequeInfoes = new HashSet<ChequeInfo>();
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
            this.ReceivePayments = new HashSet<ReceivePayment>();
            this.StockSerials = new HashSet<StockSerial>();
            this.JournalDetails = new HashSet<JournalDetail>();
        }
    
        public int PurchaseId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> PaymentModeId { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> DisountAmount { get; set; }
        public Nullable<decimal> GrantTotal { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<int> BankId { get; set; }
        public string CheckNo { get; set; }
        public Nullable<System.DateTime> CheckDate { get; set; }
        public Nullable<System.DateTime> CheckMDate { get; set; }
        public Nullable<decimal> PayAmount { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> CustomerBankId { get; set; }
        public Nullable<decimal> LoadingCharge { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<ChequeInfo> ChequeInfoes { get; set; }
        public virtual CustomerBank CustomerBank { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ReceivePayment> ReceivePayments { get; set; }
        public virtual ICollection<StockSerial> StockSerials { get; set; }
        public virtual ICollection<JournalDetail> JournalDetails { get; set; }
    }
}