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
    
    public partial class PatientAssessmentType
    {
        public PatientAssessmentType()
        {
            this.PatientAssessmentGrades = new HashSet<PatientAssessmentGrade>();
        }
    
        public System.Guid PatientAssesmentTypeId { get; set; }
        public string PatientAssessmentTypeName { get; set; }
    
        public virtual ICollection<PatientAssessmentGrade> PatientAssessmentGrades { get; set; }
    }
}