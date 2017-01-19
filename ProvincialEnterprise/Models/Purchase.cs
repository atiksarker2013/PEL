using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string InvoiceNo { get; set; }
        //public Nullable<int> SupplierId { get; set; }
        //public Nullable<int> AccountId { get; set; }
        //public Nullable<int> PaymentModeId { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        //public Nullable<decimal> TotalAmount { get; set; }
        //public Nullable<decimal> DisountAmount { get; set; }
        //public Nullable<decimal> GrantTotal { get; set; }
        //public Nullable<decimal> DueAmount { get; set; }
        //public Nullable<int> BankId { get; set; }
        //public string CheckNo { get; set; }
        //public Nullable<System.DateTime> CheckDate { get; set; }
        //public Nullable<System.DateTime> CheckMDate { get; set; }
        //public Nullable<decimal> PayAmount { get; set; }
        //public Nullable<int> ItemId { get; set; }
        //public Nullable<int> ModelId { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> UnitPice { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; } 
    }
}