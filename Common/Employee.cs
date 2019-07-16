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
    
    public partial class Employee
    {
        public Employee()
        {
            this.Assessments = new HashSet<Assessment>();
            this.Doctors = new HashSet<Doctor>();
            this.PatientsEmployees = new HashSet<PatientsEmployee>();
            this.Roles = new HashSet<Role>();
        }
    
        public System.Guid EmployeesId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SSN { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> ViewPatient { get; set; }
        public string Remark { get; set; }
        public Nullable<System.Guid> Occupations_fk { get; set; }
        public Nullable<System.Guid> WorkTypes_fk { get; set; }
        public Nullable<System.Guid> NextOfKin_fk { get; set; }
        public Nullable<System.Guid> Personfk { get; set; }
    
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual NextOfKin NextOfKin { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Person Person { get; set; }
        public virtual WorkType WorkType { get; set; }
        public virtual ICollection<PatientsEmployee> PatientsEmployees { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}