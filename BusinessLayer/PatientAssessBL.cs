using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataLayer;

namespace BusinessLayer
{
    public class PatientAssessBL
    {
        public IQueryable<PatientAssesment> GetPatientAssessments()
        {
            return new PatientAssessHandler().GetPatientsAssessments();
        }

        public IQueryable<PatientAssessmentType> GetPatientAssessmentTypes()
        {
            return new PatientAssessHandler().GetPatientAssessTypes();
        }

        public IQueryable<PatientAssessmentGrade> GetPatientAssessmentGrades()
        {
            return new PatientAssessHandler().GetPatientAssessGrades();
        }

        public IQueryable<PatientAssessmentGrade> GetPatientAssessmentTypeGrades(Guid typeid)
        {
            return new PatientAssessHandler().GetPatientAssessTypeGrades(typeid);
        }

        public void AddPatientAssessment(PatientAssesment ass)
        {
            new PatientAssessHandler().AddPatientAssessment(ass);
        }


        public PatientAssesment GetPatientAssessment(Guid patid)
        {
            return new PatientAssessHandler().GetPatientAssessment(patid);
        }

        public IQueryable<PatientAssesment> GetPatientAssessmentsOfPatient(int patid)
        {
            return new PatientAssessHandler().GetPatientAssessmentsOfPatient(patid);
        }

        public void UpdatePatientAssessment(PatientAssesment pa)
        {
            new PatientAssessHandler().UpdatePatientAssessment(pa);
        }
    }
}
