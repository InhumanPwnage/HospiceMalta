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
    
    public partial class IllnessesMedical
    {
        public System.Guid IllnessesMedicalId { get; set; }
        public Nullable<System.DateTime> IllnessesDate { get; set; }
        public string IllnessesEventsOfRevelance { get; set; }
        public Nullable<System.Guid> MedicalType_fk { get; set; }
        public string MedicalDescription { get; set; }
        public Nullable<int> PatientId_fk { get; set; }
    
        public virtual MedicalType MedicalType { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
