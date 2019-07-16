using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataLayer
{
    public class AssessmentsHandler: ConnectionClass
    {
        public AssessmentsHandler() : base() { }

        public IQueryable<Assessment> GetAssessments()
        {
            return Entities.Assessments;
        }

        public IQueryable<AssessmentType> GetAssessmentTypes()
        {
            return this.Entities.AssessmentTypes;
        }

        public IQueryable<AssessmentOrigin> GetAssessmentOrigins()
        {
            return Entities.AssessmentOrigins;
        }

        public IQueryable<Employee> GetAssessmentWorkers()
        {
            return Entities.Employees;
        }


        public void AddAssessment(Common.Assessment ass)
        {
            this.Entities.Assessments.Add(ass);
            this.Entities.SaveChanges();
        }

        //load assessment on page
        public Assessment GetAssessment(Guid assid)
        {
            return this.Entities.Assessments.FirstOrDefault(assess => assess.AssesmentId == assid);
        }

        //get particular assessments
        public IQueryable<Assessment> GetAssessmentsOfPatient(int patid)
        {
            return this.Entities.Assessments.Where(u => u.PatientId_fk == patid);
        }

        public void UpdateAssessment(Assessment a)
        {
            Assessment ExistingAss = this.GetAssessment(a.AssesmentId);
            Entities.Entry(ExistingAss).CurrentValues.SetValues(a);
            Entities.SaveChanges();
        }
    }
}
