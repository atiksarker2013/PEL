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
    
    public partial class Grade
    {
        public Grade()
        {
            this.Designations = new HashSet<Designation>();
        }
    
        public int GradeId { get; set; }
        public string GradeType { get; set; }
    
        public virtual ICollection<Designation> Designations { get; set; }
    }
}
