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
    
    public partial class StockOpening
    {
        public int StockOpeningId { get; set; }
        public Nullable<int> BranchId { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}
