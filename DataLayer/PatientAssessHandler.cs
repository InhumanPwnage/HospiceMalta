using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataLayer
{
    public class PatientAssessHandler : ConnectionClass
    {
        public PatientAssessHandler() : base() { }

        public IQueryable<PatientAssesment> GetPatientsAssessments()
        {
            return Entities.PatientAssesments;
        }

        public IQueryable<PatientAssessmentType> GetPatientAssessTypes()
        {
            return Entities.PatientAssessmentTypes;
        }

        //depends on type
        public IQueryable<PatientAssessmentGrade> GetPatientAssessGrades()
        {
            return Entities.PatientAssessmentGrades;
        }

        //get Grades according to the matching TypeId's GUID
        public IQueryable<PatientAssessmentGrade> GetPatientAssessTypeGrades(Guid typeid)
        {
            return Entities.PatientAssessmentGrades.Where(x => x.PatientAssessmentTypeId_fk == typeid);
        }

        public void AddPatientAssessment(Common.PatientAssesment ass)
        {
            this.Entities.PatientAssesments.Add(ass);
            this.Entities.SaveChanges();
        }


        //load assessment on page
        public PatientAssesment GetPatientAssessment(Guid patid)
        {
            return this.Entities.PatientAssesments.FirstOrDefault(patient => patient.PatientAssesmentId == patid);
        }

        //get particular assessments
        public IQueryable<PatientAssesment> GetPatientAssessmentsOfPatient(int patid)
        {
            return this.Entities.PatientAssesments.Where(u => u.PatientId_fk == patid);
        }

        public void UpdatePatientAssessment(PatientAssesment pa)
        {
            PatientAssesment ExistingPatAss = this.GetPatientAssessment(pa.PatientAssesmentId);

            Entities.Entry(ExistingPatAss).CurrentValues.SetValues(pa);
            Entities.SaveChanges();
        }
    }
}
