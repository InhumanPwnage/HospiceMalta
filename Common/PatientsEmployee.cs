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
    
    public partial class PatientsEmployee
    {
        public int PatientFileNumber_fk { get; set; }
        public System.Guid EmployeeId_fk { get; set; }
        public System.DateTime PatientDate { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
