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
    
    public partial class FunctionalAssesment
    {
        public System.Guid FunctionalAssesmentId { get; set; }
        public Nullable<System.Guid> FunctionalAssesmentType { get; set; }
        public string FunctionalAssesmentDescription { get; set; }
        public Nullable<int> PatientId_fk { get; set; }
        public Nullable<bool> FunctionalAssesmentDisable { get; set; }
    
        public virtual FunctionalAssessmentType FunctionalAssessmentType { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
