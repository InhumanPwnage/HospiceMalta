//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common
{
    using System;
    using System.Collections.Generic;
    
    public partial class OriginOfReferral
    {
        public OriginOfReferral()
        {
            this.Patients = new HashSet<Patient>();
        }
    
        public System.Guid OriginOfReferralId { get; set; }
        public string OriginOfReferralName { get; set; }
    
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
