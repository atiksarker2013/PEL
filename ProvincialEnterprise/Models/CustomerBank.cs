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
    
    public partial class CustomerBank
    {
        public CustomerBank()
        {
            this.ChequeInfoes = new HashSet<ChequeInfo>();
            this.Customers = new HashSet<Customer>();
            this.PurchaseHeads = new HashSet<PurchaseHead>();
        }
    
        public int BankId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ChequeInfo> ChequeInfoes { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<PurchaseHead> PurchaseHeads { get; set; }
    }
}
