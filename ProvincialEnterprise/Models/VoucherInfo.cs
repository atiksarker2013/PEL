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
    
    public partial class VoucherInfo
    {
        public int VoucherInfoId { get; set; }
        public string VNo { get; set; }
        public Nullable<System.DateTime> VDate { get; set; }
        public string Type { get; set; }
        public Nullable<int> BranchId { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}
