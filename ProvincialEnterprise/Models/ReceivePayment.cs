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
    
    public partial class ReceivePayment
    {
        public ReceivePayment()
        {
            this.ChequeInfoes = new HashSet<ChequeInfo>();
        }
    
        public int RPId { get; set; }
        public string SType { get; set; }
        public Nullable<int> PurchaseId { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<int> AccountId { get; set; }
        public string Narration { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<System.DateTime> ChequeDate { get; set; }
        public Nullable<System.DateTime> MChequeDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string AmountDesc { get; set; }
        public string ChecqueInHand { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> PaymentModeId { get; set; }
        public string Status { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual ICollection<ChequeInfo> ChequeInfoes { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
        public virtual PurchaseHead PurchaseHead { get; set; }
    }
}
