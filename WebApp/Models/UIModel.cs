using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class UIModel
    {
        public class PatientModel
        {

            public Common.Patient Patient { get; set; }

            public IQueryable<Common.Patient> Patients { get; set; }
            public Common.Person Person { get; set; }
            public Common.FamilySocial FamilySocial { get; set; }
            public Common.Medication Medication { get; set; }
            public Common.AllergiesSpiritual AllergiesSpiritual { get; set; }
            public Common.IllnessesMedical IllnessesMedical { get; set; }
            public Common.NextOfKin NextOfKin { get; set; }
            public Common.CaseConferance CaseConferance { get; set; }
            public Common.Equipment Equipment { get; set; }
            public Common.DiagnosisPatient DiagnosisPatient { get; set; }

        }
        public class StoreDropDown
        {
            public string Gender { get; set; }
            public Guid? Island { get; set; }
            public Guid? Locality { get; set; }
            public Guid? Street { get; set; }
            public Guid? Property { get; set; }
            public Guid? PatientAware { get; set; }
            public Guid? RelativesAware { get; set; }
            public Guid? DecPlace { get; set; }
            public Guid? FileStatus { get; set; }
            public Guid? Title { get; set; }
            public Guid? OriginReferral { get; set; }
            public Guid? Diagnosis { get; set; }
            public DateTime DiagnosisDate { get; set; }

            public Guid? KeyWorker { get; set; }

            public Guid? FamilyDoctorEmp { get; set; }
            public string FamilyDoctorName { get; set; }

            public Guid? OncologistEmp { get; set; }
            public string OncologistName { get; set; }

            public Guid? ConsultantEmp { get; set; }
            public string ConsultantName { get; set; }
        }
    }
}